<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCStep3
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.grdQuickControlStep3 = New ThemedDataGrid.MKDataGridView()
        Me.controlheadid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Period = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrossTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportToExcel = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdQuickControlStep3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(231, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 3"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdQuickControlStep3)
        Me.SplitContainer1.Size = New System.Drawing.Size(565, 461)
        Me.SplitContainer1.SplitterDistance = 112
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblFromDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 50)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "QCStep3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Period :"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Font = New System.Drawing.Font("Comic Sans MS", 9.75!)
        Me.lblFromDate.ForeColor = System.Drawing.Color.Red
        Me.lblFromDate.Location = New System.Drawing.Point(76, 16)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(22, 18)
        Me.lblFromDate.TabIndex = 6
        Me.lblFromDate.Text = "01"
        '
        'grdQuickControlStep3
        '
        Me.grdQuickControlStep3.AllowUserToAddRows = False
        Me.grdQuickControlStep3.BackgroundColor = System.Drawing.Color.White
        Me.grdQuickControlStep3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdQuickControlStep3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdQuickControlStep3.ColumnHeadersHeight = 28
        Me.grdQuickControlStep3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.controlheadid, Me.Period, Me.TotalCost, Me.GrossTotal, Me.NetTotal, Me.Diff, Me.ExportToExcel})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdQuickControlStep3.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdQuickControlStep3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdQuickControlStep3.EnableHeadersVisualStyles = False
        Me.grdQuickControlStep3.GridColor = System.Drawing.Color.Orange
        Me.grdQuickControlStep3.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Orange
        Me.grdQuickControlStep3.Location = New System.Drawing.Point(0, 0)
        Me.grdQuickControlStep3.Name = "grdQuickControlStep3"
        Me.grdQuickControlStep3.ReadOnly = True
        Me.grdQuickControlStep3.RowHeadersVisible = False
        Me.grdQuickControlStep3.RowTemplate.Height = 26
        Me.grdQuickControlStep3.Size = New System.Drawing.Size(565, 345)
        Me.grdQuickControlStep3.TabIndex = 12
        '
        'controlheadid
        '
        Me.controlheadid.HeaderText = "ControlHeadID"
        Me.controlheadid.Name = "controlheadid"
        Me.controlheadid.ReadOnly = True
        Me.controlheadid.Visible = False
        Me.controlheadid.Width = 139
        '
        'Period
        '
        Me.Period.HeaderText = "Period"
        Me.Period.Name = "Period"
        Me.Period.ReadOnly = True
        Me.Period.Width = 230
        '
        'TotalCost
        '
        Me.TotalCost.HeaderText = "TotalCost"
        Me.TotalCost.Name = "TotalCost"
        Me.TotalCost.ReadOnly = True
        Me.TotalCost.Width = 101
        '
        'GrossTotal
        '
        Me.GrossTotal.HeaderText = "GrossRevenue"
        Me.GrossTotal.Name = "GrossTotal"
        Me.GrossTotal.ReadOnly = True
        Me.GrossTotal.Width = 136
        '
        'NetTotal
        '
        Me.NetTotal.HeaderText = "NetRevenue"
        Me.NetTotal.Name = "NetTotal"
        Me.NetTotal.ReadOnly = True
        Me.NetTotal.Width = 120
        '
        'Diff
        '
        Me.Diff.HeaderText = "Profit(NetRevenue-TotalCost)"
        Me.Diff.Name = "Diff"
        Me.Diff.ReadOnly = True
        Me.Diff.Width = 249
        '
        'ExportToExcel
        '
        Me.ExportToExcel.HeaderText = "ExportToExcel"
        Me.ExportToExcel.Name = "ExportToExcel"
        Me.ExportToExcel.ReadOnly = True
        Me.ExportToExcel.Text = "ExportToExcel"
        Me.ExportToExcel.UseColumnTextForButtonValue = True
        Me.ExportToExcel.Width = 150
        '
        'QCStep3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "QCStep3"
        Me.Size = New System.Drawing.Size(565, 461)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdQuickControlStep3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdQuickControlStep3 As ThemedDataGrid.MKDataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents controlheadid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrossTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Diff As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportToExcel As System.Windows.Forms.DataGridViewButtonColumn

End Class
