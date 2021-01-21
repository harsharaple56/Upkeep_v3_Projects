Imports CWPlusBL

Public Class FrmQuickControls
    Dim dt As DataTable
    Dim objQV As ClsQuickExcess
    Public Sub BindGrid()
        Try
            dt = New DataTable
            objQV = New ClsQuickExcess
            objQV.Month = 0
            objQV.Year = 0
            objQV.FromDate = dtpFrom.Value
            objQV.ToDate = DtpTo.Value
            dt = objQV.FetchControlsDatewise.Tables(0)
            grd.DataSource = Nothing
            grd.DataSource = dt
            grd.Columns("ControlHeadID").Visible = False
        Catch ex As Exception
            Throw ex
        Finally
            dt = Nothing
            objQV = Nothing
        End Try

    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        BindGrid()
    End Sub
    Private Sub FrmQuickControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub
    Public Sub DeleteRecords(ByVal ControlID As Double)
        Try
            Dim Ans As String = MsgBox("Are You Sure Want To Remove", MsgBoxStyle.YesNo, "Remove")
            If Ans = vbNo Then
                Exit Sub
            End If
            objQV = New ClsQuickExcess
            objQV.ControlID = ControlID
            objQV.FunDeleteControls()
            MsgBox(objQV.ErrorMsg)
            BindGrid()
        Catch ex As Exception
            Throw ex
        Finally
            dt = Nothing
            objQV = Nothing
        End Try
    End Sub
    Private Sub grd_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentClick
        If e.ColumnIndex = 0 Then
            DeleteRecords(grd.Item("ControlHeadID", e.RowIndex).Value)
        End If
    End Sub

    Private Sub BtnCostAdjustment_Click(sender As System.Object, e As System.EventArgs) Handles BtnCostAdjustment.Click
        Try 
            If MDI.cmbLicenseName.SelectedValue > 0 Then
                Dim Ans As String = MsgBox("Are you sure you want to run cost adjustment it may take some time!!!", MsgBoxStyle.YesNo, "Remove")
                If Ans = vbNo Then
                    Exit Sub
                End If
                objQV = New ClsQuickExcess
                objQV.RunCostAdjustment(MDI.cmbLicenseName.SelectedValue)
                MsgBox(objQV.ErrorMsg)
            Else
                MsgBox("Please select license", MsgBoxStyle.Exclamation, "CWPlus")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            objQV = Nothing
        End Try
    End Sub
End Class