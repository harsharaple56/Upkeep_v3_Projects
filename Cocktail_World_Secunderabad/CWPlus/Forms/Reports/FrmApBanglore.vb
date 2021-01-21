Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient



Public Class FrmApBanglore
    Dim CocktailReportMenuID As Integer
    Dim StrProcedureName As String
    Dim GroupBoxName As String
    Dim StrReportName As String
    Dim StrSubReportName As String
    Dim arrReportName(0) As String
    Dim isCombine As Integer
    Dim gblDataTable As DataTable
    Dim xmldocString As String
    Dim filepath As String
    Dim FileName As String

   




    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTheme(grpApReport)
    End Sub

    Private Sub FrmApBanglore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grpApReport.Visible = False
        FetchMenuIDForCocktailReport()
    End Sub
#Region "Procedure"
    Public Sub FetchMenuIDForCocktailReport()
        Dim objCocktail As New ClsCocktailReports
        Dim ObjDt As New DataTable
        Try
            objCocktail.MenuDesc = gblMenuDesc
            ObjDt = objCocktail.FunFetchMenuID
            If ObjDt.Rows.Count > 0 Then
                CocktailReportMenuID = ObjDt.Rows(0).Item("MenuID")
                StrProcedureName = ObjDt.Rows(0).Item("procedurename")
                GroupBoxName = ObjDt.Rows(0).Item("GroupboxName")
                StrReportName = ObjDt.Rows(0).Item("ReportName")
                isCombine = ObjDt.Rows(0).Item("isCombine")
                arrReportName(0) = StrReportName



                btnok.Enabled = ObjDt.Rows(0).Item("ok")
                btnExport.Enabled = ObjDt.Rows(0).Item("Excel")
                ' btnCrystalReport.Enabled = ObjDt.Rows(0).Item("Crystal")
                btnPdf.Enabled = ObjDt.Rows(0).Item("pdf")

            End If

            Dim obj1() As Control
            obj1 = Me.Controls.Find(GroupBoxName, True)
            obj1(0).Location = New Point(12, 12)
            'grpApReport.Text = StrReportName

            If StrReportName = "apreport" Then
                grpApReport.Text = "Form-7B(Daily)"
            ElseIf StrReportName = "banglorereport" Then
                grpApReport.Text = "Brandwise"
            ElseIf StrReportName = "delhireport" Then
                grpApReport.Text = "Brandwise(Daily)"
            ElseIf StrReportName = "ap6Breport" Then
                grpApReport.Text = "Form R-6B(Daily)"
            End If


            grdApBangloreReport.Text = UCase(gblMenuDesc) & " " & "Report"
            If obj1.Length > 0 Then obj1(0).Visible = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GenerateLicenseXML() As XmlDocument
        GenerateLicenseXML = Nothing
        Dim xmldoc As XmlDocument
        xmldoc = New XmlDocument
        xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            XmlElt = xmldoc.CreateElement("License")
            XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
            xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
        Next
        GenerateLicenseXML = xmldoc
    End Function

    Public Sub FetchAPBangloreReport()
        Dim ObjApBang As New ClsCocktailReports
        Dim ObjDt As New DataTable
        'Dim xmldoc As New XmlDocument
        'xmldoc.LoadXml("<CWPLUS><AllLicense></AllLicense></CWPLUS>")
        'Dim XmlElt As XmlElement = xmldoc.CreateElement("License")
        Try
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

            If gblArrMDICheckedLicense.Count = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
            gblArrMDICheckedLicense.Clear()
            FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

            '''''''For Cocktail GroupBox 
            'If grpApReport.Visible = True Then
            'For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            'XmlElt = xmldoc.CreateElement("License")
            'XmlElt.SetAttribute("LicenseID", gblArrMDICheckedLicense.Item(cntr))
            'xmldoc.DocumentElement.Item("AllLicense").AppendChild(XmlElt)
            'Next
            'End If
            ObjApBang.CocktailReportXml = GenerateLicenseXML()
            'xmldocString = xmldoc.InnerXml
            ObjApBang.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            ObjApBang.ToDate = dtToDate.Value.ToString("dd-MMM-yyyy")
            ObjApBang.All = isCombine
            ObjApBang.UserName = gblUserName
            ObjDt = ObjApBang.FunFetchApBangloreReport(StrProcedureName, IIf(txtTimeOut.Text = "", 30, CInt(txtTimeOut.Text)))
            gblDataTable = ObjDt
            grdApBangloreReport.DataSource = ObjDt

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjApBang) = False Then
                ObjApBang = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
        End Try
    End Sub

    Public Function GetLicenseID() As String

        'GetLicenseID = False
        gblArrMDICheckedLicense.Clear()
        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)
        For cntr = 0 To gblArrMDICheckedLicense.Count - 2
            GetLicenseID &= gblArrMDICheckedLicense.Item(cntr) & ","
        Next
        GetLicenseID &= gblArrMDICheckedLicense.Item(gblArrMDICheckedLicense.Count - 1)
    End Function
    Private Function GetFirstDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim Flr4FromDate As DateTime = dtDate
        Flr4FromDate = Flr4FromDate.AddDays(-(Flr4FromDate.Day - 1))
        dtFromDate.Text = Flr4FromDate
        Return Flr4FromDate
    End Function

    Private Function GetLastDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim Flr4ToDate As New DateTime(dtDate.Year, dtDate.Month, 1)
        Flr4ToDate = Flr4ToDate.AddMonths(1)
        Flr4ToDate = Flr4ToDate.AddDays(-(Flr4ToDate.Day))
        dtToDate.Text = Flr4ToDate
        Return Flr4ToDate


    End Function

#End Region

#Region "Print To PDF Report"
    Private Sub GenerateReportCombined(ByVal locdt As DataTable)
        Dim pdfDoc As Document
        Dim fs As FileStream


        Dim ObjpdfWriter As PdfWriter
        Dim ObjPriPdfCell As PdfPCell
        Dim ObjPriPara As Paragraph
        Dim width As Integer()
        Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable
        Dim ObjTitleFont, ObjPriFooter, ObjNormal, ObjHeader, ObjSmall As iTextSharp.text.Font
        Try
            'ObjTitleFont = New Font(iTextSharp.text.Font.COURIER, 9, Font.Bold)
            ObjNormal = New Font(iTextSharp.text.Font.TIMES_ROMAN, 8)
            ObjHeader = New Font(iTextSharp.text.Font.TIMES_ROMAN, 12, Font.Bold)
            ObjSmall = New Font(iTextSharp.text.Font.TIMES_ROMAN, 6)
            'ObjPriFooter = New Font(iTextSharp.text.Font.COURIER, 7)

            pdfDoc = New Document(PageSize.A4, 5.0F, 5.0F, 5.0F, 0.0F)

            'If File.Exists(Path.Combine("D:\", "sachin_pdf" & ".pdf")) Then
            '    File.Delete(Path.Combine("D:\", "sachin_pdf" & ".pdf"))
            'End If

            'fs = New FileStream(Path.Combine("D:\", "sachin_pdf" & ".pdf"), FileMode.Create, FileAccess.Write)
            'ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)





            If File.Exists(Path.Combine(Application.StartupPath, PdfReportName & ".pdf")) Then
                File.Delete(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
            End If
            fs = New FileStream(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"), FileMode.Create, FileAccess.Write)
            ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)

            pdfDoc.Open()
            width = New Integer() {100}
            ObjPriTable = New PdfPTable(3)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("License"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("LicenseNumber"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph(Format(dtFromDate.Value, "dd-MMM-yyyy") & "-" & Format(dtToDate.Value, "dd-MMM-yyyy"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)






            ObjPriMainTable = New PdfPTable(7)

            width = New Integer() {34, 12, 11, 12, 12, 10, 15}

            ObjPriMainTable.SetWidths(width)



            'ObjPriMainTable.WidthPercentage = 40

            'pdfDoc.Add(New iTextSharp.text.Phrase("sachin"))

            ObjPriPara = New Paragraph("Brand name", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)


            ObjPriPara = New Paragraph("Size(ML)", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Permit No", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Opening", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Purchase", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Sales", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Closing Stock", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            For IntLocCnt As Integer = 0 To locdt.Rows.Count - 1

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("BrandDesc").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriMainTable.AddCell(ObjPriPdfCell)


                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Size").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("PermitNo").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("opening").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)

                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Purchase").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)

                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Sale").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)

                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Closing").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)

                ObjPriMainTable.AddCell(ObjPriPdfCell)

            Next


            pdfDoc.Add(ObjPriTable)
            pdfDoc.Add(ObjPriMainTable)

            pdfDoc.Close()
            fs.Flush()
            fs.Close()
        Catch pdf As ObjectDisposedException
            Process.Start(IO.Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Dim PdfReportName As String = ""
    Private Sub GenerateReportWithBorder(ByVal locdt As DataTable)
        Dim pdfDoc As Document
        Dim fs As FileStream
        Dim ObjpdfWriter As PdfWriter
        Dim ObjPriPdfCell As PdfPCell
        Dim ObjPriPara As Paragraph
        Dim width As Integer()
        Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable


        Dim ObjTitleFont, ObjPriFooter, ObjNormal, ObjHeader, ObjSmall As iTextSharp.text.Font
        Try
            'ObjTitleFont = New Font(iTextSharp.text.Font.COURIER, 9, Font.Bold)
            ObjNormal = New Font(iTextSharp.text.Font.TIMES_ROMAN, 10)
            ObjHeader = New Font(iTextSharp.text.Font.TIMES_ROMAN, 14, Font.Bold)
            ObjSmall = New Font(iTextSharp.text.Font.TIMES_ROMAN, 9)
            'ObjPriFooter = New Font(iTextSharp.text.Font.COURIER, 7)

            pdfDoc = New Document(PageSize.A4.Rotate(), 5.0F, 5.0F, 5.0F, 0.0F)




            If File.Exists(Path.Combine(Application.StartupPath, PdfReportName & ".pdf")) Then
                File.Delete(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))

            End If

            fs = New FileStream(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"), FileMode.Create, FileAccess.Write)

            ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)
            pdfDoc.Open()
            width = New Integer() {100}

            ObjPriTable = New PdfPTable(3)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("License"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Form - 7B" & vbCrLf & "( SEE RULE - 38 )", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("LicenseNumber"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("DAILY BRAND WISE ACCOUNTS REGISTER", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("(Separate page should be set apart for each type of Liquor with an index in the front page of the register)", ObjSmall)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 1
            ObjPriTable.AddCell(ObjPriPdfCell)


            ObjPriMainTable = New PdfPTable(7)
            width = New Integer() {10, 30, 17, 10, 10, 10, 15}

            ObjPriMainTable.SetWidths(width)

            'ObjPriMainTable.WidthPercentage = 40

            'pdfDoc.Add(New iTextSharp.text.Phrase("sachin"))

            ObjPriPara = New Paragraph("Date", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Brand", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Opening Quarts", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Receipts Quarts", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Issues Quarts", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Balance Quarts", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Signature of the License", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("1", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("2", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("3", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("4", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("5", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("6", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("7", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 1
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            For IntLocCnt As Integer = 0 To locdt.Rows.Count - 1

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Date").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("BrandDesc").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("opening").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("purchase").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Sale").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Closing").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)


                ObjPriPara = New Paragraph("", ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)
            Next

            pdfDoc.Add(ObjPriTable)
            pdfDoc.Add(ObjPriMainTable)

            pdfDoc.Close()

            fs.Flush()
            fs.Close()
        Catch pdf As ObjectDisposedException
            Process.Start(IO.Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GenerateReportWithOutBorder(ByVal locdt As DataTable)
        Dim pdfDoc As Document
        Dim fs As FileStream
        Dim ObjpdfWriter As PdfWriter
        Dim ObjPriPdfCell As PdfPCell
        Dim ObjPriPara As Paragraph
        Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable
        Dim width As Integer()
        Dim ObjTitleFont, ObjPriFooter, ObjNormal, ObjHeader, ObjHeaderForBrand, ObjSmall As iTextSharp.text.Font
        Try
            'ObjTitleFont = New Font(iTextSharp.text.Font.COURIER, 9, Font.Bold)
            ObjNormal = New Font(iTextSharp.text.Font.TIMES_ROMAN, 10)
            ObjHeader = New Font(iTextSharp.text.Font.TIMES_ROMAN, 14, Font.Bold)
            ObjSmall = New Font(iTextSharp.text.Font.TIMES_ROMAN, 9)
            'ObjPriFooter = New Font(iTextSharp.text.Font.COURIER, 7)
            ObjHeaderForBrand = New Font(iTextSharp.text.Font.TIMES_ROMAN, 12, Font.Bold)

            pdfDoc = New Document(PageSize.A4.Rotate(), 0.0F, 0.0F, 0.0F, 0.0F)

            If File.Exists(Path.Combine(Application.StartupPath, PdfReportName & ".pdf")) Then
                File.Delete(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
            End If

            fs = New FileStream(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"), FileMode.Create, FileAccess.Write)
            ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)
            pdfDoc.Open()


            Width = New Integer() {100}
            ObjPriTable = New PdfPTable(1)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("License"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Form - 7B" & vbCrLf & "( SEE RULE - 38 )", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("LicenseNumber"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("", ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("DAILY BRAND WISE ACCOUNTS REGISTER", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("(Separate page should be set apart for each type of Liquor with an index in the front page of the register)", ObjSmall)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.Border = 0
            'ObjPriTable.AddCell(ObjPriPdfCell)


            ObjPriMainTable = New PdfPTable(7)
            width = New Integer() {20, 60, 34, 20, 20, 20, 30}

            ObjPriMainTable.SetWidths(width)

            'ObjPriMainTable.WidthPercentage = 40

            'pdfDoc.Add(New iTextSharp.text.Phrase("sachin"))

            'ObjPriPara = New Paragraph("Date", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Brand", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Opening Quarts", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Receipts Quarts", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Issues Quarts", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Balance Quarts", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Signature of the License", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("1", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("2", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("3", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("4", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("5", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("6", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("7", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriPdfCell.Border = 0
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            For IntLocCnt As Integer = 0 To locdt.Rows.Count - 1

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Date").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriPdfCell.Border = 0

                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("BrandDesc").ToString, ObjHeaderForBrand)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("opening").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("purchase").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Sale").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Closing").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)


                ObjPriPara = New Paragraph("", ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                'ObjPriPdfCell.HorizontalAlignment = 1
                ObjPriMainTable.AddCell(ObjPriPdfCell)
            Next

            pdfDoc.Add(ObjPriTable)
            pdfDoc.Add(ObjPriMainTable)

            pdfDoc.Close()

            fs.Flush()
            fs.Close()
        Catch pdf As ObjectDisposedException
            Process.Start(IO.Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GenerateReportCombinedWithoutBorder(ByVal locdt As DataTable)
        Dim pdfDoc As Document
        Dim fs As FileStream
        Dim ObjpdfWriter As PdfWriter
        Dim ObjPriPdfCell As PdfPCell

        Dim width As Integer()
        Dim ObjPriPara As Paragraph
        Dim ObjPriMainTable, ObjPriTable, ObjPriBorder, ObjPriSpace As PdfPTable
        Dim ObjTitleFont, ObjPriFooter, ObjNormal, ObjHeader, ObjSmall As iTextSharp.text.Font


        Try
            'ObjTitleFont = New Font(iTextSharp.text.Font.COURIER, 9, Font.Bold)
            ObjNormal = New Font(iTextSharp.text.Font.TIMES_ROMAN, 8)
            ObjHeader = New Font(iTextSharp.text.Font.TIMES_ROMAN, 13, Font.Bold)
            ObjSmall = New Font(iTextSharp.text.Font.TIMES_ROMAN, 6)
            'ObjPriFooter = New Font(iTextSharp.text.Font.COURIER, 7)

            pdfDoc = New Document(PageSize.A4, 5.0F, 5.0F, 5.0F, 0.0F)


            If File.Exists(Path.Combine(Application.StartupPath, PdfReportName & ".pdf")) Then
                File.Delete(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
            End If
            fs = New FileStream(Path.Combine(Application.StartupPath, PdfReportName & ".pdf"), FileMode.OpenOrCreate, FileAccess.ReadWrite)
            ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)


            ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)


            pdfDoc.Open()
            width = New Integer() {100}
            ObjPriSpace = New PdfPTable(1)
            ObjPriPara = New Paragraph("")
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriPdfCell.Padding = 10.0F
            ObjPriSpace.AddCell(ObjPriPdfCell)
            ObjPriSpace.SetWidths(width)
            pdfDoc.Add(ObjPriSpace)

            ObjPriTable = New PdfPTable(3)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("License"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph(locdt.Rows(0).Item("LicenseNumber"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 2
            ObjPriPdfCell.Border = 0
            'ObjPriPdfCell.Right = 2
            ObjPriTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph(Format(dtToDate.Value, "dd-MMM-yyyy"), ObjHeader)
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.HorizontalAlignment = 2
            ObjPriPdfCell.Border = 0
            ObjPriTable.AddCell(ObjPriPdfCell)
            pdfDoc.Add(ObjPriTable)



            pdfDoc.Add(ObjPriSpace)

            ObjPriMainTable = New PdfPTable(7)

            width = New Integer() {33, 5, 17, 10, 10, 10, 15}

            ObjPriMainTable.SetWidths(width)
            'ObjPriPara = New Paragraph("Brand name", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Size", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Permit No", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Opening", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Purchase", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Sales", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            'ObjPriPara = New Paragraph("Closing Stock", ObjHeader)
            'ObjPriPdfCell = New PdfPCell(ObjPriPara)
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)




            For IntLocCnt As Integer = 0 To locdt.Rows.Count - 1

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("BrandDesc").ToString, ObjNormal)
                'ObjPriPdfCell.Width = 200.0F
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0

                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Size").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("PermitNo").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("opening").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("purchase").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("SALE").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                ObjPriMainTable.AddCell(ObjPriPdfCell)

                ObjPriPara = New Paragraph(locdt.Rows(IntLocCnt).Item("Closing").ToString, ObjNormal)
                ObjPriPdfCell = New PdfPCell(ObjPriPara)
                ObjPriPdfCell.Border = 0
                ObjPriMainTable.AddCell(ObjPriPdfCell)

            Next


            pdfDoc.Add(ObjPriMainTable)

            pdfDoc.Close()
            fs.Flush()
            fs.Close()

            'Process.Start(IO.Path.Combine(Application.StartupPath, "PDFR\Banglore_pdf" & ".pdf"))
        Catch pdf As ObjectDisposedException
            Process.Start(IO.Path.Combine(Application.StartupPath, PdfReportName & ".pdf"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim IntLicenseValue As Integer

        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            IntLicenseValue = gblArrMDICheckedLicense.Item(cntr)
        Next

        If IntLicenseValue = 0 Then
            If MDI.cmbLicenseName.SelectedValue = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
        End If

        FetchAPBangloreReport()
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        'Dim SaveFile As New SaveFileDialog
        'If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    If IO.File.Exists(SaveFile.FileName) Then
        '        IO.File.Delete(SaveFile.FileName)
        '    End If
        'filepath = IO.Path.GetDirectoryName(FileName)
        '    FileName = IO.Path.GetFileName(SaveFile.FileName)
        'Else
        '    Exit Sub
        'End If

        If StrReportName = "banglorereport" Then
            If chkISBorder.Checked = False And isCombine = True Then
                PdfReportName = "PDFR\Banglore_pdf"
                GenerateReportCombinedWithoutBorder(gblDataTable)
            End If

            If chkISBorder.Checked = True And isCombine = True Then
                PdfReportName = "PDFR\Banglore_pdf"
                GenerateReportCombined(gblDataTable)
            End If
        End If

        If StrReportName = "apreport" Then
            If chkISBorder.Checked = False And isCombine = False Then
                PdfReportName = "PDFR\ApReport_pdf"
                GenerateReportWithOutBorder(gblDataTable)
            End If
            If chkISBorder.Checked = True And isCombine = False Then
                PdfReportName = "PDFR\ApReport_pdf"
                GenerateReportWithBorder(gblDataTable)
            End If
        End If

        If StrReportName = "delhireport" Then
            If chkISBorder.Checked = False And isCombine = False Then
                PdfReportName = "PDFR\Delhi_pdf"
                GenerateReportWithOutBorder(gblDataTable)
            End If
            If chkISBorder.Checked = True And isCombine = False Then
                PdfReportName = "PDFR\Delhi_pdf"
                GenerateReportWithBorder(gblDataTable)
            End If

        End If




        'Dim dlgRes As DialogResult
        'dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If dlgRes = Windows.Forms.DialogResult.Yes Then
        '    Process.Start(SaveFile.FileName & ".pdf")
        'End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            MsgBox("Please select license", vbInformation, "CWPlus")
            Exit Sub
        End If

        If Me.grdApBangloreReport.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If
        Dim objCocktail As New ClsCocktailReports
        Try
            ExportExcelTemplate(gblDataTable)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objCocktail) = False Then
                objCocktail = Nothing
            End If
        End Try
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click

        Dim IntLicenseValue As Integer

        FetchMDILicenseChecked(MDI.chkLicenseName, MDI.cmbLicenseName.SelectedValue)

        For cntr = 0 To gblArrMDICheckedLicense.Count - 1
            IntLicenseValue = gblArrMDICheckedLicense.Item(cntr)
        Next

        If IntLicenseValue = 0 Then
            If MDI.cmbLicenseName.SelectedValue = 0 Then
                MsgBox("Please Select License")
                Exit Sub
            End If
        End If

        xmldocString = GenerateLicenseXML().InnerXml
        Dim StrApp As String = "'" & xmldocString & "','" & dtFromDate.Text & "','" & dtToDate.Text & "'," & isCombine & ",'" & gblUserName & "'"
        GenerateReport(StrReportName, "proc#" & StrProcedureName & "#" & StrApp & "", txtTimeOut.Text)
    End Sub

    Public Sub SendReport()
        Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
        If IO.File.Exists(SaveFile) Then
            IO.File.Delete(SaveFile)
        End If
        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdApBangloreReport)
        frmSendReport.Show()
    End Sub

    Private Sub btnMailReport_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

    Private Sub txtTimeOut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTimeOut.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
        Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If

        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub
End Class