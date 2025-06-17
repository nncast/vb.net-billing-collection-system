Public Class frmPayments
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedBillID As Integer = -1
    Public selectedPaymentID As Integer = -1

    Private Sub frmPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")
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
                              "WHERE b.status IN ('Unpaid', 'Partial') ORDER BY b.duedate ASC"
        GetQuery(query, "bills")

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
       Dim query As String = "SELECT p.id AS payment_id, CONCAT(c.fname, ' ', c.lname) AS fullname, p.billid, p.date, p.amount, b.amount AS bill_amount " & _
                       "FROM tblpayments p " & _
                       "LEFT JOIN tblbills b ON p.billid = b.id " & _
                       "LEFT JOIN tblreadings r ON b.readingid = r.id " & _
                       "LEFT JOIN tblconsumers c ON r.consumerid = c.id " & _
                       "ORDER BY p.billid, p.date ASC"


        GetQuery(query, "payments")
        lvpayments.Items.Clear()

        Dim cumulativePaid As New Dictionary(Of Integer, Decimal)

        For Each r As DataRow In ds.Tables("payments").Rows
            Dim billId As Integer = CInt(r("billid"))
            Dim paymentAmount As Decimal = CDec(r("amount"))
            Dim billAmount As Decimal = CDec(r("bill_amount"))

            If Not cumulativePaid.ContainsKey(billId) Then
                cumulativePaid(billId) = 0
            End If
            cumulativePaid(billId) += paymentAmount

            Dim balance As Decimal = billAmount - cumulativePaid(billId)

            With lvpayments.Items.Add(r("payment_id").ToString())
                .SubItems.Add(billId.ToString())
                .SubItems.Add(r("fullname").ToString())
                .SubItems.Add(CDate(r("date")).ToShortDateString())
                .SubItems.Add(Format(paymentAmount, "N2"))
                .SubItems.Add(Format(balance, "N2"))
            End With
        Next
    End Sub

    Private Sub lvbills_DoubleClick(sender As Object, e As EventArgs) Handles lvbills.DoubleClick
        If lvbills.SelectedItems.Count = 0 Then Exit Sub

        Dim item = lvbills.FocusedItem
        selectedBillID = CInt(item.SubItems(0).Text)
        txtbillid.Text = selectedBillID.ToString()

        Dim billAmount As Decimal = CDec(item.SubItems(3).Text)

        Dim query As String = "SELECT SUM(amount) AS total_paid FROM tblpayments WHERE billid = " & selectedBillID
        GetQuery(query, "bill_total")
        Dim totalPaid As Decimal = 0
        If ds.Tables("bill_total").Rows.Count > 0 AndAlso Not IsDBNull(ds.Tables("bill_total").Rows(0)("total_paid")) Then
            totalPaid = CDec(ds.Tables("bill_total").Rows(0)("total_paid"))
        End If

        Dim balance As Decimal = billAmount - totalPaid
        lblremaining.Text = "₱ " & Format(balance, "N2")

        fillPayments()

        btnupdate.Enabled = False
        btndelete.Enabled = False
    End Sub

    Private Sub lvpayments_DoubleClick(sender As Object, e As EventArgs) Handles lvpayments.DoubleClick
        If lvpayments.SelectedItems.Count = 0 Then Exit Sub

        Dim item = lvpayments.FocusedItem
        selectedPaymentID = CInt(item.SubItems(0).Text)
        txtbillid.Text = item.SubItems(1).Text
        dtpdate.Value = CDate(item.SubItems(3).Text)
        txtamount.Text = item.SubItems(4).Text
        lblremaining.Text = "₱ " & Format(CDec(item.SubItems(5).Text), "N2")

        btnupdate.Enabled = True
        btndelete.Enabled = True
    End Sub


    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        adding = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnnew.Enabled = False
        clearFields()
        txtbillid.Text = selectedBillID.ToString()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Not IsNumeric(txtamount.Text) Then
            MsgBox("Invalid amount.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim payAmount = Decimal.Parse(txtamount.Text)
        Dim payDate = dtpdate.Value.ToString("yyyy-MM-dd")

        If payAmount <= 0 Then
            MsgBox("Payment amount must be greater than zero.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If adding Then
            If selectedBillID = -1 Then
                MsgBox("No bill selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim remainingBalance As Decimal = Decimal.Parse(lblremaining.Text.Replace("₱", "").Trim())
            If payAmount > remainingBalance Then
                MsgBox("Payment exceeds remaining balance.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            SetQuery("INSERT INTO tblpayments (billid, date, amount) VALUES (" & _
                     selectedBillID & ", '" & payDate & "', " & payAmount & ")")
            MsgBox("Payment added successfully!", MsgBoxStyle.Information)

            UpdateBillStatus(selectedBillID)

        ElseIf updating Then
            If selectedPaymentID = -1 Then
                MsgBox("No payment selected.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            SetQuery("UPDATE tblpayments SET date = '" & payDate & "', amount = " & payAmount & _
                     " WHERE id = " & selectedPaymentID)
            MsgBox("Payment updated successfully!", MsgBoxStyle.Information)

            UpdateBillStatus(CInt(txtbillid.Text))
        End If

        fillPayments()
        clearFields()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
        adding = False
        updating = False
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
            SetQuery("DELETE FROM tblpayments WHERE id = " & selectedPaymentID)
            MsgBox("Payment deleted.", MsgBoxStyle.Information)
            UpdateBillStatus(CInt(txtbillid.Text))
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

    Public Sub UpdateBillStatus(billId As Integer)
        Dim query As String = "SELECT amount FROM tblbills WHERE id = " & billId
        GetQuery(query, "bill_amt")

        If ds.Tables("bill_amt").Rows.Count = 0 Then Exit Sub

        Dim billAmount As Decimal = CDec(ds.Tables("bill_amt").Rows(0)("amount"))

        query = "SELECT SUM(amount) AS total_paid FROM tblpayments WHERE billid = " & billId
        GetQuery(query, "bill_paid")

        Dim totalPaid As Decimal = 0
        If ds.Tables("bill_paid").Rows.Count > 0 AndAlso Not IsDBNull(ds.Tables("bill_paid").Rows(0)("total_paid")) Then
            totalPaid = CDec(ds.Tables("bill_paid").Rows(0)("total_paid"))
        End If

        Dim newStatus As String
        If totalPaid >= billAmount Then
            newStatus = "Paid"
        ElseIf totalPaid > 0 Then
            newStatus = "Partial"
        Else
            newStatus = "Unpaid"
        End If

        SetQuery("UPDATE tblbills SET status = '" & newStatus & "' WHERE id = " & billId)
    End Sub

End Class
