Public Class frmBills
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedBillID As Integer = -1

    Private Sub frmBills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")

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
            q &= " AND (c.fname LIKE '%" & txtsearchread.Text & "%' OR c.lname LIKE '%" & txtsearchread.Text & "%')"
        End If

        q &= " ORDER BY r.date DESC"
        GetQuery(q, "readings")

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
        Dim q As String = "SELECT b.id, b.readingid, c.fname, c.lname, r.date AS reading_date, b.duedate, b.amount, b.status " & _
                  "FROM tblbills b " & _
                  "LEFT JOIN tblreadings r ON b.readingid = r.id " & _
                  "LEFT JOIN tblconsumers c ON r.consumerid = c.id"

        If txtsearch.Text.Trim() <> "" Then
            q &= " WHERE c.fname LIKE '%" & txtsearch.Text & "%' OR c.lname LIKE '%" & txtsearch.Text & "%'"
        End If
        q &= " ORDER BY b.duedate DESC"

        GetQuery(q, "bills")

        lvbill.Items.Clear()
        For Each r As DataRow In ds.Tables("bills").Rows
            With lvbill.Items.Add(r("id").ToString())
                .SubItems.Add(r("readingid").ToString())
                .SubItems.Add(r("fname").ToString() & " " & r("lname").ToString())
                .SubItems.Add(CDate(r("reading_date")).ToShortDateString()) ' <-- Add this
                .SubItems.Add(CDate(r("duedate")).ToShortDateString())
                .SubItems.Add(r("amount").ToString())
                .SubItems.Add(r("status").ToString())
            End With
        Next

    End Sub

    Private Sub lvreadings_DoubleClick(sender As Object, e As EventArgs) Handles lvreadings.DoubleClick
        If lvreadings.SelectedItems.Count > 0 Then
            txtreadid.Text = lvreadings.FocusedItem.SubItems(0).Text

            Dim q As String = "SELECT curr - prev AS `usage` FROM tblreadings WHERE id = " & txtreadid.Text
            GetQuery(q, "usage")
            Dim usage As Decimal = Convert.ToDecimal(ds.Tables("usage").Rows(0)("usage"))

            Dim a As String = "SELECT rate FROM tblrates ORDER BY id DESC LIMIT 1"
            GetQuery(a, "rate")
            Dim rate As Decimal = Convert.ToDecimal(ds.Tables("rate").Rows(0)("rate"))

            txtamount.Text = (usage * rate).ToString("N2")

            dtpdate.Value = CDate(lvreadings.FocusedItem.SubItems(2).Text).AddDays(15)
        End If
    End Sub



    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearFields()
        adding = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtreadid.Text = "" Or txtamount.Text = "" Then
            MsgBox("Please select a reading and compute amount.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not Decimal.TryParse(txtamount.Text, Nothing) Then
            MsgBox("Invalid amount format.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If cmbstatus.SelectedIndex = -1 Then
            MsgBox("Please select a bill status.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If dtpdate.Value.Date < Today Then
            MsgBox("Due date cannot be in the past.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim qval As String = "SELECT prev, curr FROM tblreadings WHERE id = " & txtreadid.Text
        GetQuery(qval, "readingval")
        Dim prev As Decimal = Convert.ToDecimal(ds.Tables("readingval").Rows(0)("prev"))
        Dim curr As Decimal = Convert.ToDecimal(ds.Tables("readingval").Rows(0)("curr"))

        If curr < prev Then
            MsgBox("Invalid reading: Current reading cannot be less than previous.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim readid As Integer = Integer.Parse(txtreadid.Text)
        Dim amount As Decimal = Decimal.Parse(txtamount.Text)
        Dim duedate As String = dtpdate.Value.ToString("yyyy-MM-dd")
        Dim status As String = cmbstatus.Text

        Dim q As String = "SELECT COUNT(*) FROM tblbills WHERE readingid = " & readid
        GetQuery(q, "checkbill")
        If adding AndAlso Convert.ToInt32(ds.Tables("checkbill").Rows(0)(0)) > 0 Then
            MsgBox("A bill for this reading already exists.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If adding Then
            SetQuery("INSERT INTO tblbills (readingid, duedate, amount, status) VALUES (" &
                     readid & ", '" & duedate & "', " & amount & ", '" & status & "')")

            GetQuery("SELECT LAST_INSERT_ID()", "lastid")
            selectedBillID = Convert.ToInt32(ds.Tables("lastid").Rows(0)(0))

            adding = False
            MsgBox("Bill added successfully!", MsgBoxStyle.Information)

        ElseIf updating Then
            SetQuery("UPDATE tblbills SET readingid = " & readid & ", duedate = '" & duedate &
                     "', amount = " & amount & ", status = '" & status & "' WHERE id = " & selectedBillID)
            updating = False
            MsgBox("Bill updated successfully!", MsgBoxStyle.Information)
        End If

        If status = "Paid" Then
            Dim q2 As String = "SELECT COUNT(*) FROM tblpayments WHERE billid = " & selectedBillID
            GetQuery(q2, "haspayment")

            If Convert.ToInt32(ds.Tables("haspayment").Rows(0)(0)) = 0 Then
                Dim today As String = Format(DateTime.Now, "yyyy-MM-dd")
                SetQuery("INSERT INTO tblpayments (billid, date, amount) VALUES (" & selectedBillID & ", '" & today & "', " & amount & ")")
                MsgBox("Auto payment added because bill was marked as Paid.", MsgBoxStyle.Information)
            End If
        End If

        fillBills()
        clearFields()
        disablebuttons()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
    End Sub


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

        Dim qCheck As String = "SELECT COUNT(*) FROM tblpayments WHERE billid = " & selectedBillID
        GetQuery(qCheck, "haspayments")

        Dim paymentCount As Integer = Convert.ToInt32(ds.Tables("haspayments").Rows(0)(0))
        If paymentCount > 0 Then
            If MsgBox("This bill has " & paymentCount & " payment(s). Deleting it will remove all related payments. Continue?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirm Deletion") = MsgBoxResult.Yes Then
                SetQuery("DELETE FROM tblpayments WHERE billid = " & selectedBillID)
            Else
                Exit Sub
            End If
        End If

        SetQuery("DELETE FROM tblbills WHERE id = " & selectedBillID)
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
        If lvbill.SelectedItems.Count > 0 Then
            With lvbill.FocusedItem
                selectedBillID = Integer.Parse(.SubItems(0).Text)
                txtreadid.Text = .SubItems(1).Text
                dtpdate.Value = CDate(.SubItems(4).Text)
                txtamount.Text = .SubItems(5).Text
                cmbstatus.Text = .SubItems(6).Text
            End With

            btnupdate.Enabled = True
            btndelete.Enabled = True
            pnlinput.Enabled = False
            pnlinput2.Enabled = False
        End If
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
