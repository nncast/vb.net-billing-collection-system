Public Class frmConsumer_a
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public consumerId As Integer = Nothing

    Private Sub frmConsumer_a_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbbilling", "3306", "root", "")
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
            query &= " WHERE id LIKE '%" & search & "%' OR " &
                     "fname LIKE '%" & search & "%' OR " &
                     "lname LIKE '%" & search & "%' OR " &
                     "phone LIKE '%" & search & "%' OR " &
                     "address LIKE '%" & search & "%'"
        End If

        GetQuery(query, "tblconsumers")

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
        If txtfname.Text.Trim() = "" Or txtlname.Text.Trim() = "" Or txtphone.Text.Trim() = "" Or txtaddress.Text.Trim() = "" Then
            MsgBox("All fields are required.", MsgBoxStyle.Critical, "Validation Error")
            Return
        End If

        If adding Then
            If MsgBox("Add new consumer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                SetQuery("INSERT INTO tblconsumers (fname, lname, phone, address) VALUES ('" &
                    txtfname.Text.Trim() & "', '" & txtlname.Text.Trim() & "', '" &
                    txtphone.Text.Trim() & "', '" & txtaddress.Text.Trim() & "')")

                MsgBox("Consumer added successfully!", MsgBoxStyle.Information, "Success")
                adding = False
            End If
        ElseIf updating Then
            If MsgBox("Update this consumer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                SetQuery("UPDATE tblconsumers SET fname = '" & txtfname.Text.Trim() & "', " &
                    "lname = '" & txtlname.Text.Trim() & "', phone = '" & txtphone.Text.Trim() & "', " &
                    "address = '" & txtaddress.Text.Trim() & "' WHERE id = " & consumerId)

                MsgBox("Consumer updated successfully!", MsgBoxStyle.Information, "Success")
                updating = False
            End If
        End If

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
            SetQuery("DELETE FROM tblconsumers WHERE id = " & consumerId)
            fill()
            clearfields()
            MsgBox("Consumer and all related data deleted successfully!", MsgBoxStyle.Information, "Success")
        End If
    End Sub

    Private Sub lvconsumer_DoubleClick(sender As Object, e As EventArgs) Handles lvconsumer.DoubleClick
        consumerId = CInt(lvconsumer.FocusedItem.SubItems(0).Text)
        GetQuery("SELECT * FROM tblconsumers WHERE id = " & consumerId, "tblconsumers")

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
