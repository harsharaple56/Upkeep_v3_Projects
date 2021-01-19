<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneralSetup
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
        Me.imgClose = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.grdGeneralSetup = New System.Windows.Forms.DataGridView()
        Me.reportid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reportname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ok = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.excel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.crystal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pdf = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.filter = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.iscombine = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkFlivAdd = New System.Windows.Forms.CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.grdMenus = New System.Windows.Forms.DataGridView()
        Me.ChkAllowNegativeStock = New System.Windows.Forms.CheckBox()
        Me.ChkOnlyInventory = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbBrandwise = New System.Windows.Forms.RadioButton()
        Me.rdbCategorywise = New System.Windows.Forms.RadioButton()
        Me.rdbSubCategorywise = New System.Windows.Forms.RadioButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdGeneralSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.grdMenus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.imgClose)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(827, 470)
        Me.SplitContainer1.SplitterDistance = 53
        Me.SplitContainer1.TabIndex = 0
        '
        'imgClose
        '
        Me.imgClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(771, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 44)
        Me.imgClose.TabIndex = 10
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(827, 413)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(819, 387)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report Button Setup"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdGeneralSetup)
        Me.SplitContainer2.Size = New System.Drawing.Size(813, 381)
        Me.SplitContainer2.SplitterDistance = 59
        Me.SplitContainer2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Location = New System.Drawing.Point(762, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(54, 52)
        Me.Panel1.TabIndex = 23
        '
        'imgSave
        '
        Me.imgSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 5)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 44)
        Me.imgSave.TabIndex = 9
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'grdGeneralSetup
        '
        Me.grdGeneralSetup.AllowDrop = True
        Me.grdGeneralSetup.AllowUserToAddRows = False
        Me.grdGeneralSetup.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdGeneralSetup.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdGeneralSetup.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdGeneralSetup.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdGeneralSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdGeneralSetup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.reportid, Me.reportname, Me.ok, Me.excel, Me.crystal, Me.pdf, Me.filter, Me.iscombine})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdGeneralSetup.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdGeneralSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdGeneralSetup.GridColor = System.Drawing.Color.Black
        Me.grdGeneralSetup.Location = New System.Drawing.Point(0, 0)
        Me.grdGeneralSetup.Name = "grdGeneralSetup"
        Me.grdGeneralSetup.Size = New System.Drawing.Size(813, 318)
        Me.grdGeneralSetup.TabIndex = 14
        '
        'reportid
        '
        Me.reportid.HeaderText = "ReportID"
        Me.reportid.Name = "reportid"
        '
        'reportname
        '
        Me.reportname.HeaderText = "Report Name"
        Me.reportname.Name = "reportname"
        '
        'ok
        '
        Me.ok.HeaderText = "Button Ok"
        Me.ok.Name = "ok"
        Me.ok.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ok.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'excel
        '
        Me.excel.HeaderText = "Button Excel"
        Me.excel.Name = "excel"
        Me.excel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.excel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'crystal
        '
        Me.crystal.HeaderText = "Button Crystal"
        Me.crystal.Name = "crystal"
        Me.crystal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.crystal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'pdf
        '
        Me.pdf.HeaderText = "Button PDF"
        Me.pdf.Name = "pdf"
        Me.pdf.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pdf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'filter
        '
        Me.filter.HeaderText = "Button Filter"
        Me.filter.Name = "filter"
        Me.filter.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.filter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'iscombine
        '
        Me.iscombine.HeaderText = "Button ISCombine"
        Me.iscombine.Name = "iscombine"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.ChkOnlyInventory)
        Me.TabPage2.Controls.Add(Me.ChkAllowNegativeStock)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.chkFlivAdd)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(819, 387)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General Setup"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.CWPlus.My.Resources.Resources.save
        Me.Button1.Location = New System.Drawing.Point(770, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 44)
        Me.Button1.TabIndex = 10
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkFlivAdd
        '
        Me.chkFlivAdd.AutoSize = True
        Me.chkFlivAdd.Location = New System.Drawing.Point(24, 23)
        Me.chkFlivAdd.Name = "chkFlivAdd"
        Me.chkFlivAdd.Size = New System.Drawing.Size(89, 17)
        Me.chkFlivAdd.TabIndex = 0
        Me.chkFlivAdd.Text = "FLIV Address"
        Me.chkFlivAdd.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.txtClientName)
        Me.TabPage3.Controls.Add(Me.lblClient)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(819, 387)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Client Master"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.CWPlus.My.Resources.Resources.save
        Me.Button2.Location = New System.Drawing.Point(770, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 44)
        Me.Button2.TabIndex = 11
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtClientName
        '
        Me.txtClientName.Location = New System.Drawing.Point(105, 20)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(210, 20)
        Me.txtClientName.TabIndex = 2
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Location = New System.Drawing.Point(8, 23)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(69, 13)
        Me.lblClient.TabIndex = 1
        Me.lblClient.Text = "Clients Name"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SplitContainer3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(819, 387)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Menu Priority"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Button3)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblMenu)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmbMenu)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.grdMenus)
        Me.SplitContainer3.Size = New System.Drawing.Size(813, 381)
        Me.SplitContainer3.SplitterDistance = 58
        Me.SplitContainer3.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Image = Global.CWPlus.My.Resources.Resources.save
        Me.Button3.Location = New System.Drawing.Point(761, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(43, 44)
        Me.Button3.TabIndex = 11
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Location = New System.Drawing.Point(17, 22)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(34, 13)
        Me.lblMenu.TabIndex = 4
        Me.lblMenu.Text = "Menu"
        '
        'cmbMenu
        '
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Location = New System.Drawing.Point(69, 19)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(140, 21)
        Me.cmbMenu.TabIndex = 2
        '
        'grdMenus
        '
        Me.grdMenus.AllowUserToAddRows = False
        Me.grdMenus.AllowUserToDeleteRows = False
        Me.grdMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMenus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMenus.Location = New System.Drawing.Point(0, 0)
        Me.grdMenus.Name = "grdMenus"
        Me.grdMenus.Size = New System.Drawing.Size(813, 319)
        Me.grdMenus.TabIndex = 0
        '
        'ChkAllowNegativeStock
        '
        Me.ChkAllowNegativeStock.AutoSize = True
        Me.ChkAllowNegativeStock.Location = New System.Drawing.Point(144, 23)
        Me.ChkAllowNegativeStock.Name = "ChkAllowNegativeStock"
        Me.ChkAllowNegativeStock.Size = New System.Drawing.Size(122, 17)
        Me.ChkAllowNegativeStock.TabIndex = 11
        Me.ChkAllowNegativeStock.Text = "AllowNegativeStock"
        Me.ChkAllowNegativeStock.UseVisualStyleBackColor = True
        '
        'ChkOnlyInventory
        '
        Me.ChkOnlyInventory.AutoSize = True
        Me.ChkOnlyInventory.Location = New System.Drawing.Point(281, 21)
        Me.ChkOnlyInventory.Name = "ChkOnlyInventory"
        Me.ChkOnlyInventory.Size = New System.Drawing.Size(91, 17)
        Me.ChkOnlyInventory.TabIndex = 12
        Me.ChkOnlyInventory.Text = "OnlyInventory"
        Me.ChkOnlyInventory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbSubCategorywise)
        Me.GroupBox1.Controls.Add(Me.rdbCategorywise)
        Me.GroupBox1.Controls.Add(Me.rdbBrandwise)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 56)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Karnataka Daily Report"
        '
        'rdbBrandwise
        '
        Me.rdbBrandwise.AutoSize = True
        Me.rdbBrandwise.Location = New System.Drawing.Point(16, 19)
        Me.rdbBrandwise.Name = "rdbBrandwise"
        Me.rdbBrandwise.Size = New System.Drawing.Size(77, 17)
        Me.rdbBrandwise.TabIndex = 0
        Me.rdbBrandwise.TabStop = True
        Me.rdbBrandwise.Text = "Brand wise"
        Me.rdbBrandwise.UseVisualStyleBackColor = True
        '
        'rdbCategorywise
        '
        Me.rdbCategorywise.AutoSize = True
        Me.rdbCategorywise.Location = New System.Drawing.Point(120, 19)
        Me.rdbCategorywise.Name = "rdbCategorywise"
        Me.rdbCategorywise.Size = New System.Drawing.Size(91, 17)
        Me.rdbCategorywise.TabIndex = 1
        Me.rdbCategorywise.TabStop = True
        Me.rdbCategorywise.Text = "Category wise"
        Me.rdbCategorywise.UseVisualStyleBackColor = True
        '
        'rdbSubCategorywise
        '
        Me.rdbSubCategorywise.AutoSize = True
        Me.rdbSubCategorywise.Location = New System.Drawing.Point(257, 19)
        Me.rdbSubCategorywise.Name = "rdbSubCategorywise"
        Me.rdbSubCategorywise.Size = New System.Drawing.Size(113, 17)
        Me.rdbSubCategorywise.TabIndex = 2
        Me.rdbSubCategorywise.TabStop = True
        Me.rdbSubCategorywise.Text = "Sub-Category wise"
        Me.rdbSubCategorywise.UseVisualStyleBackColor = True
        '
        'frmGeneralSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 470)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmGeneralSetup"
        Me.Text = "frmGeneralSetup"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdGeneralSetup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.grdMenus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdGeneralSetup As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkFlivAdd As System.Windows.Forms.CheckBox
    Friend WithEvents reportid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reportname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ok As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents excel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents crystal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pdf As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents filter As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents iscombine As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblClient As System.Windows.Forms.Label
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdMenus As System.Windows.Forms.DataGridView
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents cmbMenu As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ChkOnlyInventory As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAllowNegativeStock As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbSubCategorywise As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCategorywise As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBrandwise As System.Windows.Forms.RadioButton
End Class
