<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParameter
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbParameter = New System.Windows.Forms.ComboBox()
        Me.txtParameterDesc = New System.Windows.Forms.TextBox()
        Me.lblBehaviour = New System.Windows.Forms.Label()
        Me.lblParameterDesc = New System.Windows.Forms.Label()
        Me.lblParameterID = New System.Windows.Forms.Label()
        Me.lblPName = New System.Windows.Forms.Label()
        Me.txtParameterName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.grdParameter = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdParameter, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdParameter)
        Me.SplitContainer1.Size = New System.Drawing.Size(862, 421)
        Me.SplitContainer1.SplitterDistance = 134
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbParameter)
        Me.GroupBox1.Controls.Add(Me.txtParameterDesc)
        Me.GroupBox1.Controls.Add(Me.lblBehaviour)
        Me.GroupBox1.Controls.Add(Me.lblParameterDesc)
        Me.GroupBox1.Controls.Add(Me.lblParameterID)
        Me.GroupBox1.Controls.Add(Me.lblPName)
        Me.GroupBox1.Controls.Add(Me.txtParameterName)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 124)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter"
        '
        'cmbParameter
        '
        Me.cmbParameter.FormattingEnabled = True
        Me.cmbParameter.Items.AddRange(New Object() {"<---Select--->", "Negative", "Positive"})
        Me.cmbParameter.Location = New System.Drawing.Point(110, 88)
        Me.cmbParameter.Name = "cmbParameter"
        Me.cmbParameter.Size = New System.Drawing.Size(235, 21)
        Me.cmbParameter.TabIndex = 3
        '
        'txtParameterDesc
        '
        Me.txtParameterDesc.Location = New System.Drawing.Point(110, 53)
        Me.txtParameterDesc.Name = "txtParameterDesc"
        Me.txtParameterDesc.Size = New System.Drawing.Size(235, 20)
        Me.txtParameterDesc.TabIndex = 2
        '
        'lblBehaviour
        '
        Me.lblBehaviour.AutoSize = True
        Me.lblBehaviour.Location = New System.Drawing.Point(49, 96)
        Me.lblBehaviour.Name = "lblBehaviour"
        Me.lblBehaviour.Size = New System.Drawing.Size(55, 13)
        Me.lblBehaviour.TabIndex = 19
        Me.lblBehaviour.Text = "Behaviour"
        '
        'lblParameterDesc
        '
        Me.lblParameterDesc.AutoSize = True
        Me.lblParameterDesc.Location = New System.Drawing.Point(21, 60)
        Me.lblParameterDesc.Name = "lblParameterDesc"
        Me.lblParameterDesc.Size = New System.Drawing.Size(83, 13)
        Me.lblParameterDesc.TabIndex = 18
        Me.lblParameterDesc.Text = "Parameter Desc"
        '
        'lblParameterID
        '
        Me.lblParameterID.AutoSize = True
        Me.lblParameterID.Location = New System.Drawing.Point(380, 27)
        Me.lblParameterID.Name = "lblParameterID"
        Me.lblParameterID.Size = New System.Drawing.Size(13, 13)
        Me.lblParameterID.TabIndex = 17
        Me.lblParameterID.Text = "0"
        '
        'lblPName
        '
        Me.lblPName.AutoSize = True
        Me.lblPName.Location = New System.Drawing.Point(21, 27)
        Me.lblPName.Name = "lblPName"
        Me.lblPName.Size = New System.Drawing.Size(86, 13)
        Me.lblPName.TabIndex = 15
        Me.lblPName.Text = "Parameter Name"
        '
        'txtParameterName
        '
        Me.txtParameterName.Location = New System.Drawing.Point(110, 20)
        Me.txtParameterName.Name = "txtParameterName"
        Me.txtParameterName.Size = New System.Drawing.Size(235, 20)
        Me.txtParameterName.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(708, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(151, 44)
        Me.Panel1.TabIndex = 13
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 4)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(44, 37)
        Me.imgSave.TabIndex = 5
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = Global.CWPlus.My.Resources.Resources.button_cancel
        Me.imgDelete.Location = New System.Drawing.Point(53, 4)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(40, 37)
        Me.imgDelete.TabIndex = 6
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(99, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(40, 37)
        Me.imgClose.TabIndex = 7
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'grdParameter
        '
        Me.grdParameter.AllowDrop = True
        Me.grdParameter.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdParameter.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdParameter.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdParameter.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdParameter.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdParameter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParameter.GridColor = System.Drawing.Color.Black
        Me.grdParameter.Location = New System.Drawing.Point(0, 0)
        Me.grdParameter.Name = "grdParameter"
        Me.grdParameter.Size = New System.Drawing.Size(862, 283)
        Me.grdParameter.TabIndex = 4
        '
        'FrmParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 421)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmParameter"
        Me.Text = "FrmParameter"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdParameter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdParameter As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbParameter As System.Windows.Forms.ComboBox
    Friend WithEvents txtParameterDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblBehaviour As System.Windows.Forms.Label
    Friend WithEvents lblParameterDesc As System.Windows.Forms.Label
    Friend WithEvents lblParameterID As System.Windows.Forms.Label
    Friend WithEvents lblPName As System.Windows.Forms.Label
    Friend WithEvents txtParameterName As System.Windows.Forms.TextBox
End Class
