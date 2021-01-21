Imports System
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Web.UI
Imports iTextSharp.text.html.simpleparser

Public Class FrmOptimumQtyReport
    Dim objCocktail As New CWPlusBL.Master.ClsCocktailReports
    Dim ObjDt As DataTable
    Dim StrPriLicenseNo, StrPriLicenseName, StrPriAddresss As String

#Region "Procedures"
    Public Sub BindGrid()
        ObjDt = New DataTable
        objCocktail = New CWPlusBL.Master.ClsCocktailReports
        objCocktail.LicenseID = MDI.cmbLicenseName.SelectedValue
        objCocktail.ReportDate = dtDate.Value
        ObjDt = objCocktail.FunFetchOptQtyReport(IIf(Trim(txtTimeout.Text) = "", 30, Trim(txtTimeout.Text)))
        grdBaseQtyReport.DataSource = Nothing
        grdBaseQtyReport.DataSource = ObjDt
        MakeIDColumnsHide(grdBaseQtyReport)
        grdBaseQtyReport.Columns("LicenseNo").Visible = False
        grdBaseQtyReport.Columns("LicenseDesc").Visible = False
        grdBaseQtyReport.Columns("address").Visible = False
        StrPriLicenseNo = ObjDt.Rows(0).Item("LicenseNo")
        StrPriLicenseName = ObjDt.Rows(0).Item("LicenseDesc")
        StrPriAddresss = ObjDt.Rows(0).Item("address")
    End Sub
#End Region
    Private Sub btnok_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjDt = New DataTable
        ObjDt = DirectCast(grdBaseQtyReport.DataSource, DataTable)
        ExportExcelTemplate(ObjDt)
    End Sub
    Dim arrReportName(0) As String

    Private Sub btnPdf_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        arrReportName(0) = "Optimum Stock Report on " & Format(dtDate.Value, "dd-MMM-yyyy hh:mm:ss tt") & vbCrLf & StrPriLicenseNo & StrPriLicenseName & vbCrLf & StrPriAddresss & vbCrLf & vbCrLf
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            'Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            'ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdBaseQtyReport)
            ExportOptimumQtyToPDF(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileNameWithoutExtension(SaveFile.FileName), arrReportName, grdBaseQtyReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub


    Private Sub btnMailReport_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

    Public Sub SendReport()
        Try
            arrReportName(0) = "Optimum Stock Report on " & Format(dtDate.Value, "dd-MMM-yyyy hh:mm:ss tt") & vbCrLf & StrPriLicenseNo & StrPriLicenseName & vbCrLf & StrPriAddresss & vbCrLf & vbCrLf
            Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
            If IO.File.Exists(SaveFile) Then
                IO.File.Delete(SaveFile)
            End If
            'Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            'ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBaseQtyReport)
            ExportOptimumQtyToPDF(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdBaseQtyReport)
            frmSendReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#Region "Print To Pdf "

    Dim TitlesHead As String
    Public Sub ExportOptimumQtyToPDF(ByVal FilePath As String, ByVal FileName As String, ByVal Titles() As String, ByVal ParamArray srcGrid() As DataGridView)
        Dim pdfDoc As Document
        Dim fs As FileStream
        Dim ObjpdfWriter As PdfWriter
        Dim ObjPriPara As Paragraph
        Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable
        Dim ObjPriPdfCell As PdfPCell
        Dim titleCounter As Integer = 0
        Dim ObjTitleFont, ObjPriFooter As iTextSharp.text.Font

        TitlesHead = Titles(titleCounter)

        Dim ReportHeader As iTextSharp.text.Font
        ReportHeader = FontFactory.GetFont("Thoma", 30, 1, BaseColor.GRAY)
        Try
            ObjTitleFont = New iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 15, iTextSharp.text.Font.BOLD)
            ObjPriFooter = New iTextSharp.text.Font(iTextSharp.text.Font.COURIER, 7, iTextSharp.text.Font.NORMAL)

            pdfDoc = New Document(PageSize.A4.Rotate(), 5.0F, 5.0F, 5.0F, 5.0F)
            fs = New FileStream(Path.Combine(FilePath, FileName & ".pdf"), FileMode.Create, FileAccess.Write)
            ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)

            ObjpdfWriter.PageEvent = New HeaderPDF(grdBaseQtyReport, TitlesHead)

            pdfDoc.Open()

            ObjPriBorder = New PdfPTable(1)
            ObjPriBorder.WidthPercentage = 100.0F

            ObjPriMainTable = New PdfPTable(1)
            ObjPriMainTable.WidthPercentage = 40

            'ObjPriPdfCell = New PdfPCell(New Phrase(TitlesHead))
            'ObjPriPdfCell.HorizontalAlignment = 1
            'ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriTable = New PdfPTable(GetPdfTable(grdBaseQtyReport))
            ObjPriPdfCell = New PdfPCell(ObjPriTable)
            ObjPriPdfCell.Border = 0
            ObjPriPdfCell.PaddingTop = 71.0F
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("")
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("")
            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPara = New Paragraph("Printed by - " & My.User.Name & " | Printed on - " & Date.Now.ToString("dd-MMM-yyyy hh:mm:ss"), ObjPriFooter)

            ObjPriPdfCell = New PdfPCell(ObjPriPara)
            ObjPriPdfCell.Border = 0
            ObjPriMainTable.AddCell(ObjPriPdfCell)

            ObjPriPdfCell = New PdfPCell(ObjPriMainTable)
            ObjPriPdfCell.Padding = 5.0F
            ObjPriBorder.AddCell(ObjPriPdfCell)

            pdfDoc.Add(ObjPriBorder)

            pdfDoc.Close()

            fs.Flush()
            fs.Close()
        Catch ex As ObjectDisposedException
            'do nothing
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(pdfDoc) = Nothing Then
                pdfDoc = Nothing
            End If
            If IsNothing(fs) = Nothing Then
                fs = Nothing
            End If
        End Try
    End Sub

    Private Function GetPdfTable(ByVal ObjGrd As DataGridView) As PdfPTable
        GetPdfTable = Nothing
        Dim PdfPriTable As PdfPTable
        Dim PdfPriCell As PdfPCell
        Dim IntLocColCnt As Integer = 0
        Dim IntLocRowCnt As Integer = 0
        Dim IntNoOfColumns As Integer = 0
        Dim ObjSmallFont, ObjColumnHeader As New iTextSharp.text.Font

        ''Shiva
        Dim titleCounter As Integer = 0
        Dim ObjTitleFont As iTextSharp.text.Font


        'Dim ITextHeaderFont1 As iTextSharp.text.Font
        'ITextHeaderFont1 = FontFactory.GetFont("Thoma", 15, 1, BaseColor.GRAY)
        ''Shiva


        Try
            ObjSmallFont.SetFamily("verdana")
            ObjSmallFont.Size = 10.0F

            ObjColumnHeader.SetFamily("verdana")
            ObjColumnHeader.Size = 10.0F

            '  ObjGrd.Rows.Add("SHIVA")

            For IntLocColCnt = 0 To ObjGrd.ColumnCount - 1
                If Not ObjGrd.Columns(CInt(IntLocColCnt)).Visible Then Continue For
                IntNoOfColumns += 1
            Next

            PdfPriTable = New PdfPTable(IntNoOfColumns)

            'commented by sachin on 20 Apr for header repeation in all pages
            'PdfPriCell = New PdfPCell(New Phrase(TitlesHead))
            'PdfPriCell.Colspan = ObjGrd.ColumnCount
            'PdfPriCell.HorizontalAlignment = 1
            'PdfPriTable.AddCell(PdfPriCell)

            'For IntLocColCnt = 0 To ObjGrd.ColumnCount - 1
            '    If Not ObjGrd.Columns(CInt(IntLocColCnt)).Visible Then Continue For
            '    PdfPriCell = New PdfPCell(New Phrase(ObjGrd.Columns(IntLocColCnt).HeaderText, ObjColumnHeader))
            '    PdfPriCell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            '    PdfPriTable.AddCell(PdfPriCell)
            'Next


            For IntLocRowCnt = 0 To ObjGrd.RowCount - 1

                For IntLocColCnt = 0 To ObjGrd.ColumnCount - 1
                    If Not ObjGrd.Columns(CInt(IntLocColCnt)).Visible Then Continue For

                    If IsNothing(ObjGrd.Item(IntLocColCnt, IntLocRowCnt).Value) = False Then
                        Dim StrLocItemData As String = IIf(IsDBNull(ObjGrd.Item(IntLocColCnt, IntLocRowCnt).Value), "", ObjGrd.Item(IntLocColCnt, IntLocRowCnt).Value)
                        If StrLocItemData <> "" Then
                            PdfPriCell = New PdfPCell(New Phrase(StrLocItemData, ObjSmallFont))
                        Else
                            PdfPriCell = New PdfPCell(New Phrase(""))
                        End If
                    Else
                        PdfPriCell = New PdfPCell(New Phrase(""))
                    End If
                    PdfPriTable.AddCell(PdfPriCell)

                Next
            Next

            PdfPriTable.WidthPercentage = 100.0F
            GetPdfTable = PdfPriTable
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(PdfPriTable) = False Then
                PdfPriTable = Nothing
            End If
            If IsNothing(PdfPriCell) = False Then
                PdfPriCell = Nothing
            End If
        End Try
    End Function




#End Region



    Private Sub FrmOptimumQtyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTimeout.Text = 500
    End Sub
End Class

Public Class HeaderPDF
    Implements IPdfPageEvent

    Private dtGrid As DataGridView
    Private Title As String

    Public Sub New(ByVal grid As DataGridView, ByVal TitlesHead As String)
        dtGrid = grid
        Title = TitlesHead
    End Sub

    Public Sub OnChapter(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, paragraphPosition As Single, title As iTextSharp.text.Paragraph) Implements iTextSharp.text.pdf.IPdfPageEvent.OnChapter

    End Sub

    Public Sub OnChapterEnd(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnChapterEnd

    End Sub

    Public Sub OnCloseDocument(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnCloseDocument

    End Sub

    Public Sub OnEndPage(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnEndPage

    End Sub

    Public Sub OnGenericTag(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, rect As iTextSharp.text.Rectangle, text As String) Implements iTextSharp.text.pdf.IPdfPageEvent.OnGenericTag

    End Sub

    Public Sub OnOpenDocument(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnOpenDocument

    End Sub

    Public Sub OnParagraph(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnParagraph

    End Sub

    Public Sub OnParagraphEnd(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnParagraphEnd

    End Sub

    Public Sub OnSection(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, paragraphPosition As Single, depth As Integer, title As iTextSharp.text.Paragraph) Implements iTextSharp.text.pdf.IPdfPageEvent.OnSection

    End Sub

    Public Sub OnSectionEnd(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document, paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnSectionEnd

    End Sub

    Public Sub OnStartPage(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnStartPage
        Dim table As New PdfPTable(1)
        'table.WidthPercentage = 100; //PdfPTable.writeselectedrows below didn't like this
        table.TotalWidth = 822 'document.PageSize.Width - document.LeftMargin - document.RightMargin
        'this centers [table]
        Dim table2 As New PdfPTable(12)
        Dim cell2 As PdfPCell

        Dim ObjColumnHeader As New iTextSharp.text.Font
        ObjColumnHeader.SetFamily("verdana")
        ObjColumnHeader.Size = 10.0F

        'For IntLocColCnt As Integer = 0 To dtGrid.ColumnCount - 1
        '    If Not dtGrid.Columns(CInt(IntLocColCnt)).Visible Then Continue For
        '    cell2 = New PdfPCell(New Phrase(dtGrid.Columns(IntLocColCnt).HeaderText, ObjColumnHeader))
        '    cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        '    table2.AddCell(cell2)
        'Next


        'Dim ITextHeaderFont1 As iTextSharp.text.Font
        'ITextHeaderFont1 = FontFactory.GetFont("Thoma", 30, 1, BaseColor.GRAY)

        cell2 = New PdfPCell(New Phrase(Title))
        cell2.Colspan = 12
        cell2.HorizontalAlignment = 1
        table2.AddCell(cell2)



        cell2 = New PdfPCell(New Phrase("Category", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Subcategory", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Brand", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Size", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Optimum Level", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)


        cell2 = New PdfPCell(New Phrase("Opening", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Purchase", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Sale", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Closing", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("BaseQty", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Reorder Level", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        cell2 = New PdfPCell(New Phrase("Excess Quantity", ObjColumnHeader))
        cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        table2.AddCell(cell2)

        'For IntLocColCnt = 0 To 11
        '    cell2 = New PdfPCell(New Phrase("Header", ObjColumnHeader))
        '    cell2.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
        '    table2.AddCell(cell2)
        'Next

        'title
        'cell2 = New PdfPCell(New Phrase(vbLf & "TITLE", New Font(Font.HELVETICA, 16, Font.BOLD Or Font.UNDERLINE)))
        'cell2.HorizontalAlignment = Element.ALIGN_CENTER
        'cell2.Colspan = 2
        'table2.AddCell(cell2)

        Dim cell As New PdfPCell(table2)
        table.AddCell(cell)

        table.WriteSelectedRows(0, -1, document.LeftMargin + 5, document.PageSize.Height - 5, writer.DirectContent)
    End Sub
End Class