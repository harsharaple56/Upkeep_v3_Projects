Public Class frmScheduleVariance
    Dim ObjSchVar As CWPlusBL.Master.ClsScheduleVariance
    Dim objlicense As CWPlusBL.Master.Utitity
    Dim objDt As DataTable

#Region "Procedures"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTROLS
        AddTheme(SplitContainer1.Panel1)
    End Sub

    Private Sub ClrScreen()
        cmbLicense.SelectedValue = 0
        cmbRepeat.SelectedValue = 0
        dtDate.Value = DateTime.Now
        lblID.Text = 0

    End Sub

    Public Sub BindGrid()
        Try
            ObjSchVar = New CWPlusBL.Master.ClsScheduleVariance
            objDt = New DataTable

            objDt = ObjSchVar.FunFetch

            grdSchedule.DataSource = Nothing
            grdSchedule.DataSource = objDt
            grdSchedule.Columns("scheduleid").Visible = False
            grdSchedule.Columns("licenseid").Visible = False
            grdSchedule.Columns("repeatid").Visible = False
            grdSchedule.Columns("license").Width = 150
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
            If Not IsNothing(ObjSchVar) Then
                ObjSchVar = Nothing
            End If
        End Try
       
    End Sub

    Public Function Save() As Boolean
        Save = False
        If lblID.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Schedule Variance")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Schedule Variance")
                Exit Function
            End If
        End If
        If cmbLicense.SelectedValue = 0 Then
            MsgBox("Select License", MsgBoxStyle.Information, "Schedule Variance")
            Exit Function
        ElseIf cmbRepeat.SelectedValue = 0 Then
            MsgBox("Select Repeat", MsgBoxStyle.Information, "Schedule Variance")
            Exit Function
        End If
        Try
            ObjSchVar = New CWPlusBL.Master.ClsScheduleVariance
            ObjSchVar.ScheduleID = lblID.Text
            ObjSchVar.LicenseID = cmbLicense.SelectedValue
            ObjSchVar.StartDate = dtDate.Value
            ObjSchVar.Repeat = cmbRepeat.SelectedValue
            ObjSchVar.UserName = gblUserName
            Save = ObjSchVar.FunSave
            MsgBox(ObjSchVar.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjSchVar) Then
                ObjSchVar = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Schedule Variance")
        End If
        If lblID.Text = 0 Then
            MsgBox("Select Schedule to delete", MsgBoxStyle.Critical, "Schedule Variance")
            Exit Function
        End If
        Try
            ObjSchVar = New CWPlusBL.Master.ClsScheduleVariance
            ObjSchVar.ScheduleID = lblID.Text
            ObjSchVar.UserName = gblUserName
            FunDelete = ObjSchVar.FunDelete
            MsgBox(ObjSchVar.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjSchVar) Then
                ObjSchVar = Nothing
            End If
        End Try
    End Function

    Private Sub BindLicense()
        Try
            objlicense = New CWPlusBL.Master.Utitity
            objDt = New DataTable
            objlicense.UserID = gblUserID
            objDt = objlicense.FunFetchLicenseByRights
            cmbLicense.DataSource = Nothing
            ComboBindingTemplate(cmbLicense, objDt, "LicenseDesc", "LicenseID")
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

    Private Sub BindRepeatCombo()
        Try
            objDt = New DataTable
            objDt.Columns.Add("Dispfield")
            objDt.Columns.Add("Valuefield")

            objDt.Rows.Add("Daily", 1)
            objDt.Rows.Add("Weekly", 7)
            objDt.Rows.Add("Fortnight", 15)
            objDt.Rows.Add("Monthly", 30)
            objDt.Rows.Add("Quarterly", 90)
            objDt.Rows.Add("Half-Yearly", 180)
            objDt.Rows.Add("Yearly", 365)

            cmbRepeat.DataSource = Nothing
            ComboBindingTemplate(cmbRepeat, objDt, "dispfield", "Valuefield")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(objDt) Then
                objDt = Nothing
            End If
        End Try
    End Sub
#End Region
    Private Sub frmScheduleVariance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        BindLicense()
        BindRepeatCombo()
        BindGrid()
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

    Private Sub grdSchedule_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSchedule.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblID.Text = grdSchedule.Item("scheduleid", e.RowIndex).Value
        cmbLicense.SelectedValue = grdSchedule.Item("licenseid", e.RowIndex).Value
        cmbRepeat.SelectedValue = grdSchedule.Item("repeatid", e.RowIndex).Value
        dtDate.Value = CDate(grdSchedule.Item("startdate", e.RowIndex).Value)
    End Sub
End Class