Imports CWPlusBL.Accor
Imports System.Data

Public Class FrmAssignOfficerv2
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub FrmAssignOfficerv2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        FetchDesignation()
        BindDiscountTypes()

        If GblDblAngHeadId = 0 Then
            imgDelete.Enabled = False
        End If
    End Sub

    Private Sub FetchDesignation()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Designation = ""
            ObjPriDt = ObjCls.FunFetchDesignation()
            grdDesignation.DataSource = ObjPriDt
            grdDesignation.Columns.RemoveAt(0)
            Dim bs As BindingSource = New BindingSource()
            bs.DataSource = grdDesignation.DataSource
            bs.Filter = "Designation" + " like '%" + txtDesignation.Text + "%'"
            grdDesignation.DataSource = bs
            grdDesignation.Columns("DesignId").Visible = False
            grdDesignation.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub BindDiscountTypes()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchDiscountTypes(2)
            grdAandG.DataSource = ObjPriDt
            Dim bs As BindingSource = New BindingSource()
            bs.DataSource = grdAandG.DataSource
            bs.Filter = "discname" + " like '%" + txtAandG.Text + "%'"
            grdAandG.DataSource = bs
            grdAandG.Columns("discid").Visible = False
            grdAandG.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        If Savev2() Then
            Me.Close()
            FrmOfficerMeal.BindCheckData()
        End If
    End Sub

    Private Function Savev2() As Boolean
        Savev2 = False
        Try
            If txtDesignation.Text = "" Then
                MsgBox("Please select Designation")
                Exit Function
            End If

            If lblCheckId.Text = "CheckId" Then
                MsgBox("Please select proper Designation")
                Exit Function
            End If
            'If txtDesignation.Text <> "--Select--" Then
            '    MsgBox("Please select either Designation/A&G Field")
            '    Exit Function
            'End If


            For index = 0 To FrmOfficerMeal.grdDCCReport.RowCount - 1
                If CBool(FrmOfficerMeal.grdDCCReport.Item("sel", index).Value) Then
                    ObjCls = New ClsReports
                    ObjCls.AngHeadId = FrmOfficerMeal.grdDCCReport.Item("AngHeadId", index).Value
                    ObjCls.BusinessDate = FrmOfficerMeal.grdDCCReport.Item("businessdate", index).Value
                    ObjCls.RevenueCenterId = FrmOfficerMeal.grdDCCReport.Item("RevenueCenterId", index).Value
                    ObjCls.RevenueCenterName = FrmOfficerMeal.grdDCCReport.Item("RevenueCenterName", index).Value
                    ObjCls.CheckId = FrmOfficerMeal.grdDCCReport.Item("CheckId", index).Value
                    ObjCls.OfficerBillNo = FrmOfficerMeal.grdDCCReport.Item("BillNo", index).Value
                    ObjCls.Type = FrmOfficerMeal.grdDCCReport.Item("Type", index).Value

                    'If txtDesignation.Text = "--Select--" Then
                    '    ObjCls.AnGFields = drpDiscountType.Text
                    '    ObjCls.IsAngField = True
                    'Else
                    ObjCls.AnGFields = txtDesignation.Text
                    ObjCls.IsAngField = False
                    'End If

                    'If drpName.Text = "--Select--" Then
                    '    ObjCls.AnGFieldsInfo = ""
                    'Else
                    '    ObjCls.AnGFieldsInfo = drpName.Text
                    'End If
                    ObjCls.AnGFieldsInfo = txtRemarks.Text
                    ObjCls.MultipleDesignation = chkMultiDesignation.Checked
                    ObjCls.UserName = gblUserName
                    Savev2 = ObjCls.FunSaveAnGDetails

                End If
            Next
            'ObjCls = New ClsReports
            'ObjCls.AngHeadId = GblDblAngHeadId
            'ObjCls.BusinessDate = GblDtBusinessDate
            'ObjCls.RevenueCenterId = GBLDblRevenueCenterId
            'ObjCls.RevenueCenterName = GblStrRevenueCenterName
            'ObjCls.CheckId = GblDblCheckId
            'ObjCls.OfficerBillNo = GblStrBillNo
            'ObjCls.Type = GblStrDiscountType

            'If drpDesignation.Text = "--Select--" Then
            '    ObjCls.AnGFields = drpDiscountType.Text
            '    ObjCls.IsAngField = True
            'Else
            '    ObjCls.AnGFields = drpDesignation.Text
            '    ObjCls.IsAngField = False
            'End If

            'If drpName.Text = "--Select--" Then
            '    ObjCls.AnGFieldsInfo = ""
            'Else
            '    ObjCls.AnGFieldsInfo = drpName.Text
            'End If
            'ObjCls.MultipleDesignation = chkMultiDesignation.Checked
            'ObjCls.UserName = gblUserName
            'Savev2 = ObjCls.FunSaveAnGDetails
            MsgBox(ObjCls.ErrorMsg)

            'GBLDblRevenueCenterId = 0
            'GblDblCheckId = 0
            'GblStrRevenueCenterName = ""
            'GblStrBillNo = ""
            'GblDtBusinessDate = #1/1/1900#
            'GblDblAngHeadId = 0
            'GblStrDiscountType = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        GBLDblRevenueCenterId = 0
        GblDblCheckId = 0
        GblStrRevenueCenterName = ""
        GblStrBillNo = ""
        GblDtBusinessDate = #1/1/1900#
        Me.Close()
        FrmOfficerMeal.BindCheckData()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
        If FunDelete() Then
            Me.Close()
            FrmOfficerMeal.BindCheckData()
        End If
    End Sub

    Public Function FunDelete() As Boolean
        FunDelete = False
        Try
            ObjCls = New CWPlusBL.Accor.ClsReports
            ObjCls.AngHeadId = GblDblAngHeadId
            FunDelete = ObjCls.FunDeleteAngDetails
            MsgBox(ObjCls.ErrorMsg)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjCls) Then
                ObjCls = Nothing
            End If
        End Try
    End Function

    Private Sub ImgSaveAandG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgSaveAandG.Click
        If Savev3() Then
            Me.Close()
            FrmOfficerMeal.BindCheckData()
        End If
    End Sub

    Private Function Savev3() As Boolean
        Savev3 = False
        Try
            If txtAandG.Text = "" Then
                MsgBox("Please select A&G Field")
                Exit Function
            End If

            If lblCheckIdAnG.Text = "CheckId" Then
                MsgBox("Please select proper A&G Field")
                Exit Function
            End If

            'If txtDesignation.Text <> "--Select--" Then
            '    MsgBox("Please select either Designation/A&G Field")
            '    Exit Function
            'End If


            For index = 0 To FrmOfficerMeal.grdDCCReport.RowCount - 1
                If CBool(FrmOfficerMeal.grdDCCReport.Item("sel", index).Value) Then
                    ObjCls = New ClsReports
                    ObjCls.AngHeadId = FrmOfficerMeal.grdDCCReport.Item("AngHeadId", index).Value
                    ObjCls.BusinessDate = FrmOfficerMeal.grdDCCReport.Item("businessdate", index).Value
                    ObjCls.RevenueCenterId = FrmOfficerMeal.grdDCCReport.Item("RevenueCenterId", index).Value
                    ObjCls.RevenueCenterName = FrmOfficerMeal.grdDCCReport.Item("RevenueCenterName", index).Value
                    ObjCls.CheckId = FrmOfficerMeal.grdDCCReport.Item("CheckId", index).Value
                    ObjCls.OfficerBillNo = FrmOfficerMeal.grdDCCReport.Item("BillNo", index).Value
                    ObjCls.Type = FrmOfficerMeal.grdDCCReport.Item("Type", index).Value

                    'If txtDesignation.Text = "--Select--" Then
                    '    ObjCls.AnGFields = drpDiscountType.Text
                    '    ObjCls.IsAngField = True
                    'Else
                    ObjCls.AnGFields = txtAandG.Text
                    ObjCls.IsAngField = True
                    'End If

                    'If drpName.Text = "--Select--" Then
                    '    ObjCls.AnGFieldsInfo = ""
                    'Else
                    '    ObjCls.AnGFieldsInfo = drpName.Text
                    'End If
                    ObjCls.AnGFieldsInfo = txtRemarks.Text
                    ObjCls.MultipleDesignation = chkMultiDesignation.Checked
                    ObjCls.UserName = gblUserName
                    Savev3 = ObjCls.FunSaveAnGDetails

                End If
            Next
            'ObjCls = New ClsReports
            'ObjCls.AngHeadId = GblDblAngHeadId
            'ObjCls.BusinessDate = GblDtBusinessDate
            'ObjCls.RevenueCenterId = GBLDblRevenueCenterId
            'ObjCls.RevenueCenterName = GblStrRevenueCenterName
            'ObjCls.CheckId = GblDblCheckId
            'ObjCls.OfficerBillNo = GblStrBillNo
            'ObjCls.Type = GblStrDiscountType

            'If drpDesignation.Text = "--Select--" Then
            '    ObjCls.AnGFields = drpDiscountType.Text
            '    ObjCls.IsAngField = True
            'Else
            '    ObjCls.AnGFields = drpDesignation.Text
            '    ObjCls.IsAngField = False
            'End If

            'If drpName.Text = "--Select--" Then
            '    ObjCls.AnGFieldsInfo = ""
            'Else
            '    ObjCls.AnGFieldsInfo = drpName.Text
            'End If
            'ObjCls.MultipleDesignation = chkMultiDesignation.Checked
            'ObjCls.UserName = gblUserName
            'Savev2 = ObjCls.FunSaveAnGDetails
            MsgBox(ObjCls.ErrorMsg)

            'GBLDblRevenueCenterId = 0
            'GblDblCheckId = 0
            'GblStrRevenueCenterName = ""
            'GblStrBillNo = ""
            'GblDtBusinessDate = #1/1/1900#
            'GblDblAngHeadId = 0
            'GblStrDiscountType = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtDesignation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesignation.KeyPress
        FetchDesignation()
    End Sub

    Private Sub txtAandG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAandG.KeyPress
        BindDiscountTypes()
    End Sub

    Private Sub grdDesignation_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDesignation.CellContentDoubleClick
        If grdDesignation.RowCount > 0 Then
            txtDesignation.Text = grdDesignation("Designation", e.RowIndex).Value
            lblCheckId.Text = grdDesignation("DesignId", e.RowIndex).Value
        End If
    End Sub

    Private Sub grdAandG_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAandG.CellContentDoubleClick
        If grdAandG.RowCount > 0 Then
            txtAandG.Text = grdAandG("discname", e.RowIndex).Value
            lblCheckIdAnG.Text = grdAandG("discid", e.RowIndex).Value
        End If
    End Sub


    Private Sub ImgDeleteAandG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgDeleteAandG.Click
        If FunDelete() Then
            Me.Close()
            FrmOfficerMeal.BindCheckData()
        End If
    End Sub

    Private Sub ImgCloseAandG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgCloseAandG.Click
        GBLDblRevenueCenterId = 0
        GblDblCheckId = 0
        GblStrRevenueCenterName = ""
        GblStrBillNo = ""
        GblDtBusinessDate = #1/1/1900#
        Me.Close()
        FrmOfficerMeal.BindCheckData()
    End Sub
End Class