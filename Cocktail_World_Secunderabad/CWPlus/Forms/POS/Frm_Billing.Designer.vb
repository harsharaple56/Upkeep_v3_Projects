<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Billing
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
        Me.lblOPID = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtBCode = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.grdBrands = New System.Windows.Forms.DataGridView()
        CType(Me.grdBrands, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblOPID
        '
        Me.lblOPID.AutoSize = True
        Me.lblOPID.Location = New System.Drawing.Point(162, 291)
        Me.lblOPID.Name = "lblOPID"
        Me.lblOPID.Size = New System.Drawing.Size(35, 13)
        Me.lblOPID.TabIndex = 6
        Me.lblOPID.Text = "label7"
        Me.lblOPID.Visible = False
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(316, 291)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(104, 18)
        Me.label6.TabIndex = 5
        Me.label6.Text = "QUANTITY"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(319, 314)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(101, 27)
        Me.txtQty.TabIndex = 3
        Me.txtQty.Text = "1"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(12, 317)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(60, 18)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "label3"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(240, 317)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(60, 18)
        Me.lblSize.TabIndex = 3
        Me.lblSize.Text = "label5"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(488, 111)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(56, 18)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "DATE"
        '
        'txtBCode
        '
        Me.txtBCode.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBCode.Location = New System.Drawing.Point(145, 12)
        Me.txtBCode.Name = "txtBCode"
        Me.txtBCode.Size = New System.Drawing.Size(275, 27)
        Me.txtBCode.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(240, 291)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(49, 18)
        Me.label4.TabIndex = 2
        Me.label4.Text = "SIZE"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(12, 291)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(127, 18)
        Me.label2.TabIndex = 0
        Me.label2.Text = "BRAND NAME"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(12, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(127, 18)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Search Brand"
        '
        'grdBrands
        '
        Me.grdBrands.AllowUserToAddRows = False
        Me.grdBrands.AllowUserToDeleteRows = False
        Me.grdBrands.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.grdBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBrands.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdBrands.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grdBrands.Location = New System.Drawing.Point(15, 57)
        Me.grdBrands.Name = "grdBrands"
        Me.grdBrands.ReadOnly = True
        Me.grdBrands.Size = New System.Drawing.Size(405, 227)
        Me.grdBrands.TabIndex = 2
        '
        'Frm_Billing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 469)
        Me.Controls.Add(Me.grdBrands)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblOPID)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.txtBCode)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.lblName)
        Me.Name = "Frm_Billing"
        Me.Text = "Frm_Billing"
        CType(Me.grdBrands, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblOPID As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents txtQty As System.Windows.Forms.TextBox
    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents txtBCode As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents grdBrands As System.Windows.Forms.DataGridView
End Class
