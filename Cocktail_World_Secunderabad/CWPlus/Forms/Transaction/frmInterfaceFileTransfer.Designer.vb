<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterfaceFileTransfer
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dtpDate2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnImportExcel = New System.Windows.Forms.Button()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUseThisFile = New System.Windows.Forms.Button()
        Me.lstFiles = New System.Windows.Forms.ListBox()
        Me.grdBrand = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpDate2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdBrand)
        Me.SplitContainer1.Size = New System.Drawing.Size(808, 458)
        Me.SplitContainer1.SplitterDistance = 158
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 2
        '
        'dtpDate2
        '
        Me.dtpDate2.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate2.Location = New System.Drawing.Point(72, 12)
        Me.dtpDate2.Name = "dtpDate2"
        Me.dtpDate2.Size = New System.Drawing.Size(104, 20)
        Me.dtpDate2.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Date"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.BtnImportExcel)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.btnImport)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(656, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(140, 83)
        Me.Panel1.TabIndex = 23
        '
        'BtnImportExcel
        '
        Me.BtnImportExcel.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.BtnImportExcel.Location = New System.Drawing.Point(3, 53)
        Me.BtnImportExcel.Name = "BtnImportExcel"
        Me.BtnImportExcel.Size = New System.Drawing.Size(133, 26)
        Me.BtnImportExcel.TabIndex = 15
        Me.BtnImportExcel.Text = "Import Excel"
        Me.BtnImportExcel.UseVisualStyleBackColor = True
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(47, 6)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 41)
        Me.imgSave.TabIndex = 12
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Image = Global.CWPlus.My.Resources.Resources.import1
        Me.btnImport.Location = New System.Drawing.Point(2, 7)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(39, 40)
        Me.btnImport.TabIndex = 11
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(96, 6)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 41)
        Me.imgClose.TabIndex = 13
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUseThisFile)
        Me.GroupBox1.Controls.Add(Me.lstFiles)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 110)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Files"
        '
        'btnUseThisFile
        '
        Me.btnUseThisFile.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnUseThisFile.Location = New System.Drawing.Point(308, 46)
        Me.btnUseThisFile.Name = "btnUseThisFile"
        Me.btnUseThisFile.Size = New System.Drawing.Size(40, 42)
        Me.btnUseThisFile.TabIndex = 3
        Me.btnUseThisFile.UseVisualStyleBackColor = True
        '
        'lstFiles
        '
        Me.lstFiles.FormattingEnabled = True
        Me.lstFiles.Location = New System.Drawing.Point(14, 22)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(288, 82)
        Me.lstFiles.TabIndex = 2
        '
        'grdBrand
        '
        Me.grdBrand.AllowDrop = True
        Me.grdBrand.AllowUserToAddRows = False
        Me.grdBrand.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBrand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdBrand.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdBrand.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBrand.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdBrand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBrand.GridColor = System.Drawing.Color.Black
        Me.grdBrand.Location = New System.Drawing.Point(0, 0)
        Me.grdBrand.Name = "grdBrand"
        Me.grdBrand.ReadOnly = True
        Me.grdBrand.Size = New System.Drawing.Size(808, 299)
        Me.grdBrand.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Transfer Interface Report"
        '
        'frmInterfaceFileTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 458)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmInterfaceFileTransfer"
        Me.Text = "frmInterfaceFileTransfer"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdBrand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUseThisFile As System.Windows.Forms.Button
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents grdBrand As System.Windows.Forms.DataGridView
    Friend WithEvents BtnImportExcel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
