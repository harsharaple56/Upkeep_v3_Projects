<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgReportSearch
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.cmbCocktail = New System.Windows.Forms.ComboBox()
        Me.cmbCategorySize = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Brand"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cocktail"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(81, 140)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(162, 140)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmbBrand
        '
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(93, 10)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(165, 21)
        Me.cmbBrand.TabIndex = 10
        '
        'cmbSize
        '
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(92, 35)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(165, 21)
        Me.cmbSize.TabIndex = 11
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(92, 61)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(165, 21)
        Me.cmbCategory.TabIndex = 12
        '
        'cmbCocktail
        '
        Me.cmbCocktail.FormattingEnabled = True
        Me.cmbCocktail.Location = New System.Drawing.Point(92, 113)
        Me.cmbCocktail.Name = "cmbCocktail"
        Me.cmbCocktail.Size = New System.Drawing.Size(165, 21)
        Me.cmbCocktail.TabIndex = 13
        '
        'cmbCategorySize
        '
        Me.cmbCategorySize.FormattingEnabled = True
        Me.cmbCategorySize.Location = New System.Drawing.Point(92, 88)
        Me.cmbCategorySize.Name = "cmbCategorySize"
        Me.cmbCategorySize.Size = New System.Drawing.Size(165, 21)
        Me.cmbCategorySize.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Category Size"
        '
        'dlgReportSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 176)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbCategorySize)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCocktail)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.cmbSize)
        Me.Controls.Add(Me.cmbBrand)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "dlgReportSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Search"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmbBrand As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSize As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCocktail As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategorySize As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
