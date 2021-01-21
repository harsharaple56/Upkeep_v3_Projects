Public Class FrmAuditReport

    Dim ObjBevRec As CWPlusBL.Accor.ClsReports
    Dim ObjPriDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTORLS 
        AddTheme(SplitContainer1.Panel1)
    End Sub


    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub BtnAudReport1_Click(sender As System.Object, e As System.EventArgs) Handles BtnAudReport1.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("auditreport1", "proc#" & "Spr_FetchAuditReport" & "#" & StrParam & "#10000")
    End Sub

    Private Sub BtnAudReport2_Click(sender As System.Object, e As System.EventArgs) Handles BtnAudReport2.Click
        Dim StrParam As String = ""
        StrParam = "'" & Format(DtFromDate.Value, "dd-MMM-yyyy") & "','" & Format(DtToDate.Value, "dd-MMM-yyyy") & "','" & gblUserName & "'"
        GenerateReport("auditreport2", "proc#" & "Spr_FetchAuditReport2" & "#" & StrParam & "#10000")
    End Sub
End Class