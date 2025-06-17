Imports Microsoft.VisualBasic.PowerPacks

Public Class frmDashboard

    Private ReadOnly timer As New Timer()

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill()
    End Sub

    Public Sub fill()
        InitializeLists()
        InitializeImageLists()

        For Each shp As Microsoft.VisualBasic.PowerPacks.RectangleShape In shapeList
            AddHandler shp.Click, AddressOf NavigationItem_Click
        Next

        For Each lbl As Control In lblList
            AddHandler lbl.Click, AddressOf NavigationItem_Click
        Next

        For Each pic As PictureBox In picActiveList
            AddHandler pic.Click, AddressOf NavigationItem_Click
        Next

        For Each pic As PictureBox In picNotList
            AddHandler pic.Click, AddressOf NavigationItem_Click
        Next

        SetActive(0)

        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()

        switchPanel(frmHome)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        UpdateDateTime()
    End Sub

    Private Sub UpdateDateTime()
        Dim currentTime As DateTime = DateTime.Now
        Dim hour As Integer = currentTime.Hour

        If hour >= 5 And hour < 12 Then
            lblgreet.Text = "Good Morning"
        ElseIf hour >= 12 And hour < 17 Then
            lblgreet.Text = "Good Afternoon"
        ElseIf hour >= 17 And hour < 22 Then
            lblgreet.Text = "Good Evening"
        Else
            lblgreet.Text = "Good Night"
        End If

        lbldate.Text = "It's " + currentTime.ToString("dddd, dd MMMM yyyy")
    End Sub

    Public Sub switchPanel(frm As Form)
        Panel2.Controls.Clear()
        frm.TopLevel = False
        Panel2.Controls.Add(frm)
        frm.Dock = DockStyle.Fill
        frm.Show()
    End Sub

    Public locationNames As New List(Of String) From {
        "Home", "Consumer", "Readings", "Bills", "Payment", "Reports", "Rate"
    }

    Private Sub NavigationItem_Click(sender As Object, e As EventArgs)
        Dim index As Integer = -1

        If TypeOf sender Is RectangleShape Then
            index = shapeList.IndexOf(DirectCast(sender, RectangleShape))

        ElseIf TypeOf sender Is Control Then
            Dim ctrl As Control = DirectCast(sender, Control)

            If lblList.Contains(ctrl) Then
                index = lblList.IndexOf(ctrl)

            ElseIf picActiveList.Contains(ctrl) Then
                index = picActiveList.IndexOf(ctrl)

            ElseIf picNotList.Contains(ctrl) Then
                index = picNotList.IndexOf(ctrl)
            End If
        End If

        If index >= 0 Then
            SetActive(index)

            Select Case index
                Case 0
                    switchPanel(frmHome)
                    frmHome.loadform()
                Case 1
                    switchPanel(frmConsumer_a)
                    frmConsumer_a.loadform()
                Case 2
                    switchPanel(frmReading)
                    frmReading.loadform()
                Case 3
                    switchPanel(frmBills)
                    frmBills.loadform()
                Case 4
                    switchPanel(frmPayments)
                    frmPayments.loadform()
                Case 5
                    switchPanel(frmReport)
                    frmReport.fill()
            End Select


            lblloc.Text = "Dashboard        /"
            lblloc2.Text = locationNames(index)
        End If
    End Sub

    Private Sub lblrate_Click(sender As Object, e As EventArgs) Handles lblrate.Click
        SetActive(lblList.IndexOf(lblrate))
        switchPanel(frmRate)
        frmRate.loadform()
    End Sub

    Private Sub RectangleShape2_Click(sender As Object, e As EventArgs) Handles RectangleShape2.Click
        If MsgBox("Are you sure you want to leave?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Leave") = MsgBoxResult.Yes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If MsgBox("Are you sure you want to leave?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Leave") = MsgBoxResult.Yes Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

End Class
