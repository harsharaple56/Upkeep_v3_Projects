<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrnSaleList
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
        Me.chkSale = New System.Windows.Forms.CheckBox()
        Me.lblSaleID = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.lblBillDAte = New System.Windows.Forms.Label()
        Me.txtBillno = New System.Windows.Forms.TextBox()
        Me.grdSaleList = New System.Windows.Forms.DataGridView()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ttlp = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Sale.SuspendLayout()
        CType(Me.grdSaleList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Sale)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdSaleList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Size = New System.Drawing.Size(901, 393)
        Me.SplitContainer1.SplitterDistance = 109
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(795, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(103, 48)
        Me.Panel1.TabIndex = 12
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(3, 3)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(42, 38)
        Me.imgNew.TabIndex = 7
        Me.ttlp.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(51, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(43, 37)
        Me.imgClose.TabIndex = 8
        Me.ttlp.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'Sale
        '
        Me.Sale.Controls.Add(Me.dtFromDate)
        Me.Sale.Controls.Add(Me.Label1)
        Me.Sale.Controls.Add(Me.chkSale)
        Me.Sale.Controls.Add(Me.lblSaleID)
        Me.Sale.Controls.Add(Me.btnSearch)
        Me.Sale.Controls.Add(Me.lblBillNo)
        Me.Sale.Controls.Add(Me.dtToDate)
        Me.Sale.Controls.Add(Me.lblBillDAte)
        Me.Sale.Controls.Add(Me.txtBillno)
        Me.Sale.Location = New System.Drawing.Point(3, 9)
        Me.Sale.Name = "Sale"
        Me.Sale.Size = New System.Drawing.Size(479, 91)
        Me.Sale.TabIndex = 10
        Me.Sale.TabStop = False
        Me.Sale.Text = "Sale"
        '
        'dtFromDate
        '
        Me.dtFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromDate.Location = New System.Drawing.Point(75, 19)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(107, 20)
        Me.dtFromDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "From Date"
        '
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(366, 21)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(103, 17)
        Me.chkSale.TabIndex = 3
        Me.chkSale.Text = "Select Datewise"
        Me.chkSale.UseVisualStyleBackColor = True
        '
        'lblSaleID
        '
        Me.lblSaleID.AutoSize = True
        Me.lblSaleID.Location = New System.Drawing.Point(377, 62)
        Me.lblSaleID.Name = "lblSaleID"
        Me.lblSaleID.Size = New System.Drawing.Size(13, 13)
        Me.lblSaleID.TabIndex = 0
        Me.lblSaleID.Text = "0"
        Me.lblSaleID.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.CWPlus.My.Resources.Resources.search__1_
        Me.btnSearch.Location = New System.Drawing.Point(193, 49)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(43, 31)
        Me.btnSearch.TabIndex = 5
        Me.ttlp.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblBillNo
        '
        Me.lblBillNo.AutoSize = True
        Me.lblBillNo.Location = New System.Drawing.Point(16, 58)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(60, 13)
        Me.lblBillNo.TabIndex = 1
        Me.lblBillNo.Text = "Bill Number"
        '
        'dtToDate
        '
        Me.dtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToDate.Location = New System.Drawing.Point(242, 19)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(107, 20)
        Me.dtToDate.TabIndex = 2
        '
        'lblBillDAte
        '
        Me.lblBillDAte.AutoSize = True
        Me.lblBillDAte.Location = New System.Drawing.Point(190, 21)
        Me.lblBillDAte.Name = "lblBillDAte"
        Me.lblBillDAte.Size = New System.Drawing.Size(46, 13)
        Me.lblBillDAte.TabIndex = 5
        Me.lblBillDAte.Text = "To Date"
        '
        'txtBillno
        '
        Me.txtBillno.Location = New System.Drawing.Point(82, 55)
        Me.txtBillno.Name = "txtBillno"
        Me.txtBillno.Size = New System.Drawing.Size(100, 20)
        Me.txtBillno.TabIndex = 4
        '
        'grdSaleList
        '
        Me.grdSaleList.AllowDrop = True
        Me.grdSaleList.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdSaleList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdSaleList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdSaleList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSaleList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit, Me.Delete})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdSaleList.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdSaleList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSaleList.GridColor = System.Drawing.Color.Black
        Me.grdSaleList.Location = New System.Drawing.Point(0, 0)
        Me.grdSaleList.Name = "grdSaleList"
        Me.grdSaleList.Size = New System.Drawing.Size(901, 280)
        Me.grdSaleList.TabIndex = 6
        '
        'Edit
        '
        Me.Edit.HeaderText = "Edit"
        Me.Edit.Name = "Edit"
        Me.Edit.Text = "Edit"
        Me.Edit.UseColumnTextForButtonValue = True
        '
        'Delete
        '
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        Me.Delete.Text = "Delete"
        Me.Delete.UseColumnTextForButtonValue = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(148, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ttlp
        '
        Me.ttlp.IsBalloon = True
        '
        'FrnSaleList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 393)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrnSaleList"
        Me.Text = "FrnSaleList"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Sale.ResumeLayout(False)
        Me.Sale.PerformLayout()
        CType(Me.grdSaleList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdSaleList As System.Windows.Forms.DataGridView
    Friend WithEvents lblSaleID As System.Windows.Forms.Label
    Friend WithEvents lblBillDAte As System.Windows.Forms.Label
    Friend WithEvents txtBillno As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents Sale As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents chkSale As System.Windows.Forms.CheckBox
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Delete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents ttlp As System.Windows.Forms.ToolTip
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
