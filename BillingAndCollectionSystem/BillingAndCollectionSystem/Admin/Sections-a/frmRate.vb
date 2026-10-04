Public Class frmRate
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public rateid As Integer = Nothing

    Private Sub frmRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
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
            query &= " WHERE rate LIKE @s OR date LIKE @s"
        End If
        query &= " ORDER BY date DESC"

        GetQuery(query, "tblrates", P("@s", "%" & search & "%"))
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
        rateid = Nothing
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
        Dim rate As Decimal
        If txtrate.Text.Trim() = "" Then
            MsgBox("Rate is required!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Not Decimal.TryParse(txtrate.Text.Trim(), rate) OrElse rate <= 0 Then
            MsgBox("Rate must be a number greater than zero.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim saved As Boolean = False
        If adding Then
            If MsgBox("Add new rate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                saved = SetQuery("INSERT INTO tblrates (date, rate) VALUES (NOW(), @rate)", P("@rate", rate))
                If saved Then MsgBox("Rate added successfully!")
            End If
        ElseIf updating Then
            If MsgBox("Update this rate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                saved = SetQuery("UPDATE tblrates SET rate = @rate WHERE id = @id", P("@rate", rate), P("@id", rateid))
                If saved Then MsgBox("Rate updated successfully!")
            End If
        End If

        If Not saved Then Exit Sub

        adding = False
        updating = False
        rateid = Nothing
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

        ' Bills are priced with the newest rate, so at least one must always exist.
        If CInt(GetValue("SELECT COUNT(*) FROM tblrates")) <= 1 Then
            MsgBox("This is the only rate. Add a new rate before deleting it, because bills need a rate.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("Delete this rate?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            If SetQuery("DELETE FROM tblrates WHERE id = @id", P("@id", rateid)) Then
                MsgBox("Rate deleted successfully!")
                fill()
                clearfields()
                rateid = Nothing
                disablebuttons()
            End If
        End If
    End Sub

    Private Sub lvrate_DoubleClick(sender As Object, e As EventArgs) Handles lvrate.DoubleClick
        If adding Or updating Or lvrate.SelectedItems.Count = 0 Then Exit Sub

        Dim item = lvrate.SelectedItems(0)
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
                rateid = Nothing
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
