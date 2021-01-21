Imports System.Xml

Public Class FrmEvalGeneralSetup

    Public gblArrEvalLicense As New ArrayList

    Private Sub FrmEvalGeneralSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindUserName()
        BindOperation()
        BindFilePathGrid()
    End Sub

    Public Sub BindFilePathGrid()
        Dim ObjClsGenSetUp As CWPlusBL.Accor.ClsGentralSetUp = New CWPlusBL.Accor.ClsGentralSetUp
        Dim ObjPriDt As New DataTable
        Try
            ObjClsGenSetUp.SetFilePath = ""
            ObjPriDt = ObjClsGenSetUp.FunFetch()
            grdBulkInsertFilePath.Rows.Clear()
            For index = 0 To ObjPriDt.Rows.Count - 1
                grdBulkInsertFilePath.Rows.Add(ObjPriDt.Rows(index).Item("OPERATIONNAME"), ObjPriDt.Rows(index).Item("FILEPATH"), ObjPriDt.Rows(index).Item("CONNECTIONSTRING"), ObjPriDt.Rows(index).Item("FILEPREFIX"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjClsGenSetUp) Then
                ObjClsGenSetUp = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub


    Public Sub BindUserName()
        Dim ObjDtUser As New CWPlusBL.Master.ClsUserMaster
        Dim ObjPriDt As New DataTable
        Try
            ObjPriDt = ObjDtUser.FunFetch
            cmbUserName.DataSource = Nothing
            ComboBindingTemplate(cmbUserName, ObjPriDt, "User", "UserID")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDtUser) Then
                ObjDtUser = Nothing
            End If
            If Not IsNothing(ObjPriDt) Then
                ObjPriDt = Nothing
            End If
        End Try
    End Sub

    Private Sub BindOperation(Optional ByVal LocUserid As Integer = 0)
        Dim ObjClsEval As CWPlusBL.Accor.ClsReports
        Dim ObjPriDt As DataTable
        Try
            For chkCtr = 0 To chklstOperations.Items.Count - 1
                chklstOperations.SetItemChecked(chkCtr, False)
            Next

            ObjPriDt = New DataTable
            ObjClsEval = New CWPlusBL.Accor.ClsReports
            ObjClsEval.UserID = LocUserid
            ObjPriDt = ObjClsEval.FunFetchOperationName

            If LocUserid = 0 Then
                With chklstOperations
                    .DataSource = ObjPriDt
                    .DisplayMember = "OperationName"
                    .ValueMember = "BulkInsertID"
                End With
            Else
                For index = 0 To ObjPriDt.Rows.Count - 1
                    For chkCtr = 0 To chklstOperations.Items.Count - 1
                        If DirectCast(chklstOperations.Items(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = ObjPriDt.Rows(index)("BulkInsertID") Then
                            chklstOperations.SetItemChecked(chkCtr, True)
                        End If
                    Next
                Next
            End If




        Catch ex As Exception
            Throw ex
        Finally
            ObjPriDt = Nothing
            ObjClsEval = Nothing
        End Try
    End Sub

    Private Function GenerateLicenseXML() As XmlDocument
        GenerateLicenseXML = Nothing
        Dim xmldoc As XmlDocument
        xmldoc = New XmlDocument
        xmldoc.LoadXml("<Report><EvalPack></EvalPack></Report>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("Operation")
        For cntr = 0 To gblArrEvalLicense.Count - 1
            XmlElt = xmldoc.CreateElement("Operation")
            XmlElt.SetAttribute("Bulkinsertid", gblArrEvalLicense.Item(cntr))
            xmldoc.DocumentElement.Item("EvalPack").AppendChild(XmlElt)
        Next
        GenerateLicenseXML = xmldoc
    End Function

    Private Sub EvalLincenseChecked()
        gblArrEvalLicense.Clear()

        If chklstOperations.CheckedItems.Count > 0 Then
            gblArrEvalLicense.Clear()
            For chkCtr = 0 To chklstOperations.CheckedItems.Count - 1
                If Not DirectCast(chklstOperations.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0) = 0 Then
                    gblArrEvalLicense.Add(DirectCast(chklstOperations.CheckedItems(chkCtr), System.Data.DataRowView).Row.ItemArray(0))
                End If
            Next
        End If
    End Sub

    Private Sub imgClose_Click(sender As System.Object, e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgSave_Click(sender As System.Object, e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Public Sub Save()

        If cmbUserName.SelectedValue = 0 Then
            MsgBox("Please select username")
            Exit Sub
        End If

        Dim ObjCls As New CWPlusBL.Accor.ClsReports
        Try
            gblArrEvalLicense.Clear()
            EvalLincenseChecked()

            If gblArrEvalLicense.Count = 0 Then
                MsgBox("Select atleast one operation", MsgBoxStyle.Critical, "CWPlus")
                Exit Sub
            End If

            ObjCls.UserID = cmbUserName.SelectedValue
            ObjCls.OperationXML = GenerateLicenseXML()
            ObjCls.FunSaveUserEvalOperation()
            MsgBox(ObjCls.ErrorMsg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbUserName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If Not TypeOf cmbUserName.SelectedValue Is Decimal Then
            Exit Sub
        End If
        BindOperation(cmbUserName.SelectedValue)
    End Sub

    Private Sub btnSaveFilePath_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveFilePath.Click
        SaveFilePath()
    End Sub
    Sub SaveFilePath()
        Dim ObjClsGenSetUp As CWPlusBL.Accor.ClsGentralSetUp = New CWPlusBL.Accor.ClsGentralSetUp
        Dim strFilePath As String
        If txtFilePath.Text = "" Then
            MsgBox("Please Enter Valid Path First", MsgBoxStyle.Critical, "CWPlus")
            Exit Sub
        Else
            strFilePath = LTrim(RTrim(txtFilePath.Text))
            ObjClsGenSetUp.SetFilePath = strFilePath
            ObjClsGenSetUp.FunSave()
            MsgBox(ObjClsGenSetUp.ErrorMsg)
            txtFilePath.Text = ""
            strFilePath = ""
            BindFilePathGrid()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub
End Class