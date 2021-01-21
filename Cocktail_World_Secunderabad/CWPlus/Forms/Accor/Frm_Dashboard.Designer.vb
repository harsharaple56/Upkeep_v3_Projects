<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Dashboard
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnPlotChart = New System.Windows.Forms.Button()
        Me.drpReport = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbDashboard = New System.Windows.Forms.TabControl()
        Me.tpGrid = New System.Windows.Forms.TabPage()
        Me.grdReport = New System.Windows.Forms.DataGridView()
        Me.tpChart = New System.Windows.Forms.TabPage()
        Me.btnok = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tbDashboard.SuspendLayout()
        Me.tpGrid.SuspendLayout()
        CType(Me.grdReport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbDashboard)
        Me.SplitContainer1.Size = New System.Drawing.Size(1025, 738)
        Me.SplitContainer1.SplitterDistance = 118
        Me.SplitContainer1.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnPlotChart)
        Me.GroupBox1.Controls.Add(Me.drpReport)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DtToDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtFromDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 101)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DCC Report"
        '
        'BtnPlotChart
        '
        Me.BtnPlotChart.Location = New System.Drawing.Point(405, 54)
        Me.BtnPlotChart.Name = "BtnPlotChart"
        Me.BtnPlotChart.Size = New System.Drawing.Size(75, 23)
        Me.BtnPlotChart.TabIndex = 18
        Me.BtnPlotChart.Text = "Plot Chart"
        Me.BtnPlotChart.UseVisualStyleBackColor = True
        Me.BtnPlotChart.Visible = False
        '
        'drpReport
        '
        Me.drpReport.FormattingEnabled = True
        Me.drpReport.Location = New System.Drawing.Point(108, 56)
        Me.drpReport.Name = "drpReport"
        Me.drpReport.Size = New System.Drawing.Size(274, 21)
        Me.drpReport.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Select Report"
        '
        'DtToDate
        '
        Me.DtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtToDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtToDate.Location = New System.Drawing.Point(264, 19)
        Me.DtToDate.Name = "DtToDate"
        Me.DtToDate.Size = New System.Drawing.Size(118, 26)
        Me.DtToDate.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "To Date"
        '
        'DtFromDate
        '
        Me.DtFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtFromDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFromDate.Location = New System.Drawing.Point(79, 19)
        Me.DtFromDate.Name = "DtFromDate"
        Me.DtFromDate.Size = New System.Drawing.Size(118, 26)
        Me.DtFromDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From Date"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Location = New System.Drawing.Point(959, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(54, 45)
        Me.Panel1.TabIndex = 18
        '
        'tbDashboard
        '
        Me.tbDashboard.Controls.Add(Me.tpGrid)
        Me.tbDashboard.Controls.Add(Me.tpChart)
        Me.tbDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDashboard.Location = New System.Drawing.Point(0, 0)
        Me.tbDashboard.Name = "tbDashboard"
        Me.tbDashboard.SelectedIndex = 0
        Me.tbDashboard.Size = New System.Drawing.Size(1025, 616)
        Me.tbDashboard.TabIndex = 1
        '
        'tpGrid
        '
        Me.tpGrid.Controls.Add(Me.grdReport)
        Me.tpGrid.Location = New System.Drawing.Point(4, 22)
        Me.tpGrid.Name = "tpGrid"
        Me.tpGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGrid.Size = New System.Drawing.Size(1017, 590)
        Me.tpGrid.TabIndex = 0
        Me.tpGrid.Text = "Detail View"
        Me.tpGrid.UseVisualStyleBackColor = True
        '
        'grdReport
        '
        Me.grdReport.AllowUserToAddRows = False
        Me.grdReport.AllowUserToDeleteRows = False
        Me.grdReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReport.Location = New System.Drawing.Point(3, 3)
        Me.grdReport.Name = "grdReport"
        Me.grdReport.ReadOnly = True
        Me.grdReport.Size = New System.Drawing.Size(1011, 584)
        Me.grdReport.TabIndex = 0
        '
        'tpChart
        '
        Me.tpChart.Location = New System.Drawing.Point(4, 22)
        Me.tpChart.Name = "tpChart"
        Me.tpChart.Padding = New System.Windows.Forms.Padding(3)
        Me.tpChart.Size = New System.Drawing.Size(1017, 590)
        Me.tpChart.TabIndex = 1
        Me.tpChart.Text = "Chart View"
        Me.tpChart.UseVisualStyleBackColor = True
        '
        'btnok
        '
        Me.btnok.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnok.Location = New System.Drawing.Point(3, 3)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(47, 42)
        Me.btnok.TabIndex = 3
        Me.btnok.UseVisualStyleBackColor = True
        '
        'Frm_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 738)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Frm_Dashboard"
        Me.Text = "Frm_Dashboard"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.tbDashboard.ResumeLayout(False)
        Me.tpGrid.ResumeLayout(False)
        CType(Me.grdReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents drpReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnPlotChart As System.Windows.Forms.Button
    Friend WithEvents tbDashboard As System.Windows.Forms.TabControl
    Friend WithEvents tpGrid As System.Windows.Forms.TabPage
    Friend WithEvents grdReport As System.Windows.Forms.DataGridView
    Friend WithEvents tpChart As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
