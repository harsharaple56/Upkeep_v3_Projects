<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCocktailReport
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTimeOut = New System.Windows.Forms.TextBox()
        Me.grpChataiReportmodify = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dtchataiToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtchataiFromDate = New System.Windows.Forms.DateTimePicker()
        Me.grpSaleReport = New System.Windows.Forms.GroupBox()
        Me.lblTotalQty = New System.Windows.Forms.Label()
        Me.lblSaleBillNo = New System.Windows.Forms.Label()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.DtSaleToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSaleToDate = New System.Windows.Forms.Label()
        Me.lblSaleFromDate = New System.Windows.Forms.Label()
        Me.dtSaleFromDate = New System.Windows.Forms.DateTimePicker()
        Me.grpPurchaseReport = New System.Windows.Forms.GroupBox()
        Me.cmbSuplier = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPurchaseTotal = New System.Windows.Forms.Label()
        Me.lblinvoice = New System.Windows.Forms.Label()
        Me.txtinvoiceNo = New System.Windows.Forms.TextBox()
        Me.lblPurTpNo = New System.Windows.Forms.Label()
        Me.txtTpNo = New System.Windows.Forms.TextBox()
        Me.dtpurToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPurToDate = New System.Windows.Forms.Label()
        Me.lblpurFromDate = New System.Windows.Forms.Label()
        Me.dtpPurFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMailReport = New System.Windows.Forms.Button()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpCocktailReport = New System.Windows.Forms.GroupBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpCocktailReport = New System.Windows.Forms.DateTimePicker()
        Me.grdCocktailReport = New System.Windows.Forms.DataGridView()
        Me.tltpCocktailreport = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpChataiReportmodify.SuspendLayout()
        Me.grpSaleReport.SuspendLayout()
        Me.grpPurchaseReport.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpCocktailReport.SuspendLayout()
        CType(Me.grdCocktailReport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTimeOut)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpChataiReportmodify)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSaleReport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpPurchaseReport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpCocktailReport)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdCocktailReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(1362, 440)
        Me.SplitContainer1.SplitterDistance = 120
        Me.SplitContainer1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Timeout in seconds"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Location = New System.Drawing.Point(117, 98)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Size = New System.Drawing.Size(53, 20)
        Me.txtTimeOut.TabIndex = 12
        Me.txtTimeOut.Text = "30"
        '
        'grpChataiReportmodify
        '
        Me.grpChataiReportmodify.Controls.Add(Me.CheckBox1)
        Me.grpChataiReportmodify.Controls.Add(Me.dtchataiToDate)
        Me.grpChataiReportmodify.Controls.Add(Me.Label3)
        Me.grpChataiReportmodify.Controls.Add(Me.Label4)
        Me.grpChataiReportmodify.Controls.Add(Me.dtchataiFromDate)
        Me.grpChataiReportmodify.Location = New System.Drawing.Point(831, 13)
        Me.grpChataiReportmodify.Name = "grpChataiReportmodify"
        Me.grpChataiReportmodify.Size = New System.Drawing.Size(330, 87)
        Me.grpChataiReportmodify.TabIndex = 11
        Me.grpChataiReportmodify.TabStop = False
        Me.grpChataiReportmodify.Text = "Chatai Report"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(148, 53)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(37, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dtchataiToDate
        '
        Me.dtchataiToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtchataiToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtchataiToDate.Location = New System.Drawing.Point(225, 19)
        Me.dtchataiToDate.Name = "dtchataiToDate"
        Me.dtchataiToDate.Size = New System.Drawing.Size(99, 20)
        Me.dtchataiToDate.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "To Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "From Date"
        '
        'dtchataiFromDate
        '
        Me.dtchataiFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtchataiFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtchataiFromDate.Location = New System.Drawing.Point(68, 20)
        Me.dtchataiFromDate.Name = "dtchataiFromDate"
        Me.dtchataiFromDate.Size = New System.Drawing.Size(99, 20)
        Me.dtchataiFromDate.TabIndex = 1
        '
        'grpSaleReport
        '
        Me.grpSaleReport.Controls.Add(Me.lblTotalQty)
        Me.grpSaleReport.Controls.Add(Me.lblSaleBillNo)
        Me.grpSaleReport.Controls.Add(Me.txtBillNo)
        Me.grpSaleReport.Controls.Add(Me.DtSaleToDate)
        Me.grpSaleReport.Controls.Add(Me.lblSaleToDate)
        Me.grpSaleReport.Controls.Add(Me.lblSaleFromDate)
        Me.grpSaleReport.Controls.Add(Me.dtSaleFromDate)
        Me.grpSaleReport.Location = New System.Drawing.Point(486, 10)
        Me.grpSaleReport.Name = "grpSaleReport"
        Me.grpSaleReport.Size = New System.Drawing.Size(339, 90)
        Me.grpSaleReport.TabIndex = 9
        Me.grpSaleReport.TabStop = False
        Me.grpSaleReport.Text = "Sale Report"
        '
        'lblTotalQty
        '
        Me.lblTotalQty.AutoSize = True
        Me.lblTotalQty.Location = New System.Drawing.Point(19, 71)
        Me.lblTotalQty.Name = "lblTotalQty"
        Me.lblTotalQty.Size = New System.Drawing.Size(0, 13)
        Me.lblTotalQty.TabIndex = 12
        '
        'lblSaleBillNo
        '
        Me.lblSaleBillNo.AutoSize = True
        Me.lblSaleBillNo.Location = New System.Drawing.Point(19, 53)
        Me.lblSaleBillNo.Name = "lblSaleBillNo"
        Me.lblSaleBillNo.Size = New System.Drawing.Size(37, 13)
        Me.lblSaleBillNo.TabIndex = 11
        Me.lblSaleBillNo.Text = "Bill No"
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(68, 50)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(100, 20)
        Me.txtBillNo.TabIndex = 3
        '
        'DtSaleToDate
        '
        Me.DtSaleToDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtSaleToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtSaleToDate.Location = New System.Drawing.Point(236, 21)
        Me.DtSaleToDate.Name = "DtSaleToDate"
        Me.DtSaleToDate.Size = New System.Drawing.Size(99, 20)
        Me.DtSaleToDate.TabIndex = 2
        '
        'lblSaleToDate
        '
        Me.lblSaleToDate.AutoSize = True
        Me.lblSaleToDate.Location = New System.Drawing.Point(184, 22)
        Me.lblSaleToDate.Name = "lblSaleToDate"
        Me.lblSaleToDate.Size = New System.Drawing.Size(46, 13)
        Me.lblSaleToDate.TabIndex = 8
        Me.lblSaleToDate.Text = "To Date"
        '
        'lblSaleFromDate
        '
        Me.lblSaleFromDate.AutoSize = True
        Me.lblSaleFromDate.Location = New System.Drawing.Point(6, 21)
        Me.lblSaleFromDate.Name = "lblSaleFromDate"
        Me.lblSaleFromDate.Size = New System.Drawing.Size(56, 13)
        Me.lblSaleFromDate.TabIndex = 7
        Me.lblSaleFromDate.Text = "From Date"
        '
        'dtSaleFromDate
        '
        Me.dtSaleFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtSaleFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSaleFromDate.Location = New System.Drawing.Point(68, 20)
        Me.dtSaleFromDate.Name = "dtSaleFromDate"
        Me.dtSaleFromDate.Size = New System.Drawing.Size(99, 20)
        Me.dtSaleFromDate.TabIndex = 1
        '
        'grpPurchaseReport
        '
        Me.grpPurchaseReport.Controls.Add(Me.cmbSuplier)
        Me.grpPurchaseReport.Controls.Add(Me.Label5)
        Me.grpPurchaseReport.Controls.Add(Me.lblPurchaseTotal)
        Me.grpPurchaseReport.Controls.Add(Me.lblinvoice)
        Me.grpPurchaseReport.Controls.Add(Me.txtinvoiceNo)
        Me.grpPurchaseReport.Controls.Add(Me.lblPurTpNo)
        Me.grpPurchaseReport.Controls.Add(Me.txtTpNo)
        Me.grpPurchaseReport.Controls.Add(Me.dtpurToDate)
        Me.grpPurchaseReport.Controls.Add(Me.lblPurToDate)
        Me.grpPurchaseReport.Controls.Add(Me.lblpurFromDate)
        Me.grpPurchaseReport.Controls.Add(Me.dtpPurFromDate)
        Me.grpPurchaseReport.Location = New System.Drawing.Point(193, 13)
        Me.grpPurchaseReport.Name = "grpPurchaseReport"
        Me.grpPurchaseReport.Size = New System.Drawing.Size(359, 105)
        Me.grpPurchaseReport.TabIndex = 8
        Me.grpPurchaseReport.TabStop = False
        Me.grpPurchaseReport.Text = "Purchase Report"
        '
        'cmbSuplier
        '
        Me.cmbSuplier.FormattingEnabled = True
        Me.cmbSuplier.Location = New System.Drawing.Point(208, 76)
        Me.cmbSuplier.Name = "cmbSuplier"
        Me.cmbSuplier.Size = New System.Drawing.Size(145, 21)
        Me.cmbSuplier.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Supplier"
        '
        'lblPurchaseTotal
        '
        Me.lblPurchaseTotal.AutoSize = True
        Me.lblPurchaseTotal.Location = New System.Drawing.Point(18, 71)
        Me.lblPurchaseTotal.Name = "lblPurchaseTotal"
        Me.lblPurchaseTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblPurchaseTotal.TabIndex = 13
        '
        'lblinvoice
        '
        Me.lblinvoice.AutoSize = True
        Me.lblinvoice.Location = New System.Drawing.Point(174, 52)
        Me.lblinvoice.Name = "lblinvoice"
        Me.lblinvoice.Size = New System.Drawing.Size(59, 13)
        Me.lblinvoice.TabIndex = 7
        Me.lblinvoice.Text = "Invoice No"
        '
        'txtinvoiceNo
        '
        Me.txtinvoiceNo.Location = New System.Drawing.Point(233, 50)
        Me.txtinvoiceNo.Name = "txtinvoiceNo"
        Me.txtinvoiceNo.Size = New System.Drawing.Size(100, 20)
        Me.txtinvoiceNo.TabIndex = 4
        '
        'lblPurTpNo
        '
        Me.lblPurTpNo.AutoSize = True
        Me.lblPurTpNo.Location = New System.Drawing.Point(19, 52)
        Me.lblPurTpNo.Name = "lblPurTpNo"
        Me.lblPurTpNo.Size = New System.Drawing.Size(37, 13)
        Me.lblPurTpNo.TabIndex = 5
        Me.lblPurTpNo.Text = "Tp No"
        '
        'txtTpNo
        '
        Me.txtTpNo.Location = New System.Drawing.Point(68, 49)
        Me.txtTpNo.Name = "txtTpNo"
        Me.txtTpNo.Size = New System.Drawing.Size(100, 20)
        Me.txtTpNo.TabIndex = 3
        '
        'dtpurToDate
        '
        Me.dtpurToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpurToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpurToDate.Location = New System.Drawing.Point(236, 19)
        Me.dtpurToDate.Name = "dtpurToDate"
        Me.dtpurToDate.Size = New System.Drawing.Size(99, 20)
        Me.dtpurToDate.TabIndex = 2
        '
        'lblPurToDate
        '
        Me.lblPurToDate.AutoSize = True
        Me.lblPurToDate.Location = New System.Drawing.Point(184, 21)
        Me.lblPurToDate.Name = "lblPurToDate"
        Me.lblPurToDate.Size = New System.Drawing.Size(46, 13)
        Me.lblPurToDate.TabIndex = 2
        Me.lblPurToDate.Text = "To Date"
        '
        'lblpurFromDate
        '
        Me.lblpurFromDate.AutoSize = True
        Me.lblpurFromDate.Location = New System.Drawing.Point(6, 20)
        Me.lblpurFromDate.Name = "lblpurFromDate"
        Me.lblpurFromDate.Size = New System.Drawing.Size(56, 13)
        Me.lblpurFromDate.TabIndex = 1
        Me.lblpurFromDate.Text = "From Date"
        '
        'dtpPurFromDate
        '
        Me.dtpPurFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPurFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPurFromDate.Location = New System.Drawing.Point(68, 19)
        Me.dtpPurFromDate.Name = "dtpPurFromDate"
        Me.dtpPurFromDate.Size = New System.Drawing.Size(99, 20)
        Me.dtpPurFromDate.TabIndex = 1
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
        Me.Panel1.Location = New System.Drawing.Point(1167, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(144, 97)
        Me.Panel1.TabIndex = 7
        '
        'btnMailReport
        '
        Me.btnMailReport.Image = Global.CWPlus.My.Resources.Resources.email_open
        Me.btnMailReport.Location = New System.Drawing.Point(5, 50)
        Me.btnMailReport.Name = "btnMailReport"
        Me.btnMailReport.Size = New System.Drawing.Size(44, 40)
        Me.btnMailReport.TabIndex = 14
        Me.tltpCocktailreport.SetToolTip(Me.btnMailReport, "Mail Report")
        Me.btnMailReport.UseVisualStyleBackColor = True
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.CWPlus.My.Resources.Resources.pdf
        Me.btnPdf.Location = New System.Drawing.Point(96, 49)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(42, 41)
        Me.btnPdf.TabIndex = 13
        Me.tltpCocktailreport.SetToolTip(Me.btnPdf, "Export To Crystal Report")
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnMore
        '
        Me.btnMore.Image = Global.CWPlus.My.Resources.Resources.search
        Me.btnMore.Location = New System.Drawing.Point(50, 49)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(44, 41)
        Me.btnMore.TabIndex = 12
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(96, 3)
        Me.btnCrystalReport.Name = "btnCrystalReport"
        Me.btnCrystalReport.Size = New System.Drawing.Size(42, 40)
        Me.btnCrystalReport.TabIndex = 5
        Me.tltpCocktailreport.SetToolTip(Me.btnCrystalReport, "Export To Crystal Report")
        Me.btnCrystalReport.UseVisualStyleBackColor = True
        '
        'btnok
        '
        Me.btnok.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnok.Location = New System.Drawing.Point(5, 3)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(44, 40)
        Me.btnok.TabIndex = 3
        Me.tltpCocktailreport.SetToolTip(Me.btnok, "ok")
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(50, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(44, 39)
        Me.btnExport.TabIndex = 4
        Me.tltpCocktailreport.SetToolTip(Me.btnExport, "Export To Excel")
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'grpCocktailReport
        '
        Me.grpCocktailReport.Controls.Add(Me.chkAll)
        Me.grpCocktailReport.Controls.Add(Me.Label1)
        Me.grpCocktailReport.Controls.Add(Me.dtpCocktailReport)
        Me.grpCocktailReport.Location = New System.Drawing.Point(12, 12)
        Me.grpCocktailReport.Name = "grpCocktailReport"
        Me.grpCocktailReport.Size = New System.Drawing.Size(156, 90)
        Me.grpCocktailReport.TabIndex = 0
        Me.grpCocktailReport.TabStop = False
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(42, 53)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(37, 17)
        Me.chkAll.TabIndex = 2
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date"
        '
        'dtpCocktailReport
        '
        Me.dtpCocktailReport.CustomFormat = "dd-MMM-yyyy"
        Me.dtpCocktailReport.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCocktailReport.Location = New System.Drawing.Point(42, 26)
        Me.dtpCocktailReport.Name = "dtpCocktailReport"
        Me.dtpCocktailReport.Size = New System.Drawing.Size(99, 20)
        Me.dtpCocktailReport.TabIndex = 1
        '
        'grdCocktailReport
        '
        Me.grdCocktailReport.AllowDrop = True
        Me.grdCocktailReport.AllowUserToAddRows = False
        Me.grdCocktailReport.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCocktailReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grdCocktailReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdCocktailReport.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdCocktailReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCocktailReport.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdCocktailReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCocktailReport.GridColor = System.Drawing.Color.Black
        Me.grdCocktailReport.Location = New System.Drawing.Point(0, 0)
        Me.grdCocktailReport.Name = "grdCocktailReport"
        Me.grdCocktailReport.ReadOnly = True
        Me.grdCocktailReport.Size = New System.Drawing.Size(1362, 316)
        Me.grdCocktailReport.TabIndex = 9
        '
        'tltpCocktailreport
        '
        Me.tltpCocktailreport.IsBalloon = True
        '
        'FrmCocktailReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1362, 440)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmCocktailReport"
        Me.Text = "FrmCocktailReport"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpChataiReportmodify.ResumeLayout(False)
        Me.grpChataiReportmodify.PerformLayout()
        Me.grpSaleReport.ResumeLayout(False)
        Me.grpSaleReport.PerformLayout()
        Me.grpPurchaseReport.ResumeLayout(False)
        Me.grpPurchaseReport.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpCocktailReport.ResumeLayout(False)
        Me.grpCocktailReport.PerformLayout()
        CType(Me.grdCocktailReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpCocktailReport As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpCocktailReport As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdCocktailReport As System.Windows.Forms.DataGridView
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents tltpCocktailreport As System.Windows.Forms.ToolTip
    Friend WithEvents grpSaleReport As System.Windows.Forms.GroupBox
    Friend WithEvents grpPurchaseReport As System.Windows.Forms.GroupBox
    Friend WithEvents lblpurFromDate As System.Windows.Forms.Label
    Friend WithEvents dtpPurFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpurToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPurToDate As System.Windows.Forms.Label
    Friend WithEvents lblSaleBillNo As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents DtSaleToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSaleToDate As System.Windows.Forms.Label
    Friend WithEvents lblSaleFromDate As System.Windows.Forms.Label
    Friend WithEvents dtSaleFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPurTpNo As System.Windows.Forms.Label
    Friend WithEvents txtTpNo As System.Windows.Forms.TextBox
    Friend WithEvents lblinvoice As System.Windows.Forms.Label
    Friend WithEvents txtinvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents grpChataiReportmodify As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents dtchataiToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtchataiFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTotalQty As System.Windows.Forms.Label
    Friend WithEvents lblPurchaseTotal As System.Windows.Forms.Label
    Friend WithEvents txtTimeOut As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSuplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMailReport As System.Windows.Forms.Button
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
