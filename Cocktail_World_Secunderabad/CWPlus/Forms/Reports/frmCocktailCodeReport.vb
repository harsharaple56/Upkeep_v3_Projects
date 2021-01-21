Public Class frmCocktailCodeReport
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjAssignctcode As CWPlusBL.Master.AssignCocktailCode
    Dim ObjDt As DataTable
#Region "Procedures"
    Public Sub BindGrid()
        If MDI.cmbLicenseName.SelectedValue = 0 Then
            grdCocktailCodeReport.DataSource = Nothing
        End If
        ObjDt = New DataTable
        objCocktail = New CWPlusBL.Master.ClsCocktailReports
        objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
        objCocktail.CocktailId = cmbCocktail.SelectedValue
        objCocktail.CocktailCode = txtCode.Text
        ObjDt = objCocktail.FunFetchCocktailCodeReport
        grdCocktailCodeReport.DataSource = Nothing
        grdCocktailCodeReport.DataSource = ObjDt
        MakeIDColumnsHide(grdCocktailCodeReport)
        grdCocktailCodeReport.Columns("CocktailName").Width = 200
        grdCocktailCodeReport.Columns("Cocktailcode").Width = 150
    End Sub
    Public Sub BindCombo()
        Dim ds As New DataSet
        Try
            ObjAssignctcode = New CWPlusBL.Master.AssignCocktailCode

            ObjAssignctcode.AssigncocktailcodeId = cmbCocktail.SelectedValue
            ds = ObjAssignctcode.FetchAssigncocktail
            With cmbCocktail
                .DataSource = ds.Tables(0)
                .DisplayMember = "Cocktailname"
                .ValueMember = "CocktailId"
                .SelectedValue = -1
                .Text = ""
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjAssignctcode) Then
                ObjAssignctcode = Nothing
            End If
            If Not IsNothing(ds) Then
                ds = Nothing
            End If
        End Try
    End Sub
#End Region

    Private Sub frmBrandCodeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BindGrid()

        BindCombo()
    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjDt = New DataTable
        ObjDt = DirectCast(grdCocktailCodeReport.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim arrReportName(0) As String

        arrReportName(0) = "Cocktail Code Report"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdCocktailCodeReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub
End Class