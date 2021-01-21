<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLicenseWiseSummery
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
        Me.grpApReport = New System.Windows.Forms.GroupBox()
        Me.rdbClosing = New System.Windows.Forms.RadioButton()
        Me.rdbSale = New System.Windows.Forms.RadioButton()
        Me.rdbTransfer = New System.Windows.Forms.RadioButton()
        Me.rdbPurchase = New System.Windows.Forms.RadioButton()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grdLicensewiseSummery = New System.Windows.Forms.DataGridView()
        Me.chkInML = New System.Windows.Forms.CheckBox()
        Me.grpApReport.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdLicensewiseSummery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpApReport
        '
        Me.grpApReport.Controls.Add(Me.chkInML)
        Me.grpApReport.Controls.Add(Me.rdbClosing)
        Me.grpApReport.Controls.Add(Me.rdbSale)
        Me.grpApReport.Controls.Add(Me.rdbTransfer)
        Me.grpApReport.Controls.Add(Me.rdbPurchase)
        Me.grpApReport.Controls.Add(Me.dtToDate)
        Me.grpApReport.Controls.Add(Me.Label3)
        Me.grpApReport.Controls.Add(Me.Label4)
        Me.grpApReport.Controls.Add(Me.dtFromDate)
        Me.grpApReport.Location = New System.Drawing.Point(0, 16)
        Me.grpApReport.Name = "grpApReport"
        Me.grpApReport.Size = New System.Drawing.Size(671, 87)
        Me.grpApReport.TabIndex = 13
        Me.grpApReport.TabStop = False
        Me.grpApReport.Text = "License wise Summery"
        '
        'rdbClosing
        '
        Me.rdbClosing.AutoSize = True
        Me.rdbClosing.Location = New System.Drawing.Point(278, 47)
        Me.rdbClosing.Name = "rdbClosing"
        Me.rdbClosing.Size = New System.Drawing.Size(59, 17)
        Me.rdbClosing.TabIndex = 12
        Me.rdbClosing.Text = "Closing"
        Me.rdbClosing.UseVisualStyleBackColor = True
        '
        'rdbSale
        '
        Me.rdbSale.AutoSize = True
        Me.rdbSale.Location = New System.Drawing.Point(121, 47)
        Me.rdbSale.Name = "rdbSale"
        Me.rdbSale.Size = New System.Drawing.Size(46, 17)
        Me.rdbSale.TabIndex = 11
        Me.rdbSale.Text = "Sale"
        Me.rdbSale.UseVisualStyleBackColor = True
        '
        'rdbTransfer
        '
        Me.rdbTransfer.AutoSize = True
        Me.rdbTransfer.Location = New System.Drawing.Point(195, 47)
        Me.rdbTransfer.Name = "rdbTransfer"
        Me.rdbTransfer.Size = New System.Drawing.Size(64, 17)
        Me.rdbTransfer.TabIndex = 10
        Me.rdbTransfer.Text = "Transfer"
        Me.rdbTransfer.UseVisualStyleBackColor = True
        '
        'rdbPurchase
        '
        Me.rdbPurchase.AutoSize = True
        Me.rdbPurchase.Checked = True
        Me.rdbPurchase.Location = New System.Drawing.Point(21, 47)
        Me.rdbPurchase.Name = "rdbPurchase"
        Me.rdbPurchase.Size = New System.Drawing.Size(70, 17)
        Me.rdbPurchase.TabIndex = 9
        Me.rdbPurchase.TabStop = True
        Me.rdbPurchase.Text = "Purchase"
        Me.rdbPurchase.UseVisualStyleBackColor = True
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Location = New System.Drawing.Point(759, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 51)
        Me.Panel1.TabIndex = 14
        '
        'btnok
        '
        Me.btnok.Image = Global.CWPlus.My.Resources.Resources.ok
        Me.btnok.Location = New System.Drawing.Point(3, 4)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(47, 42)
        Me.btnok.TabIndex = 3
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.CWPlus.My.Resources.Resources.excel
        Me.btnExport.Location = New System.Drawing.Point(51, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(45, 42)
        Me.btnExport.TabIndex = 4
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'grdLicensewiseSummery
        '
        Me.grdLicensewiseSummery.AllowDrop = True
        Me.grdLicensewiseSummery.AllowUserToAddRows = False
        Me.grdLicensewiseSummery.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdLicensewiseSummery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdLicensewiseSummery.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdLicensewiseSummery.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdLicensewiseSummery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdLicensewiseSummery.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdLicensewiseSummery.GridColor = System.Drawing.Color.Black
        Me.grdLicensewiseSummery.Location = New System.Drawing.Point(0, 109)
        Me.grdLicensewiseSummery.Name = "grdLicensewiseSummery"
        Me.grdLicensewiseSummery.ReadOnly = True
        Me.grdLicensewiseSummery.Size = New System.Drawing.Size(871, 364)
        Me.grdLicensewiseSummery.TabIndex = 15
        '
        'chkInML
        '
        Me.chkInML.AutoSize = True
        Me.chkInML.Location = New System.Drawing.Point(395, 17)
        Me.chkInML.Name = "chkInML"
        Me.chkInML.Size = New System.Drawing.Size(64, 17)
        Me.chkInML.TabIndex = 13
        Me.chkInML.Text = "Is In ML"
        Me.chkInML.UseVisualStyleBackColor = True
        '
        'FrmLicenseWiseSummery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 470)
        Me.Controls.Add(Me.grdLicensewiseSummery)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpApReport)
        Me.Name = "FrmLicenseWiseSummery"
        Me.Text = "FrmLicenseWiseSummery"
        Me.grpApReport.ResumeLayout(False)
        Me.grpApReport.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdLicensewiseSummery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpApReport As System.Windows.Forms.GroupBox
    Friend WithEvents rdbSale As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTransfer As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPurchase As System.Windows.Forms.RadioButton
    Friend WithEvents dtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents rdbClosing As System.Windows.Forms.RadioButton
    Friend WithEvents grdLicensewiseSummery As System.Windows.Forms.DataGridView
    Friend WithEvents chkInML As System.Windows.Forms.CheckBox
End Class
