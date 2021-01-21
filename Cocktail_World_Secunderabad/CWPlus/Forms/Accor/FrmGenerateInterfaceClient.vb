Imports IGClassLibrary

Public Class FrmGenerateInterfaceClient

    Private Sub FrmGenerateInterfaceClient_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim objIG As New IGConsumer()
        Try
            lblMessage.Text = objIG.GetTestMessage()
            lblMessage.ForeColor = Color.Green
            BindOperation()
        Catch ex As Exception
            lblMessage.Text = "Interface Generator service is stopped"
            lblMessage.ForeColor = Color.Red
            BtnGenerate.Enabled = False
        Finally
            If IsNothing(objIG) = False Then
                objIG = Nothing
            End If
        End Try
    End Sub

    Private Sub BindOperation()
        Dim ObjClsEval As CWPlusBL.Accor.ClsReports
        Dim ObjPriDt As DataTable
        Try
            ObjPriDt = New DataTable

            ObjClsEval = New CWPlusBL.Accor.ClsReports
            ObjClsEval.UserID = gblUserID
            ObjPriDt = ObjClsEval.FunFetchOperationName

            With chklstOperations
                .DataSource = ObjPriDt
                .DisplayMember = "OperationName"
                .ValueMember = "BulkInsertID"
            End With
        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjClsEval = Nothing
        End Try
    End Sub

    Private Sub BtnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerate.Click

        If CDate(Format(dtToDate.Value, "dd-MMM-yyyy")) < CDate(Format(dtFromDate.Value, "dd-MMM-yyyy")) Then
            MsgBox("Todate cannot be less than Fromdate")
            Exit Sub
        End If

        Dim objIG As New IGConsumer()
        Dim ObjArr As New ArrayList
        Try
            For Each itm In chklstOperations.CheckedItems
                ObjArr.Add(DirectCast(itm, DataRowView)("OperationName"))
            Next
            objIG.FromdDate = Format(dtFromDate.Value, "dd-MMM-yyyy")
            objIG.ToDate = Format(dtToDate.Value, "dd-MMM-yyyy")
            objIG.OperationName = ObjArr.ToArray
            MsgBox(objIG.InvokeGenerateInterface())
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(objIG) = False Then
                objIG = Nothing
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class