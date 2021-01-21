<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DesignerRectTracker3 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports))
        Dim CBlendItems2 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker4 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CButton2 = New CButtonLib.CButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.CWPlus.My.Resources.Resources.Picture1
        Me.PictureBox1.Location = New System.Drawing.Point(142, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(310, 245)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(136, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Quick Excise Done"
        '
        'CButton2
        '
        Me.CButton2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CButton2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DesignerRectTracker3.IsActive = False
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.CButton2.CenterPtTracker = DesignerRectTracker3
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(210, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(179, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.5412186!, 1.0!}
        Me.CButton2.ColorFillBlend = CBlendItems2
        Me.CButton2.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.CButton2.Corners.All = CType(16, Short)
        Me.CButton2.Corners.LowerLeft = CType(16, Short)
        Me.CButton2.Corners.LowerRight = CType(16, Short)
        Me.CButton2.Corners.UpperLeft = CType(16, Short)
        Me.CButton2.Corners.UpperRight = CType(16, Short)
        Me.CButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CButton2.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.CButton2.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.CButton2.FocalPoints.CenterPtX = 0.979798!
        Me.CButton2.FocalPoints.CenterPtY = 0.4864865!
        Me.CButton2.FocalPoints.FocusPtX = 0.0!
        Me.CButton2.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.CButton2.FocusPtTracker = DesignerRectTracker4
        Me.CButton2.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CButton2.ForeColor = System.Drawing.Color.Black
        Me.CButton2.Image = Nothing
        Me.CButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CButton2.ImageIndex = 0
        Me.CButton2.ImageSize = New System.Drawing.Size(16, 16)
        Me.CButton2.Location = New System.Drawing.Point(142, 289)
        Me.CButton2.Name = "CButton2"
        Me.CButton2.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.CButton2.SideImage = Nothing
        Me.CButton2.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CButton2.SideImageSize = New System.Drawing.Size(48, 48)
        Me.CButton2.Size = New System.Drawing.Size(182, 43)
        Me.CButton2.TabIndex = 5
        Me.CButton2.Text = "Generate Report"
        Me.CButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.CButton2.TextMargin = New System.Windows.Forms.Padding(2)
        Me.CButton2.TextShadow = System.Drawing.Color.White
        Me.CButton2.TextShadowShow = False
        Me.CButton2.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.CButton2.UseMnemonic = True
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.CButton2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Reports"
        Me.Size = New System.Drawing.Size(589, 378)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CButton2 As CButtonLib.CButton

End Class
