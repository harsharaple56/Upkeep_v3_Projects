Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml
Imports System.Data.SqlClient

Public Class FrmBulkLiterReport
    Dim xmldocString As String


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AddTheme(grpBulkReport)
    End Sub
    Private Sub FrmBulkLiterReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'FetchAPBangloreReport()
    End Sub


    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        FetchAPBangloreReport()
    End Sub
    Dim answer As String
    Dim blisValid As Boolean = False
    Dim gblDt As DataTable

    Public Sub FetchAPBangloreReport()
        Dim ObjBulkReport As New ClsCocktailReports
        'Dim ObjDt As New DataTable
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        Try
            gblDt = New DataTable
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

            If gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            gblArrMDICheckedLicense.Clear()
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
            '''''''For Cocktail GroupBox 
            If grpBulkReport.Visible = True Then
                For cntr = 0 To gblArrMDICheckedLicense.Count - 1
                    XmlElt = xmldoc.CreateElement("License")
                    XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
                    xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
                Next
            End If
            ObjBulkReport.CocktailReportXml = xmldoc
            xmldocString = xmldoc.InnerXml
            ObjBulkReport.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            ObjBulkReport.ToDate = DtToDate.Value.ToString("dd-MMM-yyyy")
            ObjBulkReport.isValid = True

            Dim timeout As Integer
            timeout = IIf(Trim(txtTimeOut.Text) = "", 30, Trim(txtTimeOut.Text))

            gblDt = ObjBulkReport.FunFetchBulkLiterReport(timeout)
            grdBulkLiterReport.DataSource = gblDt

            'If ObjBulkReport.StrPriOutMsg = "U Have Selected Restorant and store License" Then
            '    answer = MsgBox(ObjBulkReport.StrPriOutMsg & vbCrLf & "Do u Want To continue", MsgBoxStyle.YesNo, "CWPlus")

            '    If answer = vbNo Then
            '        Exit Sub
            '    Else
            '        Dim ObjBulkReportforNo = New ClsCocktailReports
            '        Dim objDtForNo = New DataTable
            '        ObjBulkReportforNo.CocktailReportXml = xmldoc
            '        ObjBulkReportforNo.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            '        ObjBulkReportforNo.ToDate = DtToDate.Value.ToString("dd-MMM-yyyy")
            '        ObjBulkReportforNo.isValid = ObjBulkReport.bloutbit

            '        blisValid = ObjBulkReport.bloutbit

            '        objDtForNo = ObjBulkReportforNo.FunFetchBulkLiterReport()
            '        grdBulkLiterReport.DataSource = objDtForNo
            '        gblDt = objDtForNo
            '        Exit Sub
            '    End If

            'Else
            '    Dim ObjBulkReportforNo = New ClsCocktailReports
            '    Dim objDtForNo = New DataTable
            '    ObjBulkReportforNo.CocktailReportXml = xmldoc
            '    ObjBulkReportforNo.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            '    ObjBulkReportforNo.ToDate = DtToDate.Value.ToString("dd-MMM-yyyy")
            '    ObjBulkReportforNo.isValid = ObjBulkReport.bloutbit
            '    blisValid = ObjBulkReport.bloutbit
            '    objDtForNo = ObjBulkReportforNo.FunFetchBulkLiterReport()
            '    grdBulkLiterReport.DataSource = objDtForNo

            '    gblDt = objDtForNo
            '    Exit Sub
            'End If
            ''grdBulkLiterReport.DataSource = ObjDt
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjBulkReport) = False Then
                ObjBulkReport = Nothing
            End If
        End Try
    End Sub




    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        Dim StrApp As String = "'" & xmldocString & "','" & dtFromDate.Text & "','" & DtToDate.Text & "'," & blisValid & " "
        GenerateReport("BulkReport", "proc#" & "Spr_BulkReportLiter" & "#" & StrApp & "")
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            MsgBox("Please select license", vbInformation, "CWPlus")
            Exit Sub
        End If

        If Me.grdBulkLiterReport.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If
        Try
            ExportExcelTemplate(gblDt)
        Catch ex As Exception
            Throw ex
        Finally

            If IsNothing(gblDt) = False Then
                gblDt = Nothing
            End If
        End Try
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim arrReportName(0) As String

        arrReportName(0) = "Bulk License Report"
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBulkLiterReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub
End Class