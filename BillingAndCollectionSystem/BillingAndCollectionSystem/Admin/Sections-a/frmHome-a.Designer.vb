<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbltotalcustomers = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.rec = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblunpaidbills = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblcollected = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ShapeContainer4 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lv1 = New System.Windows.Forms.ListView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ShapeContainer5 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.piccons = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(371, 177)
        Me.Panel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Panel4.Controls.Add(Me.piccons)
        Me.Panel4.Controls.Add(Me.lbltotalcustomers)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(20, 15)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(329, 142)
        Me.Panel4.TabIndex = 4
        '
        'lbltotalcustomers
        '
        Me.lbltotalcustomers.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalcustomers.Font = New System.Drawing.Font("Century Gothic", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalcustomers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.lbltotalcustomers.Location = New System.Drawing.Point(41, 49)
        Me.lbltotalcustomers.Name = "lbltotalcustomers"
        Me.lbltotalcustomers.Size = New System.Drawing.Size(165, 62)
        Me.lbltotalcustomers.TabIndex = 2
        Me.lbltotalcustomers.Text = "00"
        Me.lbltotalcustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 38)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Consumers"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.rec})
        Me.ShapeContainer1.Size = New System.Drawing.Size(371, 177)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'rec
        '
        Me.rec.BorderColor = System.Drawing.Color.Black
        Me.rec.BorderWidth = 3
        Me.rec.CornerRadius = 20
        Me.rec.FillColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.rec.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rec.Location = New System.Drawing.Point(4, 6)
        Me.rec.Name = "rec"
        Me.rec.SelectionColor = System.Drawing.Color.Orange
        Me.rec.Size = New System.Drawing.Size(359, 165)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Location = New System.Drawing.Point(374, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(371, 177)
        Me.Panel2.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.lblunpaidbills)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(20, 15)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(329, 142)
        Me.Panel5.TabIndex = 6
        '
        'lblunpaidbills
        '
        Me.lblunpaidbills.BackColor = System.Drawing.Color.Transparent
        Me.lblunpaidbills.Font = New System.Drawing.Font("Century Gothic", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblunpaidbills.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lblunpaidbills.Location = New System.Drawing.Point(41, 49)
        Me.lblunpaidbills.Name = "lblunpaidbills"
        Me.lblunpaidbills.Size = New System.Drawing.Size(165, 62)
        Me.lblunpaidbills.TabIndex = 2
        Me.lblunpaidbills.Text = "00"
        Me.lblunpaidbills.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 38)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Unpaid Bills"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(371, 177)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape1.BorderWidth = 3
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(4, 6)
        Me.RectangleShape1.Name = "rec"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape1.Size = New System.Drawing.Size(359, 165)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.ShapeContainer3)
        Me.Panel3.Location = New System.Drawing.Point(748, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(371, 177)
        Me.Panel3.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Panel6.Controls.Add(Me.PictureBox2)
        Me.Panel6.Controls.Add(Me.lblcollected)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Location = New System.Drawing.Point(20, 15)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(329, 142)
        Me.Panel6.TabIndex = 7
        '
        'lblcollected
        '
        Me.lblcollected.BackColor = System.Drawing.Color.Transparent
        Me.lblcollected.Font = New System.Drawing.Font("Century Gothic", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcollected.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lblcollected.Location = New System.Drawing.Point(41, 49)
        Me.lblcollected.Name = "lblcollected"
        Me.lblcollected.Size = New System.Drawing.Size(216, 62)
        Me.lblcollected.TabIndex = 2
        Me.lblcollected.Text = "00"
        Me.lblcollected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 38)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Monthly Collection"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer3.Size = New System.Drawing.Size(371, 177)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape2.BorderWidth = 3
        Me.RectangleShape2.CornerRadius = 20
        Me.RectangleShape2.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(4, 6)
        Me.RectangleShape2.Name = "rec"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape2.Size = New System.Drawing.Size(359, 165)
        '
        'chart1
        '
        Me.chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.chart1.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        ChartArea1.Name = "ChartArea1"
        Me.chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chart1.Legends.Add(Legend1)
        Me.chart1.Location = New System.Drawing.Point(20, 15)
        Me.chart1.Name = "chart1"
        Me.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chart1.Series.Add(Series1)
        Me.chart1.Size = New System.Drawing.Size(537, 380)
        Me.chart1.TabIndex = 4
        Me.chart1.Text = "Collection"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.chart1)
        Me.Panel7.Controls.Add(Me.ShapeContainer4)
        Me.Panel7.Location = New System.Drawing.Point(0, 180)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(587, 420)
        Me.Panel7.TabIndex = 7
        '
        'ShapeContainer4
        '
        Me.ShapeContainer4.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer4.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer4.Name = "ShapeContainer4"
        Me.ShapeContainer4.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3})
        Me.ShapeContainer4.Size = New System.Drawing.Size(587, 420)
        Me.ShapeContainer4.TabIndex = 0
        Me.ShapeContainer4.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape3.BorderWidth = 3
        Me.RectangleShape3.CornerRadius = 20
        Me.RectangleShape3.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(4, 6)
        Me.RectangleShape3.Name = "rec"
        Me.RectangleShape3.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape3.Size = New System.Drawing.Size(574, 407)
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lv1)
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Controls.Add(Me.ShapeContainer5)
        Me.Panel8.Location = New System.Drawing.Point(593, 180)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(526, 420)
        Me.Panel8.TabIndex = 8
        '
        'lv1
        '
        Me.lv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lv1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lv1.FullRowSelect = True
        Me.lv1.Location = New System.Drawing.Point(19, 49)
        Me.lv1.Name = "lv1"
        Me.lv1.Size = New System.Drawing.Size(484, 346)
        Me.lv1.TabIndex = 18
        Me.lv1.UseCompatibleStateImageBehavior = False
        Me.lv1.View = System.Windows.Forms.View.Details
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Candara", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label8.Location = New System.Drawing.Point(28, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(230, 29)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Recent Transactions :"
        '
        'ShapeContainer5
        '
        Me.ShapeContainer5.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer5.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer5.Name = "ShapeContainer5"
        Me.ShapeContainer5.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape4})
        Me.ShapeContainer5.Size = New System.Drawing.Size(526, 420)
        Me.ShapeContainer5.TabIndex = 0
        Me.ShapeContainer5.TabStop = False
        '
        'RectangleShape4
        '
        Me.RectangleShape4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RectangleShape4.BorderWidth = 3
        Me.RectangleShape4.CornerRadius = 20
        Me.RectangleShape4.FillColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.RectangleShape4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape4.Location = New System.Drawing.Point(4, 6)
        Me.RectangleShape4.Name = "rec"
        Me.RectangleShape4.SelectionColor = System.Drawing.Color.Orange
        Me.RectangleShape4.Size = New System.Drawing.Size(512, 407)
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(263, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(63, 113)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(263, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 113)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'piccons
        '
        Me.piccons.BackColor = System.Drawing.Color.Transparent
        Me.piccons.Image = CType(resources.GetObject("piccons.Image"), System.Drawing.Image)
        Me.piccons.Location = New System.Drawing.Point(263, 26)
        Me.piccons.Name = "piccons"
        Me.piccons.Size = New System.Drawing.Size(63, 113)
        Me.piccons.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.piccons.TabIndex = 5
        Me.piccons.TabStop = False
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1116, 600)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHome"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents rec As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltotalcustomers As System.Windows.Forms.Label
    Friend WithEvents piccons As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblunpaidbills As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblcollected As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer4 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer5 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape4 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lv1 As System.Windows.Forms.ListView
End Class
