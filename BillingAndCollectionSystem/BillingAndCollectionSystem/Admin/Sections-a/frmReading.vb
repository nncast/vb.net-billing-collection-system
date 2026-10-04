Public Class frmReading
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedConsumerID As Integer = 0
    Public selectedReadingID As Integer = -1

    Private Sub frmReading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
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
            query &= " WHERE fname LIKE @s OR lname LIKE @s"
        End If
        GetQuery(query, "cons", P("@s", "%" & txtsearchcon.Text.Trim() & "%"))
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
            query &= " WHERE c.fname LIKE @s OR c.lname LIKE @s"
        End If
        query &= " ORDER BY r.date DESC"

        GetQuery(query, "read", P("@s", "%" & txtsearch.Text.Trim() & "%"))
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
        selectedReadingID = -1
        adding = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedReadingID = -1 Then
            MsgBox("Select a reading record first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' A bill's amount is computed from its reading, so a billed reading can't change underneath it.
        If CInt(GetValue("SELECT COUNT(*) FROM tblbills WHERE readingid = @id", P("@id", selectedReadingID))) > 0 Then
            MsgBox("This reading already has a bill. Delete the bill first if the reading needs to be corrected.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
        pnlinput2.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim conid As Integer
        Dim prev As Decimal
        Dim curr As Decimal

        If txtconid.Text.Trim() = "" Then
            MsgBox("Please select a consumer.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not Integer.TryParse(txtconid.Text.Trim(), conid) Then
            MsgBox("Invalid consumer ID.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If txtprev.Text.Trim() = "" OrElse txtcurr.Text.Trim() = "" Then
            MsgBox("Previous and Current readings are required.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not Decimal.TryParse(txtprev.Text.Trim(), prev) OrElse prev < 0 Then
            MsgBox("Previous reading must be a valid number.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not Decimal.TryParse(txtcurr.Text.Trim(), curr) Then
            MsgBox("Current reading must be a valid number.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If curr < prev Then
            MsgBox("Current reading must be greater than or equal to previous reading.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tblconsumers WHERE id = @id", P("@id", conid))) = 0 Then
            MsgBox("Consumer #" & conid & " does not exist.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim readingdate As String = dtpdate.Value.ToString("yyyy-MM-dd")
        Dim readingMonth As String = dtpdate.Value.ToString("yyyy-MM")

        ' One reading per consumer per month (the record being edited doesn't count).
        Dim sameMonth As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblreadings WHERE consumerid = @c AND DATE_FORMAT(date, '%Y-%m') = @m AND id <> @id",
                                                 P("@c", conid), P("@m", readingMonth), P("@id", If(updating, selectedReadingID, -1))))
        If sameMonth > 0 Then
            MsgBox(If(updating, "Another reading", "A reading") & " already exists for this consumer in " & dtpdate.Value.ToString("MMMM yyyy") & ".", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim saved As Boolean = False
        If adding Then
            saved = SetQuery("INSERT INTO tblreadings (consumerid, date, prev, curr) VALUES (@c, @d, @prev, @curr)",
                             P("@c", conid), P("@d", readingdate), P("@prev", prev), P("@curr", curr))
            If saved Then MsgBox("Reading record added successfully!", MsgBoxStyle.Information)

        ElseIf updating Then
            saved = SetQuery("UPDATE tblreadings SET consumerid = @c, date = @d, prev = @prev, curr = @curr WHERE id = @id",
                             P("@c", conid), P("@d", readingdate), P("@prev", prev), P("@curr", curr), P("@id", selectedReadingID))
            If saved Then MsgBox("Reading record updated successfully!", MsgBoxStyle.Information)
        End If

        If Not saved Then Exit Sub

        adding = False
        updating = False
        selectedReadingID = -1
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

        updating = False
        disablebuttons()
        clearFields()
        pnlinput.Enabled = False
        pnlinput2.Enabled = False
        selectedConsumerID = -1
        selectedReadingID = -1
    End Sub

    Private Sub lvconsumers_DoubleClick(sender As Object, e As EventArgs) Handles lvconsumers.DoubleClick
        If lvconsumers.SelectedItems.Count = 0 Then Exit Sub

        txtconid.Text = lvconsumers.SelectedItems(0).SubItems(0).Text
        selectedConsumerID = Integer.Parse(txtconid.Text)

        GetQuery("SELECT curr, date FROM tblreadings WHERE consumerid = @c ORDER BY date DESC LIMIT 1", "last", P("@c", selectedConsumerID))

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
        If adding Or updating Or lvreadings.SelectedItems.Count = 0 Then Exit Sub

        Dim item As ListViewItem = lvreadings.SelectedItems(0)

        selectedReadingID = Integer.Parse(item.SubItems(0).Text)
        txtconid.Text = item.SubItems(6).Text
        dtpdate.Value = CDate(item.SubItems(2).Text)
        txtprev.Text = item.SubItems(3).Text
        txtcurr.Text = item.SubItems(4).Text
        txtusage.Text = item.SubItems(5).Text

        btnupdate.Enabled = True
        btndelete.Enabled = True
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

        Dim billIdValue As Object = GetValue("SELECT id FROM tblbills WHERE readingid = @r", P("@r", selectedReadingID))
        Dim billExists As Boolean = billIdValue IsNot Nothing
        Dim billID As Integer = If(billExists, CInt(billIdValue), -1)

        If billExists Then
            Dim paymentCount As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblpayments WHERE billid = @b", P("@b", billID)))

            If paymentCount > 0 Then
                If MsgBox("This reading is linked to a bill with " & paymentCount & " payment(s). Deleting it will also delete all related transactions. Continue?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirm Deletion") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If
        End If

        If MsgBox("Are you sure you want to delete this reading record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Reading") = MsgBoxResult.Yes Then
            Try
                BeginTransaction()
                If billExists Then
                    Execute("DELETE FROM tblpayments WHERE billid = @b", P("@b", billID))
                    Execute("DELETE FROM tblbills WHERE id = @b", P("@b", billID))
                End If
                Execute("DELETE FROM tblreadings WHERE id = @r", P("@r", selectedReadingID))
                CommitTransaction()
            Catch ex As Exception
                RollbackTransaction()
                MsgBox("Could not delete the reading: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

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
