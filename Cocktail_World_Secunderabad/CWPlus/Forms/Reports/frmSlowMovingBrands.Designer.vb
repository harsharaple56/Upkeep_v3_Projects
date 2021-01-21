<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSlowMovingBrands
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdBrand = New System.Windows.Forms.DataGridView()
        Me.btnMailReport = New System.Windows.Forms.Button()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblAbovecategory = New System.Windows.Forms.Label()
        Me.lblBelowCategory = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAboveBrand = New System.Windows.Forms.Label()
        Me.lblBelowBrand = New System.Windows.Forms.Label()
        Me.lblBrandCount = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdCategory = New System.Windows.Forms.DataGridView()
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdBrand
        '
        Me.grdBrand.AllowDrop = True
        Me.grdBrand.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBrand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBrand.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdBrand.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBrand.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdBrand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrand.GridColor = System.Drawing.Color.Black
        Me.grdBrand.Location = New System.Drawing.Point(3, 3)
        Me.grdBrand.Name = "grdBrand"
        Me.grdBrand.Size = New System.Drawing.Size(1199, 289)
        Me.grdBrand.TabIndex = 9
        '
        'btnMailReport
        '
        Me.btnMailReport.Image = Global.CWPlus.My.Resources.Resources.email_open
        Me.btnMailReport.Location = New System.Drawing.Point(149, 3)
        Me.btnMailReport.Name = "btnMailReport"
        Me.btnMailReport.Size = New System.Drawing.Size(44, 40)
        Me.btnMailReport.TabIndex = 17
        Me.btnMailReport.UseVisualStyleBackColor = True
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.CWPlus.My.Resources.Resources.pdf
        Me.btnPdf.Location = New System.Drawing.Point(98, 3)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(46, 43)
        Me.btnPdf.TabIndex = 13
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(198, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "To Date"
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(250, 13)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(118, 20)
        Me.dtTo.TabIndex = 9
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtFrom)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1213, 409)
        Me.SplitContainer1.SplitterDistance = 84
        Me.SplitContainer1.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblAbovecategory)
        Me.GroupBox2.Controls.Add(Me.lblBelowCategory)
        Me.GroupBox2.Controls.Add(Me.lblCategory)
        Me.GroupBox2.Location = New System.Drawing.Point(317, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 40)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Category Wise"
        '
        'lblAbovecategory
        '
        Me.lblAbovecategory.AutoSize = True
        Me.lblAbovecategory.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbovecategory.Location = New System.Drawing.Point(238, 17)
        Me.lblAbovecategory.Name = "lblAbovecategory"
        Me.lblAbovecategory.Size = New System.Drawing.Size(0, 16)
        Me.lblAbovecategory.TabIndex = 19
        '
        'lblBelowCategory
        '
        Me.lblBelowCategory.AutoSize = True
        Me.lblBelowCategory.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBelowCategory.Location = New System.Drawing.Point(104, 17)
        Me.lblBelowCategory.Name = "lblBelowCategory"
        Me.lblBelowCategory.Size = New System.Drawing.Size(0, 16)
        Me.lblBelowCategory.TabIndex = 18
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(16, 16)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(0, 16)
        Me.lblCategory.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAboveBrand)
        Me.GroupBox1.Controls.Add(Me.lblBelowBrand)
        Me.GroupBox1.Controls.Add(Me.lblBrandCount)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 40)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Brand Wise"
        '
        'lblAboveBrand
        '
        Me.lblAboveBrand.AutoSize = True
        Me.lblAboveBrand.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboveBrand.Location = New System.Drawing.Point(183, 16)
        Me.lblAboveBrand.Name = "lblAboveBrand"
        Me.lblAboveBrand.Size = New System.Drawing.Size(0, 16)
        Me.lblAboveBrand.TabIndex = 19
        '
        'lblBelowBrand
        '
        Me.lblBelowBrand.AutoSize = True
        Me.lblBelowBrand.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBelowBrand.Location = New System.Drawing.Point(83, 16)
        Me.lblBelowBrand.Name = "lblBelowBrand"
        Me.lblBelowBrand.Size = New System.Drawing.Size(0, 16)
        Me.lblBelowBrand.TabIndex = 18
        '
        'lblBrandCount
        '
        Me.lblBrandCount.AutoSize = True
        Me.lblBrandCount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandCount.Location = New System.Drawing.Point(16, 16)
        Me.lblBrandCount.Name = "lblBrandCount"
        Me.lblBrandCount.Size = New System.Drawing.Size(0, 16)
        Me.lblBrandCount.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnMailReport)
        Me.Panel2.Controls.Add(Me.btnPdf)
        Me.Panel2.Controls.Add(Me.btnok)
        Me.Panel2.Controls.Add(Me.btnExport)
        Me.Panel2.Location = New System.Drawing.Point(1005, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(205, 46)
        Me.Panel2.TabIndex = 8
        '
        'btnok
        '
        Me.btnok.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnok.Location = New System.Drawing.Point(3, 3)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(43, 43)
        Me.btnok.TabIndex = 3
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(51, 2)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(44, 44)
        Me.btnExport.TabIndex = 4
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "From Date"
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(74, 13)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(118, 20)
        Me.dtFrom.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1213, 321)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdBrand)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1205, 295)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Brand Wise"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdCategory)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1205, 295)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Category Wise"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdCategory
        '
        Me.grdCategory.AllowDrop = True
        Me.grdCategory.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCategory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdCategory.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCategory.GridColor = System.Drawing.Color.Black
        Me.grdCategory.Location = New System.Drawing.Point(3, 3)
        Me.grdCategory.Name = "grdCategory"
        Me.grdCategory.Size = New System.Drawing.Size(861, 294)
        Me.grdCategory.TabIndex = 10
        '
        'frmSlowMovingBrands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 409)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSlowMovingBrands"
        Me.Text = "frmSlowMovingBrands"
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdBrand As System.Windows.Forms.DataGridView
    Friend WithEvents btnMailReport As System.Windows.Forms.Button
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdCategory As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBelowBrand As System.Windows.Forms.Label
    Friend WithEvents lblBrandCount As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAbovecategory As System.Windows.Forms.Label
    Friend WithEvents lblBelowCategory As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblAboveBrand As System.Windows.Forms.Label
End Class
