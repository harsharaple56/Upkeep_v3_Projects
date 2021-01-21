Imports System
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Web.UI
Imports iTextSharp.text.html.simpleparser
Imports System.Data
Imports System.Data.SqlClient


Namespace CWUtility
    Public Class Utility
        'DEFAULT PATH FOR PDF REPORTS
        Public Shared WorkingFolder = Path.Combine(Application.StartupPath, "PDFR")
        Public Shared WorkingFile = Path.Combine(WorkingFolder, "Output.pdf")
        Public Shared Doc As Document
        Public Sub New()
            'DELETE PREVIOUS OUTPUT
            If File.Exists(WorkingFile) Then
                File.Delete(WorkingFile)
            End If
            'Initialize Pdf Document
            Doc = New Document(PageSize.A4.Rotate())
        End Sub
    End Class

    Public Class ClsExportToPdf
        Inherits Utility

        Public Function GetLicenseDesc() As String
            Dim objm = New CWPlusBL.Master.Utitity
            objm.LicenseID = gblLicenseID
            GetLicenseDesc = objm.FunFetchLicenseByRights().Rows(0)("LicenseDesc")
        End Function

        Public Function MakeVariancePdf(ByVal dt As DataTable) As Boolean
            Dim ObjTitleFont, ObjPriFooter As iTextSharp.text.Font
            Dim ObjPriPara As Paragraph
            Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable
            Dim ObjPriPdfCell As PdfPCell
            ObjTitleFont = New Font(Font.HELVETICA, 9, Font.BOLD)
            ObjPriFooter = New Font(Font.COURIER, 7, Font.NORMAL)
            ObjTitleFont.Color = BaseColor.BLUE

            Try
                Using FS As New FileStream(WorkingFile, FileMode.Create, FileAccess.Write, FileShare.None)
                    ObjPriBorder = New PdfPTable(1)
                    ObjPriBorder.WidthPercentage = 100.0F

                    ObjPriMainTable = New PdfPTable(1)
                    ObjPriMainTable.WidthPercentage = 100.0F

                    ObjPriPara = New Paragraph("Variances " & GblPurchaseDate.ToString("dd-MMM-yyyy"), ObjTitleFont)
                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPara = New Paragraph(" ")
                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriTable = New PdfPTable(GetPdfTable(dt))

                    ObjPriPdfCell = New PdfPCell(ObjPriTable)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPara = New Paragraph(" ")
                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPdfCell = New PdfPCell(ObjPriMainTable)
                    ObjPriPdfCell.Padding = 5.0F
                    ObjPriBorder.AddCell(ObjPriPdfCell)

                    PdfWriter.GetInstance(Doc, FS)
                    Doc.Open()
                    Doc.Add(ObjPriBorder)
                    Doc.Close()
                    Return True
                End Using
            Catch
                Return False
            End Try
        End Function


        Private Function GetPdfTable(ByVal ObjGrd As DataTable) As PdfPTable
            GetPdfTable = Nothing
            Dim PdfPriTable As PdfPTable
            Dim PdfPriCell As PdfPCell
            Dim IntLocColCnt As Integer = 0
            Dim IntLocRowCnt As Integer = 0
            Dim IntNoOfColumns As Integer = 0
            Dim ObjSmallFont, ObjColumnHeader As New iTextSharp.text.Font
            Try
                ObjSmallFont.SetFamily("verdana")
                ObjSmallFont.Size = 6.0F

                ObjColumnHeader.SetFamily("verdana")
                ObjColumnHeader.Size = 6.0F

                PdfPriTable = New PdfPTable(ObjGrd.Columns.Count)

                For IntLocColCnt = 0 To ObjGrd.Columns.Count - 1
                    PdfPriCell = New PdfPCell(New Phrase(ObjGrd.Columns(IntLocColCnt).Caption, ObjColumnHeader))
                    PdfPriCell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    PdfPriTable.AddCell(PdfPriCell)
                Next

                For IntLocRowCnt = 0 To ObjGrd.Rows.Count - 1
                    For IntLocColCnt = 0 To ObjGrd.Columns.Count - 1
                        If (IsNothing(ObjGrd.Rows(IntLocRowCnt)(IntLocColCnt)) = False) AndAlso (IsDBNull(ObjGrd.Rows(IntLocRowCnt)(IntLocColCnt)) = False) Then
                            Dim StrLocItemData As String = ObjGrd.Rows(IntLocRowCnt)(IntLocColCnt)
                            If StrLocItemData <> "" Then
                                PdfPriCell = New PdfPCell(New Phrase(ObjGrd.Rows(IntLocRowCnt)(IntLocColCnt).ToString, ObjSmallFont))
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

        Public Sub MakeDocument()
            Dim dt = New DataTable
            dt.Columns.Add("Name")
            dt.Columns.Add("Contact No")
            For index = 1 To 26
                dt.Rows.Add("Name " & index, New Random().Next(955311101, 999999999))
            Next
            Using FS As New FileStream(WorkingFile, FileMode.Create, FileAccess.Write, FileShare.None)
                'Initialize Pdf Document

                Dim swr As New StreamWriter(FS)
                Dim sw As New StringWriter()
                Dim hw As New HtmlTextWriter(sw)

                sw.WriteLine("<span style='font-size:14px; color:red; font-family:'Comic Sans MS';'>")

                sw.Write("<span align='right'>" & Date.Now.ToString("dd-MMM-yyyy hh:mm:ss") & "</span> <br />")
                Dim grid As New Web.UI.WebControls.DataGrid
                Dim dtLoc As DataTable = dt
                grid.HeaderStyle.Font.Bold = True
                grid.DataSource = dtLoc
                grid.DataMember = dtLoc.TableName
                grid.DataBind()
                grid.RenderControl(hw)
                sw.Write("</span>")
                sw.Write("<hr/>")

                Dim sr As New StringReader(sw.ToString())
                Dim htmlparser As New HTMLWorker(Doc)
                PdfWriter.GetInstance(Doc, swr.BaseStream)
                Doc.Open()
                htmlparser.Parse(sr)
                swr.Write(Doc)
                Doc.Close()
            End Using
        End Sub

    End Class


    Public Class ClsCocktailReportPDF
        Inherits Utility
#Region "Print To Pdf "

        Dim TitlesHead As String
        Public Sub ExportToPdfv2(ByVal FilePath As String, ByVal FileName As String, ByVal Titles() As String, ByVal ParamArray srcGrid() As DataGridView)
            Dim pdfDoc As Document
            Dim fs As FileStream
            Dim ObjpdfWriter As PdfWriter
            Dim ObjPriPara As Paragraph
            Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable
            Dim ObjPriPdfCell As PdfPCell
            Dim titleCounter As Integer = 0
            Dim ObjTitleFont, ObjPriFooter, ObjPriHeader As iTextSharp.text.Font ''updated by abhijeet  on 1st July 201

            TitlesHead = Titles(titleCounter)

            Dim ITextHeaderFont1 As iTextSharp.text.Font
            ITextHeaderFont1 = FontFactory.GetFont("Thoma", 30, 1, BaseColor.GRAY)
            Try
                ObjTitleFont = New Font(Font.HELVETICA, 15, Font.BOLD)
                ObjPriFooter = New Font(Font.COURIER, 7, Font.NORMAL)
                ObjPriHeader = New Font(Font.HELVETICA, 12, Font.BOLD)  ''updated by abhijeet  on 1st July 2016 

                pdfDoc = New Document(PageSize.A1.Rotate(), 5.0F, 5.0F, 5.0F, 5.0F)
                fs = New FileStream(Path.Combine(FilePath, FileName & ".pdf"), FileMode.Create, FileAccess.Write)

                ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)

                pdfDoc.Open()

                ObjPriBorder = New PdfPTable(1)
                ObjPriBorder.WidthPercentage = 100.0F

                ObjPriMainTable = New PdfPTable(1)
                'ObjPriMainTable.WidthPercentage = 100.0F

                'ObjPriTable.WidthPercentage = 40
                ObjPriMainTable.WidthPercentage = 40


                'Dim img As Image = Image.GetInstance(Path.Combine(Application.StartupPath, "pdf.png"))
                'img.ScaleToFit(12.0f0, 12.0f0)

                'ObjPriPdfCell = New PdfPCell(img)
                'ObjPriPdfCell.Border = 0
                'ObjPriMainTable.AddCell(ObjPriPdfCell)


                'ObjPriPara = New Paragraph(Titles(titleCounter), ObjTitleFont)



                'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                'ObjPriPdfCell.Border = 0

                'ObjPriMainTable.AddCell(ObjPriPdfCell)

                'Commented By RV On 28-March-2019 STARTS
                'ObjPriPara = New Paragraph("Date:-" & Date.Now.ToString() & "|  License Name - " & MDI.cmbLicenseName.Text, ObjPriHeader)
                'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                'ObjPriPdfCell.Border = 0
                'ObjPriMainTable.AddCell(ObjPriPdfCell)
                'Commented By RV On 28-March-2019 ENDS


                For Each grd As DataGridView In srcGrid
                    'ObjPriPara = New Paragraph(Titles(titleCounter), ObjTitleFont)

                    'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    'ObjPriPdfCell.Border = 0
                    'ObjPriMainTable.AddCell(ObjPriPdfCell)

                    'ObjPriPara = New Paragraph("")

                    'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    'ObjPriPdfCell.Border = 0
                    'ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriTable = New PdfPTable(GetPdfTable(grd))

                    ObjPriPdfCell = New PdfPCell(ObjPriTable)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPara = New Paragraph("Date:-" & Date.Now.ToString() & "|  License Name - " & MDI.cmbLicenseName.Text, ObjPriHeader)     'Added By RV On 28-March-2019

                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPara = New Paragraph("")

                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    titleCounter += 1
                Next


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

        'ADD by Mohammed
        Public Sub ExportToPdfv2New(ByVal FilePath As String, ByVal FileName As String, ByVal Titles() As String, ByVal ParamArray srcGrid() As DataGridView)
            Dim pdfDoc As Document
            Dim fs As FileStream
            Dim ObjpdfWriter As PdfWriter
            Dim ObjPriPara As Paragraph
            Dim ObjPriMainTable, ObjPriTable, ObjPriBorder As PdfPTable
            Dim ObjPriPdfCell As PdfPCell
            Dim titleCounter As Integer = 0
            Dim ObjTitleFont, ObjPriFooter, ObjPriHeader, ObjPriCell As iTextSharp.text.Font ''updated by abhijeet  on 1st July 201

            TitlesHead = Titles(titleCounter)

            Dim ITextHeaderFont1 As iTextSharp.text.Font
            ITextHeaderFont1 = FontFactory.GetFont("Thoma", 30, 1, BaseColor.GRAY)
            Try
                ObjTitleFont = New Font(Font.HELVETICA, 15, Font.BOLD)
                ObjPriFooter = New Font(Font.COURIER, 7, Font.NORMAL)
                ObjPriHeader = New Font(Font.HELVETICA, 12, Font.BOLD)  ''updated by abhijeet  on 1st July 2016 
                ObjPriCell = New Font(Font.HELVETICA, 12, Font.NORMAL)

                pdfDoc = New Document(PageSize.A1.Rotate(), 2.0F, 2.0F, 2.0F, 2.0F)
                fs = New FileStream(Path.Combine(FilePath, FileName & ".pdf"), FileMode.Create, FileAccess.Write)

                ObjpdfWriter = PdfWriter.GetInstance(pdfDoc, fs)

                pdfDoc.Open()

                ObjPriBorder = New PdfPTable(1)
                ObjPriBorder.WidthPercentage = 100.0F

                ObjPriMainTable = New PdfPTable(1)
                'ObjPriMainTable.WidthPercentage = 100.0F

                'ObjPriTable.WidthPercentage = 40
                ObjPriMainTable.WidthPercentage = 100


                'Dim img As Image = Image.GetInstance(Path.Combine(Application.StartupPath, "pdf.png"))
                'img.ScaleToFit(12.0f0, 12.0f0)

                'ObjPriPdfCell = New PdfPCell(img)
                'ObjPriPdfCell.Border = 0
                'ObjPriMainTable.AddCell(ObjPriPdfCell)


                'ObjPriPara = New Paragraph(Titles(titleCounter), ObjTitleFont)



                'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                'ObjPriPdfCell.Border = 0

                'ObjPriMainTable.AddCell(ObjPriPdfCell)

                'Commented By RV On 28-March-2019 STARTS
                'ObjPriPara = New Paragraph("Date:-" & Date.Now.ToString() & "|  License Name - " & MDI.cmbLicenseName.Text, ObjPriHeader)
                'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                'ObjPriPdfCell.Border = 0
                'ObjPriMainTable.AddCell(ObjPriPdfCell)
                'Commented By RV On 28-March-2019 ENDS


                For Each grd As DataGridView In srcGrid
                    'ObjPriPara = New Paragraph(Titles(titleCounter), ObjTitleFont)

                    'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    'ObjPriPdfCell.Border = 0
                    'ObjPriMainTable.AddCell(ObjPriPdfCell)

                    'ObjPriPara = New Paragraph("")

                    'ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    'ObjPriPdfCell.Border = 0
                    'ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriTable = New PdfPTable(GetPdfTableNew(grd))

                    ObjPriPdfCell = New PdfPCell(ObjPriTable)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPara = New Paragraph("Date:-" & Date.Now.ToString() & "|  License Name - " & MDI.cmbLicenseName.Text, ObjPriHeader)     'Added By RV On 28-March-2019

                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0
                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    ObjPriPara = New Paragraph("")

                    ObjPriPdfCell = New PdfPCell(ObjPriPara)
                    ObjPriPdfCell.Border = 0

                    ObjPriMainTable.AddCell(ObjPriPdfCell)

                    titleCounter += 1
                Next


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

        'Added by Mohammed


        Private Function GetPdfTableNew(ByVal ObjGrd As DataGridView) As PdfPTable
            GetPdfTableNew = Nothing
            Dim PdfPriTable As PdfPTable
            Dim PdfPriCell As PdfPCell
            Dim IntLocColCnt As Integer = 0
            Dim IntLocRowCnt As Integer = 0
            Dim IntNoOfColumns As Integer = 0
            Dim ObjSmallFont, ObjColumnHeader As New iTextSharp.text.Font

            ''Shiva
            Dim titleCounter As Integer = 0
            Dim ObjTitleFont As iTextSharp.text.Font


            Dim ITextHeaderFont1 As iTextSharp.text.Font
            ITextHeaderFont1 = FontFactory.GetFont("Thoma", 24, 1, BaseColor.GRAY)
            ''Shiva


            Try
                ObjSmallFont.SetFamily("verdana")
                ObjSmallFont.Size = 28.0F

                ObjColumnHeader.SetFamily("verdana")
                ObjColumnHeader.Size = 24.0F

                '  ObjGrd.Rows.Add("SHIVA")



                For IntLocColCnt = 0 To ObjGrd.ColumnCount - 1
                    If Not ObjGrd.Columns(CInt(IntLocColCnt)).Visible Then Continue For
                    IntNoOfColumns += 1
                Next

                PdfPriTable = New PdfPTable(IntNoOfColumns)



                PdfPriCell = New PdfPCell(New Phrase(TitlesHead, ITextHeaderFont1))
                PdfPriCell.Colspan = ObjGrd.ColumnCount
                PdfPriCell.HorizontalAlignment = 1
                PdfPriTable.AddCell(PdfPriCell)

                For IntLocColCnt = 0 To ObjGrd.ColumnCount - 1
                    If Not ObjGrd.Columns(CInt(IntLocColCnt)).Visible Then Continue For
                    PdfPriCell = New PdfPCell(New Phrase(ObjGrd.Columns(IntLocColCnt).HeaderText, ObjColumnHeader))
                    PdfPriCell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    PdfPriTable.AddCell(PdfPriCell)
                Next


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
                GetPdfTableNew = PdfPriTable
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


            Dim ITextHeaderFont1 As iTextSharp.text.Font
            ITextHeaderFont1 = FontFactory.GetFont("Thoma", 15, 1, BaseColor.GRAY)
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



                PdfPriCell = New PdfPCell(New Phrase(TitlesHead, ITextHeaderFont1))
                PdfPriCell.Colspan = ObjGrd.ColumnCount
                PdfPriCell.HorizontalAlignment = 1
                PdfPriTable.AddCell(PdfPriCell)

                For IntLocColCnt = 0 To ObjGrd.ColumnCount - 1
                    If Not ObjGrd.Columns(CInt(IntLocColCnt)).Visible Then Continue For
                    PdfPriCell = New PdfPCell(New Phrase(ObjGrd.Columns(IntLocColCnt).HeaderText, ObjColumnHeader))
                    PdfPriCell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                    PdfPriTable.AddCell(PdfPriCell)
                Next


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

        Public Sub ExportToPdfNew(ByVal FilePath As String, ByVal FileName As String, ByVal Titles() As String, ByVal ParamArray srcGrid() As DataTable)
            srcGrid(0).Columns.Remove("catg")
            srcGrid(0).Columns.Remove("Brand")
            srcGrid(0).Columns.Remove("fllicno")
            srcGrid(0).Columns.Remove("fllicname")
            srcGrid(0).Columns.Remove("fdate")
            srcGrid(0).Columns("shortname").ColumnName = "Brand"
            Dim document As Document = New Document
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(Path.Combine(FilePath, FileName & ".pdf"), FileMode.Create, FileAccess.Write))
            document.Open()
            'iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("c://ggi logo.bmp");
            'document.Add(img);
            Dim font5 As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 4)
            Dim font8 As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 15.0F)
            'float[] columnDefinitionSize = { 22F, 22F, 12.0fF, 7.75F, 7.77F, 7.77F, 7.77F, 7.77F, 10.88F, 10.88F, 10.88F, 4.75F, 7.77F, 7.77F, 7.77F, 7.77F, 7.77F, 7.77F, 9F };
            Dim table As PdfPTable = New PdfPTable(srcGrid(0).Columns.Count)
            Dim row As PdfPRow = Nothing
            Dim widths() As Single = New Single() {40.0F, 30.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F, 12.0F}
            table.SetWidths(widths)
            table.WidthPercentage = 100
            Dim iCol As Integer = 0
            Dim colname As String = ""
            Dim cell As PdfPCell = New PdfPCell(New Phrase("Products"))
            '''table.AddCell(cell);
            cell.Colspan = srcGrid(0).Columns.Count
            'cell.Border = 0;
            'cell.HorizontalAlignment = 1;
            For Each c As DataColumn In srcGrid(0).Columns
                table.AddCell(New Phrase(c.ColumnName, font5))
            Next
            'cell.BackgroundColor = new iTextSharp.text.Color(0xC0, 0xC0, 0xC0);
            For Each r As DataRow In srcGrid(0).Rows
                If (srcGrid(0).Rows.Count > 0) Then
                    table.AddCell(New Phrase(r(0).ToString, font5))
                    table.AddCell(New Phrase(r(1).ToString, font5))
                    table.AddCell(New Phrase(r(2).ToString, font5))
                    table.AddCell(New Phrase(r(3).ToString, font5))
                    table.AddCell(New Phrase(r(4).ToString, font5))
                    table.AddCell(New Phrase(r(5).ToString, font5))
                    table.AddCell(New Phrase(r(6).ToString, font5))
                    table.AddCell(New Phrase(r(7).ToString, font5))
                    table.AddCell(New Phrase(r(8).ToString, font5))
                    table.AddCell(New Phrase(r(9).ToString, font5))
                    table.AddCell(New Phrase(r(10).ToString, font5))
                    table.AddCell(New Phrase(r(11).ToString, font5))
                    table.AddCell(New Phrase(r(12).ToString, font5))
                    table.AddCell(New Phrase(r(13).ToString, font5))
                    table.AddCell(New Phrase(r(14).ToString, font5))
                    table.AddCell(New Phrase(r(15).ToString, font5))
                    table.AddCell(New Phrase(r(16).ToString, font5))
                    table.AddCell(New Phrase(r(17).ToString, font5))
                    table.AddCell(New Phrase(r(18).ToString, font5))
                    table.AddCell(New Phrase(r(19).ToString, font5))
                    table.AddCell(New Phrase(r(20).ToString, font5))
                    table.AddCell(New Phrase(r(21).ToString, font5))
                    table.AddCell(New Phrase(r(22).ToString, font5))
                    table.AddCell(New Phrase(r(23).ToString, font5))
                    table.AddCell(New Phrase(r(24).ToString, font5))
                    table.AddCell(New Phrase(r(25).ToString, font5))
                    table.AddCell(New Phrase(r(26).ToString, font5))
                    table.AddCell(New Phrase(r(27).ToString, font5))
                    table.AddCell(New Phrase(r(28).ToString, font5))
                    table.AddCell(New Phrase(r(29).ToString, font5))
                    table.AddCell(New Phrase(r(30).ToString, font5))
                    table.AddCell(New Phrase(r(31).ToString, font5))
                    table.AddCell(New Phrase(r(32).ToString, font5))
                    table.AddCell(New Phrase(r(33).ToString, font5))
                    table.AddCell(New Phrase(r(34).ToString, font5))
                    table.AddCell(New Phrase(r(35).ToString, font5))
                    table.AddCell(New Phrase(r(36).ToString, font5))
                    table.AddCell(New Phrase(r(37).ToString, font5))

                End If
            Next
            document.Add(table)
            document.Close()
        End Sub






#End Region





    End Class

End Namespace