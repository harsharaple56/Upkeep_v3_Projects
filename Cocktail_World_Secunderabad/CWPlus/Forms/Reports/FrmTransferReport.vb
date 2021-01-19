Imports System.Data
Imports CWPlusBL.Master
Public Class FrmTransferReport
    Dim arrReportName(0) As String
    Dim gblDdataTable As DataTable
    Public _Brand As String = ""
    Public _Category As String = ""
    Public _Size As String = ""
    Public _Cocktail As String = ""
    Public chk As Boolean

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
     
        FetchTransferReports()
    End Sub

    Private Sub FrmTransferReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindLicenseForTransfer()
        FetchTransferReports()
        arrReportName(0) = "TransferReports"
    End Sub

    Public Sub FetchTransferReports()
        chk = True

        lblTotalCost.Text = ""
        Dim ObjTransfer As New ClsTransfer
        Dim ObjPriDt As New DataTable
        Try

            ObjTransfer.ToLicenseID = Me.cmbToLicense.SelectedValue
            ObjTransfer.Brand = _Brand
            ObjTransfer.Category = _Category
            ObjTransfer.Size = _Size
            ObjTransfer.Cocktail = _Cocktail

            ObjTransfer.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjTransfer.FromDate = dtFromDate.Value.ToString("dd-MMM-yyyy")
            ObjTransfer.ToDate = dtToDate.Value.ToString("dd-MMM-yyyy")
            ObjTransfer.TPNo = txtTPNo.Text
            ObjTransfer.InviceNo = txtInvoiceNo.Text
            ObjTransfer.FLIVAddress = txtFLIV.Text
            ObjPriDt = ObjTransfer.FunFetchTransferReports
            ' ObjPriDt.Columns.Remove("TransferHeadID")


            gblDdataTable = ObjPriDt
            grdTransferReport.DataSource = Nothing
            grdTransferReport.DataSource = ObjPriDt

            If chk Then
                CalculateQty()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjTransfer) = False Then
                ObjTransfer = Nothing
            End If
            If IsNothing(ObjPriDt) = False Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Not TypeOf (MDI.cmbLicenseName.SelectedValue) Is Decimal Then
            MsgBox("Please select license", vbInformation, "CWPlus")
            Exit Sub
        End If

        If Me.grdTransferReport.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If

        Dim objCocktail As New ClsCocktailReports

        Try
            ExportExcelTemplate(gblDdataTable)

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objCocktail) = False Then
                objCocktail = Nothing
            End If
            'If IsNothing(gblDdataTable) = False Then
            '    gblDdataTable = Nothing
            'End If
        End Try
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click

        If Me.grdTransferReport.Rows.Count = 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If
        Dim SaveFile As New SaveFileDialog
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), arrReportName, grdTransferReport)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim ObjSearch As New dlgReportSearch
        ObjSearch.IntForm = 2
        If ObjSearch.ShowDialog = DialogResult.OK Then
            FetchTransferReports()
        End If
    End Sub

    Private Sub btnCrystalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrystalReport.Click
        MsgBox("Not Done", MsgBoxStyle.Critical)
    End Sub

    Public Sub BindLicenseForTransfer()
        Dim objlicense As New clsMultipleLicenase
        Dim objDt As New DataTable

        Try
            ObjLicense.LicenseID = MDI.cmbLicenseName.SelectedValue
            objDt = objlicense.FunFetch
            ComboBindingTemplate(cmbToLicense, objDt, "LicenseDesc", "LicenseID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjLicense) Then
                ObjLicense = Nothing
            End If
            If Not IsNothing(objdt) Then
                objdt = Nothing
            End If
        End Try
    End Sub

    Public Sub CalculateQty()
        Dim vBtl As Double = 0
        Dim vSpeg As Double = 0
        Dim vLpeg As Double = 0
        If grdTransferReport.Visible Then
            For index = 0 To grdTransferReport.RowCount - 1
                vBtl += grdTransferReport("BottleQty", index).Value
                vSpeg += grdTransferReport("SpegQty", index).Value
                'vLpeg += grdTransferReport("lpeg", index).Value
            Next
            lblTotalCost.Text = "Bottle:   " & vBtl & "  SPeg:   " & vSpeg
        End If
        
    End Sub

    Private Sub grdTransferReport_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTransferReport.CellContentClick
        If grdTransferReport.Columns(e.ColumnIndex).Name.ToLower = "edit" Then
            If Not CBool(fetchRights("Transfer").Rows(0).Item("Edit")) Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Transfer")
                Exit Sub
            End If
            Dim objTransfer As New FrmTransfer()
            objTransfer.IsReport = True
            objTransfer.TransferHeadID = grdTransferReport.Item("TransferHeadID", e.RowIndex).Value
            objTransfer.txtFLIV.Text = IIf(IsDBNull(grdTransferReport.Item("FLIV", e.RowIndex).Value), "", grdTransferReport.Item("FLIV", e.RowIndex).Value)
            objTransfer.txtInvoiceNo.Text = grdTransferReport.Item("InvioceNo", e.RowIndex).Value
            objTransfer.txtTransferHeadTPNo.Text = grdTransferReport.Item("TpNo", e.RowIndex).Value
            objTransfer.dtpTransferHead.Value = CDate(grdTransferReport.Item("Transfer Date", e.RowIndex).Value)
            objTransfer.MdiParent = MDI
            objTransfer.Show()
            objTransfer.WindowState = FormWindowState.Maximized
        ElseIf grdTransferReport.Columns(e.ColumnIndex).Name.ToLower = "delete" Then
            If Not CBool(fetchRights("Transfer").Rows(0).Item("delete")) Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Transfer")
                Exit Sub
            End If
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Transfer")
            If Ans = vbNo Then
                Exit Sub
            End If
            Dim objTransfer As New ClsTransfer
            Dim ObjDt As New DataTable
            Dim objSale As New ClsSale
            objTransfer.TransferHeadID = grdTransferReport.Item("TransferHeadID", e.RowIndex).Value
            objTransfer.UserName = gblUserName
            objSale.LicenseID = MDI.cmbLicenseName.SelectedValue
            objSale.BillDate = grdTransferReport.Item("Transfer Date", e.RowIndex).Value
            ObjDt = objSale.FunFetchSaleEditVar()                        'Added By RV on 13-Sep-2019

            'Added By RV on 13-Sep-2019 Starts
            If ObjDt.Rows.Count > 0 Then
                MessageBox.Show("Cannot Delete Used in Variance")

            Else

                Dim str As String = objTransfer.FunDelete
                MsgBox(objTransfer.ErrorMsg)
                btnok.PerformClick()
            End If
        End If
    End Sub
End Class