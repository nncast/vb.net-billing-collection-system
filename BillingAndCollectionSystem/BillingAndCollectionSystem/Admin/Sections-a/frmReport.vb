Public Class frmReport
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")
        fill()
    End Sub

    Public Sub fill()
        Dim filter As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT c.fname, c.lname, DATE_FORMAT(r.date, '%Y-%m') AS report_month, " &
        "SUM(b.amount) AS total_bills, " &
        "IFNULL(SUM(p.total_payments), 0) AS total_payments " &
        "FROM tblbills b " &
        "JOIN tblreadings r ON b.readingid = r.id " &
        "JOIN tblconsumers c ON r.consumerid = c.id " &
        "LEFT JOIN (" &
        "   SELECT billid, SUM(amount) AS total_payments " &
        "   FROM tblpayments GROUP BY billid" &
        ") p ON b.id = p.billid "


        If filter <> "" Then
            query &= "WHERE DATE_FORMAT(r.date, '%Y-%m') LIKE '%" & filter & "%' "
        End If


        query &= "GROUP BY report_month, c.fname, c.lname ORDER BY report_month DESC"

        GetQuery(query, "monthly")

        lvreport.Items.Clear()
        For Each r As DataRow In ds.Tables("monthly").Rows
            Dim monthStr = Format(Date.Parse(r("report_month").ToString()), "MMMM yyyy")
            Dim fullName = r("fname").ToString() & " " & r("lname").ToString()
            Dim totalBills = CDec(r("total_bills"))
            Dim totalPayments = CDec(r("total_payments"))
            Dim balance = totalBills - totalPayments

            With lvreport.Items.Add(monthStr)
                .SubItems.Add(fullName)
                .SubItems.Add(Format(totalBills, "N2"))
                .SubItems.Add(Format(totalPayments, "N2"))
                .SubItems.Add(Format(balance, "N2"))
            End With
        Next


    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub
End Class
