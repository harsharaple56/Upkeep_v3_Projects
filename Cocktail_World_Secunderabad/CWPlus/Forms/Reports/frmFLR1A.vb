Imports CWPlusBL.Master
Public Class frmFLR1A




    Dim ObjPriDt As DataTable


    Public Sub BindCombo()
        Dim ObjTransferHead As New ClsTransfer
        Try
            ObjPriDt = New DataTable
            ObjTransferHead.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjTransferHead.FromDate = dtFromDate.Text
            ObjTransferHead.ToDate = dtToDate.Text
            ObjPriDt = ObjTransferHead.FunFetch
            ComboBindingTemplate(cmbTPNo, ObjPriDt, "tpno", "transferheadid")
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjTransferHead) = False Then
                ObjTransferHead = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub
    Public Sub BindGrid()
        Dim ObjTransferHead As New ClsTransfer
        Try
            ObjPriDt = New DataTable
            ObjTransferHead.TransferHeadID = cmbTPNo.SelectedValue
            ObjPriDt = ObjTransferHead.FunFetchFLR1A
            grdFLR1A.DataSource = Nothing
            grdFLR1A.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjTransferHead) = False Then
                ObjTransferHead = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Public Sub BindGridforFLR9()
        Dim ObjTransferHead As New ClsTransfer
        Try
            ObjPriDt = New DataTable
            ObjTransferHead.TransferHeadID = cmbTPNo.SelectedValue
            ObjPriDt = ObjTransferHead.FunFetchFLR9
            grdFLR1A.DataSource = Nothing
            grdFLR1A.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjTransferHead) = False Then
                ObjTransferHead = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub frmFLR1A_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'by shiva
        'FetchMenuIDForCocktailReport()
        ' by shiva
        BindCombo()
    End Sub

    Private Sub cmbTPNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTPNo.SelectedIndexChanged
        If Not TypeOf (cmbTPNo.SelectedValue) Is Decimal Then
            Exit Sub
        End If
        'BindGrid()
        If gblMenuDesc = Trim("flr1a") Then
            BindGrid()
        Else
            BindGridforFLR9()
        End If


    End Sub

    Private Sub dtFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromDate.ValueChanged, dtToDate.ValueChanged
        BindCombo()
    End Sub


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ObjPriDt = New DataTable
        ObjPriDt = DirectCast(grdFLR1A.DataSource, DataTable)
        ExportExcelTemplate(ObjPriDt)
    End Sub
    Dim arrReportName(0) As String
    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click


        If gblMenuDesc = Trim("flr1a") Then
            arrReportName(0) = "FLR1A Report"
        Else
            arrReportName(0) = "FLR9A Report"
        End If

        'arrReportName(0) = "FLR1A Report"


        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdFLR1A)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")

            End If
        End If
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click

        If gblMenuDesc = Trim("flr1a") Then
            'GenerateReport("flr1a", "proc#" & "Spr_FetchflrIA" & "#" & StrApp & "")
            GenerateReport("FL1a", "proc#" & "Spr_FetchflrIA" & "#" & cmbTPNo.SelectedValue & "")
        Else
            GenerateReport("Flr9a", "proc#" & "Spr_Fetchflr9A" & "#" & cmbTPNo.SelectedValue & "")
        End If


    End Sub


    Public Sub SendReport()
        Dim SaveFile As String = Application.StartupPath & "\CW_Report.pdf"
        If IO.File.Exists(SaveFile) Then
            IO.File.Delete(SaveFile)
        End If
        Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
        ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile), IO.Path.GetFileNameWithoutExtension(SaveFile), arrReportName, grdFLR1A)
        frmSendReport.Show()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnMailReport.Click
        SendReport()
    End Sub

End Class