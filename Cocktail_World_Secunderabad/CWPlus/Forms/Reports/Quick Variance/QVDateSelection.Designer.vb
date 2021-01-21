<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QVDateSelection
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
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QVDateSelection))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOK = New CButtonLib.CButton()
        Me.tmrButtonFocus = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MMMM/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(125, 42)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(211, 23)
        Me.DateTimePicker1.TabIndex = 4
        Me.DateTimePicker1.Value = New Date(2012, 5, 3, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(79, 45)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Font = New System.Drawing.Font("Comic Sans MS", 14.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 91)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Date To Proceed"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOK.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker1.IsActive = True
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnOK.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.4731183!, 1.0!}
        Me.btnOK.ColorFillBlend = CBlendItems1
        Me.btnOK.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnOK.Corners.All = CType(-1, Short)
        Me.btnOK.Corners.LowerLeft = CType(0, Short)
        Me.btnOK.Corners.LowerRight = CType(17, Short)
        Me.btnOK.Corners.UpperLeft = CType(0, Short)
        Me.btnOK.Corners.UpperRight = CType(17, Short)
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnOK.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnOK.FocalPoints.CenterPtX = 0.979798!
        Me.btnOK.FocalPoints.CenterPtY = 0.4864865!
        Me.btnOK.FocalPoints.FocusPtX = 0.0!
        Me.btnOK.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnOK.FocusPtTracker = DesignerRectTracker2
        Me.btnOK.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Image = Nothing
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOK.ImageIndex = 0
        Me.btnOK.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnOK.Location = New System.Drawing.Point(206, 199)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnOK.SideImage = Nothing
        Me.btnOK.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.SideImageSize = New System.Drawing.Size(48, 48)
        Me.btnOK.Size = New System.Drawing.Size(109, 36)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "Proceed >>"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnOK.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnOK.TextShadow = System.Drawing.Color.White
        Me.btnOK.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnOK.UseMnemonic = True
        '
        'tmrButtonFocus
        '
        Me.tmrButtonFocus.Enabled = True
        Me.tmrButtonFocus.Interval = 500
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CWPlus.My.Resources.Resources.variance
        Me.PictureBox1.Location = New System.Drawing.Point(78, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(364, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'QVDateSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(520, 239)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "QVDateSelection"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QVDateSelection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As CButtonLib.CButton
    Friend WithEvents tmrButtonFocus As System.Windows.Forms.Timer
       
End Class
