Public Class FrmChataiRackOutletReport
    Dim objRack As CWPlusBL.Master.RackOutletReports
    Dim ObjDta As DataTable

    Sub BindGrid()
        grdData.Rows.Clear()
        grdData.Columns.Clear()
        grdData.DataSource = Nothing

        If Not MDI.cmbLicenseName.SelectedValue > 0 Then
            MsgBox("Select a license", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If
        Try
            objRack = New CWPlusBL.Master.RackOutletReports
            objRack.FromDate = dtchataiFromDate.Value
            objRack.ToDate = dtchataiToDate.Value
            objRack.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjDta = objRack.FunFetchChataiReportForRackOutlet()
            If ObjDta.Rows.Count > 0 Then
                FunChataiReport(ObjDta)
            End If

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub FunChataiReport(ByVal dt As DataTable)

        Dim dtGrp As New DataTable
        dtGrp = dt.DefaultView.ToTable(True, "date")

        Dim dtGrpCols As New DataTable
        dtGrpCols = dt.DefaultView.ToTable(True, "catg", "siz")

        grdData.Columns.Add("Title", "")
        grdData.Columns.Add("Date", "Date")
        grdData.Columns.Add("TPNO", "TPNO")
        grdData.Columns("Date").Width = 180

        For index = 0 To dtGrpCols.Rows.Count - 1
            If index = 0 Then
                grdData.Columns.Add(dtGrpCols.Rows(index)("catg"), dtGrpCols.Rows(index)("catg"))
                grdData.Columns(CStr(dtGrpCols.Rows(index)("catg"))).ReadOnly = True
            Else
                If Not dtGrpCols.Rows(index - 1)("catg") = dtGrpCols.Rows(index)("catg") Then
                    grdData.Columns.Add(dtGrpCols.Rows(index)("catg"), dtGrpCols.Rows(index)("catg"))
                    grdData.Columns(CStr(dtGrpCols.Rows(index)("catg"))).ReadOnly = True
                End If
            End If
            grdData.Columns.Add(dtGrpCols.Rows(index)("catg") & dtGrpCols.Rows(index)("siz"), dtGrpCols.Rows(index)("siz"))
        Next

        For index = 0 To dtGrp.Rows.Count - 1
            Dim dv As DataView
            dv = New DataView(dt)
            dv.RowFilter = "date='" & dtGrp.Rows(index)("date") & "'"
            grdData.Rows.Add("Opening", dtGrp.Rows(index)("date"), Nothing)
            grdData.Rows(grdData.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
            grdData.Rows.Add("Purchase", Nothing, dv(0)("tpno"))
            grdData.Rows.Add("Total", Nothing, Nothing)
            grdData.Rows.Add("Sale", Nothing, dv(0)("trntpno"))
            grdData.Rows.Add("Closing", Nothing, Nothing)
            Dim rwIndex As Integer = grdData.RowCount - 5
            For dvCtr = 0 To dv.Count - 1
                For inctr = 0 To 4
                    grdData.Item(CStr(dv(dvCtr + inctr)("catg") & dv(dvCtr + inctr)("siz")), rwIndex + inctr).Value = dv(dvCtr + inctr)("totsale")
                Next
                dvCtr += 4
            Next
        Next
        grdData.Columns(0).Frozen = True
        grdData.Columns(1).Frozen = True
        grdData.AutoResizeColumns()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      
        If Not ObjDta.Rows.Count > 0 Then
            MsgBox("Nothing To Export ")
            Exit Sub
        End If
        Try
            ExportExcelTemplate(ObjDta)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click
        Dim SaveFile As New SaveFileDialog

        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(SaveFile.FileName) Then
                IO.File.Delete(SaveFile.FileName)
            End If
            Dim ObjPdf As New CWUtility.ClsCocktailReportPDF
            ObjPdf.ExportToPdfv2(IO.Path.GetDirectoryName(SaveFile.FileName), IO.Path.GetFileName(SaveFile.FileName), {"Chatai Rack Outlet Report"}, grdData)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Exported Successfully !" & vbCrLf & "Do you want to open the file ?", "CWPlus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Process.Start(SaveFile.FileName & ".pdf")
            End If
        End If
    End Sub
End Class