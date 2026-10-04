Public Class frmPayments
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedBillID As Integer = -1
    Public selectedPaymentID As Integer = -1

    Private Sub frmPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        loadform()
    End Sub

    Public Sub loadform()
        btnnew.Enabled = True
        btnsave.Enabled = False
        pnlinput.Enabled = False
        pnlinput2.Enabled = False

        fillBills()
        fillPayments()
        clearFields()
    End Sub

    Public Sub fillBills()
        Dim query As String = "SELECT b.id, CONCAT(c.fname, ' ', c.lname) AS fullname, b.duedate, b.amount, b.status " &
                              "FROM tblbills b LEFT JOIN tblreadings r ON b.readingid = r.id " &
                              "LEFT JOIN tblconsumers c ON r.consumerid = c.id " &
                              "WHERE b.status IN ('Unpaid', 'Partial')"
        If txtsearchbill.Text.Trim() <> "" Then
            query &= " AND (c.fname LIKE @s OR c.lname LIKE @s OR b.id LIKE @s)"
        End If
        query &= " ORDER BY b.duedate ASC"
        GetQuery(query, "bills", P("@s", "%" & txtsearchbill.Text.Trim() & "%"))

        lvbills.Items.Clear()
        For Each r As DataRow In ds.Tables("bills").Rows
            With lvbills.Items.Add(r("id").ToString())
                .SubItems.Add(r("fullname").ToString())
                .SubItems.Add(CDate(r("duedate")).ToShortDateString())
                .SubItems.Add(Format(CDec(r("amount")), "N2"))
                .SubItems.Add(r("status").ToString())
            End With
        Next
    End Sub

    Public Sub fillPayments()
        Dim query As String = "SELECT p.id AS payment_id, CONCAT(c.fname, ' ', c.lname) AS fullname, p.billid, p.date, p.amount, b.amount AS bill_amount " &
                              "FROM tblpayments p " &
                              "LEFT JOIN tblbills b ON p.billid = b.id " &
                              "LEFT JOIN tblreadings r ON b.readingid = r.id " &
                              "LEFT JOIN tblconsumers c ON r.consumerid = c.id " &
                              "ORDER BY p.billid, p.date ASC, p.id ASC"

        GetQuery(query, "payments")
        lvpayments.Items.Clear()

        Dim search As String = txtsearch.Text.Trim().ToLower()
        Dim cumulativePaid As New Dictionary(Of Integer, Decimal)

        ' The running balance needs every payment of a bill, so filter only after computing it.
        For Each r As DataRow In ds.Tables("payments").Rows
            Dim billId As Integer = CInt(r("billid"))
            Dim paymentAmount As Decimal = CDec(r("amount"))
            Dim billAmount As Decimal = CDec(r("bill_amount"))

            If Not cumulativePaid.ContainsKey(billId) Then
                cumulativePaid(billId) = 0
            End If
            cumulativePaid(billId) += paymentAmount

            Dim balance As Decimal = billAmount - cumulativePaid(billId)
            Dim name As String = r("fullname").ToString()

            If search <> "" AndAlso Not name.ToLower().Contains(search) AndAlso billId.ToString() <> search Then Continue For

            With lvpayments.Items.Add(r("payment_id").ToString())
                .SubItems.Add(billId.ToString())
                .SubItems.Add(name)
                .SubItems.Add(CDate(r("date")).ToShortDateString())
                .SubItems.Add(Format(paymentAmount, "N2"))
                .SubItems.Add(Format(balance, "N2"))
            End With
        Next
    End Sub

    ' Amount still owed on a bill, ignoring one payment (the one being edited).
    Private Function RemainingBalance(billId As Integer, Optional excludePaymentId As Integer = -1) As Decimal
        Dim billAmount As Decimal = Convert.ToDecimal(GetValue("SELECT amount FROM tblbills WHERE id = @b", P("@b", billId)))
        Dim paid As Decimal = Convert.ToDecimal(GetValue("SELECT IFNULL(SUM(amount), 0) FROM tblpayments WHERE billid = @b AND id <> @p", P("@b", billId), P("@p", excludePaymentId)))
        Return billAmount - paid
    End Function

    Private Sub lvbills_DoubleClick(sender As Object, e As EventArgs) Handles lvbills.DoubleClick
        If adding Or updating Or lvbills.SelectedItems.Count = 0 Then Exit Sub

        selectedBillID = CInt(lvbills.SelectedItems(0).SubItems(0).Text)
        txtbillid.Text = selectedBillID.ToString()
        lblremaining.Text = "₱ " & Format(RemainingBalance(selectedBillID), "N2")

        fillPayments()

        btnupdate.Enabled = False
        btndelete.Enabled = False
    End Sub

    Private Sub lvpayments_DoubleClick(sender As Object, e As EventArgs) Handles lvpayments.DoubleClick
        If adding Or updating Or lvpayments.SelectedItems.Count = 0 Then Exit Sub

        Dim item = lvpayments.SelectedItems(0)
        selectedPaymentID = CInt(item.SubItems(0).Text)
        txtbillid.Text = item.SubItems(1).Text
        dtpdate.Value = CDate(item.SubItems(3).Text)
        txtamount.Text = item.SubItems(4).Text
        lblremaining.Text = "₱ " & Format(CDec(item.SubItems(5).Text), "N2")

        btnupdate.Enabled = True
        btndelete.Enabled = True
    End Sub


    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        If selectedBillID = -1 Then
            MsgBox("Double-click a pending bill first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim billId As Integer = selectedBillID
        adding = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnnew.Enabled = False
        clearFields()
        txtbillid.Text = billId.ToString()
        lblremaining.Text = "₱ " & Format(RemainingBalance(billId), "N2")
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim payAmount As Decimal
        If Not Decimal.TryParse(txtamount.Text.Trim(), payAmount) Then
            MsgBox("Invalid amount.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim payDate = dtpdate.Value.ToString("yyyy-MM-dd")

        If payAmount <= 0 Then
            MsgBox("Payment amount must be greater than zero.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim billId As Integer
        If adding Then
            If selectedBillID = -1 Then
                MsgBox("No bill selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            billId = selectedBillID
        ElseIf updating Then
            If selectedPaymentID = -1 Then
                MsgBox("No payment selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            billId = CInt(txtbillid.Text)
        Else
            Exit Sub
        End If

        ' Total payments may never exceed the bill, whether adding or editing a payment.
        If payAmount > RemainingBalance(billId, If(updating, selectedPaymentID, -1)) Then
            MsgBox("Payment exceeds remaining balance.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            BeginTransaction()
            If adding Then
                Execute("INSERT INTO tblpayments (billid, date, amount) VALUES (@b, @d, @a)", P("@b", billId), P("@d", payDate), P("@a", payAmount))
            Else
                Execute("UPDATE tblpayments SET date = @d, amount = @a WHERE id = @id", P("@d", payDate), P("@a", payAmount), P("@id", selectedPaymentID))
            End If
            UpdateBillStatus(billId)
            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not save the payment: " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        MsgBox(If(adding, "Payment added successfully!", "Payment updated successfully!"), MsgBoxStyle.Information)

        adding = False
        updating = False
        selectedBillID = -1
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
        loadform()
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        adding = False
        updating = False
        clearFields()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
        btnsave.Enabled = False
        btncancel.Enabled = False
        btnnew.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedPaymentID = -1 Then
            MsgBox("Select a payment first.", MsgBoxStyle.Information)
            Exit Sub
        End If
        updating = True
        adding = False
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnnew.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedPaymentID = -1 Then
            MsgBox("Select a payment to delete.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Delete selected payment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim billId As Integer = CInt(txtbillid.Text)
            Try
                BeginTransaction()
                Execute("DELETE FROM tblpayments WHERE id = @id", P("@id", selectedPaymentID))
                UpdateBillStatus(billId)
                CommitTransaction()
            Catch ex As Exception
                RollbackTransaction()
                MsgBox("Could not delete the payment: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            MsgBox("Payment deleted.", MsgBoxStyle.Information)
            fillBills()
            fillPayments()
            clearFields()
        End If
    End Sub

    Public Sub clearFields()
        txtamount.Clear()
        txtbillid.Clear()
        lblremaining.Text = "₱ 0.00"
        dtpdate.Value = Today
        selectedPaymentID = -1
    End Sub

    ' Recalculates a bill's status from its payments. Call inside a transaction.
    Public Sub UpdateBillStatus(billId As Integer)
        Dim billAmount As Object = GetValue("SELECT amount FROM tblbills WHERE id = @b", P("@b", billId))
        If billAmount Is Nothing Then Exit Sub

        Dim totalPaid As Decimal = Convert.ToDecimal(GetValue("SELECT IFNULL(SUM(amount), 0) FROM tblpayments WHERE billid = @b", P("@b", billId)))
        Execute("UPDATE tblbills SET status = @s WHERE id = @b", P("@s", frmBills.BillStatus(Convert.ToDecimal(billAmount), totalPaid)), P("@b", billId))
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fillPayments()
    End Sub

    Private Sub txtsearchbill_TextChanged(sender As Object, e As EventArgs) Handles txtsearchbill.TextChanged
        fillBills()
    End Sub

End Class
