Imports System
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Web.UI
Imports iTextSharp.text.html.simpleparser

Public Class ClsCostingReport

    'DEFAULT PATH FOR PDF REPORTS
    Dim WorkingFolder = Path.Combine(Application.StartupPath, "PDFR")
    Dim WorkingFile = Path.Combine(WorkingFolder, "Output.pdf")

    Dim Doc As Document

    Public Sub New()
        'DELETE PREVIOUS OUTPUT
        If File.Exists(WorkingFile) Then
            File.Delete(WorkingFile)
        End If
    End Sub

    Public Sub InitPdfDoc(FS As FileStream)
        'Initialize Pdf Document
        Doc = New Document(PageSize.LETTER)
    End Sub

    Public Sub MakeDocument()
        Dim dt = New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Contact No")
        For index = 1 To 26
            dt.Rows.Add("Name " & index, New Random().Next(955311101, 999999999))
        Next

        Using FS As New FileStream(WorkingFile, FileMode.Create, FileAccess.Write, FileShare.None)
            'Initialize Pdf Document
            InitPdfDoc(FS)
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
