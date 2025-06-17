Public Class frmRate
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public rateid As Integer = Nothing

    Private Sub frmRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")
        loadform()
    End Sub

    Public Sub loadform()
        btnnew.Enabled = True
        btnsave.Enabled = False
        pnlinput.Enabled = False

        fill()
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT id, date, rate FROM tblrates"
        If search <> "" Then
            query &= " WHERE rate LIKE '%" & search & "%' OR date LIKE '%" & search & "%'"
        End If
        query &= " ORDER BY date DESC"

        GetQuery(query, "tblrates")
        lvrate.Items.Clear()

        For Each r As DataRow In ds.Tables("tblrates").Rows
            With lvrate.Items.Add(r("id").ToString())
                .SubItems.Add(CDate(r("date")).ToShortDateString())
                .SubItems.Add(Format(CDec(r("rate")), "N2"))
            End With
        Next
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearfields()
        adding = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If rateid = Nothing Then
            MsgBox("Select a rate to update.", MsgBoxStyle.Information)
            Exit Sub
        End If
        enablebuttons()
        updating = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtrate.Text.Trim() = "" Then
            MsgBox("Rate is required!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If adding Then
            If MsgBox("Add new rate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                SetQuery("INSERT INTO tblrates (date, rate) VALUES (NOW(), " & txtrate.Text.Trim() & ")")
                MsgBox("Rate added successfully!")
                adding = False
            End If
        ElseIf updating Then
            If MsgBox("Update this rate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                SetQuery("UPDATE tblrates SET rate = " & txtrate.Text.Trim() & " WHERE id = " & rateid)
                MsgBox("Rate updated successfully!")
                updating = False
            End If
        End If

        fill()
        clearfields()
        disablebuttons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If rateid = Nothing Then
            MsgBox("Select a rate to delete.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Delete this rate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            SetQuery("DELETE FROM tblrates WHERE id = " & rateid)
            MsgBox("Rate deleted successfully!")
            fill()
            clearfields()
            rateid = Nothing
        End If
    End Sub

    Private Sub lvrate_DoubleClick(sender As Object, e As EventArgs) Handles lvrate.DoubleClick
        If lvrate.SelectedItems.Count = 0 Then Exit Sub

        Dim item = lvrate.FocusedItem
        rateid = CInt(item.SubItems(0).Text)
        txtrate.Text = item.SubItems(2).Text

        btnupdate.Enabled = True
        btndelete.Enabled = True
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Or updating Then
            If MsgBox("Cancel current operation?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                adding = False
                updating = False
                clearfields()
                disablebuttons()
                pnlinput.Enabled = False
            End If
        End If
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
        btnupdate.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = False
        btnsave.Enabled = False
    End Sub

    Public Sub clearfields()
        txtrate.Clear()
    End Sub
End Class
