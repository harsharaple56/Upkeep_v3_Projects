<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransferList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.Sale = New System.Windows.Forms.GroupBox()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTransferDate = New System.Windows.Forms.CheckBox()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.lblTransferHeadID = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblTPlNo = New System.Windows.Forms.Label()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTransferDAte = New System.Windows.Forms.Label()
        Me.txtTPNo = New System.Windows.Forms.TextBox()
        Me.grdTransferList = New System.Windows.Forms.DataGridView()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ttlp = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Sale.SuspendLayout()
        CType(Me.grdTransferList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Sale)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdTransferList)
        Me.SplitContainer1.Size = New System.Drawing.Size(750, 417)
        Me.SplitContainer1.SplitterDistance = 108
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(648, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(99, 54)
        Me.Panel1.TabIndex = 12
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(3, 3)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(42, 44)
        Me.imgNew.TabIndex = 8
        Me.ttlp.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(51, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 44)
        Me.imgClose.TabIndex = 9
        Me.ttlp.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'Sale
        '
        Me.Sale.Controls.Add(Me.dtFromDate)
        Me.Sale.Controls.Add(Me.Label1)
        Me.Sale.Controls.Add(Me.chkTransferDate)
        Me.Sale.Controls.Add(Me.lblInvoice)
        Me.Sale.Controls.Add(Me.lblTransferHeadID)
        Me.Sale.Controls.Add(Me.txtInvoiceNo)
        Me.Sale.Controls.Add(Me.btnSearch)
        Me.Sale.Controls.Add(Me.lblTPlNo)
        Me.Sale.Controls.Add(Me.dtToDate)
        Me.Sale.Controls.Add(Me.lblTransferDAte)
        Me.Sale.Controls.Add(Me.txtTPNo)
        Me.Sale.Location = New System.Drawing.Point(12, 8)
        Me.Sale.Name = "Sale"
        Me.Sale.Size = New System.Drawing.Size(523, 95)
        Me.Sale.TabIndex = 11
        Me.Sale.TabStop = False
        Me.Sale.Text = "Transfer"
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
        'chkTransferDate
        '
        Me.chkTransferDate.AutoSize = True
        Me.chkTransferDate.Location = New System.Drawing.Point(405, 18)
        Me.chkTransferDate.Name = "chkTransferDate"
        Me.chkTransferDate.Size = New System.Drawing.Size(103, 17)
        Me.chkTransferDate.TabIndex = 3
        Me.chkTransferDate.Text = "Select Datewise"
        Me.chkTransferDate.UseVisualStyleBackColor = True
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
        'btnSearch
        '
        Me.btnSearch.Image = Global.CWPlus.My.Resources.Resources.search__1_
        Me.btnSearch.Location = New System.Drawing.Point(453, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(43, 39)
        Me.btnSearch.TabIndex = 6
        Me.ttlp.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = True
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
        'grdTransferList
        '
        Me.grdTransferList.AllowDrop = True
        Me.grdTransferList.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTransferList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTransferList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdTransferList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdTransferList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTransferList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit, Me.Delete})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTransferList.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdTransferList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTransferList.GridColor = System.Drawing.Color.Black
        Me.grdTransferList.Location = New System.Drawing.Point(0, 0)
        Me.grdTransferList.Name = "grdTransferList"
        Me.grdTransferList.Size = New System.Drawing.Size(750, 305)
        Me.grdTransferList.TabIndex = 7
        '
        'Edit
        '
        Me.Edit.HeaderText = "Edit"
        Me.Edit.Name = "Edit"
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Edit.Text = "Edit"
        Me.Edit.UseColumnTextForButtonValue = True
        '
        'Delete
        '
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        Me.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Delete.Text = "Delete"
        Me.Delete.UseColumnTextForButtonValue = True
        '
        'ttlp
        '
        Me.ttlp.IsBalloon = True
        '
        'FrmTransferList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 417)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmTransferList"
        Me.Text = "FrmTransferList"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Sale.ResumeLayout(False)
        Me.Sale.PerformLayout()
        CType(Me.grdTransferList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdTransferList As System.Windows.Forms.DataGridView
    Friend WithEvents lblTransferHeadID As System.Windows.Forms.Label
    Friend WithEvents Sale As System.Windows.Forms.GroupBox
    Friend WithEvents lblInvoice As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblTPlNo As System.Windows.Forms.Label
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTransferDAte As System.Windows.Forms.Label
    Friend WithEvents txtTPNo As System.Windows.Forms.TextBox
    Friend WithEvents chkTransferDate As System.Windows.Forms.CheckBox
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Delete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents ttlp As System.Windows.Forms.ToolTip
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
