<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBeverageReconInputs
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBeverageReconInputs))
        Me.grdBevRecon = New System.Windows.Forms.DataGridView()
        Me.imgSave = New System.Windows.Forms.Button()
        Me.imgDelete = New System.Windows.Forms.Button()
        Me.imgClose = New System.Windows.Forms.Button()
        Me.lblid = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSearchByArticle = New System.Windows.Forms.TextBox()
        Me.lblSearchByArticle = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.DtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBreakage = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblArticleNo = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DtBusinessDate = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.drpCostCenter = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imgNew = New System.Windows.Forms.Button()
        Me.tltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSeach = New System.Windows.Forms.Button()
        Me.txtArticleName = New System.Windows.Forms.TextBox()
        Me.lblArticleID = New System.Windows.Forms.Label()
        CType(Me.grdBevRecon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdBevRecon
        '
        Me.grdBevRecon.AllowDrop = True
        Me.grdBevRecon.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBevRecon.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdBevRecon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdBevRecon.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdBevRecon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBevRecon.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdBevRecon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBevRecon.GridColor = System.Drawing.Color.Black
        Me.grdBevRecon.Location = New System.Drawing.Point(0, 0)
        Me.grdBevRecon.Name = "grdBevRecon"
        Me.grdBevRecon.ReadOnly = True
        Me.grdBevRecon.Size = New System.Drawing.Size(797, 26)
        Me.grdBevRecon.TabIndex = 2
        '
        'imgSave
        '
        Me.imgSave.Image = CType(resources.GetObject("imgSave.Image"), System.Drawing.Image)
        Me.imgSave.Location = New System.Drawing.Point(47, 3)
        Me.imgSave.Name = "imgSave"
        Me.imgSave.Size = New System.Drawing.Size(39, 40)
        Me.imgSave.TabIndex = 9
        Me.tltip.SetToolTip(Me.imgSave, "Save")
        Me.imgSave.UseVisualStyleBackColor = True
        '
        'imgDelete
        '
        Me.imgDelete.Image = CType(resources.GetObject("imgDelete.Image"), System.Drawing.Image)
        Me.imgDelete.Location = New System.Drawing.Point(92, 3)
        Me.imgDelete.Name = "imgDelete"
        Me.imgDelete.Size = New System.Drawing.Size(41, 40)
        Me.imgDelete.TabIndex = 10
        Me.tltip.SetToolTip(Me.imgDelete, "Delete")
        Me.imgDelete.UseVisualStyleBackColor = True
        '
        'imgClose
        '
        Me.imgClose.Image = CType(resources.GetObject("imgClose.Image"), System.Drawing.Image)
        Me.imgClose.Location = New System.Drawing.Point(139, 3)
        Me.imgClose.Name = "imgClose"
        Me.imgClose.Size = New System.Drawing.Size(45, 40)
        Me.imgClose.TabIndex = 11
        Me.tltip.SetToolTip(Me.imgClose, "Close")
        Me.imgClose.UseVisualStyleBackColor = True
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(598, 72)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(26, 13)
        Me.lblid.TabIndex = 1
        Me.lblid.Text = "IDN"
        Me.lblid.Visible = False
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblid)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdBevRecon)
        Me.SplitContainer1.Size = New System.Drawing.Size(797, 302)
        Me.SplitContainer1.SplitterDistance = 272
        Me.SplitContainer1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSearchByArticle)
        Me.GroupBox1.Controls.Add(Me.lblSearchByArticle)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.DtToDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtFromDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 86)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Beverage Reconsile Comments"
        '
        'txtSearchByArticle
        '
        Me.txtSearchByArticle.Location = New System.Drawing.Point(79, 57)
        Me.txtSearchByArticle.Name = "txtSearchByArticle"
        Me.txtSearchByArticle.Size = New System.Drawing.Size(100, 20)
        Me.txtSearchByArticle.TabIndex = 26
        '
        'lblSearchByArticle
        '
        Me.lblSearchByArticle.AutoSize = True
        Me.lblSearchByArticle.Location = New System.Drawing.Point(23, 57)
        Me.lblSearchByArticle.Name = "lblSearchByArticle"
        Me.lblSearchByArticle.Size = New System.Drawing.Size(36, 13)
        Me.lblSearchByArticle.TabIndex = 25
        Me.lblSearchByArticle.Text = "Article"
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.CWPlus.My.Resources.Resources.search__1_
        Me.btnSearch.Location = New System.Drawing.Point(400, 19)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(43, 31)
        Me.btnSearch.TabIndex = 24
        Me.btnSearch.UseVisualStyleBackColor = True
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblArticleID)
        Me.GroupBox2.Controls.Add(Me.txtArticleName)
        Me.GroupBox2.Controls.Add(Me.btnSeach)
        Me.GroupBox2.Controls.Add(Me.chkBreakage)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtValue)
        Me.GroupBox2.Controls.Add(Me.lblArticleNo)
        Me.GroupBox2.Controls.Add(Me.lblQuantity)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtQuantity)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.DtBusinessDate)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.drpCostCenter)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(539, 165)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enter Comments"
        '
        'chkBreakage
        '
        Me.chkBreakage.AutoSize = True
        Me.chkBreakage.Location = New System.Drawing.Point(383, 122)
        Me.chkBreakage.Name = "chkBreakage"
        Me.chkBreakage.Size = New System.Drawing.Size(118, 17)
        Me.chkBreakage.TabIndex = 25
        Me.chkBreakage.Text = "Breakage/Spoilage"
        Me.chkBreakage.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(212, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Rate"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(280, 119)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(74, 20)
        Me.txtValue.TabIndex = 23
        '
        'lblArticleNo
        '
        Me.lblArticleNo.AutoSize = True
        Me.lblArticleNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticleNo.Location = New System.Drawing.Point(471, 92)
        Me.lblArticleNo.Name = "lblArticleNo"
        Me.lblArticleNo.Size = New System.Drawing.Size(59, 15)
        Me.lblArticleNo.TabIndex = 22
        Me.lblArticleNo.Text = "Article No"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(13, 122)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(46, 13)
        Me.lblQuantity.TabIndex = 21
        Me.lblQuantity.Text = "Quantity"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Article Name"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(123, 119)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(74, 20)
        Me.txtQuantity.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Date"
        '
        'DtBusinessDate
        '
        Me.DtBusinessDate.CustomFormat = "dd-MMM-yyyy"
        Me.DtBusinessDate.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtBusinessDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtBusinessDate.Location = New System.Drawing.Point(123, 23)
        Me.DtBusinessDate.Name = "DtBusinessDate"
        Me.DtBusinessDate.Size = New System.Drawing.Size(118, 26)
        Me.DtBusinessDate.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Cost Center Name"
        '
        'drpCostCenter
        '
        Me.drpCostCenter.FormattingEnabled = True
        Me.drpCostCenter.Location = New System.Drawing.Point(123, 55)
        Me.drpCostCenter.Name = "drpCostCenter"
        Me.drpCostCenter.Size = New System.Drawing.Size(205, 21)
        Me.drpCostCenter.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.imgNew)
        Me.Panel1.Controls.Add(Me.imgSave)
        Me.Panel1.Controls.Add(Me.imgDelete)
        Me.Panel1.Controls.Add(Me.imgClose)
        Me.Panel1.Location = New System.Drawing.Point(598, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(187, 46)
        Me.Panel1.TabIndex = 13
        '
        'imgNew
        '
        Me.imgNew.Image = Global.CWPlus.My.Resources.Resources.window_new
        Me.imgNew.Location = New System.Drawing.Point(3, 3)
        Me.imgNew.Name = "imgNew"
        Me.imgNew.Size = New System.Drawing.Size(43, 40)
        Me.imgNew.TabIndex = 21
        Me.tltip.SetToolTip(Me.imgNew, "Add New")
        Me.imgNew.UseVisualStyleBackColor = True
        '
        'tltip
        '
        Me.tltip.IsBalloon = True
        '
        'btnSeach
        '
        Me.btnSeach.Location = New System.Drawing.Point(458, 58)
        Me.btnSeach.Name = "btnSeach"
        Me.btnSeach.Size = New System.Drawing.Size(75, 23)
        Me.btnSeach.TabIndex = 26
        Me.btnSeach.Text = "Search Article"
        Me.btnSeach.UseVisualStyleBackColor = True
        '
        'txtArticleName
        '
        Me.txtArticleName.Enabled = False
        Me.txtArticleName.Location = New System.Drawing.Point(123, 90)
        Me.txtArticleName.Name = "txtArticleName"
        Me.txtArticleName.Size = New System.Drawing.Size(320, 20)
        Me.txtArticleName.TabIndex = 27
        '
        'lblArticleID
        '
        Me.lblArticleID.AutoSize = True
        Me.lblArticleID.Enabled = False
        Me.lblArticleID.Location = New System.Drawing.Point(343, 68)
        Me.lblArticleID.Name = "lblArticleID"
        Me.lblArticleID.Size = New System.Drawing.Size(39, 13)
        Me.lblArticleID.TabIndex = 28
        Me.lblArticleID.Text = "Label4"
        '
        'frmBeverageReconInputs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 302)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmBeverageReconInputs"
        Me.Text = "Beverage REconsile Comments"
        CType(Me.grdBevRecon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdBevRecon As System.Windows.Forms.DataGridView
    Friend WithEvents imgSave As System.Windows.Forms.Button
    Friend WithEvents tltip As System.Windows.Forms.ToolTip
    Friend WithEvents imgDelete As System.Windows.Forms.Button
    Friend WithEvents imgClose As System.Windows.Forms.Button
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgNew As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DtBusinessDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents drpCostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblArticleNo As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents chkBreakage As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchByArticle As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchByArticle As System.Windows.Forms.Label
    Friend WithEvents btnSeach As System.Windows.Forms.Button
    Friend WithEvents lblArticleID As System.Windows.Forms.Label
    Friend WithEvents txtArticleName As System.Windows.Forms.TextBox
End Class
