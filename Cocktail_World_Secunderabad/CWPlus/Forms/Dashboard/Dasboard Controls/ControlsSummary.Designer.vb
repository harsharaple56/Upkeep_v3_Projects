<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlsSummary
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
        Me.splitCosting = New System.Windows.Forms.SplitContainer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grdCosting = New ThemedDataGrid.MKDataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.splitCosting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCosting.Panel1.SuspendLayout()
        Me.splitCosting.Panel2.SuspendLayout()
        Me.splitCosting.SuspendLayout()
        CType(Me.grdCosting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitCosting
        '
        Me.splitCosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCosting.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitCosting.Location = New System.Drawing.Point(0, 0)
        Me.splitCosting.Name = "splitCosting"
        Me.splitCosting.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCosting.Panel1
        '
        Me.splitCosting.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.splitCosting.Panel1.Controls.Add(Me.Button1)
        Me.splitCosting.Panel1.Controls.Add(Me.dtTo)
        Me.splitCosting.Panel1.Controls.Add(Me.Label4)
        Me.splitCosting.Panel1.Controls.Add(Me.dtFrom)
        Me.splitCosting.Panel1.Controls.Add(Me.Label5)
        Me.splitCosting.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.splitCosting.Panel1.ForeColor = System.Drawing.Color.White
        '
        'splitCosting.Panel2
        '
        Me.splitCosting.Panel2.Controls.Add(Me.grdCosting)
        Me.splitCosting.Size = New System.Drawing.Size(398, 201)
        Me.splitCosting.SplitterDistance = 26
        Me.splitCosting.SplitterWidth = 1
        Me.splitCosting.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.Button1.Location = New System.Drawing.Point(296, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 27)
        Me.Button1.TabIndex = 21
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd/MM/yyyy"
        Me.dtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(194, 3)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(94, 20)
        Me.dtTo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "To :"
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(53, 3)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(94, 20)
        Me.dtFrom.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "From :"
        '
        'grdCosting
        '
        Me.grdCosting.AllowUserToAddRows = False
        Me.grdCosting.AllowUserToResizeColumns = False
        Me.grdCosting.AllowUserToResizeRows = False
        Me.grdCosting.BackgroundColor = System.Drawing.Color.White
        Me.grdCosting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCosting.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCosting.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdCosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCosting.EnableHeadersVisualStyles = False
        Me.grdCosting.GridColor = System.Drawing.Color.Orange
        Me.grdCosting.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Orange
        Me.grdCosting.Location = New System.Drawing.Point(0, 0)
        Me.grdCosting.Name = "grdCosting"
        Me.grdCosting.ReadOnly = True
        Me.grdCosting.RowHeadersVisible = False
        Me.grdCosting.RowTemplate.Height = 26
        Me.grdCosting.Size = New System.Drawing.Size(398, 174)
        Me.grdCosting.TabIndex = 2
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.splitCosting)
        Me.SplitContainer1.Size = New System.Drawing.Size(398, 230)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Controls Summary"
        '
        'ControlsSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ControlsSummary"
        Me.Size = New System.Drawing.Size(398, 230)
        Me.Tag = "3"
        Me.splitCosting.Panel1.ResumeLayout(False)
        Me.splitCosting.Panel1.PerformLayout()
        Me.splitCosting.Panel2.ResumeLayout(False)
        CType(Me.splitCosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCosting.ResumeLayout(False)
        CType(Me.grdCosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitCosting As System.Windows.Forms.SplitContainer
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdCosting As ThemedDataGrid.MKDataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
