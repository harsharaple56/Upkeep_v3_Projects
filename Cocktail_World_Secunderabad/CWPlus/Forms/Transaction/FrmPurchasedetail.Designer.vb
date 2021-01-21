<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPurchasedetail
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtTodate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chkdatewise = New System.Windows.Forms.CheckBox()
        Me.lblid = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.txtTpno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdpurchasedetail = New System.Windows.Forms.DataGridView()
        Me.btnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnrem = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tltpText = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdpurchasedetail, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdpurchasedetail)
        Me.SplitContainer1.Size = New System.Drawing.Size(969, 472)
        Me.SplitContainer1.SplitterDistance = 111
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(867, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(99, 54)
        Me.Panel1.TabIndex = 13
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(3, 3)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(42, 44)
        Me.imgNew.TabIndex = 8
        Me.tltpText.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(51, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 44)
        Me.imgClose.TabIndex = 9
        Me.tltpText.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtTodate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Chkdatewise)
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Dtdate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceNo)
        Me.GroupBox1.Controls.Add(Me.txtTpno)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Purchase Detail"
        '
        'dtTodate
        '
        Me.dtTodate.CustomFormat = "dd/MM/yyyy"
        Me.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTodate.Location = New System.Drawing.Point(261, 24)
        Me.dtTodate.Name = "dtTodate"
        Me.dtTodate.Size = New System.Drawing.Size(130, 21)
        Me.dtTodate.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(203, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "To Date"
        '
        'Chkdatewise
        '
        Me.Chkdatewise.AutoSize = True
        Me.Chkdatewise.Location = New System.Drawing.Point(397, 28)
        Me.Chkdatewise.Name = "Chkdatewise"
        Me.Chkdatewise.Size = New System.Drawing.Size(103, 17)
        Me.Chkdatewise.TabIndex = 3
        Me.Chkdatewise.Text = "Select Datewise"
        Me.Chkdatewise.UseVisualStyleBackColor = True
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(457, 69)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(14, 13)
        Me.lblid.TabIndex = 2
        Me.lblid.Text = "0"
        Me.lblid.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.CWPlus.My.Resources.Resources.search__1_
        Me.btnSearch.Location = New System.Drawing.Point(406, 63)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(45, 31)
        Me.btnSearch.TabIndex = 6
        Me.tltpText.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Dtdate
        '
        Me.Dtdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtdate.Location = New System.Drawing.Point(79, 26)
        Me.Dtdate.Name = "Dtdate"
        Me.Dtdate.Size = New System.Drawing.Size(118, 21)
        Me.Dtdate.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "From Date"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(284, 69)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(116, 21)
        Me.txtInvoiceNo.TabIndex = 5
        '
        'txtTpno
        '
        Me.txtTpno.Location = New System.Drawing.Point(79, 73)
        Me.txtTpno.Name = "txtTpno"
        Me.txtTpno.Size = New System.Drawing.Size(118, 21)
        Me.txtTpno.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "INVoiceNo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TPNo"
        '
        'grdpurchasedetail
        '
        Me.grdpurchasedetail.AllowDrop = True
        Me.grdpurchasedetail.AllowUserToAddRows = False
        Me.grdpurchasedetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdpurchasedetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grdpurchasedetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdpurchasedetail.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdpurchasedetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpurchasedetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnEdit, Me.btnrem})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdpurchasedetail.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdpurchasedetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdpurchasedetail.GridColor = System.Drawing.Color.Black
        Me.grdpurchasedetail.Location = New System.Drawing.Point(0, 0)
        Me.grdpurchasedetail.Name = "grdpurchasedetail"
        Me.grdpurchasedetail.ReadOnly = True
        Me.grdpurchasedetail.Size = New System.Drawing.Size(969, 357)
        Me.grdpurchasedetail.TabIndex = 7
        '
        'btnEdit
        '
        Me.btnEdit.HeaderText = "Edit"
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ReadOnly = True
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.ToolTipText = "Edit"
        Me.btnEdit.UseColumnTextForButtonValue = True
        Me.btnEdit.Width = 60
        '
        'btnrem
        '
        Me.btnrem.HeaderText = "Delete"
        Me.btnrem.Name = "btnrem"
        Me.btnrem.ReadOnly = True
        Me.btnrem.Text = "Delete"
        Me.btnrem.ToolTipText = "Delete"
        Me.btnrem.UseColumnTextForButtonValue = True
        Me.btnrem.Width = 60
        '
        'tltpText
        '
        Me.tltpText.IsBalloon = True
        '
        'FrmPurchasedetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 472)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmPurchasedetail"
        Me.Text = "FrmPurchasedetail"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdpurchasedetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Dtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTpno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdpurchasedetail As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Chkdatewise As System.Windows.Forms.CheckBox
    Friend WithEvents btnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnrem As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents tltpText As System.Windows.Forms.ToolTip
    Friend WithEvents dtTodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
