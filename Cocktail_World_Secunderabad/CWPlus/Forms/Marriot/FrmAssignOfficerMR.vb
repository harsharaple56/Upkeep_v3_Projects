Imports CWPlusBL.Marriot
Imports System.Data

Public Class FrmAssignOfficerMR

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable
    Dim AnGField As Char

    Private Sub FrmAssignOfficer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblRevenueCenterName.Text = GblStrRevenueCenterName
        lblBillNo.Text = GblStrBillNo
        FetchDesignation()
        BindDiscountTypes()

        If GblDblAngHeadId = 0 Then
            imgDelete.Enabled = False
        End If
    End Sub

    Private Sub BindDiscountTypes()
        Try
            ObjPriDt = New DataTable
            Dim ObjClsdt = New ClsDiscount
            ObjClsdt.DblPubDiscountID = 0
            ObjPriDt = ObjClsdt.FunFetch()
            ComboBindingTemplate(drpDiscountType, ObjPriDt, "A&GFields", "DiscountID")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub FetchDesignation()
        Try
            ObjPriDt = New DataTable
            Dim ObjClsd = New ClsDesignation
            ObjClsd.DesignationId = 0
            ObjPriDt = ObjClsd.FunFetch()
            ComboBindingTemplate(drpDesignation, ObjPriDt, "DesignationDesc", "DesignationId")

        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Try

            ObjCls = New ClsReports

            'ObjPriDt = ObjCls.FunFetchAnGField()
            'AnGField = ObjPriDt.Rows(0)("AnGField")

            'If AnGField = "A" Then
            'If Savev2() Then
            '    Me.Close()
            '    FrmOfficerMeal.BindCheckData()
            'End If
            'Else
            If Savev3() Then
                Me.Close()
                FrmOfficerMealMR.BindCheckData()
            End If
            'End If




        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    'Private Function Save() As Boolean
    '    Save = False
    '    Try
    '        ObjCls = New ClsReports
    '        ObjCls.RevenueCenterId = GBLDblRevenueCenterId
    '        ObjCls.CheckId = GblDblCheckId
    '        ObjCls.RevenueCenterName = GblStrRevenueCenterName
    '        ObjCls.OfficerBillNo = GblStrBillNo

    '        If drpName.Text = "--Select--" Then
    '            ObjCls.EmployeeName = ""
    '        Else
    '            ObjCls.EmployeeName = drpName.Text
    '        End If

    '        If drpDesignation.Text = "--Select--" Then
    '            ObjCls.Designation = ""
    '        Else
    '            ObjCls.Designation = drpDesignation.Text
    '        End If

    '        ObjCls.BusinessDate = GblDtBusinessDate
    '        ObjCls.DiscountType = GblStrDiscount
    '        ObjCls.Amount = GblDblAmount
    '        ObjCls.Type = GblStrDiscountType

    '        If drpDiscountType.Text = "--Select--" Then
    '            ObjCls.AnGFields = GblStrAngFields
    '        Else
    '            ObjCls.AnGFields = drpDiscountType.Text
    '        End If

    '        Save = ObjCls.FunSaveOfficerMealDetail()
    '        If Not Save Then
    '            MsgBox(ObjCls.ErrorMsg)
    '        End If

    '        GBLDblRevenueCenterId = 0
    '        GblDblCheckId = 0
    '        GblStrRevenueCenterName = ""
    '        GblStrBillNo = ""
    '        GblDtBusinessDate = #1/1/1900#
    '        GblStrDiscount = ""
    '        GblStrDiscountType = ""
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function Savev2() As Boolean
    '    Savev2 = False
    '    Try
    '        If drpDesignation.Text = "--Select--" And drpDiscountType.Text = "--Select--" Then
    '            MsgBox("Please select Designation/A&G Field")
    '            Exit Function
    '        End If
    '        If drpDesignation.Text <> "--Select--" And drpDiscountType.Text <> "--Select--" Then
    '            MsgBox("Please select either Designation/A&G Field")
    '            Exit Function
    '        End If


    '        For index = 0 To FrmOfficerMeal.grdDCCReport.RowCount - 1
    '            If CBool(FrmOfficerMeal.grdDCCReport.Item("sel", index).Value) Then
    '                ObjCls = New ClsReports
    '                ObjCls.AngHeadId = FrmOfficerMeal.grdDCCReport.Item("AngHeadId", index).Value
    '                ObjCls.BusinessDate = FrmOfficerMeal.grdDCCReport.Item("businessdate", index).Value
    '                ObjCls.RevenueCenterId = FrmOfficerMeal.grdDCCReport.Item("RevenueCenterId", index).Value
    '                ObjCls.RevenueCenterName = FrmOfficerMeal.grdDCCReport.Item("RevenueCenterName", index).Value
    '                ObjCls.CheckId = FrmOfficerMeal.grdDCCReport.Item("CheckId", index).Value
    '                ObjCls.OfficerBillNo = FrmOfficerMeal.grdDCCReport.Item("BillNo", index).Value
    '                ObjCls.Type = FrmOfficerMeal.grdDCCReport.Item("Type", index).Value

    '                If drpDesignation.Text = "--Select--" Then
    '                    ObjCls.AnGFields = drpDiscountType.Text
    '                    ObjCls.IsAngField = True
    '                Else
    '                    ObjCls.AnGFields = drpDesignation.Text
    '                    ObjCls.IsAngField = False
    '                End If

    '                If drpName.Text = "--Select--" Then
    '                    ObjCls.AnGFieldsInfo = ""
    '                Else
    '                    ObjCls.AnGFieldsInfo = drpName.Text
    '                End If
    '                ObjCls.AnGFieldsInfo = txtRemarks.Text
    '                ObjCls.MultipleDesignation = chkMultiDesignation.Checked
    '                ObjCls.UserName = gblUserName
    '                Savev2 = ObjCls.FunSaveAnGDetails

    '            End If
    '        Next
    '        'ObjCls = New ClsReports
    '        'ObjCls.AngHeadId = GblDblAngHeadId
    '        'ObjCls.BusinessDate = GblDtBusinessDate
    '        'ObjCls.RevenueCenterId = GBLDblRevenueCenterId
    '        'ObjCls.RevenueCenterName = GblStrRevenueCenterName
    '        'ObjCls.CheckId = GblDblCheckId
    '        'ObjCls.OfficerBillNo = GblStrBillNo
    '        'ObjCls.Type = GblStrDiscountType

    '        'If drpDesignation.Text = "--Select--" Then
    '        '    ObjCls.AnGFields = drpDiscountType.Text
    '        '    ObjCls.IsAngField = True
    '        'Else
    '        '    ObjCls.AnGFields = drpDesignation.Text
    '        '    ObjCls.IsAngField = False
    '        'End If

    '        'If drpName.Text = "--Select--" Then
    '        '    ObjCls.AnGFieldsInfo = ""
    '        'Else
    '        '    ObjCls.AnGFieldsInfo = drpName.Text
    '        'End If
    '        'ObjCls.MultipleDesignation = chkMultiDesignation.Checked
    '        'ObjCls.UserName = gblUserName
    '        'Savev2 = ObjCls.FunSaveAnGDetails
    '        MsgBox(ObjCls.ErrorMsg)

    '        'GBLDblRevenueCenterId = 0
    '        'GblDblCheckId = 0
    '        'GblStrRevenueCenterName = ""
    '        'GblStrBillNo = ""
    '        'GblDtBusinessDate = #1/1/1900#
    '        'GblDblAngHeadId = 0
    '        'GblStrDiscountType = ""

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Function Savev3() As Boolean
        Savev3 = False
        Try
            If drpDesignation.Text = "--Select--" And drpDiscountType.Text = "--Select--" Then
                MsgBox("Please select Designation/A&G Field")
                Exit Function
            End If
            'If drpDesignation.Text <> "--Select--" And drpDiscountType.Text <> "--Select--" Then
            '    MsgBox("Please select either Designation/A&G Field")
            '    Exit Function
            'End If


            For index = 0 To FrmOfficerMealMR.grdDCCReport.RowCount - 1
                If CBool(FrmOfficerMealMR.grdDCCReport.Item("sel", index).Value) Then
                    ObjCls = New ClsReports
                    ObjCls.AngHeadId = FrmOfficerMealMR.grdDCCReport.Item("AngHeadId", index).Value
                    ObjCls.BusinessDate = FrmOfficerMealMR.grdDCCReport.Item("businessdate", index).Value
                    ObjCls.RevenueCenterId = FrmOfficerMealMR.grdDCCReport.Item("RevenueCenterId", index).Value
                    ObjCls.RevenueCenterName = FrmOfficerMealMR.grdDCCReport.Item("RevenueCenterName", index).Value
                    ObjCls.CheckId = FrmOfficerMealMR.grdDCCReport.Item("CheckId", index).Value
                    ObjCls.OfficerBillNo = FrmOfficerMealMR.grdDCCReport.Item("BillNo", index).Value
                    ObjCls.Type = FrmOfficerMealMR.grdDCCReport.Item("Type", index).Value


                    ObjCls.AnGFields = drpDesignation.Text
                    ObjCls.AccountType = drpDiscountType.Text
                    ObjCls.IsAngField = True

                    ObjCls.AnGFieldsInfo = txtRemarks.Text
                    ObjCls.MultipleDesignation = chkMultiDesignation.Checked
                    ObjCls.UserName = gblUserName
                    Savev3 = ObjCls.FunSaveAnGDetailsWithAccountType

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

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        GBLDblRevenueCenterId = 0
        GblDblCheckId = 0
        GblStrRevenueCenterName = ""
        GblStrBillNo = ""
        GblDtBusinessDate = #1/1/1900#
        Me.Close()
        FrmOfficerMealMR.BindCheckData()
    End Sub

    'Private Sub drpDesignation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles drpDesignation.SelectedIndexChanged
    '    If Not TypeOf (drpDesignation.SelectedValue) Is DataRowView Then
    '        FetchEmployees()
    '    End If
    'End Sub

    Private Sub FetchEmployees()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Designation = drpDesignation.Text
            ObjPriDt = ObjCls.FunFetchDesignation()
            ComboBindingTemplate(drpName, ObjPriDt, "FullName", "EmployeeId")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub imgDelete_Click(sender As System.Object, e As System.EventArgs) Handles imgDelete.Click
        If FunDelete() Then
            Me.Close()
            FrmOfficerMealMR.BindCheckData()
        End If
    End Sub

    Public Function FunDelete() As Boolean
        FunDelete = False
        Try
            ObjCls = New CWPlusBL.Marriot.ClsReports
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


End Class