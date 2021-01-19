<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWhatIfParameters
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbPurchase = New System.Windows.Forms.ComboBox()
        Me.txtPurchase = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.cmbQuantity = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSellRate = New System.Windows.Forms.TextBox()
        Me.cmbSellRate = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSaleRate = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblPurRate = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chartExpected = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdExpected = New ThemedDataGrid.MKDataGridView()
        Me.vParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vCurrent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vExpected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbFromType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbToType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chartPredicted = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.grdPredicted = New ThemedDataGrid.MKDataGridView()
        Me.Parameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Current = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Expected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.chartExpected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdExpected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.chartPredicted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdPredicted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPurchase
        '
        Me.cmbPurchase.FormattingEnabled = True
        Me.cmbPurchase.Items.AddRange(New Object() {"--Select--", "Positive", "Negative"})
        Me.cmbPurchase.Location = New System.Drawing.Point(97, 64)
        Me.cmbPurchase.Name = "cmbPurchase"
        Me.cmbPurchase.Size = New System.Drawing.Size(114, 21)
        Me.cmbPurchase.TabIndex = 0
        '
        'txtPurchase
        '
        Me.txtPurchase.Location = New System.Drawing.Point(274, 64)
        Me.txtPurchase.Name = "txtPurchase"
        Me.txtPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPurchase.Size = New System.Drawing.Size(76, 20)
        Me.txtPurchase.TabIndex = 1
        Me.txtPurchase.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Purchase Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Qunatity"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(274, 91)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtQuantity.Size = New System.Drawing.Size(76, 20)
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Text = "0"
        '
        'cmbQuantity
        '
        Me.cmbQuantity.FormattingEnabled = True
        Me.cmbQuantity.Items.AddRange(New Object() {"--Select--", "Positive", "Negative"})
        Me.cmbQuantity.Location = New System.Drawing.Point(97, 91)
        Me.cmbQuantity.Name = "cmbQuantity"
        Me.cmbQuantity.Size = New System.Drawing.Size(114, 21)
        Me.cmbQuantity.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Sale Rate"
        '
        'txtSellRate
        '
        Me.txtSellRate.Location = New System.Drawing.Point(274, 118)
        Me.txtSellRate.Name = "txtSellRate"
        Me.txtSellRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSellRate.Size = New System.Drawing.Size(76, 20)
        Me.txtSellRate.TabIndex = 7
        Me.txtSellRate.Text = "0"
        '
        'cmbSellRate
        '
        Me.cmbSellRate.FormattingEnabled = True
        Me.cmbSellRate.Items.AddRange(New Object() {"--Select--", "Positive", "Negative"})
        Me.cmbSellRate.Location = New System.Drawing.Point(97, 118)
        Me.cmbSellRate.Name = "cmbSellRate"
        Me.cmbSellRate.Size = New System.Drawing.Size(114, 21)
        Me.cmbSellRate.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSaleRate)
        Me.GroupBox1.Controls.Add(Me.lblQty)
        Me.GroupBox1.Controls.Add(Me.lblPurRate)
        Me.GroupBox1.Controls.Add(Me.lbl)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnOk)
        Me.GroupBox1.Controls.Add(Me.cmbQuantity)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbPurchase)
        Me.GroupBox1.Controls.Add(Me.txtSellRate)
        Me.GroupBox1.Controls.Add(Me.txtPurchase)
        Me.GroupBox1.Controls.Add(Me.cmbSellRate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 245)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 185)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "What If Parameters"
        '
        'lblSaleRate
        '
        Me.lblSaleRate.AutoSize = True
        Me.lblSaleRate.Location = New System.Drawing.Point(229, 120)
        Me.lblSaleRate.Name = "lblSaleRate"
        Me.lblSaleRate.Size = New System.Drawing.Size(13, 13)
        Me.lblSaleRate.TabIndex = 14
        Me.lblSaleRate.Text = "0"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(229, 94)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(13, 13)
        Me.lblQty.TabIndex = 13
        Me.lblQty.Text = "0"
        '
        'lblPurRate
        '
        Me.lblPurRate.AutoSize = True
        Me.lblPurRate.Location = New System.Drawing.Point(229, 68)
        Me.lblPurRate.Name = "lblPurRate"
        Me.lblPurRate.Size = New System.Drawing.Size(13, 13)
        Me.lblPurRate.TabIndex = 12
        Me.lblPurRate.Text = "0"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(68, 21)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(2, 21)
        Me.lbl.TabIndex = 11
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(178, 145)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(97, 145)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(60, 23)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(757, 484)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TabControl2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(381, 245)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(373, 236)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 16)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(367, 217)
        Me.TabControl2.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chartExpected)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(359, 191)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Chart"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chartExpected
        '
        ChartArea1.Name = "ChartArea1"
        Me.chartExpected.ChartAreas.Add(ChartArea1)
        Me.chartExpected.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.chartExpected.Legends.Add(Legend1)
        Me.chartExpected.Location = New System.Drawing.Point(3, 3)
        Me.chartExpected.Name = "chartExpected"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartExpected.Series.Add(Series1)
        Me.chartExpected.Size = New System.Drawing.Size(353, 185)
        Me.chartExpected.TabIndex = 1
        Me.chartExpected.Text = "Chart2"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdExpected)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(359, 191)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Summary"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdExpected
        '
        Me.grdExpected.AllowUserToAddRows = False
        Me.grdExpected.AllowUserToDeleteRows = False
        Me.grdExpected.AllowUserToResizeColumns = False
        Me.grdExpected.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.grdExpected.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdExpected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdExpected.BackgroundColor = System.Drawing.Color.White
        Me.grdExpected.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdExpected.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdExpected.ColumnHeadersHeight = 28
        Me.grdExpected.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vParameter, Me.vCurrent, Me.vExpected})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdExpected.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdExpected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdExpected.EnableHeadersVisualStyles = False
        Me.grdExpected.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grdExpected.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        Me.grdExpected.Location = New System.Drawing.Point(3, 3)
        Me.grdExpected.Name = "grdExpected"
        Me.grdExpected.ReadOnly = True
        Me.grdExpected.RowHeadersVisible = False
        Me.grdExpected.RowTemplate.Height = 26
        Me.grdExpected.Size = New System.Drawing.Size(353, 185)
        Me.grdExpected.TabIndex = 1
        '
        'vParameter
        '
        Me.vParameter.HeaderText = "Parameter"
        Me.vParameter.Name = "vParameter"
        Me.vParameter.ReadOnly = True
        Me.vParameter.Width = 110
        '
        'vCurrent
        '
        Me.vCurrent.HeaderText = "Current"
        Me.vCurrent.Name = "vCurrent"
        Me.vCurrent.ReadOnly = True
        Me.vCurrent.Width = 88
        '
        'vExpected
        '
        Me.vExpected.HeaderText = "Expected"
        Me.vExpected.Name = "vExpected"
        Me.vExpected.ReadOnly = True
        Me.vExpected.Width = 101
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbFromType)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cmbToType)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbBrand)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(372, 161)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'cmbFromType
        '
        Me.cmbFromType.FormattingEnabled = True
        Me.cmbFromType.Items.AddRange(New Object() {"--Select--", "Challenge", "Star", "Horse", "Dog"})
        Me.cmbFromType.Location = New System.Drawing.Point(97, 41)
        Me.cmbFromType.Name = "cmbFromType"
        Me.cmbFromType.Size = New System.Drawing.Size(220, 21)
        Me.cmbFromType.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Type"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(129, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "&Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbToType
        '
        Me.cmbToType.FormattingEnabled = True
        Me.cmbToType.Items.AddRange(New Object() {"--Select--", "Challenge", "Star", "Horse", "Dog"})
        Me.cmbToType.Location = New System.Drawing.Point(97, 100)
        Me.cmbToType.Name = "cmbToType"
        Me.cmbToType.Size = New System.Drawing.Size(162, 21)
        Me.cmbToType.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Expected Type"
        '
        'cmbBrand
        '
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(97, 73)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(253, 21)
        Me.cmbBrand.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Brand"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TabControl1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(381, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(373, 236)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(367, 217)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chartPredicted)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(359, 191)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Chart"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chartPredicted
        '
        ChartArea2.Name = "ChartArea1"
        Me.chartPredicted.ChartAreas.Add(ChartArea2)
        Me.chartPredicted.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.chartPredicted.Legends.Add(Legend2)
        Me.chartPredicted.Location = New System.Drawing.Point(3, 3)
        Me.chartPredicted.Name = "chartPredicted"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chartPredicted.Series.Add(Series2)
        Me.chartPredicted.Size = New System.Drawing.Size(353, 185)
        Me.chartPredicted.TabIndex = 1
        Me.chartPredicted.Text = "Chart1"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.grdPredicted)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(359, 191)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Summary"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'grdPredicted
        '
        Me.grdPredicted.AllowUserToAddRows = False
        Me.grdPredicted.AllowUserToDeleteRows = False
        Me.grdPredicted.AllowUserToResizeColumns = False
        Me.grdPredicted.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.grdPredicted.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdPredicted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdPredicted.BackgroundColor = System.Drawing.Color.White
        Me.grdPredicted.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPredicted.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdPredicted.ColumnHeadersHeight = 28
        Me.grdPredicted.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Parameter, Me.Current, Me.Expected})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(229, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPredicted.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdPredicted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPredicted.EnableHeadersVisualStyles = False
        Me.grdPredicted.GridColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grdPredicted.GridTheme = ThemedDataGrid.MKDataGridView.GridThemes.Accent1
        Me.grdPredicted.Location = New System.Drawing.Point(3, 3)
        Me.grdPredicted.Name = "grdPredicted"
        Me.grdPredicted.ReadOnly = True
        Me.grdPredicted.RowHeadersVisible = False
        Me.grdPredicted.RowTemplate.Height = 26
        Me.grdPredicted.Size = New System.Drawing.Size(353, 185)
        Me.grdPredicted.TabIndex = 0
        '
        'Parameter
        '
        Me.Parameter.HeaderText = "Parameter"
        Me.Parameter.Name = "Parameter"
        Me.Parameter.ReadOnly = True
        Me.Parameter.Width = 110
        '
        'Current
        '
        Me.Current.HeaderText = "Current"
        Me.Current.Name = "Current"
        Me.Current.ReadOnly = True
        Me.Current.Width = 88
        '
        'Expected
        '
        Me.Expected.HeaderText = "Predicted"
        Me.Expected.Name = "Expected"
        Me.Expected.ReadOnly = True
        Me.Expected.Width = 102
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'frmWhatIfParameters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 484)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmWhatIfParameters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "What If Parameters"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.chartExpected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdExpected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.chartPredicted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.grdPredicted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbPurchase As System.Windows.Forms.ComboBox
    Friend WithEvents txtPurchase As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cmbQuantity As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSellRate As System.Windows.Forms.TextBox
    Friend WithEvents cmbSellRate As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbToType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chartExpected As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents chartPredicted As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents grdPredicted As ThemedDataGrid.MKDataGridView
    Friend WithEvents grdExpected As ThemedDataGrid.MKDataGridView
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbFromType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblPurRate As System.Windows.Forms.Label
    Friend WithEvents lblSaleRate As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents vParameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vCurrent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vExpected As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Current As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expected As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
