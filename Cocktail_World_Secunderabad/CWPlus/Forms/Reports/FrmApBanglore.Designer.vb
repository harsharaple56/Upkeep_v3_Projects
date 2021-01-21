<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmApBanglore
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMailReport = New System.Windows.Forms.Button()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpApReport = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTimeOut = New System.Windows.Forms.TextBox()
        Me.chkISBorder = New System.Windows.Forms.CheckBox()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.grdApBangloreReport = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpApReport.SuspendLayout()
        CType(Me.grdApBangloreReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpApReport)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdApBangloreReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(881, 358)
        Me.SplitContainer1.SplitterDistance = 102
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnMailReport)
        Me.Panel1.Controls.Add(Me.btnCrystalReport)
        Me.Panel1.Controls.Add(Me.btnPdf)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Location = New System.Drawing.Point(638, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 51)
        Me.Panel1.TabIndex = 13
        '
        'btnMailReport
        '
        Me.btnMailReport.Image = Global.CWPlus.My.Resources.Resources.email_open
        Me.btnMailReport.Location = New System.Drawing.Point(196, 6)
        Me.btnMailReport.Name = "btnMailReport"
        Me.btnMailReport.Size = New System.Drawing.Size(44, 40)
        Me.btnMailReport.TabIndex = 16
        Me.btnMailReport.UseVisualStyleBackColor = True
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(150, 4)
        Me.btnCrystalReport.Name = "btnCrystalReport"
        Me.btnCrystalReport.Size = New System.Drawing.Size(41, 42)
        Me.btnCrystalReport.TabIndex = 15
        Me.btnCrystalReport.UseVisualStyleBackColor = True
        '
        'btnPdf
        '
        Me.btnPdf.Image = Global.CWPlus.My.Resources.Resources.pdf
        Me.btnPdf.Location = New System.Drawing.Point(101, 4)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(42, 41)
        Me.btnPdf.TabIndex = 13
        Me.btnPdf.UseVisualStyleBackColor = True
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
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(50, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(45, 42)
        Me.btnExport.TabIndex = 4
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'grpApReport
        '
        Me.grpApReport.Controls.Add(Me.Label1)
        Me.grpApReport.Controls.Add(Me.txtTimeOut)
        Me.grpApReport.Controls.Add(Me.chkISBorder)
        Me.grpApReport.Controls.Add(Me.dtToDate)
        Me.grpApReport.Controls.Add(Me.Label3)
        Me.grpApReport.Controls.Add(Me.Label4)
        Me.grpApReport.Controls.Add(Me.dtFromDate)
        Me.grpApReport.Location = New System.Drawing.Point(3, 12)
        Me.grpApReport.Name = "grpApReport"
        Me.grpApReport.Size = New System.Drawing.Size(332, 76)
        Me.grpApReport.TabIndex = 12
        Me.grpApReport.TabStop = False
        Me.grpApReport.Text = "Chatai Report"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(186, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Time Out"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Location = New System.Drawing.Point(241, 50)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTimeOut.Size = New System.Drawing.Size(57, 20)
        Me.txtTimeOut.TabIndex = 10
        Me.txtTimeOut.Text = "30"
        '
        'chkISBorder
        '
        Me.chkISBorder.AutoSize = True
        Me.chkISBorder.Location = New System.Drawing.Point(38, 53)
        Me.chkISBorder.Name = "chkISBorder"
        Me.chkISBorder.Size = New System.Drawing.Size(82, 17)
        Me.chkISBorder.TabIndex = 9
        Me.chkISBorder.Text = "With Border"
        Me.chkISBorder.UseVisualStyleBackColor = True
        '
        'dtToDate
        '
        Me.dtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToDate.Location = New System.Drawing.Point(225, 19)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(99, 20)
        Me.dtToDate.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "To Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "From Date"
        '
        'dtFromDate
        '
        Me.dtFromDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromDate.Location = New System.Drawing.Point(68, 20)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(99, 20)
        Me.dtFromDate.TabIndex = 1
        '
        'grdApBangloreReport
        '
        Me.grdApBangloreReport.AllowDrop = True
        Me.grdApBangloreReport.AllowUserToAddRows = False
        Me.grdApBangloreReport.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdApBangloreReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdApBangloreReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdApBangloreReport.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdApBangloreReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdApBangloreReport.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdApBangloreReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdApBangloreReport.GridColor = System.Drawing.Color.Black
        Me.grdApBangloreReport.Location = New System.Drawing.Point(0, 0)
        Me.grdApBangloreReport.Name = "grdApBangloreReport"
        Me.grdApBangloreReport.ReadOnly = True
        Me.grdApBangloreReport.Size = New System.Drawing.Size(881, 252)
        Me.grdApBangloreReport.TabIndex = 10
        '
        'FrmApBanglore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 358)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmApBanglore"
        Me.Text = "FrmApBanglore"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpApReport.ResumeLayout(False)
        Me.grpApReport.PerformLayout()
        CType(Me.grdApBangloreReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grpApReport As System.Windows.Forms.GroupBox
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents grdApBangloreReport As System.Windows.Forms.DataGridView
    Friend WithEvents chkISBorder As System.Windows.Forms.CheckBox
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
    Friend WithEvents btnMailReport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTimeOut As System.Windows.Forms.TextBox
End Class
