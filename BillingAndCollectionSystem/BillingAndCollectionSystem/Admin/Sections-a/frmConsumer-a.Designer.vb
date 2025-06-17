<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsumer_a
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlinput = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtaddress = New System.Windows.Forms.TextBox()
        Me.txtphone = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lvconsumer = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.rec = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlinput.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlinput)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1115, 296)
        Me.Panel1.TabIndex = 0
        '
        'pnlinput
        '
        Me.pnlinput.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.pnlinput.Controls.Add(Me.Label4)
        Me.pnlinput.Controls.Add(Me.Label3)
        Me.pnlinput.Controls.Add(Me.txtaddress)
        Me.pnlinput.Controls.Add(Me.txtphone)
        Me.pnlinput.Controls.Add(Me.Label2)
        Me.pnlinput.Controls.Add(Me.txtlname)
        Me.pnlinput.Controls.Add(Me.Label1)
        Me.pnlinput.Controls.Add(Me.txtfname)
        Me.pnlinput.Location = New System.Drawing.Point(26, 17)
        Me.pnlinput.Name = "pnlinput"
        Me.pnlinput.Size = New System.Drawing.Size(1065, 255)
        Me.pnlinput.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(679, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Address : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(97, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 24)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Phone Number :"
        '
        'txtaddress
        '
        Me.txtaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtaddress.Location = New System.Drawing.Point(683, 69)
        Me.txtaddress.Multiline = True
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Size = New System.Drawing.Size(291, 109)
        Me.txtaddress.TabIndex = 8
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Location = New System.Drawing.Point(101, 146)
        Me.txtphone.Mask = "0000-000-0000"
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(142, 32)
        Me.txtphone.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(390, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Last Name : "
        '
        'txtlname
        '
        Me.txtlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlname.Location = New System.Drawing.Point(394, 69)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(233, 32)
        Me.txtlname.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "First Name :"
        '
        'txtfname
        '
        Me.txtfname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfname.Location = New System.Drawing.Point(101, 69)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(233, 32)
        Me.txtfname.TabIndex = 1
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1115, 296)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape1.BorderWidth = 3
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(5, 3)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape1.Size = New System.Drawing.Size(1103, 287)
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
        Me.Panel3.TabIndex = 1
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
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lvconsumer)
        Me.Panel4.Controls.Add(Me.ShapeContainer2)
        Me.Panel4.Location = New System.Drawing.Point(0, 358)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1115, 244)
        Me.Panel4.TabIndex = 3
        '
        'lvconsumer
        '
        Me.lvconsumer.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lvconsumer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvconsumer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvconsumer.FullRowSelect = True
        Me.lvconsumer.GridLines = True
        Me.lvconsumer.Location = New System.Drawing.Point(26, 20)
        Me.lvconsumer.Name = "lvconsumer"
        Me.lvconsumer.Size = New System.Drawing.Size(1065, 198)
        Me.lvconsumer.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvconsumer.TabIndex = 1
        Me.lvconsumer.UseCompatibleStateImageBehavior = False
        Me.lvconsumer.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "First Name"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Last Name"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Phone Number"
        Me.ColumnHeader4.Width = 130
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Address"
        Me.ColumnHeader5.Width = 200
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
        'txtsearch
        '
        Me.txtsearch.Location = New System.Drawing.Point(94, 309)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(233, 32)
        Me.txtsearch.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 311)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 24)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Search :"
        '
        'frmConsumer_a
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1116, 600)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmConsumer_a"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConsumer_a"
        Me.Panel1.ResumeLayout(False)
        Me.pnlinput.ResumeLayout(False)
        Me.pnlinput.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents txtfname As System.Windows.Forms.TextBox
    Friend WithEvents pnlinput As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtaddress As System.Windows.Forms.TextBox
    Friend WithEvents txtphone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtlname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lvconsumer As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents rec As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
