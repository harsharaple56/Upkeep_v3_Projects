Imports CWPlusBL.Master
Public Class frmOneDayPermitNumber
    Dim ObjOneDayPermit As New ClsOneDayPermitNumber
    Dim objPriDt As DataTable
#Region "Functions"
    Sub FetchOneDayPermitNumber()
        Try
            ObjOneDayPermit = New ClsOneDayPermitNumber
            objPriDt = New DataTable
            ObjOneDayPermit.IsMaster = 1
            ObjOneDayPermit.LicenseID = MDI.cmbLicenseName.SelectedValue
            objPriDt = ObjOneDayPermit.FunFetch()
            grdList.DataSource = Nothing
            grdList.DataSource = objPriDt

            grdList.Columns("OneDayPermitId").Visible = False
            grdList.Columns("CurrentPermitNo").Visible = False
            grdList.Columns("FromPermitNo").HeaderText = "From"
            grdList.Columns("ToPermitNo").HeaderText = "To"
            ClrScr()
        Catch ex As Exception
            ObjOneDayPermit = Nothing
            objPriDt = Nothing
        End Try

    End Sub

    Sub ClrScr()
        txtFrom.Clear()
        txtTo.Clear()
        lblID.Text = 0
    End Sub

    Sub Save()
        If txtFrom.Text = "" Or txtTo.Text = "" Then
            MsgBox("From/To should not be empty", MsgBoxStyle.Information)
            Exit Sub
        End If
        Try
            ObjOneDayPermit = New ClsOneDayPermitNumber
            ObjOneDayPermit.OneDayPermitId = lblID.Text
            ObjOneDayPermit._From = txtFrom.Text
            ObjOneDayPermit._To = txtTo.Text
            ObjOneDayPermit.UserName = gblUserName
            ObjOneDayPermit.LicenseID = MDI.cmbLicenseName.SelectedValue
            ObjOneDayPermit.FunSave()
            MsgBox(ObjOneDayPermit.ErrorMsg, MsgBoxStyle.Information)
            FetchOneDayPermitNumber()
        Catch ex As Exception
            ObjOneDayPermit = Nothing
        End Try
    End Sub

    Sub FunDelete(ByVal ID As Double)

        Try
            ObjOneDayPermit = New ClsOneDayPermitNumber
            ObjOneDayPermit.OneDayPermitId = ID
            ObjOneDayPermit.FunDelete()
            MsgBox(ObjOneDayPermit.ErrorMsg, MsgBoxStyle.Information)
            FetchOneDayPermitNumber()
        Catch ex As Exception
            ObjOneDayPermit = Nothing
        End Try
    End Sub
#End Region
  
#Region "Events"
    Private Sub txtFrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFrom.KeyPress, txtTo.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
              Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
    Private Sub frmOneDayPermitNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FetchOneDayPermitNumber()
    End Sub
    Private Sub grdList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If CBool(grdList("isused", e.RowIndex).Value) Then
            MsgBox("It's already used", MsgBoxStyle.Information)
            Exit Sub
        End If
        lblID.Text = grdList("OneDayPermitId", e.RowIndex).Value
        txtFrom.Text = grdList("FromPermitNo", e.RowIndex).Value
        txtTo.Text = grdList("ToPermitNo", e.RowIndex).Value
    End Sub
    Private Sub grdList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If grdList.Columns(e.ColumnIndex).Name.ToLower = "delete" Then

            If CBool(grdList("isused", e.RowIndex).Value) Then
                MsgBox("It's already used", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNoCancel) = vbYes Then
                FunDelete(CDbl(grdList("OneDayPermitId", e.RowIndex).Value))
            End If
         
        End If
    End Sub
#End Region
  
  
   
   
End Class