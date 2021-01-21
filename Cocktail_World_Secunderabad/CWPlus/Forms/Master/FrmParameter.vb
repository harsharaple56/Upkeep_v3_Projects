Imports System.Data
Imports CWPlusBL.Master
Public Class FrmParameter

    Private Sub FrmParameter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        cmbParameter.SelectedItem = "<---Select--->"
        FetchParameterMaster()
        lblParameterID.Visible = False
    End Sub

    Public Sub BindCombo()
        cmbParameter.Items.Add("<---Select--->")
        cmbParameter.Items.Add("Negative")
        cmbParameter.Items.Add("Positive")
    End Sub

    Public Function Save() As Boolean
        Save = False
        Dim ObjParameter As New ClsParameter
        Dim ObjDt As New DataTable

        Try
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Parameter")
                Exit Function
            End If
            ObjParameter.ParameterName = txtParameterName.Text
            ObjParameter.ParameterDesc = txtParameterDesc.Text
            ObjParameter.Behaviour = cmbParameter.SelectedItem
            ObjParameter.UserName = gblUserName
            Save = ObjParameter.FunSave()
            MsgBox(ObjParameter.ErrorMsg)
            Clear()
            FetchParameterMaster()
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjParameter) = False Then
                ObjParameter = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If

        End Try
    End Function

    Public Sub FetchParameterMaster()
        Dim ObjParameter As New ClsParameter
        Dim ObjDt As New DataTable
        Try
            'ObjParameter.ParaMeterID = lblParameterID.Text
            ObjDt = ObjParameter.FunFetch()
            grdParameter.DataSource = ObjDt
           
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjParameter) = False Then
                ObjParameter = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If
        End Try

        grdParameter.Columns("ParameterID").Visible = False
    End Sub
    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub
    Private Sub grdParameter_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdParameter.CellDoubleClick
       
            lblParameterID.Text = grdParameter("ParameterID", e.RowIndex).Value
            txtParameterName.Text = grdParameter("ParameterName", e.RowIndex).Value
            txtParameterDesc.Text = grdParameter("ParameterDesc", e.RowIndex).Value
        cmbParameter.SelectedItem = grdParameter("Behaviour", e.RowIndex).Value




    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
        FunDelete()
    End Sub
    Public Function FunDelete() As Boolean
        FunDelete = False

        If lblParameterID.Text = 0 Then
            MsgBox("Select Parameter to delete", MsgBoxStyle.Critical, "Supplier")
            Exit Function
        End If
        Dim ObjParameter As New ClsParameter
        Try
            ObjParameter.ParaMeterID = lblParameterID.Text
            ObjParameter.UserName = gblUserName
            FunDelete = ObjParameter.FunDelete
            MsgBox(ObjParameter.ErrorMsg)
            Clear()
            FetchParameterMaster()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjParameter) Then
                ObjParameter = Nothing
            End If
        End Try
    End Function
    Public Sub Clear()
        txtParameterDesc.Text = ""
        txtParameterName.Text = ""
        cmbParameter.SelectedItem = "<---Select--->"
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub
End Class