<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayments
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lvpayments = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.rec = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlinput2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lvbills = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtsearchbill = New System.Windows.Forms.TextBox()
        Me.pnlinput = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblremaining = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.txtbillid = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlinput2.SuspendLayout()
        Me.pnlinput.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lvpayments)
        Me.Panel4.Controls.Add(Me.ShapeContainer2)
        Me.Panel4.Location = New System.Drawing.Point(1, 357)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1115, 244)
        Me.Panel4.TabIndex = 11
        '
        'lvpayments
        '
        Me.lvpayments.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lvpayments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvpayments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader4, Me.ColumnHeader6, Me.ColumnHeader1, Me.ColumnHeader10})
        Me.lvpayments.FullRowSelect = True
        Me.lvpayments.GridLines = True
        Me.lvpayments.Location = New System.Drawing.Point(26, 20)
        Me.lvpayments.Name = "lvpayments"
        Me.lvpayments.Size = New System.Drawing.Size(1065, 198)
        Me.lvpayments.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvpayments.TabIndex = 1
        Me.lvpayments.UseCompatibleStateImageBehavior = False
        Me.lvpayments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ID"
        Me.ColumnHeader3.Width = 40
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "BillID"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Consumer"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Date"
        Me.ColumnHeader6.Width = 200
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Amount"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Balance"
        Me.ColumnHeader10.Width = 200
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.rec})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1115, 244)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'rec
        '
        Me.rec.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.rec.BorderWidth = 3
        Me.rec.CornerRadius = 20
        Me.rec.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.rec.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rec.Location = New System.Drawing.Point(5, 5)
        Me.rec.Name = "rec"
        Me.rec.SelectionColor = System.Drawing.Color.Orange
        Me.rec.Size = New System.Drawing.Size(1103, 227)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlinput2)
        Me.Panel1.Controls.Add(Me.pnlinput)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1115, 296)
        Me.Panel1.TabIndex = 2
        '
        'pnlinput2
        '
        Me.pnlinput2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.pnlinput2.Controls.Add(Me.Label8)
        Me.pnlinput2.Controls.Add(Me.Label6)
        Me.pnlinput2.Controls.Add(Me.lvbills)
        Me.pnlinput2.Controls.Add(Me.txtsearchbill)
        Me.pnlinput2.Location = New System.Drawing.Point(12, 17)
        Me.pnlinput2.Name = "pnlinput2"
        Me.pnlinput2.Size = New System.Drawing.Size(431, 255)
        Me.pnlinput2.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Candara", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label8.Location = New System.Drawing.Point(4, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 29)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Pending Bills"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(158, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 24)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Search :"
        '
        'lvbills
        '
        Me.lvbills.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lvbills.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvbills.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvbills.FullRowSelect = True
        Me.lvbills.Location = New System.Drawing.Point(9, 45)
        Me.lvbills.Name = "lvbills"
        Me.lvbills.Size = New System.Drawing.Size(411, 210)
        Me.lvbills.TabIndex = 6
        Me.lvbills.UseCompatibleStateImageBehavior = False
        Me.lvbills.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID"
        Me.ColumnHeader2.Width = 40
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Due Date"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Amount"
        Me.ColumnHeader9.Width = 100
        '
        'txtsearchbill
        '
        Me.txtsearchbill.Location = New System.Drawing.Point(238, 7)
        Me.txtsearchbill.Name = "txtsearchbill"
        Me.txtsearchbill.Size = New System.Drawing.Size(182, 32)
        Me.txtsearchbill.TabIndex = 14
        '
        'pnlinput
        '
        Me.pnlinput.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.pnlinput.Controls.Add(Me.Label4)
        Me.pnlinput.Controls.Add(Me.lblremaining)
        Me.pnlinput.Controls.Add(Me.Label3)
        Me.pnlinput.Controls.Add(Me.Label2)
        Me.pnlinput.Controls.Add(Me.Label1)
        Me.pnlinput.Controls.Add(Me.txtamount)
        Me.pnlinput.Controls.Add(Me.dtpdate)
        Me.pnlinput.Controls.Add(Me.txtbillid)
        Me.pnlinput.Location = New System.Drawing.Point(489, 17)
        Me.pnlinput.Name = "pnlinput"
        Me.pnlinput.Size = New System.Drawing.Size(602, 255)
        Me.pnlinput.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(315, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Balance :"
        '
        'lblremaining
        '
        Me.lblremaining.AutoSize = True
        Me.lblremaining.Font = New System.Drawing.Font("Candara", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblremaining.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblremaining.Location = New System.Drawing.Point(407, 36)
        Me.lblremaining.Name = "lblremaining"
        Me.lblremaining.Size = New System.Drawing.Size(140, 29)
        Me.lblremaining.TabIndex = 9
        Me.lblremaining.Text = "lblremaining"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Amount :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Date :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Bill ID :"
        '
        'txtamount
        '
        Me.txtamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtamount.Location = New System.Drawing.Point(32, 190)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(160, 32)
        Me.txtamount.TabIndex = 2
        '
        'dtpdate
        '
        Me.dtpdate.Location = New System.Drawing.Point(31, 111)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(344, 32)
        Me.dtpdate.TabIndex = 1
        '
        'txtbillid
        '
        Me.txtbillid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbillid.Location = New System.Drawing.Point(31, 40)
        Me.txtbillid.Name = "txtbillid"
        Me.txtbillid.Size = New System.Drawing.Size(100, 32)
        Me.txtbillid.TabIndex = 0
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1115, 296)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape2.BorderWidth = 3
        Me.RectangleShape2.CornerRadius = 20
        Me.RectangleShape2.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(5, 4)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape2.Size = New System.Drawing.Size(452, 287)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape1.BorderWidth = 3
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(466, 3)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape1.Size = New System.Drawing.Size(642, 287)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnsave)
        Me.Panel3.Controls.Add(Me.btncancel)
        Me.Panel3.Controls.Add(Me.btndelete)
        Me.Panel3.Controls.Add(Me.btnupdate)
        Me.Panel3.Controls.Add(Me.btnnew)
        Me.Panel3.Location = New System.Drawing.Point(417, 303)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(698, 41)
        Me.Panel3.TabIndex = 17
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.Orange
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Location = New System.Drawing.Point(564, 1)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(131, 38)
        Me.btnsave.TabIndex = 4
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.Orange
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Location = New System.Drawing.Point(427, 1)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(131, 38)
        Me.btncancel.TabIndex = 3
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.Orange
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.Location = New System.Drawing.Point(277, 1)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(131, 38)
        Me.btndelete.TabIndex = 2
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.Orange
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.Location = New System.Drawing.Point(140, 1)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(131, 38)
        Me.btnupdate.TabIndex = 1
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'btnnew
        '
        Me.btnnew.BackColor = System.Drawing.Color.Orange
        Me.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnew.Location = New System.Drawing.Point(3, 1)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(131, 38)
        Me.btnnew.TabIndex = 0
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 311)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 24)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Search :"
        '
        'txtsearch
        '
        Me.txtsearch.Location = New System.Drawing.Point(105, 309)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(233, 32)
        Me.txtsearch.TabIndex = 14
        '
        'frmPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1116, 600)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPayments"
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlinput2.ResumeLayout(False)
        Me.pnlinput2.PerformLayout()
        Me.pnlinput.ResumeLayout(False)
        Me.pnlinput.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lvpayments As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents rec As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlinput2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvbills As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtsearchbill As System.Windows.Forms.TextBox
    Friend WithEvents pnlinput As System.Windows.Forms.Panel
    Friend WithEvents lblremaining As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtbillid As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
