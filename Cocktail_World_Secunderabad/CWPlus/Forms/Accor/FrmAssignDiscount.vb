Imports CWPlusBL.Accor

Public Class FrmAssignDiscount

    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub imgClose_Click_1(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        GblStrOldDiscountTypeOldVD = ""
        GblStrRemarkVD = ""
        Me.Close()
    End Sub

    Private Sub imgSave_Click(sender As System.Object, e As System.EventArgs) Handles imgSave.Click

        If Not drpDiscountType.SelectedValue > 0 Then
            MsgBox("Select discount type", MsgBoxStyle.Information, "CWPlus")
            Exit Sub
        End If

        If Trim(txtRemarks.Text) = "" Then
            MsgBox("Remark is compulsory")
            Exit Sub
        End If

        GblStrDiscountTypeDescVD = drpDiscountType.Text
        GblStrDiscountTypeIDVD = drpDiscountType.SelectedValue
        GblStrRemarkVD = txtRemarks.Text
        Me.Close()
        FrmViewData.SubApplyChanges()
    End Sub

    Private Sub FrmAssignDiscount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindDiscountTypes()
        txtRemarks.Text = GblStrRemarkVD
    End Sub

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