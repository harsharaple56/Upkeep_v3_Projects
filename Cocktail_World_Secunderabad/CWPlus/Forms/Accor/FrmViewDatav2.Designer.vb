Imports ThemedDataGrid

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewDatav2
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DtBusinessDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.drpRevenueCenter = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdSaleData = New ThemedDataGrid.MKDataGridView()
        Me.MkDataGridView1 = New ThemedDataGrid.MKDataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdSaleData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MkDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtBusinessDate
        '
        Me.DtBusinessDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtBusinessDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtBusinessDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtBusinessDate.Location = New System.Drawing.Point(87, 19)
        Me.DtBusinessDate.Name = "DtBusinessDate"
        Me.DtBusinessDate.Size = New System.Drawing.Size(118, 26)
        Me.DtBusinessDate.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCheckNo)
        Me.GroupBox1.Controls.Add(Me.drpRevenueCenter)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtBusinessDate)
        Me.GroupBox1.Controls.Add(Me.btnMore)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 61)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Data"
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Location = New System.Drawing.Point(508, 25)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(79, 20)
        Me.txtCheckNo.TabIndex = 16
        '
        'drpRevenueCenter
        '
        Me.drpRevenueCenter.FormattingEnabled = True
        Me.drpRevenueCenter.Location = New System.Drawing.Point(302, 25)
        Me.drpRevenueCenter.Name = "drpRevenueCenter"
        Me.drpRevenueCenter.Size = New System.Drawing.Size(139, 21)
        Me.drpRevenueCenter.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(447, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Check No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Revenue Center"
        '
        'btnMore
        '
        Me.btnMore.Image = Global.CWPlus.My.Resources.Resources.search
        Me.btnMore.Location = New System.Drawing.Point(593, 14)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(43, 41)
        Me.btnMore.TabIndex = 12
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Business Date"
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(731, 469)
        Me.SplitContainer1.SplitterDistance = 91
        Me.SplitContainer1.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(667, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(52, 46)
        Me.Panel1.TabIndex = 25
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(4, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 40)
        Me.imgClose.TabIndex = 5
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(731, 374)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdSaleData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(723, 348)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdSaleData
        '
        Me.grdSaleData.AllowUserToAddRows = False
        Me.grdSaleData.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.grdSaleData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdSaleData.BackgroundColor = System.Drawing.Color.White
        Me.grdSaleData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(198, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdSaleData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdSaleData.ColumnHeadersHeight = 28
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(162, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(232, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdSaleData.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdSaleData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSaleData.EnableHeadersVisualStyles = False
        Me.grdSaleData.GridColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.grdSaleData.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent3
        Me.grdSaleData.Location = New System.Drawing.Point(3, 3)
        Me.grdSaleData.Name = "grdSaleData"
        Me.grdSaleData.ReadOnly = True
        Me.grdSaleData.RowHeadersVisible = False
        Me.grdSaleData.RowTemplate.Height = 26
        Me.grdSaleData.Size = New System.Drawing.Size(717, 342)
        Me.grdSaleData.TabIndex = 0
        '
        'MkDataGridView1
        '
        Me.MkDataGridView1.AllowUserToAddRows = False
        Me.MkDataGridView1.AllowUserToDeleteRows = False
        Me.MkDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MkDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MkDataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.MkDataGridView1.Name = "MkDataGridView1"
        Me.MkDataGridView1.ReadOnly = True
        Me.MkDataGridView1.Size = New System.Drawing.Size(717, 342)
        Me.MkDataGridView1.TabIndex = 0
        '
        'FrmViewDatav2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 469)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmViewDatav2"
        Me.Text = "FrmViewData"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdSaleData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MkDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents DtBusinessDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents drpRevenueCenter As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents MkDataGridView1 As ThemedDataGrid.MKDataGridView
    Friend WithEvents grdSaleData As ThemedDataGrid.MKDataGridView
End Class
