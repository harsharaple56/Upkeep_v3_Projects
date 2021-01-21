Imports CWPlusBL.Accor
Imports System.Data

Public Class FrmAnGDetailed
    Dim ObjCls As ClsReports
    Dim ObjPriDt As DataTable

    Private Sub FrmAnGDetailed_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FetchDesignation()
        BindDiscountTypes()
    End Sub

    Private Sub FetchDesignation()
        Try
            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Designation = ""
            ObjPriDt = ObjCls.FunFetchDesignation()
            ComboBindingTemplate(drpDesignation, ObjPriDt, "Designation", "DesignId")
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
            ComboBindingTemplate(drpDiscountType, ObjPriDt, "discname", "discid")
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Public Sub BindGrid()
        Try
            If drpDesignation.Text = "--Select--" And drpDiscountType.Text = "--Select--" Then
                MsgBox("Please select Designation/A&G Field")
                Exit Sub
            End If
            If drpDesignation.Text <> "--Select--" And drpDiscountType.Text <> "--Select--" Then
                MsgBox("Please select either Designation/A&G Field")
                Exit Sub
            End If

            ObjPriDt = New DataTable
            ObjCls = New ClsReports
            ObjCls.Fromdate = Format(DtFromdate.Value, "dd-MMM-yyyy")
            ObjCls.ToDate = Format(DtToDate.Value, "dd-MMM-yyyy")


            If drpDesignation.Text = "--Select--" Then
                ObjCls.AnGFields = drpDiscountType.Text
            Else
                ObjCls.AnGFields = drpDesignation.Text
            End If

            ObjPriDt = ObjCls.FunFetchAnGFieldWiseReport()
            grdDCCReport.DataSource = ObjPriDt
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjCls = Nothing
        End Try
    End Sub

    Private Sub btnok_Click(sender As System.Object, e As System.EventArgs) Handles btnok.Click
        BindGrid()
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub btnCrystalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCrystalReport.Click
        If drpDesignation.Text = "--Select--" And drpDiscountType.Text = "--Select--" Then
            MsgBox("Please select Designation/A&G Field")
            Exit Sub
        End If
        If drpDesignation.Text <> "--Select--" And drpDiscountType.Text <> "--Select--" Then
            MsgBox("Please select either Designation/A&G Field")
            Exit Sub
        End If

        Dim StrPriAnGFields As String = ""
        If drpDesignation.Text = "--Select--" Then
            StrPriAnGFields = drpDiscountType.Text
        Else
            StrPriAnGFields = drpDesignation.Text
        End If

        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromdate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "','" & StrPriAnGFields & "'"
        GenerateReport("AnGFieldDetailed", "proc#" & "Spr_FetchAnGFieldWiseReport" & "#" & StrParam & "#1000000")
    End Sub

End Class