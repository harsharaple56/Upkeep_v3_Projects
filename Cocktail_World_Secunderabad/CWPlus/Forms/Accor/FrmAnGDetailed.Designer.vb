<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnGDetailed
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
        Me.DtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtFromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdDCCReport = New System.Windows.Forms.DataGridView()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.btnCrystalReport = New System.Windows.Forms.Button()
        Me.btnok = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.drpDiscountType = New System.Windows.Forms.ComboBox()
        Me.drpDesignation = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDCCReport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdDCCReport)
        Me.SplitContainer1.Size = New System.Drawing.Size(710, 407)
        Me.SplitContainer1.SplitterDistance = 132
        Me.SplitContainer1.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.drpDesignation)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.drpDiscountType)
        Me.GroupBox1.Controls.Add(Me.DtToDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DtFromdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(465, 115)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Officer Meal"
        '
        'DtToDate
        '
        Me.DtToDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtToDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtToDate.Location = New System.Drawing.Point(334, 19)
        Me.DtToDate.Name = "DtToDate"
        Me.DtToDate.Size = New System.Drawing.Size(115, 26)
        Me.DtToDate.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "To Date"
        '
        'DtFromdate
        '
        Me.DtFromdate.CustomFormat = "dd-MMM-yyyy"
        Me.DtFromdate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFromdate.Location = New System.Drawing.Point(101, 19)
        Me.DtFromdate.Name = "DtFromdate"
        Me.DtFromdate.Size = New System.Drawing.Size(115, 26)
        Me.DtFromdate.TabIndex = 2
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Controls.Add(Me.btnCrystalReport)
        Me.Panel1.Controls.Add(Me.btnok)
        Me.Panel1.Location = New System.Drawing.Point(546, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(152, 49)
        Me.Panel1.TabIndex = 18
        '
        'grdDCCReport
        '
        Me.grdDCCReport.AllowUserToAddRows = False
        Me.grdDCCReport.AllowUserToDeleteRows = False
        Me.grdDCCReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDCCReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDCCReport.Location = New System.Drawing.Point(0, 0)
        Me.grdDCCReport.Name = "grdDCCReport"
        Me.grdDCCReport.ReadOnly = True
        Me.grdDCCReport.Size = New System.Drawing.Size(710, 271)
        Me.grdDCCReport.TabIndex = 0
        '
        'imgClose
        '
        Me.imgClose.Image = Global.CWPlus.My.Resources.Resources.cancel__1_
        Me.imgClose.Location = New System.Drawing.Point(103, 4)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 40)
        Me.imgClose.TabIndex = 10
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'btnCrystalReport
        '
        Me.btnCrystalReport.Image = Global.CWPlus.My.Resources.Resources.crystalReport
        Me.btnCrystalReport.Location = New System.Drawing.Point(56, 3)
        Me.btnCrystalReport.Name = "btnCrystalReport"
        Me.btnCrystalReport.Size = New System.Drawing.Size(41, 42)
        Me.btnCrystalReport.TabIndex = 5
        Me.btnCrystalReport.UseVisualStyleBackColor = True
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "A&&G Fields"
        '
        'drpDiscountType
        '
        Me.drpDiscountType.FormattingEnabled = True
        Me.drpDiscountType.Location = New System.Drawing.Point(101, 57)
        Me.drpDiscountType.Name = "drpDiscountType"
        Me.drpDiscountType.Size = New System.Drawing.Size(348, 21)
        Me.drpDiscountType.TabIndex = 23
        '
        'drpDesignation
        '
        Me.drpDesignation.FormattingEnabled = True
        Me.drpDesignation.Location = New System.Drawing.Point(101, 87)
        Me.drpDesignation.Name = "drpDesignation"
        Me.drpDesignation.Size = New System.Drawing.Size(348, 21)
        Me.drpDesignation.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Designation"
        '
        'FrmAnGDetailed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 407)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmAnGDetailed"
        Me.Text = "FrmAnGDetailed"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdDCCReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtFromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents btnCrystalReport As System.Windows.Forms.Button
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents grdDCCReport As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents drpDiscountType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drpDesignation As System.Windows.Forms.ComboBox
End Class
