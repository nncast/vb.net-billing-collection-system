Public Class frmReading
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedConsumerID As Integer = 0
    Public selectedReadingID As Integer = -1

    Private Sub frmReading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")
        loadform()
    End Sub

    Public Sub loadform()
        btnnew.Enabled = True
        btnsave.Enabled = False
        pnlinput.Enabled = False
        pnlinput2.Enabled = False

        fillConsumerList()
        fill()
    End Sub

    Public Sub fillConsumerList()
        Dim query As String = "SELECT id, CONCAT(fname, ' ', lname) AS fullname FROM tblconsumers"
        If txtsearchcon.Text.Trim() <> "" Then
            query &= " WHERE fname LIKE '%" & txtsearchcon.Text & "%' OR lname LIKE '%" & txtsearchcon.Text & "%'"
        End If
        GetQuery(query, "cons")
        lvconsumers.Items.Clear()
        For Each r As DataRow In ds.Tables("cons").Rows
            With lvconsumers.Items.Add(r("id").ToString())
                .SubItems.Add(r("fullname").ToString())
            End With
        Next
    End Sub

    Public Sub fill()
        Dim query As String = "SELECT r.id, CONCAT(c.fname, ' ', c.lname) AS fullname, r.date, r.prev, r.curr, (r.curr - r.prev) AS `usage`, c.id AS conid " &
                              "FROM tblreadings r LEFT JOIN tblconsumers c ON r.consumerid = c.id"
        If txtsearch.Text.Trim() <> "" Then
            query &= " WHERE c.fname LIKE '%" & txtsearch.Text & "%' OR c.lname LIKE '%" & txtsearch.Text & "%'"
        End If
        query &= " ORDER BY r.date DESC"

        GetQuery(query, "read")
        lvreadings.Items.Clear()
        For Each r As DataRow In ds.Tables("read").Rows
            With lvreadings.Items.Add(r("id").ToString())
                .SubItems.Add(r("fullname").ToString())
                .SubItems.Add(CDate(r("date")).ToShortDateString())
                .SubItems.Add(r("prev").ToString())
                .SubItems.Add(r("curr").ToString())
                .SubItems.Add(r("usage").ToString())
                .SubItems.Add(r("conid").ToString())
            End With
        Next
    End Sub


    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearFields()
        adding = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedReadingID = -1 Then
            MsgBox("Select a reading record first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtconid.Text = "" Then
            MsgBox("Please select a consumer.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not IsNumeric(txtconid.Text) Then
            MsgBox("Invalid consumer ID.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not IsNumeric(txtprev.Text) Then
            MsgBox("Previous reading must be a valid number.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not IsNumeric(txtcurr.Text) Then
            MsgBox("Current reading must be a valid number.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If txtprev.Text.Trim() = "" OrElse txtcurr.Text.Trim() = "" Then
            MsgBox("Previous and Current readings are required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If CDec(txtcurr.Text) <= CDec(txtprev.Text) Then
            MsgBox("Current reading must be greater than or equal to previous reading.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim conid As Integer = Integer.Parse(txtconid.Text)
        Dim prev As Decimal = Decimal.Parse(txtprev.Text)
        Dim curr As Decimal = Decimal.Parse(txtcurr.Text)
        Dim readingdate As String = dtpdate.Value.ToString("yyyy-MM-dd")

        Dim checkQuery As String = "SELECT COUNT(*) FROM tblreadings WHERE consumerid = " & conid &
        " AND DATE_FORMAT(date, '%Y-%m') = '" & dtpdate.Value.ToString("yyyy-MM") & "'"

        GetQuery(checkQuery, "check")
        If ds.Tables("check").Rows(0)(0) > 0 AndAlso adding Then
            MsgBox("A reading already exists for this consumer in " & dtpdate.Value.ToString("MMMM yyyy") & ".", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If adding Then
            SetQuery("INSERT INTO tblreadings (consumerid, date, prev, curr) VALUES (" &
                     conid & ", '" & readingdate & "', " & prev & ", " & curr & ")")
            adding = False
            MsgBox("Reading record added successfully!", MsgBoxStyle.Information)

        ElseIf updating Then
            Dim updateCheckQuery As String = "SELECT COUNT(*) FROM tblreadings WHERE consumerid = " & conid &
            " AND DATE_FORMAT(date, '%Y-%m') = '" & dtpdate.Value.ToString("yyyy-MM") & "' AND id <> " & selectedReadingID
            GetQuery(updateCheckQuery, "checkupdate")
            If ds.Tables("checkupdate").Rows(0)(0) > 0 Then
                MsgBox("Another reading already exists for this consumer in " & dtpdate.Value.ToString("MMMM yyyy") & ".", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            SetQuery("UPDATE tblreadings SET consumerid = " & conid &
                     ", date = '" & readingdate & "', prev = " & prev &
                     ", curr = " & curr & " WHERE id = " & selectedReadingID)
            updating = False
            MsgBox("Reading record updated successfully!", MsgBoxStyle.Information)
        End If

        fill()
        clearFields()
        disablebuttons()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Are you sure you want to cancel adding new reading?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        End If

        disablebuttons()
        clearFields()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
        selectedConsumerID = -1
    End Sub

    Private Sub lvconsumers_DoubleClick(sender As Object, e As EventArgs) Handles lvconsumers.DoubleClick
        txtconid.Text = lvconsumers.FocusedItem.SubItems(0).Text
        selectedConsumerID = Integer.Parse(txtconid.Text)

        Dim q As String = "SELECT curr, date FROM tblreadings WHERE consumerid = " & selectedConsumerID & " ORDER BY date DESC LIMIT 1"
        GetQuery(q, "last")

        If ds.Tables("last").Rows.Count > 0 Then
            txtprev.Text = ds.Tables("last").Rows(0)("curr").ToString()

            Dim lastDate As Date = CDate(ds.Tables("last").Rows(0)("date"))
            dtpdate.Value = lastDate.AddMonths(1)
        Else
            txtprev.Text = "0.00"
            dtpdate.Value = Today
        End If

        txtcurr_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub lvreadings_DoubleClick(sender As Object, e As EventArgs) Handles lvreadings.DoubleClick
        If lvreadings.SelectedItems.Count = 0 Then Exit Sub

        Dim item As ListViewItem = lvreadings.FocusedItem


        selectedReadingID = Integer.Parse(item.SubItems(0).Text)
        txtconid.Text = item.SubItems(6).Text
        dtpdate.Value = CDate(item.SubItems(2).Text)
        txtprev.Text = item.SubItems(3).Text
        txtcurr.Text = item.SubItems(4).Text
        txtusage.Text = item.SubItems(5).Text

        btnupdate.Enabled = True
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
    End Sub

    Private Sub txtcurr_TextChanged(sender As Object, e As EventArgs) Handles txtcurr.TextChanged
        Dim p As Decimal
        Dim c As Decimal
        Decimal.TryParse(txtprev.Text, p)
        Decimal.TryParse(txtcurr.Text, c)

        If c >= p Then
            txtusage.Text = (c - p).ToString("N2")
        Else
            txtusage.Text = ""
        End If
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Private Sub txtsearchcon_TextChanged(sender As Object, e As EventArgs) Handles txtsearchcon.TextChanged
        fillConsumerList()
    End Sub

    Public Sub clearFields()
        txtconid.Clear()
        txtprev.Clear()
        txtcurr.Clear()
        txtusage.Clear()
        dtpdate.Value = Today
    End Sub

    Public Sub enablebuttons()
        btnnew.Enabled = False
        btnupdate.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnsave.Enabled = True
    End Sub

    Public Sub disablebuttons()
        btnnew.Enabled = True
        btnupdate.Enabled = True
        btndelete.Enabled = True
        btncancel.Enabled = True
        btnsave.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedReadingID = -1 Then
            MsgBox("Please select a reading record to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim billQuery As String = "SELECT id FROM tblbills WHERE readingid = " & selectedReadingID
        GetQuery(billQuery, "linkedBill")

        Dim billExists As Boolean = ds.Tables("linkedBill").Rows.Count > 0
        Dim billID As Integer = -1

        If billExists Then
            billID = Integer.Parse(ds.Tables("linkedBill").Rows(0)("id"))

            Dim paymentQuery As String = "SELECT COUNT(*) FROM tblpayments WHERE billid = " & billID
            GetQuery(paymentQuery, "hasPayments")

            Dim paymentCount As Integer = ds.Tables("hasPayments").Rows(0)(0)

            If paymentCount > 0 Then
                If MsgBox("This reading is linked to a bill with " & paymentCount & " payment(s). Deleting it will also delete all related transactions. Continue?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirm Deletion") = MsgBoxResult.Yes Then
                    SetQuery("DELETE FROM tblpayments WHERE billid = " & billID)
                Else
                    Exit Sub
                End If
            End If

            SetQuery("DELETE FROM tblbills WHERE id = " & billID)
        End If

        If MsgBox("Are you sure you want to delete this reading record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Reading") = MsgBoxResult.Yes Then
            SetQuery("DELETE FROM tblreadings WHERE id = " & selectedReadingID)
            MsgBox("Reading and all related transactions deleted successfully!", MsgBoxStyle.Information)

            selectedReadingID = -1
            fill()
            clearFields()
            disablebuttons()
            pnlinput.Enabled = False
            pnlinput2.Enabled = False
        End If
    End Sub


End Class
