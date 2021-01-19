<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splashscreen
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
        Me.components = New System.ComponentModel.Container()
        Dim CBlendItems3 As ProgBar.cBlendItems = New ProgBar.cBlendItems()
        Dim CFocalPoints3 As ProgBar.cFocalPoints = New ProgBar.cFocalPoints()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Splashscreen))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgBarPlus1 = New ProgBar.ProgBarPlus()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.CWPlus.My.Resources.Resources.cocktail
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ProgBarPlus1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(15, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 308)
        Me.Panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 28)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "© 2012 Compel Consultancy." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "All rights reserved."
        '
        'ProgBarPlus1
        '
        Me.ProgBarPlus1.BarBackColor = System.Drawing.Color.Black
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(60, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.3579336!, 0.6826568!, 1.0!}
        Me.ProgBarPlus1.BarColorBlend = CBlendItems3
        Me.ProgBarPlus1.BarColorSolid = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgBarPlus1.BarColorSolidB = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ProgBarPlus1.BarLength = ProgBar.ProgBarPlus.eBarLength.Full
        Me.ProgBarPlus1.BarLengthValue = CType(25, Short)
        Me.ProgBarPlus1.BarPadding = New System.Windows.Forms.Padding(0)
        Me.ProgBarPlus1.BarStyleFill = ProgBar.ProgBarPlus.eBarStyle.GradientLinear
        Me.ProgBarPlus1.BarStyleHatch = System.Drawing.Drawing2D.HatchStyle.NarrowHorizontal
        Me.ProgBarPlus1.BarStyleLinear = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.ProgBarPlus1.BarStyleTexture = Nothing
        Me.ProgBarPlus1.BarStyleWrapMode = System.Drawing.Drawing2D.WrapMode.Clamp
        Me.ProgBarPlus1.BarType = ProgBar.ProgBarPlus.eBarType.Bar
        Me.ProgBarPlus1.BorderWidth = CType(1, Short)
        Me.ProgBarPlus1.Corners.All = CType(0, Short)
        Me.ProgBarPlus1.Corners.LowerLeft = CType(0, Short)
        Me.ProgBarPlus1.Corners.LowerRight = CType(0, Short)
        Me.ProgBarPlus1.Corners.UpperLeft = CType(0, Short)
        Me.ProgBarPlus1.Corners.UpperRight = CType(0, Short)
        Me.ProgBarPlus1.CornersApply = ProgBar.ProgBarPlus.eCornersApply.Both
        Me.ProgBarPlus1.CylonInterval = CType(1, Short)
        Me.ProgBarPlus1.CylonMove = 5.0!
        Me.ProgBarPlus1.FillDirection = ProgBar.ProgBarPlus.eFillDirection.Up_Right
        CFocalPoints3.CenterPoint = CType(resources.GetObject("CFocalPoints3.CenterPoint"), System.Drawing.PointF)
        CFocalPoints3.FocusScales = CType(resources.GetObject("CFocalPoints3.FocusScales"), System.Drawing.PointF)
        Me.ProgBarPlus1.FocalPoints = CFocalPoints3
        Me.ProgBarPlus1.Location = New System.Drawing.Point(214, 184)
        Me.ProgBarPlus1.Name = "ProgBarPlus1"
        Me.ProgBarPlus1.Orientation = ProgBar.ProgBarPlus.eOrientation.Vertical
        Me.ProgBarPlus1.Shape = ProgBar.ProgBarPlus.eShape.Text
        Me.ProgBarPlus1.ShapeText = "Cocktail World 4.0"
        Me.ProgBarPlus1.ShapeTextFont = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgBarPlus1.ShapeTextRotate = ProgBar.ProgBarPlus.eRotateText.None
        Me.ProgBarPlus1.Size = New System.Drawing.Size(384, 34)
        Me.ProgBarPlus1.TabIndex = 6
        Me.ProgBarPlus1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.ProgBarPlus1.TextAlignmentVert = System.Drawing.StringAlignment.Center
        Me.ProgBarPlus1.TextFormat = "Process {1}% Done"
        Me.ProgBarPlus1.TextPlacement = ProgBar.ProgBarPlus.eTextPlacement.OverBar
        Me.ProgBarPlus1.TextRotate = ProgBar.ProgBarPlus.eRotateText.None
        Me.ProgBarPlus1.TextShadow = True
        Me.ProgBarPlus1.TextShadowColor = System.Drawing.Color.Black
        Me.ProgBarPlus1.TextShow = ProgBar.ProgBarPlus.eTextShow.None
        Me.ProgBarPlus1.Value = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(224, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'Splashscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(656, 330)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Splashscreen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ProgBarPlus1 As ProgBar.ProgBarPlus
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class
