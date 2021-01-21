Public Class frmSearchArticle
  
    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        If txtSearchByArticleName.Text = "" And txtSearchByArticleNO.Text = "" Then
            MsgBox("Enter Either Article Name Or No.")
            Exit Sub
        Else
          
            BindGridArticles()
        End If
    End Sub
    Private Sub BindGridArticles()
        Dim ObjPriDt As New DataTable
        Dim ObjBevRec As CWPlusBL.Accor.ClsBeverageReconComment
        ObjBevRec = New CWPlusBL.Accor.ClsBeverageReconComment
        Try
            ObjBevRec = New CWPlusBL.Accor.ClsBeverageReconComment
            ObjBevRec.Article = txtSearchByArticleName.Text
            ObjBevRec.ArticleNo = txtSearchByArticleNO.Text
            ObjPriDt = ObjBevRec.FunFetchMCItems()
            grdBindArticle.DataSource = ObjPriDt

        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjBevRec = Nothing
        End Try
    End Sub

    Private Sub frmSearchArticle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindGridArticles()
    End Sub


    Private Sub grdBindArticle_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBindArticle.CellDoubleClick

        If GblFormName = "frmBeverageReconComment" Then
            frmBeverageReconComment.lblArticleNo.Text = grdBindArticle("ArticleNo", e.RowIndex).Value
            frmBeverageReconComment.lblitemID.Text = grdBindArticle("ArticleID", e.RowIndex).Value
            frmBeverageReconComment.txtArticleName.Text = grdBindArticle("ArticleName", e.RowIndex).Value
        Else
            frmBeverageReconInputs.txtArticleName.Text = grdBindArticle("ArticleName", e.RowIndex).Value
            frmBeverageReconInputs.lblArticleID.Text = grdBindArticle("ArticleID", e.RowIndex).Value
            frmBeverageReconInputs.lblArticleNo.Text = grdBindArticle("ArticleNo", e.RowIndex).Value
        End If

        Me.Close()
    End Sub

End Class