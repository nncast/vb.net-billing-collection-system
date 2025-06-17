Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")
        loadform()
    End Sub

    Public Sub loadform()
        GetQuery("SELECT COUNT(*) AS total FROM tblconsumers", "tblconsumers")
        If ds.Tables("tblconsumers").Rows.Count > 0 Then
            lbltotalcustomers.Text = ds.Tables("tblconsumers").Rows(0)("total").ToString()
        Else
            lbltotalcustomers.Text = "0"
        End If


        GetQuery("SELECT COUNT(*) AS total FROM tblbills WHERE status = 'Unpaid'", "totalUnpaidBills")
        If ds.Tables("totalUnpaidBills").Rows.Count > 0 Then
            lblunpaidbills.Text = ds.Tables("totalUnpaidBills").Rows(0)("total").ToString()
        Else
            lblunpaidbills.Text = "0"
        End If

        GetQuery("SELECT IFNULL(SUM(amount), 0) AS total FROM tblpayments WHERE MONTH(date) = MONTH(CURDATE()) AND YEAR(date) = YEAR(CURDATE())", "tblpayments")
        If ds.Tables("tblpayments").Rows.Count > 0 Then
            lblcollected.Text = "₱ " + (ds.Tables("tblpayments").Rows(0)("total")).ToString
        Else
            lblcollected.Text = "₱ 0.00"
        End If

        '=== Chart1: Monthly Collection for current year ===
        chart1.Series.Clear()
        chart1.Titles.Clear()
        chart1.Titles.Add("Monthly Collection")
        chart1.ChartAreas(0).AxisX.Title = "Month"
        chart1.ChartAreas(0).AxisY.Title = "Amount"

        Dim series As New DataVisualization.Charting.Series("Collection")
        series.ChartType = DataVisualization.Charting.SeriesChartType.Column
        series.IsValueShownAsLabel = True

        Dim monthsQuery As String = "SELECT MONTH(date) AS m, SUM(amount) AS total " &
                                    "FROM tblpayments " &
                                    "WHERE YEAR(date) = YEAR(CURDATE()) " &
                                    "GROUP BY MONTH(date) " &
                                    "ORDER BY m"
        GetQuery(monthsQuery, "monthly")

        For Each row As DataRow In ds.Tables("monthly").Rows
            Dim monthNum As Integer = row("m")
            Dim total As Decimal = row("total")
            Dim monthLabel As String = MonthName(monthNum)
            series.Points.AddXY(monthLabel, total)
        Next

        chart1.Series.Add(series)


       '=== lv1: Recent Payments ===
        lv1.Items.Clear()
        lv1.Columns.Clear()
        lv1.Columns.Add("Consumer", 150)
        lv1.Columns.Add("Amount", 80, HorizontalAlignment.Right)
        lv1.Columns.Add("Date", 100)
        lv1.Columns.Add("Status", 80)
        lv1.Columns.Add("Due Date", 100)

        Dim recentPaymentsQuery As String = "SELECT c.fname, c.lname, p.amount, p.date, b.status, b.duedate " &
            "FROM tblpayments p " &
            "INNER JOIN tblbills b ON p.billid = b.id " &
            "INNER JOIN tblreadings r ON b.readingid = r.id " &
            "INNER JOIN tblconsumers c ON r.consumerid = c.id " &
            "ORDER BY p.date DESC " &
            "LIMIT 10"
        GetQuery(recentPaymentsQuery, "recent")

        For Each row As DataRow In ds.Tables("recent").Rows
            Dim fullName As String = row("fname") & " " & row("lname")
            With lv1.Items.Add(fullName)
                .SubItems.Add("₱ " & Format(row("amount"), "N2"))
                .SubItems.Add(Format(CDate(row("date")), "yyyy-MM-dd"))
                .SubItems.Add(row("status").ToString())
                .SubItems.Add(Format(CDate(row("duedate")), "yyyy-MM-dd"))
            End With
        Next

    End Sub

End Class