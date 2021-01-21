<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdSearch = New ThemedDataGrid.MKDataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdVoid = New ThemedDataGrid.MKDataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chklstRevenueCenter = New System.Windows.Forms.CheckedListBox()
        Me.chklstDiscountMst = New System.Windows.Forms.CheckedListBox()
        Me.lblTotalQuantity = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdVoid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Location = New System.Drawing.Point(68, 61)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(79, 20)
        Me.txtCheckNo.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1001, 359)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdSearch)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(993, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdSearch
        '
        Me.grdSearch.AllowUserToAddRows = False
        Me.grdSearch.AllowUserToDeleteRows = False
        Me.grdSearch.AllowUserToResizeRows = False
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black
        Me.grdSearch.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle25
        Me.grdSearch.BackgroundColor = System.Drawing.Color.White
        Me.grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.grdSearch.ColumnHeadersHeight = 28
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdSearch.DefaultCellStyle = DataGridViewCellStyle27
        Me.grdSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSearch.EnableHeadersVisualStyles = False
        Me.grdSearch.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grdSearch.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        Me.grdSearch.Location = New System.Drawing.Point(3, 3)
        Me.grdSearch.Name = "grdSearch"
        Me.grdSearch.ReadOnly = True
        Me.grdSearch.RowHeadersVisible = False
        Me.grdSearch.RowTemplate.Height = 26
        Me.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdSearch.Size = New System.Drawing.Size(987, 327)
        Me.grdSearch.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdVoid)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(993, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Void"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdVoid
        '
        Me.grdVoid.AllowUserToAddRows = False
        Me.grdVoid.AllowUserToDeleteRows = False
        Me.grdVoid.AllowUserToResizeRows = False
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black
        Me.grdVoid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle28
        Me.grdVoid.BackgroundColor = System.Drawing.Color.White
        Me.grdVoid.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle29.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdVoid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.grdVoid.ColumnHeadersHeight = 28
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdVoid.DefaultCellStyle = DataGridViewCellStyle30
        Me.grdVoid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVoid.EnableHeadersVisualStyles = False
        Me.grdVoid.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grdVoid.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        Me.grdVoid.Location = New System.Drawing.Point(3, 3)
        Me.grdVoid.Name = "grdVoid"
        Me.grdVoid.ReadOnly = True
        Me.grdVoid.RowHeadersVisible = False
        Me.grdVoid.RowTemplate.Height = 26
        Me.grdVoid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdVoid.Size = New System.Drawing.Size(987, 327)
        Me.grdVoid.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Check No"
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtFrom.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(68, 20)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(118, 26)
        Me.dtFrom.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTotalQuantity)
        Me.GroupBox1.Controls.Add(Me.chklstDiscountMst)
        Me.GroupBox1.Controls.Add(Me.btnMore)
        Me.GroupBox1.Controls.Add(Me.chklstRevenueCenter)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCheckNo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 115)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtTo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(244, 19)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(118, 26)
        Me.dtTo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(192, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "To Date"
        '
        'btnMore
        '
        Me.btnMore.Image = Global.CWPlus.My.Resources.Resources.search
        Me.btnMore.Location = New System.Drawing.Point(797, 68)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(43, 41)
        Me.btnMore.TabIndex = 5
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From Date"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1001, 487)
        Me.SplitContainer1.SplitterDistance = 124
        Me.SplitContainer1.TabIndex = 6
        '
        'chklstRevenueCenter
        '
        Me.chklstRevenueCenter.FormattingEnabled = True
        Me.chklstRevenueCenter.Location = New System.Drawing.Point(377, 15)
        Me.chklstRevenueCenter.Name = "chklstRevenueCenter"
        Me.chklstRevenueCenter.Size = New System.Drawing.Size(217, 94)
        Me.chklstRevenueCenter.TabIndex = 21
        '
        'chklstDiscountMst
        '
        Me.chklstDiscountMst.FormattingEnabled = True
        Me.chklstDiscountMst.Location = New System.Drawing.Point(610, 15)
        Me.chklstDiscountMst.Name = "chklstDiscountMst"
        Me.chklstDiscountMst.Size = New System.Drawing.Size(172, 94)
        Me.chklstDiscountMst.TabIndex = 20
        '
        'lblTotalQuantity
        '
        Me.lblTotalQuantity.AutoSize = True
        Me.lblTotalQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalQuantity.Location = New System.Drawing.Point(179, 64)
        Me.lblTotalQuantity.Name = "lblTotalQuantity"
        Me.lblTotalQuantity.Size = New System.Drawing.Size(0, 17)
        Me.lblTotalQuantity.TabIndex = 20
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 487)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmSearch"
        Me.Text = "frmSearch"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdVoid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdSearch As ThemedDataGrid.MKDataGridView
    Friend WithEvents grdVoid As ThemedDataGrid.MKDataGridView
    Friend WithEvents chklstDiscountMst As System.Windows.Forms.CheckedListBox
    Friend WithEvents chklstRevenueCenter As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblTotalQuantity As System.Windows.Forms.Label
End Class
