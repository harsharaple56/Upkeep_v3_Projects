<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterFaceFileSale
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImportExcel = New System.Windows.Forms.Button()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUseThisFile = New System.Windows.Forms.Button()
        Me.lstFiles = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbBrand = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdBrand = New System.Windows.Forms.DataGridView()
        Me.tbCocktail = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.btnAddCocktail = New System.Windows.Forms.Button()
        Me.cmbCocktail = New System.Windows.Forms.ComboBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.grdCocktail = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbBrand.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCocktail.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.grdCocktail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpDate)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(875, 529)
        Me.SplitContainer1.SplitterDistance = 157
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.BtnImportExcel)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.btnImport)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(721, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 83)
        Me.Panel1.TabIndex = 23
        '
        'BtnImportExcel
        '
        Me.BtnImportExcel.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.BtnImportExcel.Location = New System.Drawing.Point(3, 51)
        Me.BtnImportExcel.Name = "BtnImportExcel"
        Me.BtnImportExcel.Size = New System.Drawing.Size(134, 26)
        Me.BtnImportExcel.TabIndex = 16
        Me.BtnImportExcel.Text = "Import Excel"
        Me.BtnImportExcel.UseVisualStyleBackColor = True
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(48, 5)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 41)
        Me.imgSave.TabIndex = 12
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Image = Global.CWPlus.My.Resources.Resources.import1
        Me.btnImport.Location = New System.Drawing.Point(3, 6)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(39, 40)
        Me.btnImport.TabIndex = 11
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(97, 5)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 41)
        Me.imgClose.TabIndex = 13
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUseThisFile)
        Me.GroupBox1.Controls.Add(Me.lstFiles)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 107)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Files"
        '
        'btnUseThisFile
        '
        Me.btnUseThisFile.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnUseThisFile.Location = New System.Drawing.Point(537, 19)
        Me.btnUseThisFile.Name = "btnUseThisFile"
        Me.btnUseThisFile.Size = New System.Drawing.Size(40, 42)
        Me.btnUseThisFile.TabIndex = 3
        Me.btnUseThisFile.UseVisualStyleBackColor = True
        '
        'lstFiles
        '
        Me.lstFiles.FormattingEnabled = True
        Me.lstFiles.Location = New System.Drawing.Point(17, 19)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(514, 82)
        Me.lstFiles.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(49, 12)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(104, 20)
        Me.dtpDate.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbBrand)
        Me.TabControl1.Controls.Add(Me.tbCocktail)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(875, 371)
        Me.TabControl1.TabIndex = 4
        '
        'tbBrand
        '
        Me.tbBrand.Controls.Add(Me.SplitContainer2)
        Me.tbBrand.Location = New System.Drawing.Point(4, 22)
        Me.tbBrand.Name = "tbBrand"
        Me.tbBrand.Padding = New System.Windows.Forms.Padding(3)
        Me.tbBrand.Size = New System.Drawing.Size(867, 345)
        Me.tbBrand.TabIndex = 0
        Me.tbBrand.Text = "Brand"
        Me.tbBrand.UseVisualStyleBackColor = True
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblStock)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnAdd)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbBrand)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbSize)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grdBrand)
        Me.SplitContainer2.Size = New System.Drawing.Size(861, 339)
        Me.SplitContainer2.SplitterDistance = 39
        Me.SplitContainer2.TabIndex = 1
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.Location = New System.Drawing.Point(478, 11)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(0, 19)
        Me.lblStock.TabIndex = 21
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(390, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(47, 28)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cmbBrand
        '
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(53, 11)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(162, 21)
        Me.cmbBrand.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(221, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Size"
        '
        'cmbSize
        '
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(254, 11)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(121, 21)
        Me.cmbSize.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Brand"
        '
        'grdBrand
        '
        Me.grdBrand.AllowUserToAddRows = False
        Me.grdBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBrand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrand.Location = New System.Drawing.Point(0, 0)
        Me.grdBrand.Name = "grdBrand"
        Me.grdBrand.Size = New System.Drawing.Size(861, 296)
        Me.grdBrand.TabIndex = 0
        '
        'tbCocktail
        '
        Me.tbCocktail.Controls.Add(Me.SplitContainer3)
        Me.tbCocktail.Location = New System.Drawing.Point(4, 22)
        Me.tbCocktail.Name = "tbCocktail"
        Me.tbCocktail.Padding = New System.Windows.Forms.Padding(3)
        Me.tbCocktail.Size = New System.Drawing.Size(867, 345)
        Me.tbCocktail.TabIndex = 1
        Me.tbCocktail.Text = "Cocktail"
        Me.tbCocktail.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnAddCocktail)
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmbCocktail)
        Me.SplitContainer3.Panel1.Controls.Add(Me.lbl)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.grdCocktail)
        Me.SplitContainer3.Size = New System.Drawing.Size(861, 339)
        Me.SplitContainer3.SplitterDistance = 39
        Me.SplitContainer3.TabIndex = 2
        '
        'btnAddCocktail
        '
        Me.btnAddCocktail.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAddCocktail.Location = New System.Drawing.Point(231, 4)
        Me.btnAddCocktail.Name = "btnAddCocktail"
        Me.btnAddCocktail.Size = New System.Drawing.Size(47, 28)
        Me.btnAddCocktail.TabIndex = 9
        Me.btnAddCocktail.UseVisualStyleBackColor = True
        '
        'cmbCocktail
        '
        Me.cmbCocktail.FormattingEnabled = True
        Me.cmbCocktail.Location = New System.Drawing.Point(63, 11)
        Me.cmbCocktail.Name = "cmbCocktail"
        Me.cmbCocktail.Size = New System.Drawing.Size(162, 21)
        Me.cmbCocktail.TabIndex = 8
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(12, 14)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(45, 13)
        Me.lbl.TabIndex = 6
        Me.lbl.Text = "Cocktail"
        '
        'grdCocktail
        '
        Me.grdCocktail.AllowUserToAddRows = False
        Me.grdCocktail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCocktail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCocktail.Location = New System.Drawing.Point(0, 0)
        Me.grdCocktail.Name = "grdCocktail"
        Me.grdCocktail.Size = New System.Drawing.Size(861, 296)
        Me.grdCocktail.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Sale Interface Report"
        '
        'frmInterFaceFileSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 529)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmInterFaceFileSale"
        Me.Text = "frmInterFaceFileSale"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbBrand.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCocktail.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.grdCocktail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdBrand As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbBrand As System.Windows.Forms.TabPage
    Friend WithEvents tbCocktail As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbCocktail As System.Windows.Forms.ComboBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents grdCocktail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents btnUseThisFile As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnAddCocktail As System.Windows.Forms.Button
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents BtnImportExcel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
