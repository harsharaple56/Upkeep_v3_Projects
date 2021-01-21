<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransferReport
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpTransferReport = New System.Windows.Forms.GroupBox()
        Me.lblFl4 = New System.Windows.Forms.Label()
        Me.txtFLIV = New System.Windows.Forms.TextBox()
        Me.lblTotalCost = New System.Windows.Forms.Label()
        Me.lblToLicense = New System.Windows.Forms.Label()
        Me.cmbToLicense = New System.Windows.Forms.ComboBox()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.lblTransferHeadID = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.lblTPlNo = New System.Windows.Forms.Label()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTransferDAte = New System.Windows.Forms.Label()
        Me.txtTPNo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grdTransferReport = New System.Windows.Forms.DataGridView()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpTransferReport.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdTransferReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpTransferReport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdTransferReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(861, 439)
        Me.SplitContainer1.SplitterDistance = 151
        Me.SplitContainer1.TabIndex = 0
        '
        'grpTransferReport
        '
        Me.grpTransferReport.Controls.Add(Me.lblFl4)
        Me.grpTransferReport.Controls.Add(Me.txtFLIV)
        Me.grpTransferReport.Controls.Add(Me.lblTotalCost)
        Me.grpTransferReport.Controls.Add(Me.lblToLicense)
        Me.grpTransferReport.Controls.Add(Me.cmbToLicense)
        Me.grpTransferReport.Controls.Add(Me.dtFromDate)
        Me.grpTransferReport.Controls.Add(Me.Label1)
        Me.grpTransferReport.Controls.Add(Me.lblInvoice)
        Me.grpTransferReport.Controls.Add(Me.lblTransferHeadID)
        Me.grpTransferReport.Controls.Add(Me.txtInvoiceNo)
        Me.grpTransferReport.Controls.Add(Me.lblTPlNo)
        Me.grpTransferReport.Controls.Add(Me.dtToDate)
        Me.grpTransferReport.Controls.Add(Me.lblTransferDAte)
        Me.grpTransferReport.Controls.Add(Me.txtTPNo)
        Me.grpTransferReport.Location = New System.Drawing.Point(3, 6)
        Me.grpTransferReport.Name = "grpTransferReport"
        Me.grpTransferReport.Size = New System.Drawing.Size(447, 139)
        Me.grpTransferReport.TabIndex = 14
        Me.grpTransferReport.TabStop = False
        Me.grpTransferReport.Text = "Transfer Report"
        '
        'lblFl4
        '
        Me.lblFl4.AutoSize = True
        Me.lblFl4.Location = New System.Drawing.Point(276, 99)
        Me.lblFl4.Name = "lblFl4"
        Me.lblFl4.Size = New System.Drawing.Size(32, 13)
        Me.lblFl4.TabIndex = 21
        Me.lblFl4.Text = "FL IV"
        '
        'txtFLIV
        '
        Me.txtFLIV.Location = New System.Drawing.Point(315, 96)
        Me.txtFLIV.Name = "txtFLIV"
        Me.txtFLIV.Size = New System.Drawing.Size(119, 20)
        Me.txtFLIV.TabIndex = 20
        '
        'lblTotalCost
        '
        Me.lblTotalCost.AutoSize = True
        Me.lblTotalCost.Location = New System.Drawing.Point(27, 123)
        Me.lblTotalCost.Name = "lblTotalCost"
        Me.lblTotalCost.Size = New System.Drawing.Size(39, 13)
        Me.lblTotalCost.TabIndex = 17
        Me.lblTotalCost.Text = "Label2"
        '
        'lblToLicense
        '
        Me.lblToLicense.AutoSize = True
        Me.lblToLicense.Location = New System.Drawing.Point(27, 101)
        Me.lblToLicense.Name = "lblToLicense"
        Me.lblToLicense.Size = New System.Drawing.Size(60, 13)
        Me.lblToLicense.TabIndex = 16
        Me.lblToLicense.Text = "To License"
        '
        'cmbToLicense
        '
        Me.cmbToLicense.FormattingEnabled = True
        Me.cmbToLicense.Location = New System.Drawing.Point(93, 93)
        Me.cmbToLicense.Name = "cmbToLicense"
        Me.cmbToLicense.Size = New System.Drawing.Size(121, 21)
        Me.cmbToLicense.TabIndex = 15
        '
        'dtFromDate
        '
        Me.dtFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromDate.Location = New System.Drawing.Point(94, 19)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(120, 20)
        Me.dtFromDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "From Date"
        '
        'lblInvoice
        '
        Me.lblInvoice.AutoSize = True
        Me.lblInvoice.Location = New System.Drawing.Point(227, 63)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Size = New System.Drawing.Size(82, 13)
        Me.lblInvoice.TabIndex = 8
        Me.lblInvoice.Text = "Invoice Number"
        '
        'lblTransferHeadID
        '
        Me.lblTransferHeadID.AutoSize = True
        Me.lblTransferHeadID.Location = New System.Drawing.Point(512, 96)
        Me.lblTransferHeadID.Name = "lblTransferHeadID"
        Me.lblTransferHeadID.Size = New System.Drawing.Size(13, 13)
        Me.lblTransferHeadID.TabIndex = 0
        Me.lblTransferHeadID.Text = "0"
        Me.lblTransferHeadID.Visible = False
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(315, 60)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(118, 20)
        Me.txtInvoiceNo.TabIndex = 5
        '
        'lblTPlNo
        '
        Me.lblTPlNo.AutoSize = True
        Me.lblTPlNo.Location = New System.Drawing.Point(27, 66)
        Me.lblTPlNo.Name = "lblTPlNo"
        Me.lblTPlNo.Size = New System.Drawing.Size(61, 13)
        Me.lblTPlNo.TabIndex = 1
        Me.lblTPlNo.Text = "TP Number"
        '
        'dtToDate
        '
        Me.dtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToDate.Location = New System.Drawing.Point(279, 17)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(120, 20)
        Me.dtToDate.TabIndex = 2
        '
        'lblTransferDAte
        '
        Me.lblTransferDAte.AutoSize = True
        Me.lblTransferDAte.Location = New System.Drawing.Point(227, 22)
        Me.lblTransferDAte.Name = "lblTransferDAte"
        Me.lblTransferDAte.Size = New System.Drawing.Size(46, 13)
        Me.lblTransferDAte.TabIndex = 5
        Me.lblTransferDAte.Text = "To Date"
        '
        'txtTPNo
        '
        Me.txtTPNo.Location = New System.Drawing.Point(96, 59)
        Me.txtTPNo.Name = "txtTPNo"
        Me.txtTPNo.Size = New System.Drawing.Size(118, 20)
        Me.txtTPNo.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnPdf)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.btnCrystalReport)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Location = New System.Drawing.Point(702, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(156, 97)
        Me.Panel1.TabIndex = 8
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.CWPlus.My.Resources.Resources.pdf
        Me.btnPdf.Location = New System.Drawing.Point(80, 49)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(42, 41)
        Me.btnPdf.TabIndex = 13
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.CWPlus.My.Resources.Resources.search
        Me.btnSearch.Location = New System.Drawing.Point(36, 49)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(44, 41)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Enabled = False
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(95, 3)
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
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(50, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(45, 42)
        Me.btnExport.TabIndex = 4
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'grdTransferReport
        '
        Me.grdTransferReport.AllowDrop = True
        Me.grdTransferReport.AllowUserToAddRows = False
        Me.grdTransferReport.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTransferReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTransferReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdTransferReport.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdTransferReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTransferReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit, Me.Delete})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTransferReport.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdTransferReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTransferReport.GridColor = System.Drawing.Color.Black
        Me.grdTransferReport.Location = New System.Drawing.Point(0, 0)
        Me.grdTransferReport.Name = "grdTransferReport"
        Me.grdTransferReport.ReadOnly = True
        Me.grdTransferReport.Size = New System.Drawing.Size(861, 284)
        Me.grdTransferReport.TabIndex = 10
        '
        'Edit
        '
        Me.Edit.HeaderText = "Edit"
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Text = "Edit"
        Me.Edit.UseColumnTextForButtonValue = True
        '
        'Delete
        '
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = True
        Me.Delete.Text = "Delete"
        Me.Delete.UseColumnTextForButtonValue = True
        '
        'FrmTransferReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 439)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmTransferReport"
        Me.Text = "FrmTransferReport"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpTransferReport.ResumeLayout(False)
        Me.grpTransferReport.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdTransferReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdTransferReport As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents grpTransferReport As System.Windows.Forms.GroupBox
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblInvoice As System.Windows.Forms.Label
    Friend WithEvents lblTransferHeadID As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents lblTPlNo As System.Windows.Forms.Label
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTransferDAte As System.Windows.Forms.Label
    Friend WithEvents txtTPNo As System.Windows.Forms.TextBox
    Friend WithEvents lblToLicense As System.Windows.Forms.Label
    Friend WithEvents cmbToLicense As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotalCost As System.Windows.Forms.Label
    Friend WithEvents lblFl4 As System.Windows.Forms.Label
    Friend WithEvents txtFLIV As System.Windows.Forms.TextBox
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Delete As System.Windows.Forms.DataGridViewButtonColumn
End Class
