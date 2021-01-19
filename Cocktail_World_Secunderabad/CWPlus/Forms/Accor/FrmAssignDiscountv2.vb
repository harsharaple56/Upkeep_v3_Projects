Imports CWPlusBL.Accor

Public Class FrmAssignDiscountv2

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub FrmAssignDiscount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindDiscountTypes()
        txtRemarks.Text = GblStrRemarkVD

        If txtRemarks.Text = "" Then
            txtRemarks.Text = GblStrRevenueCenterName & " - " & GblStrBillNo & " - Setteled in " & GblStrOldDiscountTypeOldVD & " instead of"
        End If
        If GblStrOldDiscountTypeOldVD = "" Then
            drpDiscountType.Enabled = False
        Else
            drpDiscountType.Enabled = True
        End If


        lblBillNo.Text = GblStrBillNo
        lblRevenueCenterName.Text = GblStrRevenueCenterName
    End Sub

    Private Sub imgClose_Click_1(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        GblStrOldDiscountTypeOldVD = ""
        GblStrRemarkVD = ""
        GblDtBusinessDate = #1/1/1900#
        GBLDblRevenueCenterId = 0
        GblStrRevenueCenterName = ""
        GblDblCheckId = 0
        GblStrBillNo = ""
        GblStrBillUniqueId = ""
        Me.Close()

    End Sub

    Private Sub imgSave_Click(sender As System.Object, e As System.EventArgs) Handles imgSave.Click
        If Savev2() Then
            Me.Close()
            FrmViewDatav2.BindData()
        End If

        'GblStrDiscountTypeDescVD = drpDiscountType.Text
        'GblStrDiscountTypeIDVD = drpDiscountType.SelectedValue
        'GblStrRemarkVD = txtRemarks.Text
        'Me.Close()
        'FrmViewData.SubApplyChanges()
    End Sub

    Private Function Savev2() As Boolean
        Savev2 = False
        Try
            'juhu void remark
            If GblStrOldDiscountTypeOldVD <> "" Then
                If Not drpDiscountType.SelectedValue > 0 Then
                    MsgBox("Select discount type", MsgBoxStyle.Information, "CWPlus")
                    Exit Function
                End If
            End If
            If Trim(txtRemarks.Text) = "" Then
                MsgBox("Remark is compulsory")
                Exit Function
            End If
            

            ObjCls = New ClsReports
            ObjCls.BusinessDate = GblDtBusinessDate
            ObjCls.RevenueCenterId = GBLDblRevenueCenterId
            ObjCls.RevenueCenterName = GblStrRevenueCenterName
            ObjCls.CheckId = GblDblCheckId
            ObjCls.OfficerBillNo = GblStrBillNo
            ObjCls.BillUniqueId = GblStrBillUniqueId

            ObjCls.OldValue = GblStrOldDiscountTypeOldVD

            'Juhu commented for remarks against all check for void
            'ObjCls.NewValue = drpDiscountType.Text
            If Not drpDiscountType.SelectedValue > 0 Then
                ObjCls.NewValue = ""
            Else
                ObjCls.NewValue = drpDiscountType.Text
            End If



            ObjCls.Remark = txtRemarks.Text
            ObjCls.Reference = ""
            ObjCls.UserName = gblUserName

            Savev2 = ObjCls.FunSaveChangedData

            GblDtBusinessDate = #1/1/1900#
            GBLDblRevenueCenterId = 0
            GblStrRevenueCenterName = ""
            GblDblCheckId = 0
            GblStrBillNo = ""
            GblStrOldDiscountTypeOldVD = ""
            GblStrRemarkVD = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub BindDiscountTypes()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjPriDt = ObjCls.FunFetchDiscountTypes
            ComboBindingTemplate(drpDiscountType, ObjPriDt, "discname", "discid")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

End Class