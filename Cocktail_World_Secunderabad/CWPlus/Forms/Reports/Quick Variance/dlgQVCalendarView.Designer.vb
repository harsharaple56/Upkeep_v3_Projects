<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgQVCalendarView
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
        Dim CalendarHighlightRange1 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange2 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange3 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange4 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim CalendarHighlightRange5 As System.Windows.Forms.Calendar.CalendarHighlightRange = New System.Windows.Forms.Calendar.CalendarHighlightRange()
        Dim DesignerRectTracker1 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgQVCalendarView))
        Dim CBlendItems1 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker2 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker3 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems2 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker4 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker5 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems3 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker6 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim DesignerRectTracker7 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Dim CBlendItems4 As CButtonLib.cBlendItems = New CButtonLib.cBlendItems()
        Dim DesignerRectTracker8 As CButtonLib.DesignerRectTracker = New CButtonLib.DesignerRectTracker()
        Me.Calendar1 = New System.Windows.Forms.Calendar.Calendar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmbLicense = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.btnPrevyr = New CButtonLib.CButton()
        Me.btnNextyr = New CButtonLib.CButton()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.btnPrev = New CButtonLib.CButton()
        Me.btnNext = New CButtonLib.CButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Calendar1
        '
        Me.Calendar1.AllowItemEdit = False
        Me.Calendar1.AllowNew = False
        Me.Calendar1.AutoScroll = True
        Me.Calendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Calendar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        CalendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday
        CalendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday
        CalendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday
        CalendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday
        CalendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00")
        CalendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday
        CalendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00")
        CalendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00")
        Me.Calendar1.HighlightRanges = New System.Windows.Forms.Calendar.CalendarHighlightRange() {CalendarHighlightRange1, CalendarHighlightRange2, CalendarHighlightRange3, CalendarHighlightRange4, CalendarHighlightRange5}
        Me.Calendar1.Location = New System.Drawing.Point(0, 0)
        Me.Calendar1.Name = "Calendar1"
        Me.Calendar1.Size = New System.Drawing.Size(926, 429)
        Me.Calendar1.TabIndex = 0
        Me.Calendar1.Text = "Calendar1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbLicense)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtYear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPrevyr)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNextyr)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMonth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPrev)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNext)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Calendar1)
        Me.SplitContainer1.Size = New System.Drawing.Size(926, 543)
        Me.SplitContainer1.SplitterDistance = 110
        Me.SplitContainer1.TabIndex = 1
        '
        'cmbLicense
        '
        Me.cmbLicense.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbLicense.BackColor = System.Drawing.Color.Bisque
        Me.cmbLicense.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLicense.FormattingEnabled = True
        Me.cmbLicense.Items.AddRange(New Object() {"License 1", "License 2", "License 3", "License 4", "License 5", "License 6"})
        Me.cmbLicense.Location = New System.Drawing.Point(562, 21)
        Me.cmbLicense.Name = "cmbLicense"
        Me.cmbLicense.Size = New System.Drawing.Size(353, 26)
        Me.cmbLicense.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Panel1.Location = New System.Drawing.Point(12, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 35)
        Me.Panel1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(296, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Expected Schedule"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(261, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 20)
        Me.Label6.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(174, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Quick Controls"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(139, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 20)
        Me.Label4.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Quick Variances"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 20)
        Me.Label1.TabIndex = 0
        '
        'txtYear
        '
        Me.txtYear.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtYear.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtYear.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.txtYear.Location = New System.Drawing.Point(352, 17)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(145, 31)
        Me.txtYear.TabIndex = 11
        Me.txtYear.Tag = "1"
        Me.txtYear.Text = "2012"
        Me.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPrevyr
        '
        Me.btnPrevyr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrevyr.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnPrevyr.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.2544803!, 0.6953405!, 1.0!}
        Me.btnPrevyr.ColorFillBlend = CBlendItems1
        Me.btnPrevyr.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnPrevyr.Corners.All = CType(-1, Short)
        Me.btnPrevyr.Corners.LowerLeft = CType(21, Short)
        Me.btnPrevyr.Corners.LowerRight = CType(0, Short)
        Me.btnPrevyr.Corners.UpperLeft = CType(21, Short)
        Me.btnPrevyr.Corners.UpperRight = CType(0, Short)
        Me.btnPrevyr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrevyr.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnPrevyr.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnPrevyr.FocalPoints.CenterPtX = 0.979798!
        Me.btnPrevyr.FocalPoints.CenterPtY = 0.4864865!
        Me.btnPrevyr.FocalPoints.FocusPtX = 0.0!
        Me.btnPrevyr.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnPrevyr.FocusPtTracker = DesignerRectTracker2
        Me.btnPrevyr.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrevyr.ForeColor = System.Drawing.Color.Black
        Me.btnPrevyr.Image = Nothing
        Me.btnPrevyr.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrevyr.ImageIndex = 0
        Me.btnPrevyr.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnPrevyr.Location = New System.Drawing.Point(294, 15)
        Me.btnPrevyr.Name = "btnPrevyr"
        Me.btnPrevyr.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnPrevyr.SideImage = Global.CWPlus.My.Resources.Resources.previous
        Me.btnPrevyr.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrevyr.SideImageSize = New System.Drawing.Size(45, 38)
        Me.btnPrevyr.Size = New System.Drawing.Size(52, 37)
        Me.btnPrevyr.TabIndex = 10
        Me.btnPrevyr.Text = ""
        Me.btnPrevyr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrevyr.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnPrevyr.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnPrevyr.TextShadow = System.Drawing.Color.White
        Me.btnPrevyr.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnPrevyr.UseMnemonic = True
        '
        'btnNextyr
        '
        Me.btnNextyr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNextyr.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker3.IsActive = False
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnNextyr.CenterPtTracker = DesignerRectTracker3
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.2544803!, 0.6953405!, 1.0!}
        Me.btnNextyr.ColorFillBlend = CBlendItems2
        Me.btnNextyr.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnNextyr.Corners.All = CType(-1, Short)
        Me.btnNextyr.Corners.LowerLeft = CType(0, Short)
        Me.btnNextyr.Corners.LowerRight = CType(21, Short)
        Me.btnNextyr.Corners.UpperLeft = CType(0, Short)
        Me.btnNextyr.Corners.UpperRight = CType(21, Short)
        Me.btnNextyr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNextyr.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnNextyr.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnNextyr.FocalPoints.CenterPtX = 0.979798!
        Me.btnNextyr.FocalPoints.CenterPtY = 0.4864865!
        Me.btnNextyr.FocalPoints.FocusPtX = 0.0!
        Me.btnNextyr.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnNextyr.FocusPtTracker = DesignerRectTracker4
        Me.btnNextyr.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNextyr.ForeColor = System.Drawing.Color.Black
        Me.btnNextyr.Image = Nothing
        Me.btnNextyr.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNextyr.ImageIndex = 0
        Me.btnNextyr.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnNextyr.Location = New System.Drawing.Point(504, 15)
        Me.btnNextyr.Name = "btnNextyr"
        Me.btnNextyr.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnNextyr.SideImage = Global.CWPlus.My.Resources.Resources._next
        Me.btnNextyr.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNextyr.SideImageSize = New System.Drawing.Size(45, 36)
        Me.btnNextyr.Size = New System.Drawing.Size(52, 37)
        Me.btnNextyr.TabIndex = 9
        Me.btnNextyr.Text = ""
        Me.btnNextyr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNextyr.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnNextyr.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnNextyr.TextShadow = System.Drawing.Color.White
        Me.btnNextyr.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnNextyr.UseMnemonic = True
        '
        'txtMonth
        '
        Me.txtMonth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMonth.AutoCompleteCustomSource.AddRange(New String() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.txtMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMonth.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtMonth.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.txtMonth.Location = New System.Drawing.Point(70, 17)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(145, 31)
        Me.txtMonth.TabIndex = 7
        Me.txtMonth.Tag = "1"
        Me.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrev.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnPrev.CenterPtTracker = DesignerRectTracker5
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.2544803!, 0.6953405!, 1.0!}
        Me.btnPrev.ColorFillBlend = CBlendItems3
        Me.btnPrev.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnPrev.Corners.All = CType(-1, Short)
        Me.btnPrev.Corners.LowerLeft = CType(21, Short)
        Me.btnPrev.Corners.LowerRight = CType(0, Short)
        Me.btnPrev.Corners.UpperLeft = CType(21, Short)
        Me.btnPrev.Corners.UpperRight = CType(0, Short)
        Me.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrev.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnPrev.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnPrev.FocalPoints.CenterPtX = 0.979798!
        Me.btnPrev.FocalPoints.CenterPtY = 0.4864865!
        Me.btnPrev.FocalPoints.FocusPtX = 0.0!
        Me.btnPrev.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnPrev.FocusPtTracker = DesignerRectTracker6
        Me.btnPrev.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrev.ForeColor = System.Drawing.Color.Black
        Me.btnPrev.Image = Nothing
        Me.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrev.ImageIndex = 0
        Me.btnPrev.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(12, 15)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnPrev.SideImage = Global.CWPlus.My.Resources.Resources.previous
        Me.btnPrev.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrev.SideImageSize = New System.Drawing.Size(45, 38)
        Me.btnPrev.Size = New System.Drawing.Size(52, 37)
        Me.btnPrev.TabIndex = 6
        Me.btnPrev.Text = ""
        Me.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnPrev.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnPrev.TextShadow = System.Drawing.Color.White
        Me.btnPrev.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnPrev.UseMnemonic = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.BorderColor = System.Drawing.Color.Black
        DesignerRectTracker7.IsActive = False
        DesignerRectTracker7.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker7.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnNext.CenterPtTracker = DesignerRectTracker7
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems4.iPoint = New Single() {0.0!, 0.2544803!, 0.6953405!, 1.0!}
        Me.btnNext.ColorFillBlend = CBlendItems4
        Me.btnNext.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btnNext.Corners.All = CType(-1, Short)
        Me.btnNext.Corners.LowerLeft = CType(0, Short)
        Me.btnNext.Corners.LowerRight = CType(21, Short)
        Me.btnNext.Corners.UpperLeft = CType(0, Short)
        Me.btnNext.Corners.UpperRight = CType(21, Short)
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.FillType = CButtonLib.CButton.eFillType.GradientLinear
        Me.btnNext.FillTypeLinear = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnNext.FocalPoints.CenterPtX = 0.979798!
        Me.btnNext.FocalPoints.CenterPtY = 0.4864865!
        Me.btnNext.FocalPoints.FocusPtX = 0.0!
        Me.btnNext.FocalPoints.FocusPtY = 0.0!
        DesignerRectTracker8.IsActive = False
        DesignerRectTracker8.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker8.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btnNext.FocusPtTracker = DesignerRectTracker8
        Me.btnNext.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Image = Nothing
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNext.ImageIndex = 0
        Me.btnNext.ImageSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(221, 15)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Shape = CButtonLib.CButton.eShape.Rectangle
        Me.btnNext.SideImage = Global.CWPlus.My.Resources.Resources._next
        Me.btnNext.SideImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNext.SideImageSize = New System.Drawing.Size(45, 36)
        Me.btnNext.Size = New System.Drawing.Size(52, 37)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = ""
        Me.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnNext.TextMargin = New System.Windows.Forms.Padding(2)
        Me.btnNext.TextShadow = System.Drawing.Color.White
        Me.btnNext.TextSmoothingMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Me.btnNext.UseMnemonic = True
        '
        'dlgQVCalendarView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 543)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "dlgQVCalendarView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dlgQVCalendarView"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Calendar1 As System.Windows.Forms.Calendar.Calendar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents btnPrev As CButtonLib.CButton
    Friend WithEvents btnNext As CButtonLib.CButton
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents btnPrevyr As CButtonLib.CButton
    Friend WithEvents btnNextyr As CButtonLib.CButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbLicense As System.Windows.Forms.ComboBox
End Class
