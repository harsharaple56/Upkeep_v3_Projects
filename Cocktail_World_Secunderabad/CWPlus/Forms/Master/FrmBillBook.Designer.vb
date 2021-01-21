<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBillBook
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
        Me.grdBillMaster = New System.Windows.Forms.DataGridView()
        Me.BillID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LicenseNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillStNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillEndNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblBillID = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grdBillMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdBillMaster
        '
        Me.grdBillMaster.AllowDrop = True
        Me.grdBillMaster.AllowUserToAddRows = False
        Me.grdBillMaster.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdBillMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBillMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BillID, Me.LicenseID, Me.LicenseNo, Me.BillStNo, Me.BillEndNo, Me.CurrentBillNo})
        Me.grdBillMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBillMaster.Location = New System.Drawing.Point(0, 0)
        Me.grdBillMaster.Name = "grdBillMaster"
        Me.grdBillMaster.Size = New System.Drawing.Size(460, 244)
        Me.grdBillMaster.TabIndex = 1
        '
        'BillID
        '
        Me.BillID.HeaderText = "BillID"
        Me.BillID.Name = "BillID"
        Me.BillID.Visible = False
        '
        'LicenseID
        '
        Me.LicenseID.HeaderText = "LicenseID"
        Me.LicenseID.Name = "LicenseID"
        Me.LicenseID.Visible = False
        '
        'LicenseNo
        '
        Me.LicenseNo.HeaderText = "LicenseNumber"
        Me.LicenseNo.Name = "LicenseNo"
        '
        'BillStNo
        '
        Me.BillStNo.HeaderText = "BillStart Number"
        Me.BillStNo.Name = "BillStNo"
        '
        'BillEndNo
        '
        Me.BillEndNo.HeaderText = "BillEnd Number"
        Me.BillEndNo.Name = "BillEndNo"
        '
        'CurrentBillNo
        '
        Me.CurrentBillNo.HeaderText = "CurrentBill Number"
        Me.CurrentBillNo.Name = "CurrentBillNo"
        '
        'lblBillID
        '
        Me.lblBillID.AutoSize = True
        Me.lblBillID.Location = New System.Drawing.Point(512, 82)
        Me.lblBillID.Name = "lblBillID"
        Me.lblBillID.Size = New System.Drawing.Size(13, 13)
        Me.lblBillID.TabIndex = 2
        Me.lblBillID.Text = "0"
        Me.lblBillID.Visible = False
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdBillMaster)
        Me.SplitContainer1.Size = New System.Drawing.Size(460, 318)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Location = New System.Drawing.Point(357, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 50)
        Me.Panel1.TabIndex = 12
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(52, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(41, 43)
        Me.imgClose.TabIndex = 3
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 4)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(43, 43)
        Me.imgSave.TabIndex = 2
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'FrmBillBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 318)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblBillID)
        Me.Name = "FrmBillBook"
        Me.Text = "FrmBillBook"
        CType(Me.grdBillMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdBillMaster As System.Windows.Forms.DataGridView
    Friend WithEvents lblBillID As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents BillID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LicenseNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillStNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillEndNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
End Class
