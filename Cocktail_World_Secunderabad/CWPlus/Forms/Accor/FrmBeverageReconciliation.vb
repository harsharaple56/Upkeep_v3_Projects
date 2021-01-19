Imports System.Xml
Imports CWPlusBL.Accor

Public Class FrmBeverageReconciliation
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim ObjExp As ClsMsOffice
    Dim ObjPriDts As DataSet
    Dim StrPriHeaderFooter As String = ""

    Public gblArrEvalLicense As New ArrayList

    Private Function GenerateLicenseXML() As XmlDocument
        GenerateLicenseXML = Nothing
        Dim xmldoc As XmlDocument
        xmldoc = New XmlDocument
        xmldoc.LoadXml("<Report><EvalPack></EvalPack></Report>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        For cntr = 0 To gblArrEvalLicense.Count - 1
            XmlElt = xmldoc.CreateElement("License")
            XmlElt.SetAttribute("Licenseid", gblArrEvalLicense.Item(cntr))
            xmldoc.DocumentElement.Item("EvalPack").AppendChild(XmlElt)
        Next
        GenerateLicenseXML = xmldoc
    End Function

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        Try

            gblArrEvalLicense.Clear()
            EvalLincenseChecked()

            If gblArrEvalLicense.Count = 0 Then
                MsgBox("Select Revenuecenter Name", MsgBoxStyle.Critical, "CWPlus")
                Exit Sub
            End If


            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjExp = New ClsMsOffice
            'ObjCls.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjCls.LicenseXML = GenerateLicenseXML()
            ObjCls.Fromdate = Format(dtFromDate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(dtToDate.Value, "dd-MMM-yyyy")
            ObjCls.UserName = gblUserName
            ObjPriDt = ObjCls.FunFetchBeverageReconciliation()
            StrPriHeaderFooter = ObjCls.ErrorMsg
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub




    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click

        gblArrEvalLicense.Clear()
        EvalLincenseChecked()

        If gblArrEvalLicense.Count = 0 Then
            MsgBox("Select Revenuecenter Name", MsgBoxStyle.Critical, "CWPlus")
            Exit Sub
        End If

        Dim StrLicense As String = ""
        StrLicense = GenerateLicenseXML.InnerXml


        Dim StrParam As String = ""
        StrParam = "'" & StrLicense & "','" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(dtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("bevrecon", "proc#" & "Spr_FetchBeverageReconciliation" & "#" & StrParam & "#10000")
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub FrmBeverageReconciliation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindEvalLicense()
    End Sub

    Private Sub BindEvalLicense()
        Dim ObjClsEval As CWPlusBL.Accor.ClsEvalLicense
        Try
            ObjPriDt = New DataTable

            ObjClsEval = New CWPlusBL.Accor.ClsEvalLicense
            ObjPriDt = ObjClsEval.FunFetch()

            Dim chkDt As New DataTable
            chkDt = ObjPriDt.Copy
            Dim dr As DataRow
            dr = chkDt.NewRow
            dr("LicenseName") = "Select All"
            dr("EvalLicenseID") = 0
            chkDt.Rows.InsertAt(dr, 0)

            With chklstEvalLicense
                .DataSource = chkDt
                .DisplayMember = "LicenseName"
                .ValueMember = "EvalLicenseID"
            End With
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub EvalLincenseChecked()
        gblArrEvalLicense.Clear()

        If chklstEvalLicense.CheckedItems.Count > 0 Then
            gblArrEvalLicense.Clear()
            For chkCtr = 0 To chklstEvalLicense.CheckedItems.Count - 1
                If Not DirectCast(chklstEvalLicense.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                    gblArrEvalLicense.Add(DirectCast(chklstEvalLicense.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0))
                End If
            Next
        End If
    End Sub

    Private Sub chklstEvalLicense_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles chklstEvalLicense.SelectedIndexChanged
        If chklstEvalLicense.SelectedIndex = 0 Then
            For rctr = 1 To chklstEvalLicense.Items.Count - 1
                chklstEvalLicense.SetItemChecked(rctr, chklstEvalLicense.GetItemChecked(0))
            Next
        End If
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports

            ObjCls.UserName = gblUserName
            ObjCls.ArticleName = txtArticleName.Text
            ObjPriDt = ObjCls.FunFetchTempBeverageRecon()
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Try

            StrPriHeaderFooter = "Beverage Reconciliation#" & Format(dtFromDate.Value, "dd-MMM-yyyy") & "-" & Format(dtToDate.Value, "dd-MMM-yyyy")

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