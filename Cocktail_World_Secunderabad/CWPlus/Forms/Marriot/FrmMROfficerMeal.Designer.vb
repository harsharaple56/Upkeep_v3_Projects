<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOfficerMealMR
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDepartment = New System.Windows.Forms.CheckBox()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.DtToDate = New System.Windows.Forms.DateTimePicker()
        Me.drpRevenueCenter = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtFromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnSummary = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.grdDCCReport = New System.Windows.Forms.DataGridView()
        Me.sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.businessdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevenueCenterId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevenueCenterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Discount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiscountType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnGFields = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnGFieldInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AngHeadId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCostPerc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDCCReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdDCCReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(795, 456)
        Me.SplitContainer1.SplitterDistance = 127
        Me.SplitContainer1.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCostPerc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkDepartment)
        Me.GroupBox1.Controls.Add(Me.txtCheckNo)
        Me.GroupBox1.Controls.Add(Me.DtToDate)
        Me.GroupBox1.Controls.Add(Me.drpRevenueCenter)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DtFromdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 108)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Officer Meal"
        '
        'chkDepartment
        '
        Me.chkDepartment.AutoSize = True
        Me.chkDepartment.Location = New System.Drawing.Point(9, 80)
        Me.chkDepartment.Name = "chkDepartment"
        Me.chkDepartment.Size = New System.Drawing.Size(108, 17)
        Me.chkDepartment.TabIndex = 24
        Me.chkDepartment.Text = "Department Wise"
        Me.chkDepartment.UseVisualStyleBackColor = True
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Location = New System.Drawing.Point(334, 51)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(84, 20)
        Me.txtCheckNo.TabIndex = 23
        '
        'DtToDate
        '
        Me.DtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtToDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtToDate.Location = New System.Drawing.Point(334, 19)
        Me.DtToDate.Name = "DtToDate"
        Me.DtToDate.Size = New System.Drawing.Size(115, 26)
        Me.DtToDate.TabIndex = 6
        '
        'drpRevenueCenter
        '
        Me.drpRevenueCenter.FormattingEnabled = True
        Me.drpRevenueCenter.Location = New System.Drawing.Point(101, 51)
        Me.drpRevenueCenter.Name = "drpRevenueCenter"
        Me.drpRevenueCenter.Size = New System.Drawing.Size(160, 21)
        Me.drpRevenueCenter.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(267, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Check No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "To Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Revenue Center"
        '
        'DtFromdate
        '
        Me.DtFromdate.CustomFormat = "dd-MMM-yyyy"
        Me.DtFromdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFromdate.Location = New System.Drawing.Point(101, 19)
        Me.DtFromdate.Name = "DtFromdate"
        Me.DtFromdate.Size = New System.Drawing.Size(115, 26)
        Me.DtFromdate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From Date"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.BtnSummary)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Controls.Add(Me.btnCrystalReport)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Location = New System.Drawing.Point(584, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(199, 49)
        Me.Panel1.TabIndex = 18
        '
        'BtnSummary
        '
        Me.BtnSummary.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.BtnSummary.Location = New System.Drawing.Point(103, 3)
        Me.BtnSummary.Name = "BtnSummary"
        Me.BtnSummary.Size = New System.Drawing.Size(41, 42)
        Me.BtnSummary.TabIndex = 11
        Me.BtnSummary.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(150, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 40)
        Me.imgClose.TabIndex = 10
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(56, 3)
        Me.btnCrystalReport.Name = "btnCrystalReport"
        Me.btnCrystalReport.Size = New System.Drawing.Size(41, 42)
        Me.btnCrystalReport.TabIndex = 5
        Me.btnCrystalReport.UseVisualStyleBackColor = True
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
        'grdDCCReport
        '
        Me.grdDCCReport.AllowUserToAddRows = False
        Me.grdDCCReport.AllowUserToDeleteRows = False
        Me.grdDCCReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDCCReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sel, Me.businessdate, Me.RevenueCenterId, Me.RevenueCenterName, Me.CheckId, Me.BillNo, Me.Discount, Me.Type, Me.Amount, Me.DiscountType, Me.AnGFields, Me.AnGFieldInfo, Me.AngHeadId, Me.Reference})
        Me.grdDCCReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDCCReport.Location = New System.Drawing.Point(0, 0)
        Me.grdDCCReport.Name = "grdDCCReport"
        Me.grdDCCReport.ReadOnly = True
        Me.grdDCCReport.Size = New System.Drawing.Size(795, 325)
        Me.grdDCCReport.TabIndex = 0
        '
        'sel
        '
        Me.sel.HeaderText = "Select"
        Me.sel.Name = "sel"
        Me.sel.ReadOnly = True
        '
        'businessdate
        '
        Me.businessdate.HeaderText = "BusinessDate"
        Me.businessdate.Name = "businessdate"
        Me.businessdate.ReadOnly = True
        Me.businessdate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.businessdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RevenueCenterId
        '
        Me.RevenueCenterId.HeaderText = "RevenueCenterId"
        Me.RevenueCenterId.Name = "RevenueCenterId"
        Me.RevenueCenterId.ReadOnly = True
        Me.RevenueCenterId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RevenueCenterId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RevenueCenterName
        '
        Me.RevenueCenterName.HeaderText = "RevenueCenterName"
        Me.RevenueCenterName.Name = "RevenueCenterName"
        Me.RevenueCenterName.ReadOnly = True
        '
        'CheckId
        '
        Me.CheckId.HeaderText = "CheckId"
        Me.CheckId.Name = "CheckId"
        Me.CheckId.ReadOnly = True
        '
        'BillNo
        '
        Me.BillNo.HeaderText = "BillNo"
        Me.BillNo.Name = "BillNo"
        Me.BillNo.ReadOnly = True
        '
        'Discount
        '
        Me.Discount.HeaderText = "Discount"
        Me.Discount.Name = "Discount"
        Me.Discount.ReadOnly = True
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'DiscountType
        '
        Me.DiscountType.HeaderText = "DiscountType"
        Me.DiscountType.Name = "DiscountType"
        Me.DiscountType.ReadOnly = True
        '
        'AnGFields
        '
        Me.AnGFields.HeaderText = "AnGFields"
        Me.AnGFields.Name = "AnGFields"
        Me.AnGFields.ReadOnly = True
        '
        'AnGFieldInfo
        '
        Me.AnGFieldInfo.HeaderText = "AnGFieldInfo"
        Me.AnGFieldInfo.Name = "AnGFieldInfo"
        Me.AnGFieldInfo.ReadOnly = True
        '
        'AngHeadId
        '
        Me.AngHeadId.HeaderText = "AngHeadId"
        Me.AngHeadId.Name = "AngHeadId"
        Me.AngHeadId.ReadOnly = True
        '
        'Reference
        '
        Me.Reference.HeaderText = "Reference"
        Me.Reference.Name = "Reference"
        Me.Reference.ReadOnly = True
        '
        'txtCostPerc
        '
        Me.txtCostPerc.Location = New System.Drawing.Point(334, 78)
        Me.txtCostPerc.Name = "txtCostPerc"
        Me.txtCostPerc.Size = New System.Drawing.Size(84, 20)
        Me.txtCostPerc.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(267, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Cost %"
        '
        'FrmOfficerMeal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 456)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmOfficerMeal"
        Me.Text = "FrmOfficerMeal"
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
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtFromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents grdDCCReport As System.Windows.Forms.DataGridView
    Friend WithEvents DtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents drpRevenueCenter As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents BtnSummary As System.Windows.Forms.Button
    Friend WithEvents sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents businessdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevenueCenterId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevenueCenterName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Discount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnGFields As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnGFieldInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AngHeadId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkDepartment As System.Windows.Forms.CheckBox
    Friend WithEvents txtCostPerc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
