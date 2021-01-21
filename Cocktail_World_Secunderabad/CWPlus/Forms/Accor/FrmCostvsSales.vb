Imports CWPlusBL.Accor
Imports System.Data
Public Class FrmCostvsSales

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim StrPriHeaderFooter As String = ""
    Dim ObjPriDts As DataSet
    Public Sub BindData()
        Try

            If drpRevenueCenter.SelectedValue = "0" Then
                MsgBox("Select Revenuecenter Name", MsgBoxStyle.Critical, "CWPlus")
                Exit Sub
            End If

            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjExp = New ClsMsOffice
            ObjCls.Fromdate = Format(dtFrom.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(dtTo.Value, "dd-MMM-yyyy")
            ObjCls.LicenseID = drpRevenueCenter.SelectedValue
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchCostvsSales()
            grdDCCReport.DataSource = ObjPriDt

        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindData()
    End Sub

     Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        If drpRevenueCenter.SelectedValue = "0" Then
            MsgBox("Please Revenuecenter License")
            Exit Sub
        End If
        Dim StrParam As String = ""
        StrParam = "'" & Format(dtFrom.Value, "dd-MMM-yyyy") & "','" & Format(dtTo.Value, "dd-MMM-yyyy") & "'," & drpRevenueCenter.SelectedValue & ",'" & gblUserName & "'"
        GenerateReport("costvsslaes", "proc#" & "Spr_FetchCostvsSales" & "#" & StrParam & vbCrLf & "Costvssale2")
    End Sub

    Private Sub FrmCostvsSales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindEvalLicense()
    End Sub

    Private Sub BindEvalLicense()
        Dim ObjClsEval As CWPlusBL.Accor.ClsEvalLicense
        Try
            ObjPriDt = New DataTable
            ObjClsEval = New CWPlusBL.Accor.ClsEvalLicense
            ObjPriDt = ObjClsEval.FunFetch()
            ComboBindingTemplate(drpRevenueCenter, ObjPriDt, "LicenseName", "EvalLicenseID")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try

            StrPriHeaderFooter = "Beverage Reconciliation#" & Format(dtFrom.Value, "dd-MMM-yyyy") & "-" & Format(dtTo.Value, "dd-MMM-yyyy")

            ObjExp = New ClsMsOffice
            ObjPriDt = DirectCast(grdDCCReport.DataSource, DataTable)
            ObjPriDts.Tables.Add(ObjPriDt)
            ObjExp.ExportToExcelHeaderFooterEval(IO.Path.GetTempPath, "temp.xls", StrPriHeaderFooter, ObjPriDts)
            Process.Start(IO.Path.GetTempPath & "\temp.xls")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub
End Class