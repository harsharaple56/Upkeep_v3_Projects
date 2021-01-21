<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportMaster
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
        Me.cmbMaster = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lnkExport = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFileFormat = New System.Windows.Forms.ComboBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.grdImportData = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdImportData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbMaster
        '
        Me.cmbMaster.FormattingEnabled = True
        Me.cmbMaster.Location = New System.Drawing.Point(136, 32)
        Me.cmbMaster.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbMaster.Name = "cmbMaster"
        Me.cmbMaster.Size = New System.Drawing.Size(196, 22)
        Me.cmbMaster.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Master >>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lnkExport)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbFileFormat)
        Me.GroupBox1.Controls.Add(Me.btnImport)
        Me.GroupBox1.Controls.Add(Me.cmbMaster)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 156)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Master Import"
        '
        'lnkExport
        '
        Me.lnkExport.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lnkExport.Location = New System.Drawing.Point(136, 115)
        Me.lnkExport.Name = "lnkExport"
        Me.lnkExport.Size = New System.Drawing.Size(97, 23)
        Me.lnkExport.TabIndex = 4
        Me.lnkExport.Text = "Export Format"
        Me.lnkExport.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Select Format >>"
        '
        'cmbFileFormat
        '
        Me.cmbFileFormat.FormattingEnabled = True
        Me.cmbFileFormat.Items.AddRange(New Object() {"Microsoft Excel 97-2003"})
        Me.cmbFileFormat.Location = New System.Drawing.Point(136, 72)
        Me.cmbFileFormat.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbFileFormat.Name = "cmbFileFormat"
        Me.cmbFileFormat.Size = New System.Drawing.Size(196, 22)
        Me.cmbFileFormat.TabIndex = 5
        '
        'btnImport
        '
        Me.btnImport.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnImport.Location = New System.Drawing.Point(244, 113)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(88, 26)
        Me.btnImport.TabIndex = 4
        Me.btnImport.Text = "Import Excel"
        Me.btnImport.UseVisualStyleBackColor = True
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdImportData)
        Me.SplitContainer1.Panel2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Size = New System.Drawing.Size(917, 574)
        Me.SplitContainer1.SplitterDistance = 184
        Me.SplitContainer1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.imgClose)
        Me.Panel2.Location = New System.Drawing.Point(812, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(93, 46)
        Me.Panel2.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Image = Global.CWPlus.My.Resources.Resources.save
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 40)
        Me.Button1.TabIndex = 9
        Me.Button1.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(48, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(39, 40)
        Me.imgClose.TabIndex = 11
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblInfo)
        Me.Panel1.Location = New System.Drawing.Point(400, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 54)
        Me.Panel1.TabIndex = 12
        Me.Panel1.Visible = False
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(5, 7)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(49, 15)
        Me.lblInfo.TabIndex = 11
        Me.lblInfo.Text = "Label3"
        '
        'grdImportData
        '
        Me.grdImportData.AllowUserToAddRows = False
        Me.grdImportData.AllowUserToDeleteRows = False
        Me.grdImportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdImportData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdImportData.Location = New System.Drawing.Point(0, 0)
        Me.grdImportData.Name = "grdImportData"
        Me.grdImportData.ReadOnly = True
        Me.grdImportData.Size = New System.Drawing.Size(917, 386)
        Me.grdImportData.TabIndex = 0
        '
        'FrmImportMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 574)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmImportMaster"
        Me.Text = "FrmImportMaster"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdImportData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbMaster As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents grdImportData As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFileFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lnkExport As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
End Class
