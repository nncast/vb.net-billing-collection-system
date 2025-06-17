Imports Microsoft.VisualBasic.PowerPacks

Module Globals
    Public shapeList As New List(Of RectangleShape)
    Public lblList As New List(Of Control)
    Public activeStateList As New List(Of Boolean)

    Public picActiveList As New List(Of PictureBox)
    Public picNotList As New List(Of PictureBox)

    Public Sub InitializeLists()
        shapeList.Clear()
        lblList.Clear()
        activeStateList.Clear()

        shapeList.Add(frmDashboard.shapedash)
        shapeList.Add(frmDashboard.shapeconsumer)
        shapeList.Add(frmDashboard.shapereadings)
        shapeList.Add(frmDashboard.shapebills)
        shapeList.Add(frmDashboard.shapepayment)
        shapeList.Add(frmDashboard.shapereports)

        lblList.Add(frmDashboard.lbldashboard)
        lblList.Add(frmDashboard.lblconsumer)
        lblList.Add(frmDashboard.lblreadings)
        lblList.Add(frmDashboard.lblbills)
        lblList.Add(frmDashboard.lblpayment)
        lblList.Add(frmDashboard.lblreport)

        For i As Integer = 0 To shapeList.Count - 1
            activeStateList.Add(False)
        Next
    End Sub

    Public Sub InitializeImageLists()
        picActiveList = New List(Of PictureBox) From {
            frmDashboard.picdashactive, frmDashboard.picconsactive, frmDashboard.picreadactive,
            frmDashboard.picbillactive, frmDashboard.picpaymentactive, frmDashboard.picreportactive
        }

        picNotList = New List(Of PictureBox) From {
            frmDashboard.picdashnot, frmDashboard.picconsnot, frmDashboard.picreadnot,
            frmDashboard.picbillnot, frmDashboard.picpaymentnot, frmDashboard.picreportnot
        }

        lblList.Add(frmDashboard.lblrate)
        activeStateList.Add(False)

    End Sub

    Public Sub SetActive(indexToActivate As Integer)
        For i As Integer = 0 To activeStateList.Count - 1
            activeStateList(i) = (i = indexToActivate)

            lblList(i).ForeColor = If(i = indexToActivate, Color.FromArgb(232, 228, 227), Color.FromArgb(48, 48, 48))
            lblList(i).BackColor = If(i = indexToActivate, Color.FromArgb(48, 48, 48), Color.FromArgb(232, 228, 227))

            If i < shapeList.Count Then
                shapeList(i).FillColor = If(i = indexToActivate, Color.FromArgb(48, 48, 48), Color.FromArgb(232, 228, 227))
                shapeList(i).BorderColor = If(i = indexToActivate, Color.Orange, Color.FromArgb(48, 48, 48))
                shapeList(i).BorderWidth = If(i = indexToActivate, 2, 1)
            End If
        Next

        For i As Integer = 0 To picActiveList.Count - 1
            If i < picActiveList.Count Then
                picActiveList(i).Visible = (i = indexToActivate)
                picNotList(i).Visible = (i <> indexToActivate)
            End If
        Next
    End Sub

End Module
