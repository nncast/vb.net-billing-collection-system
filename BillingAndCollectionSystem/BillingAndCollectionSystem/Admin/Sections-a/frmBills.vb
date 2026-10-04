Public Class frmBills
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedBillID As Integer = -1

    Private Sub frmBills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()

        ' Only the listed statuses are valid; "Partial" is set automatically from payments.
        cmbstatus.DropDownStyle = ComboBoxStyle.DropDownList

        loadform()
    End Sub

    Public Sub loadform()
        btnnew.Enabled = True
        btnsave.Enabled = False
        pnlinput.Enabled = False
        pnlinput2.Enabled = False

        fillReadings()
        fillBills()
    End Sub

    Public Sub fillReadings()
        Dim q As String = "SELECT r.id, CONCAT(c.fname, ' ', c.lname) AS fullname, r.date, r.prev, r.curr " &
                          "FROM tblreadings r " &
                          "LEFT JOIN tblconsumers c ON r.consumerid = c.id " &
                          "WHERE r.id NOT IN (SELECT readingid FROM tblbills)"

        If txtsearchread.Text.Trim() <> "" Then
            q &= " AND (c.fname LIKE @s OR c.lname LIKE @s)"
        End If

        q &= " ORDER BY r.date DESC"
        GetQuery(q, "readings", P("@s", "%" & txtsearchread.Text.Trim() & "%"))

        lvreadings.Items.Clear()
        For Each r As DataRow In ds.Tables("readings").Rows
            With lvreadings.Items.Add(r("id").ToString())
                .SubItems.Add(r("fullname").ToString())
                .SubItems.Add(CDate(r("date")).ToShortDateString())
                .SubItems.Add(r("prev").ToString())
                .SubItems.Add(r("curr").ToString())
            End With
        Next
    End Sub


    Public Sub fillBills()
        Dim q As String = "SELECT b.id, b.readingid, c.fname, c.lname, r.date AS reading_date, b.duedate, b.amount, b.status " &
                          "FROM tblbills b " &
                          "LEFT JOIN tblreadings r ON b.readingid = r.id " &
                          "LEFT JOIN tblconsumers c ON r.consumerid = c.id"

        If txtsearch.Text.Trim() <> "" Then
            q &= " WHERE c.fname LIKE @s OR c.lname LIKE @s"
        End If
        q &= " ORDER BY b.duedate DESC"

        GetQuery(q, "bills", P("@s", "%" & txtsearch.Text.Trim() & "%"))

        lvbill.Items.Clear()
        For Each r As DataRow In ds.Tables("bills").Rows
            With lvbill.Items.Add(r("id").ToString())
                .SubItems.Add(r("readingid").ToString())
                .SubItems.Add(r("fname").ToString() & " " & r("lname").ToString())
                .SubItems.Add(CDate(r("reading_date")).ToShortDateString())
                .SubItems.Add(CDate(r("duedate")).ToShortDateString())
                .SubItems.Add(r("amount").ToString())
                .SubItems.Add(r("status").ToString())
            End With
        Next

    End Sub

    Private Sub lvreadings_DoubleClick(sender As Object, e As EventArgs) Handles lvreadings.DoubleClick
        If lvreadings.SelectedItems.Count = 0 Then Exit Sub

        Dim readingId As Integer = CInt(lvreadings.SelectedItems(0).SubItems(0).Text)

        Dim rateValue As Object = GetValue("SELECT rate FROM tblrates ORDER BY id DESC LIMIT 1")
        If rateValue Is Nothing Then
            MsgBox("No rate has been set yet. Add a rate under Others > Rate first.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim usage As Decimal = Convert.ToDecimal(GetValue("SELECT curr - prev FROM tblreadings WHERE id = @id", P("@id", readingId)))
        Dim rate As Decimal = Convert.ToDecimal(rateValue)

        txtreadid.Text = readingId.ToString()
        txtamount.Text = (usage * rate).ToString("N2")
        dtpdate.Value = CDate(lvreadings.SelectedItems(0).SubItems(2).Text).AddDays(15)
    End Sub



    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearFields()
        adding = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim readid As Integer
        Dim amount As Decimal

        If txtreadid.Text.Trim() = "" Or txtamount.Text.Trim() = "" Then
            MsgBox("Please select a reading and compute amount.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not Integer.TryParse(txtreadid.Text.Trim(), readid) Then
            MsgBox("Invalid reading ID.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not Decimal.TryParse(txtamount.Text.Trim(), amount) OrElse amount < 0 Then
            MsgBox("Invalid amount format.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If cmbstatus.SelectedIndex = -1 Then
            MsgBox("Please select a bill status.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Only new bills need a future due date; an existing bill may already be overdue
        ' and still has to be editable (e.g. to mark it as paid).
        If adding AndAlso dtpdate.Value.Date < Today Then
            MsgBox("Due date cannot be in the past.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        GetQuery("SELECT prev, curr FROM tblreadings WHERE id = @id", "readingval", P("@id", readid))
        If ds.Tables("readingval").Rows.Count = 0 Then
            MsgBox("Reading #" & readid & " does not exist.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim prev As Decimal = Convert.ToDecimal(ds.Tables("readingval").Rows(0)("prev"))
        Dim curr As Decimal = Convert.ToDecimal(ds.Tables("readingval").Rows(0)("curr"))

        If curr < prev Then
            MsgBox("Invalid reading: Current reading cannot be less than previous.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tblbills WHERE readingid = @r AND id <> @id", P("@r", readid), P("@id", If(updating, selectedBillID, -1)))) > 0 Then
            MsgBox("A bill for this reading already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim duedate As String = dtpdate.Value.ToString("yyyy-MM-dd")
        Dim requestedStatus As String = cmbstatus.SelectedItem.ToString()
        Dim billID As Integer = selectedBillID
        Dim autoPayment As Decimal = 0
        Dim finalStatus As String = ""

        Try
            BeginTransaction()

            If adding Then
                Execute("INSERT INTO tblbills (readingid, duedate, amount, status) VALUES (@r, @due, @amount, 'Unpaid')",
                        P("@r", readid), P("@due", duedate), P("@amount", amount))
                billID = GetLastInsertedID()
            Else
                Execute("UPDATE tblbills SET readingid = @r, duedate = @due, amount = @amount WHERE id = @id",
                        P("@r", readid), P("@due", duedate), P("@amount", amount), P("@id", billID))
            End If

            Dim totalPaid As Decimal = Convert.ToDecimal(GetValue("SELECT IFNULL(SUM(amount), 0) FROM tblpayments WHERE billid = @b", P("@b", billID)))

            ' Marking a bill as Paid records a payment for whatever is still owed.
            If requestedStatus = "Paid" AndAlso totalPaid < amount Then
                autoPayment = amount - totalPaid
                Execute("INSERT INTO tblpayments (billid, date, amount) VALUES (@b, CURDATE(), @amount)", P("@b", billID), P("@amount", autoPayment))
                totalPaid = amount
            End If

            ' The stored status always matches the payments on the bill.
            finalStatus = BillStatus(amount, totalPaid)
            Execute("UPDATE tblbills SET status = @status WHERE id = @id", P("@status", finalStatus), P("@id", billID))

            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not save the bill: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        MsgBox(If(adding, "Bill added successfully!", "Bill updated successfully!"), MsgBoxStyle.Information)
        If autoPayment > 0 Then
            MsgBox("Auto payment of " & autoPayment.ToString("N2") & " added because bill was marked as Paid.", MsgBoxStyle.Information)
        ElseIf finalStatus <> requestedStatus Then
            MsgBox("Status was set to " & finalStatus & " to match the payments already recorded for this bill.", MsgBoxStyle.Information)
        End If

        adding = False
        updating = False
        fillBills()
        fillReadings()
        clearFields()
        disablebuttons()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
    End Sub

    Public Shared Function BillStatus(amount As Decimal, totalPaid As Decimal) As String
        If totalPaid >= amount Then Return "Paid"
        If totalPaid > 0 Then Return "Partial"
        Return "Unpaid"
    End Function


    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedBillID = -1 Then
            MsgBox("Please select a bill first.", MsgBoxStyle.Information)
            Exit Sub
        End If
        enablebuttons()
        updating = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedBillID = -1 Then
            MsgBox("Please select a bill to delete.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim paymentCount As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblpayments WHERE billid = @b", P("@b", selectedBillID)))
        If paymentCount > 0 Then
            If MsgBox("This bill has " & paymentCount & " payment(s). Deleting it will remove all related payments. Continue?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirm Deletion") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        ElseIf MsgBox("Are you sure you want to delete this bill?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Deletion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Try
            BeginTransaction()
            Execute("DELETE FROM tblpayments WHERE billid = @b", P("@b", selectedBillID))
            Execute("DELETE FROM tblbills WHERE id = @b", P("@b", selectedBillID))
            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not delete the bill: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        MsgBox("Bill and related payments deleted successfully.", MsgBoxStyle.Information)

        fillBills()
        fillReadings()
        clearFields()
        disablebuttons()
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Cancel bill creation?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Cancel bill update?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If

        disablebuttons()
        clearFields()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
        selectedBillID = -1
    End Sub

    Private Sub lvbill_DoubleClick(sender As Object, e As EventArgs) Handles lvbill.DoubleClick
        If adding Or updating Or lvbill.SelectedItems.Count = 0 Then Exit Sub

        With lvbill.SelectedItems(0)
            selectedBillID = Integer.Parse(.SubItems(0).Text)
            txtreadid.Text = .SubItems(1).Text
            dtpdate.Value = CDate(.SubItems(4).Text)
            txtamount.Text = .SubItems(5).Text
            ' "Partial" isn't selectable; it is recalculated from the payments when saving.
            cmbstatus.SelectedItem = If(.SubItems(6).Text = "Paid", "Paid", "Unpaid")
        End With

        btnupdate.Enabled = True
        btndelete.Enabled = True
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
    End Sub

    Public Sub clearFields()
        txtreadid.Clear()
        txtamount.Clear()
        cmbstatus.SelectedIndex = 0
        dtpdate.Value = Today
        selectedBillID = -1
    End Sub

    Public Sub enablebuttons()
        btnnew.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
    End Sub

    Public Sub disablebuttons()
        btnnew.Enabled = True
        btnsave.Enabled = False
        btnupdate.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = False
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fillBills()
    End Sub

    Private Sub txtsearchread_TextChanged(sender As Object, e As EventArgs) Handles txtsearchread.TextChanged
        fillReadings()
    End Sub


    Private Sub rec_Click(sender As Object, e As EventArgs) Handles rec.Click

    End Sub
End Class
