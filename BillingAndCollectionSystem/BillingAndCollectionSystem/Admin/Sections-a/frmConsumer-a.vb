Public Class frmConsumer_a
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public consumerId As Integer = Nothing

    Private Sub frmConsumer_a_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        loadform()
    End Sub

    Public Sub loadform()
        btnnew.Enabled = True
        btnsave.Enabled = False
        pnlinput.Enabled = False
        fill()
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT * FROM tblconsumers"

        If search <> "" Then
            query &= " WHERE id LIKE @s OR fname LIKE @s OR lname LIKE @s OR phone LIKE @s OR address LIKE @s"
        End If

        GetQuery(query, "tblconsumers", P("@s", "%" & search & "%"))

        lvconsumer.Items.Clear()

        If ds.Tables("tblconsumers").Rows.Count > 0 Then
            For Each row As DataRow In ds.Tables("tblconsumers").Rows
                With lvconsumer.Items.Add(row("id").ToString())
                    .SubItems.Add(row("fname").ToString())
                    .SubItems.Add(row("lname").ToString())
                    .SubItems.Add(row("phone").ToString())
                    .SubItems.Add(row("address").ToString())
                End With
            Next
        End If
    End Sub

    Public Sub clearfields()
        txtfname.Clear()
        txtlname.Clear()
        txtphone.Clear()
        txtaddress.Clear()
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearfields()
        consumerId = Nothing
        adding = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If consumerId = Nothing Then
            MsgBox("Select a consumer to update.", MsgBoxStyle.Information, "No Selection")
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' The phone box is masked, so an empty one still contains its "-" literals.
        If txtfname.Text.Trim() = "" Or txtlname.Text.Trim() = "" Or Not txtphone.MaskCompleted Or txtaddress.Text.Trim() = "" Then
            MsgBox("All fields are required.", MsgBoxStyle.Critical, "Validation Error")
            Return
        End If

        Dim saved As Boolean = False

        If adding Then
            If MsgBox("Add new consumer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                saved = SetQuery("INSERT INTO tblconsumers (fname, lname, phone, address) VALUES (@fname, @lname, @phone, @address)",
                                 P("@fname", txtfname.Text.Trim()), P("@lname", txtlname.Text.Trim()),
                                 P("@phone", txtphone.Text.Trim()), P("@address", txtaddress.Text.Trim()))
                If saved Then MsgBox("Consumer added successfully!", MsgBoxStyle.Information, "Success")
            End If
        ElseIf updating Then
            If MsgBox("Update this consumer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                saved = SetQuery("UPDATE tblconsumers SET fname = @fname, lname = @lname, phone = @phone, address = @address WHERE id = @id",
                                 P("@fname", txtfname.Text.Trim()), P("@lname", txtlname.Text.Trim()),
                                 P("@phone", txtphone.Text.Trim()), P("@address", txtaddress.Text.Trim()), P("@id", consumerId))
                If saved Then MsgBox("Consumer updated successfully!", MsgBoxStyle.Information, "Success")
            End If
        End If

        If Not saved Then Exit Sub

        adding = False
        updating = False
        consumerId = Nothing
        fill()
        clearfields()
        disablebuttons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If consumerId = Nothing Then
            MsgBox("Select a consumer to delete.", MsgBoxStyle.Information, "No Selection")
            Exit Sub
        End If

        If MsgBox("Delete this consumer and all related data?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
            ' Readings, bills and payments are removed by the ON DELETE CASCADE foreign keys.
            If SetQuery("DELETE FROM tblconsumers WHERE id = @id", P("@id", consumerId)) Then
                consumerId = Nothing
                fill()
                clearfields()
                MsgBox("Consumer and all related data deleted successfully!", MsgBoxStyle.Information, "Success")
            End If
        End If
    End Sub

    Private Sub lvconsumer_DoubleClick(sender As Object, e As EventArgs) Handles lvconsumer.DoubleClick
        If adding Or updating Or lvconsumer.SelectedItems.Count = 0 Then Exit Sub

        consumerId = CInt(lvconsumer.SelectedItems(0).SubItems(0).Text)
        GetQuery("SELECT * FROM tblconsumers WHERE id = @id", "tblconsumers", P("@id", consumerId))

        If ds.Tables("tblconsumers").Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables("tblconsumers").Rows(0)
            txtfname.Text = row("fname").ToString()
            txtlname.Text = row("lname").ToString()
            txtphone.Text = row("phone").ToString()
            txtaddress.Text = row("address").ToString()
        End If

        btnupdate.Enabled = True
        btndelete.Enabled = True
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Cancel adding?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Cancel updating?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If

        consumerId = Nothing
        disablebuttons()
        clearfields()
        pnlinput.Enabled = False
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
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
End Class
