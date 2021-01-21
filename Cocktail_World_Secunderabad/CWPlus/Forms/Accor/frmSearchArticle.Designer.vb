<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchArticle
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
        Me.lblSearchArticleByName = New System.Windows.Forms.Label()
        Me.lblSearchByArticleNo = New System.Windows.Forms.Label()
        Me.txtSearchByArticleName = New System.Windows.Forms.TextBox()
        Me.txtSearchByArticleNO = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.grdBindArticle = New System.Windows.Forms.DataGridView()
        CType(Me.grdBindArticle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSearchArticleByName
        '
        Me.lblSearchArticleByName.AutoSize = True
        Me.lblSearchArticleByName.Location = New System.Drawing.Point(19, 26)
        Me.lblSearchArticleByName.Name = "lblSearchArticleByName"
        Me.lblSearchArticleByName.Size = New System.Drawing.Size(122, 13)
        Me.lblSearchArticleByName.TabIndex = 0
        Me.lblSearchArticleByName.Text = "Search  By Article Name"
        '
        'lblSearchByArticleNo
        '
        Me.lblSearchByArticleNo.AutoSize = True
        Me.lblSearchByArticleNo.Location = New System.Drawing.Point(19, 60)
        Me.lblSearchByArticleNo.Name = "lblSearchByArticleNo"
        Me.lblSearchByArticleNo.Size = New System.Drawing.Size(105, 13)
        Me.lblSearchByArticleNo.TabIndex = 1
        Me.lblSearchByArticleNo.Text = "Search By Article No"
        '
        'txtSearchByArticleName
        '
        Me.txtSearchByArticleName.Location = New System.Drawing.Point(172, 26)
        Me.txtSearchByArticleName.Name = "txtSearchByArticleName"
        Me.txtSearchByArticleName.Size = New System.Drawing.Size(207, 20)
        Me.txtSearchByArticleName.TabIndex = 2
        '
        'txtSearchByArticleNO
        '
        Me.txtSearchByArticleNO.Location = New System.Drawing.Point(172, 60)
        Me.txtSearchByArticleNO.Name = "txtSearchByArticleNO"
        Me.txtSearchByArticleNO.Size = New System.Drawing.Size(207, 20)
        Me.txtSearchByArticleNO.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.CWPlus.My.Resources.Resources.search__1_
        Me.btnSearch.Location = New System.Drawing.Point(419, 26)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(43, 31)
        Me.btnSearch.TabIndex = 25
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'grdBindArticle
        '
        Me.grdBindArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBindArticle.Location = New System.Drawing.Point(1, 100)
        Me.grdBindArticle.Name = "grdBindArticle"
        Me.grdBindArticle.Size = New System.Drawing.Size(485, 225)
        Me.grdBindArticle.TabIndex = 26
        '
        'frmSearchArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 322)
        Me.Controls.Add(Me.grdBindArticle)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchByArticleNO)
        Me.Controls.Add(Me.txtSearchByArticleName)
        Me.Controls.Add(Me.lblSearchByArticleNo)
        Me.Controls.Add(Me.lblSearchArticleByName)
        Me.Name = "frmSearchArticle"
        Me.Text = "frmSearchArticle"
        CType(Me.grdBindArticle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSearchArticleByName As System.Windows.Forms.Label
    Friend WithEvents lblSearchByArticleNo As System.Windows.Forms.Label
    Friend WithEvents txtSearchByArticleName As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchByArticleNO As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grdBindArticle As System.Windows.Forms.DataGridView
End Class
