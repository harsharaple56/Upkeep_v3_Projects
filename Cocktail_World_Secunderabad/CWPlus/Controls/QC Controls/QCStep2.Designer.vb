<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCStep2
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblParameterID = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.grpQC2 = New System.Windows.Forms.GroupBox()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblParameter = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbParameter = New System.Windows.Forms.ComboBox()
        Me.txtGrossRevenue = New System.Windows.Forms.TextBox()
        Me.txtNetRevenue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdQuickControlStep2 = New ThemedDataGrid.MKDataGridView()
        Me.ParameterID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParameterDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Behaviour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpQC2.SuspendLayout()
        CType(Me.grdQuickControlStep2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.OldLace
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblParameterID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpQC2)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdQuickControlStep2)
        Me.SplitContainer1.Size = New System.Drawing.Size(705, 448)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.TabIndex = 0
        '
        'lblParameterID
        '
        Me.lblParameterID.AutoSize = True
        Me.lblParameterID.Location = New System.Drawing.Point(523, 96)
        Me.lblParameterID.Name = "lblParameterID"
        Me.lblParameterID.Size = New System.Drawing.Size(16, 18)
        Me.lblParameterID.TabIndex = 10
        Me.lblParameterID.Text = "0"
        Me.lblParameterID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Location = New System.Drawing.Point(657, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(45, 47)
        Me.Panel1.TabIndex = 7
        '
        'imgSave
        '
        Me.imgSave.Image = Global.CWPlus.My.Resources.Resources.save
        Me.imgSave.Location = New System.Drawing.Point(3, 2)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(42, 42)
        Me.imgSave.TabIndex = 8
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'grpQC2
        '
        Me.grpQC2.Controls.Add(Me.lblFromDate)
        Me.grpQC2.Controls.Add(Me.Label3)
        Me.grpQC2.Controls.Add(Me.btnAdd)
        Me.grpQC2.Controls.Add(Me.lblParameter)
        Me.grpQC2.Controls.Add(Me.Label1)
        Me.grpQC2.Controls.Add(Me.cmbParameter)
        Me.grpQC2.Controls.Add(Me.txtGrossRevenue)
        Me.grpQC2.Controls.Add(Me.txtNetRevenue)
        Me.grpQC2.Controls.Add(Me.Label2)
        Me.grpQC2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpQC2.Location = New System.Drawing.Point(15, 16)
        Me.grpQC2.Name = "grpQC2"
        Me.grpQC2.Size = New System.Drawing.Size(333, 182)
        Me.grpQC2.TabIndex = 6
        Me.grpQC2.TabStop = False
        Me.grpQC2.Text = "QcStep2"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.lblFromDate.ForeColor = System.Drawing.Color.Red
        Me.lblFromDate.Location = New System.Drawing.Point(108, 22)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(22, 18)
        Me.lblFromDate.TabIndex = 11
        Me.lblFromDate.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Period :"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.CWPlus.My.Resources.Resources.edit_add__1_
        Me.btnAdd.Location = New System.Drawing.Point(277, 136)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 33)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblParameter
        '
        Me.lblParameter.AutoSize = True
        Me.lblParameter.Location = New System.Drawing.Point(31, 143)
        Me.lblParameter.Name = "lblParameter"
        Me.lblParameter.Size = New System.Drawing.Size(71, 18)
        Me.lblParameter.TabIndex = 5
        Me.lblParameter.Text = "ParaMeter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Gross Revenue"
        '
        'cmbParameter
        '
        Me.cmbParameter.FormattingEnabled = True
        Me.cmbParameter.Location = New System.Drawing.Point(112, 140)
        Me.cmbParameter.Name = "cmbParameter"
        Me.cmbParameter.Size = New System.Drawing.Size(159, 26)
        Me.cmbParameter.TabIndex = 4
        '
        'txtGrossRevenue
        '
        Me.txtGrossRevenue.Location = New System.Drawing.Point(112, 53)
        Me.txtGrossRevenue.Name = "txtGrossRevenue"
        Me.txtGrossRevenue.Size = New System.Drawing.Size(159, 26)
        Me.txtGrossRevenue.TabIndex = 0
        '
        'txtNetRevenue
        '
        Me.txtNetRevenue.Location = New System.Drawing.Point(112, 95)
        Me.txtNetRevenue.Name = "txtNetRevenue"
        Me.txtNetRevenue.Size = New System.Drawing.Size(159, 26)
        Me.txtNetRevenue.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Net Revenue"
        '
        'grdQuickControlStep2
        '
        Me.grdQuickControlStep2.AllowUserToAddRows = False
        Me.grdQuickControlStep2.BackgroundColor = System.Drawing.Color.White
        Me.grdQuickControlStep2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdQuickControlStep2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdQuickControlStep2.ColumnHeadersHeight = 28
        Me.grdQuickControlStep2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ParameterID, Me.ParameterName, Me.ParameterDesc, Me.Behaviour, Me.Amount, Me.btnRemove})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdQuickControlStep2.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdQuickControlStep2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdQuickControlStep2.EnableHeadersVisualStyles = False
        Me.grdQuickControlStep2.GridColor = System.Drawing.Color.Orange
        Me.grdQuickControlStep2.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Orange
        Me.grdQuickControlStep2.Location = New System.Drawing.Point(0, 0)
        Me.grdQuickControlStep2.Name = "grdQuickControlStep2"
        Me.grdQuickControlStep2.RowHeadersVisible = False
        Me.grdQuickControlStep2.RowTemplate.Height = 26
        Me.grdQuickControlStep2.Size = New System.Drawing.Size(705, 194)
        Me.grdQuickControlStep2.TabIndex = 9
        '
        'ParameterID
        '
        Me.ParameterID.HeaderText = "ParameterID"
        Me.ParameterID.Name = "ParameterID"
        Me.ParameterID.Visible = False
        Me.ParameterID.Width = 125
        '
        'ParameterName
        '
        Me.ParameterName.HeaderText = "Parameter"
        Me.ParameterName.Name = "ParameterName"
        Me.ParameterName.ReadOnly = True
        Me.ParameterName.Width = 200
        '
        'ParameterDesc
        '
        Me.ParameterDesc.HeaderText = "Parameter Description"
        Me.ParameterDesc.Name = "ParameterDesc"
        Me.ParameterDesc.ReadOnly = True
        Me.ParameterDesc.Width = 200
        '
        'Behaviour
        '
        Me.Behaviour.HeaderText = "Behaviour"
        Me.Behaviour.Name = "Behaviour"
        Me.Behaviour.ReadOnly = True
        Me.Behaviour.Width = 200
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 180
        '
        'btnRemove
        '
        Me.btnRemove.HeaderText = "Remove"
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseColumnTextForButtonValue = True
        Me.btnRemove.Width = 170
        '
        'QCStep2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "QCStep2"
        Me.Size = New System.Drawing.Size(705, 448)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpQC2.ResumeLayout(False)
        Me.grpQC2.PerformLayout()
        CType(Me.grdQuickControlStep2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpQC2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblParameter As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbParameter As System.Windows.Forms.ComboBox
    Friend WithEvents txtGrossRevenue As System.Windows.Forms.TextBox
    Friend WithEvents txtNetRevenue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblParameterID As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents grdQuickControlStep2 As ThemedDataGrid.MKDataGridView
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ParameterID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParameterDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Behaviour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRemove As System.Windows.Forms.DataGridViewButtonColumn

End Class
