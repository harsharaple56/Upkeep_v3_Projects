<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvalGeneralSetup
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chklstOperations = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHidden = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.cmbUserName = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdBulkInsertFilePath = New System.Windows.Forms.DataGridView()
        Me.clnOpeationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnConnectionString = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clnFilePrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSaveFilePath = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdBulkInsertFilePath, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Location = New System.Drawing.Point(746, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(101, 45)
        Me.Panel1.TabIndex = 26
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(53, 2)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 42)
        Me.imgClose.TabIndex = 29
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 2)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(44, 42)
        Me.imgSave.TabIndex = 27
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(630, 398)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chklstOperations)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(622, 372)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Interface Set Up"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chklstOperations
        '
        Me.chklstOperations.FormattingEnabled = True
        Me.chklstOperations.Location = New System.Drawing.Point(-6, 66)
        Me.chklstOperations.MultiColumn = True
        Me.chklstOperations.Name = "chklstOperations"
        Me.chklstOperations.Size = New System.Drawing.Size(226, 154)
        Me.chklstOperations.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHidden)
        Me.GroupBox1.Controls.Add(Me.lblUserName)
        Me.GroupBox1.Controls.Add(Me.cmbUserName)
        Me.GroupBox1.Location = New System.Drawing.Point(-6, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 56)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User-Interface Generator Rights"
        '
        'txtHidden
        '
        Me.txtHidden.Location = New System.Drawing.Point(231, 14)
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.Size = New System.Drawing.Size(30, 20)
        Me.txtHidden.TabIndex = 6
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(5, 22)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(55, 13)
        Me.lblUserName.TabIndex = 3
        Me.lblUserName.Text = "Username"
        '
        'cmbUserName
        '
        Me.cmbUserName.FormattingEnabled = True
        Me.cmbUserName.Location = New System.Drawing.Point(75, 19)
        Me.cmbUserName.Name = "cmbUserName"
        Me.cmbUserName.Size = New System.Drawing.Size(140, 21)
        Me.cmbUserName.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdBulkInsertFilePath)
        Me.TabPage2.Controls.Add(Me.btnSaveFilePath)
        Me.TabPage2.Controls.Add(Me.txtFilePath)
        Me.TabPage2.Controls.Add(Me.lblFilePath)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(622, 372)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Save File Path"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdBulkInsertFilePath
        '
        Me.grdBulkInsertFilePath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBulkInsertFilePath.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnOpeationName, Me.clnFilePath, Me.clnConnectionString, Me.clnFilePrefix})
        Me.grdBulkInsertFilePath.Location = New System.Drawing.Point(0, 71)
        Me.grdBulkInsertFilePath.Name = "grdBulkInsertFilePath"
        Me.grdBulkInsertFilePath.Size = New System.Drawing.Size(607, 295)
        Me.grdBulkInsertFilePath.TabIndex = 29
        '
        'clnOpeationName
        '
        Me.clnOpeationName.HeaderText = "Operation Name"
        Me.clnOpeationName.Name = "clnOpeationName"
        '
        'clnFilePath
        '
        Me.clnFilePath.HeaderText = "File Location"
        Me.clnFilePath.Name = "clnFilePath"
        '
        'clnConnectionString
        '
        Me.clnConnectionString.HeaderText = "Connection String"
        Me.clnConnectionString.Name = "clnConnectionString"
        '
        'clnFilePrefix
        '
        Me.clnFilePrefix.HeaderText = "File Prefix"
        Me.clnFilePrefix.Name = "clnFilePrefix"
        '
        'btnSaveFilePath
        '
        Me.btnSaveFilePath.Image = Global.CWPlus.My.Resources.Resources.save
        Me.btnSaveFilePath.Location = New System.Drawing.Point(541, 21)
        Me.btnSaveFilePath.Name = "btnSaveFilePath"
        Me.btnSaveFilePath.Size = New System.Drawing.Size(44, 42)
        Me.btnSaveFilePath.TabIndex = 28
        Me.btnSaveFilePath.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(64, 21)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(339, 20)
        Me.txtFilePath.TabIndex = 1
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Location = New System.Drawing.Point(10, 21)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(48, 13)
        Me.lblFilePath.TabIndex = 0
        Me.lblFilePath.Text = "File Path"
        '
        'FrmEvalGeneralSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 452)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmEvalGeneralSetup"
        Me.Text = "FrmEvalGeneralSetup"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.grdBulkInsertFilePath, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chklstOperations As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHidden As System.Windows.Forms.TextBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents cmbUserName As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdBulkInsertFilePath As System.Windows.Forms.DataGridView
    Friend WithEvents btnSaveFilePath As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents clnOpeationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clnFilePath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clnConnectionString As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clnFilePrefix As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
