Public Class frmDeptMaster
    Dim ObjDept As CWPlusBL.Master.ClsDeptMaster
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim ObjDt As DataTable

#Region "Procedures"

    Private Sub ClrScreen()
        txtDept.Clear()
        txtShortName.Clear()
        txtDeptCode.Clear()

        cmbLicense.SelectedValue = 0
        lblid.Text = 0
    End Sub

    Private Sub BindLicense()
        Try

            objlicense = New CWPlusBL.Master.Utitity
            objDt = New DataTable
            objlicense.UserID = gblUserID
            objDt = objlicense.FunFetchLicenseByRights

            cmbLicense.DataSource = Nothing
            ComboBindingTemplate(cmbLicense, ObjDt, "LicenseDesc", "LicenseID")

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not IsNothing(objlicense) Then
                objlicense = Nothing
            End If
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
        End Try


    End Sub

    Public Sub BindGrid()
        Try
            ObjDept = New CWPlusBL.Master.ClsDeptMaster
            ObjDt = New DataTable
            ObjDt = ObjDept.FunFetch
            grdDept.DataSource = Nothing
            grdDept.DataSource = ObjDt
            grdDept.Columns("licenseid").Visible = False
            grdDept.Columns("deptid").Visible = False
            grdDept.Columns("license").Width = 200
            grdDept.Columns("department").Width = 200
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try

    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Department")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Department")
                Exit Function
            End If
        End If
        If txtDept.Text = "" Then
            MsgBox("Enter Department Name")
            Exit Function
        ElseIf txtShortName.Text = "" Then
            MsgBox("Enter Short Description")
            Exit Function
        End If
        Try
            ObjDept = New CWPlusBL.Master.ClsDeptMaster
            ObjDept.DeptId = lblid.Text
            ObjDept.LicenseID = cmbLicense.SelectedValue
            ObjDept.DeptDesc = txtDept.Text
            ObjDept.ShortDesc = txtShortName.Text
            ObjDept.DeptCode = txtDeptCode.Text
            ObjDept.UserName = gblUserName
            Save = ObjDept.FunSave
            MsgBox(ObjDept.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Department")
        End If
        If lblid.Text = 0 Then
            MsgBox("Select Department to delete", MsgBoxStyle.Critical, "Department")
            Exit Function
        End If
        Try
            ObjDept = New CWPlusBL.Master.ClsDeptMaster
            ObjDept.DeptId = lblid.Text
            ObjDept.UserName = gblUserName
            FunDelete = ObjDept.FunDelete
            MsgBox(ObjDept.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDept) Then
                ObjDept = Nothing
            End If
        End Try
    End Function

#End Region

    Private Sub frmDeptMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindGrid()
        BindLicense()
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
       
        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub grdDept_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDept.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdDept("DeptID", e.RowIndex).Value
        txtDept.Text = grdDept("Department", e.RowIndex).Value
        txtDeptCode.Text = grdDept("DepartmentCode", e.RowIndex).Value

        If Not IsDBNull(grdDept("shortdesc", e.RowIndex).Value) Then
            txtShortName.Text = grdDept("shortdesc", e.RowIndex).Value
        End If
        If Not IsDBNull(grdDept("licenseid", e.RowIndex).Value) Then
            cmbLicense.SelectedValue = grdDept("licenseid", e.RowIndex).Value
        Else
            cmbLicense.SelectedValue = 0
        End If

    End Sub

End Class