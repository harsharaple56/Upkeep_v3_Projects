<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiscSummaryDaywise
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
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chklstEvalLicense = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMailReport = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grdDCCReport = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFoodCostPerc = New System.Windows.Forms.TextBox()
        Me.txtBevCostPerc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLiquorCost = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDCCReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.CWPlus.My.Resources.Resources.pdf
        Me.btnPdf.Location = New System.Drawing.Point(95, 45)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(41, 41)
        Me.btnPdf.TabIndex = 13
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnMore
        '
        Me.btnMore.Image = Global.CWPlus.My.Resources.Resources.search
        Me.btnMore.Location = New System.Drawing.Point(52, 45)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(43, 41)
        Me.btnMore.TabIndex = 12
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(95, 3)
        Me.btnCrystalReport.Name = "btnCrystalReport"
        Me.btnCrystalReport.Size = New System.Drawing.Size(41, 42)
        Me.btnCrystalReport.TabIndex = 5
        Me.btnCrystalReport.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chklstEvalLicense)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdDCCReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(878, 309)
        Me.SplitContainer1.SplitterDistance = 97
        Me.SplitContainer1.TabIndex = 6
        '
        'chklstEvalLicense
        '
        Me.chklstEvalLicense.FormattingEnabled = True
        Me.chklstEvalLicense.Location = New System.Drawing.Point(422, 7)
        Me.chklstEvalLicense.Name = "chklstEvalLicense"
        Me.chklstEvalLicense.Size = New System.Drawing.Size(217, 94)
        Me.chklstEvalLicense.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLiquorCost)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtBevCostPerc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFoodCostPerc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtToDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtFromDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 82)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Discount Summary Day wise"
        '
        'dtToDate
        '
        Me.dtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtToDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToDate.Location = New System.Drawing.Point(265, 19)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(118, 26)
        Me.dtToDate.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(203, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "To Date"
        '
        'dtFromDate
        '
        Me.dtFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtFromDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromDate.Location = New System.Drawing.Point(79, 19)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(118, 26)
        Me.dtFromDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From Date"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnMailReport)
        Me.Panel1.Controls.Add(Me.btnPdf)
        Me.Panel1.Controls.Add(Me.btnMore)
        Me.Panel1.Controls.Add(Me.btnCrystalReport)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Location = New System.Drawing.Point(738, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(141, 97)
        Me.Panel1.TabIndex = 18
        '
        'btnMailReport
        '
        Me.btnMailReport.Image = Global.CWPlus.My.Resources.Resources.email_open
        Me.btnMailReport.Location = New System.Drawing.Point(3, 46)
        Me.btnMailReport.Name = "btnMailReport"
        Me.btnMailReport.Size = New System.Drawing.Size(47, 40)
        Me.btnMailReport.TabIndex = 14
        Me.btnMailReport.UseVisualStyleBackColor = True
        '
        'btnok
        '
        Me.btnok.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnok.Location = New System.Drawing.Point(3, 3)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(47, 42)
        Me.btnok.TabIndex = 3
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(50, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(45, 42)
        Me.btnExport.TabIndex = 4
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'grdDCCReport
        '
        Me.grdDCCReport.AllowUserToAddRows = False
        Me.grdDCCReport.AllowUserToDeleteRows = False
        Me.grdDCCReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDCCReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDCCReport.Location = New System.Drawing.Point(0, 0)
        Me.grdDCCReport.Name = "grdDCCReport"
        Me.grdDCCReport.ReadOnly = True
        Me.grdDCCReport.Size = New System.Drawing.Size(878, 208)
        Me.grdDCCReport.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Food Cost %"
        '
        'txtFoodCostPerc
        '
        Me.txtFoodCostPerc.Location = New System.Drawing.Point(79, 56)
        Me.txtFoodCostPerc.Name = "txtFoodCostPerc"
        Me.txtFoodCostPerc.Size = New System.Drawing.Size(37, 20)
        Me.txtFoodCostPerc.TabIndex = 7
        Me.txtFoodCostPerc.Text = "25"
        '
        'txtBevCostPerc
        '
        Me.txtBevCostPerc.Location = New System.Drawing.Point(216, 56)
        Me.txtBevCostPerc.Name = "txtBevCostPerc"
        Me.txtBevCostPerc.Size = New System.Drawing.Size(37, 20)
        Me.txtBevCostPerc.TabIndex = 9
        Me.txtBevCostPerc.Text = "25"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(122, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Beverage Cost %"
        '
        'txtLiquorCost
        '
        Me.txtLiquorCost.Location = New System.Drawing.Point(336, 56)
        Me.txtLiquorCost.Name = "txtLiquorCost"
        Me.txtLiquorCost.Size = New System.Drawing.Size(37, 20)
        Me.txtLiquorCost.TabIndex = 11
        Me.txtLiquorCost.Text = "25"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(259, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Liquor Cost %"
        '
        'FrmDiscSummaryDaywise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 309)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmDiscSummaryDaywise"
        Me.Text = "FrmDiscSummaryDaywise"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdDCCReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMailReport As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents grdDCCReport As System.Windows.Forms.DataGridView
    Friend WithEvents chklstEvalLicense As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtBevCostPerc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFoodCostPerc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLiquorCost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
