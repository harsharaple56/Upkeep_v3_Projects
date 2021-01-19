Imports CWPlusBL.Accor

Public Class FrmAssignCardNo
    Dim ObjCls As ClsReports

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        GblStrDiscountType = ""
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
    End Sub

    Private Function Savev2() As Boolean
        Savev2 = False
        Try

            If Trim(txtCardNo.Text) = "" Then
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

            ObjCls.DiscountType = GblStrDiscountType
            ObjCls.CardNo = txtCardNo.Text
            ObjCls.UserName = gblUserName

            Savev2 = ObjCls.FunSaveChangedMembershipData

            GblDtBusinessDate = #1/1/1900#
            GBLDblRevenueCenterId = 0
            GblStrRevenueCenterName = ""
            GblDblCheckId = 0
            GblStrBillNo = ""
            GblStrDiscountType = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class