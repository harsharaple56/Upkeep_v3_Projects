Imports System.Data
Imports CWPlusBL.Master
Imports System.Xml


Public Class QCStep2

    'Dim gblGrossTotal As Double
    Public Sub initMe()
        If gblControlHeadID > 0 Then
            AssignDateToLable()
            BindParaMeter()
            FetchTotalAmountFromSaleDetails()
            FetchControls()
            Exit Sub
        Else
            FetchFromDateToDate()
            AssignDateToLable()
            BindParaMeter()
            FetchTotalAmountFromSaleDetails()
            FetchControls()
            Exit Sub
        End If

        'FetchFromDateToDate()
        'AssignDateToLable()
        'BindParaMeter()
        'FetchTotalAmountFromSaleDetails()
        'FetchControls()

        grdQuickControlStep2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
    End Sub
    Private Sub QCStep2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub AssignDateToLable()
        lblFromDate.Text = GblFromDate.ToString("dd-MMM-yyyy") & " To " & GblToDate.ToString("dd-MMM-yyyy")
    End Sub
    Public Sub FetchFromDateToDate()
        Dim ObjDate As New CWPlusBL.ClsQuickControl
        Dim Objdt As New DataTable
        Try
            ObjDate.ToDate = GblPurchaseDate
            Objdt = ObjDate.FunFetcFromDateToDate()
            If Objdt.Rows.Count > 0 Then
                GblFromDate = Objdt.Rows(0).Item("FromDate")
                GblToDate = Objdt.Rows(0).Item("ToDate")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjDate) = False Then
                ObjDate = Nothing
            End If
            If IsNothing(Objdt) = False Then
                Objdt = Nothing
            End If
        End Try
    End Sub


    Public Sub BindParaMeter()
        Dim ObjParameter As New ClsParameter
        Dim ObjDt As New DataTable
        Try
            ObjParameter.ParaMeterID = lblParameterID.Text
            ObjDt = ObjParameter.FunFetch
            cmbParameter.DataSource = Nothing
            ComboBindingTemplate(cmbParameter, ObjDt, "ParameterName", "ParameterID")
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjParameter) = False Then
                ObjParameter = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjDt = Nothing
            End If

        End Try

    End Sub

    Private Sub cmbParameter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbParameter.SelectedIndexChanged
        If Not TypeOf cmbParameter.SelectedValue Is Decimal Then
            Exit Sub
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not TypeOf cmbParameter.SelectedValue Is Decimal Then
            Exit Sub
        End If
        Dim ObjParameter As New ClsParameter
        Dim ObjDt As New DataTable

        If cmbParameter.SelectedValue = 0 Then
            Exit Sub
        End If
        ObjParameter.ParaMeterID = cmbParameter.SelectedValue
        ObjDt = ObjParameter.FunFetch
        If ObjDt.Rows.Count > 0 Then
            grdQuickControlStep2.Rows.Add(cmbParameter.SelectedValue, ObjDt.Rows(0).Item("ParameterName"), ObjDt.Rows(0).Item("ParameterDesc"), ObjDt.Rows(0).Item("Behaviour"), 0)
        End If
    End Sub

    Public Sub FetchTotalAmountFromSaleDetails()
        Dim ObjTotal As New CWPlusBL.ClsQuickControl
        Dim ObjDt As New DataTable
        Try
            ObjTotal.FromDate = GblFromDate
            ObjTotal.ToDate = GblToDate
            ObjDt = ObjTotal.FetchQuickControls2()
            If ObjDt.Rows.Count > 0 Then
                txtGrossRevenue.Text = ObjDt.Rows(0).Item("GrossSaleAmount")
                gblGrossTotal = txtGrossRevenue.Text
                txtNetRevenue.Text = txtGrossRevenue.Text
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjTotal) = False Then
                ObjTotal = Nothing
            End If

            If IsNothing(ObjDt) = False Then
                ObjTotal = Nothing
            End If
        End Try
    End Sub
    Private Sub grdQuickControlStep2_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdQuickControlStep2.CellValueChanged
        'If e.RowIndex = 0 Then
        '    Exit Sub
        'End If

        'Dim ObjParameter As New ClsParameter
        'Dim ObjDt As New DataTable
        If cmbParameter.SelectedValue = 0 Then
            Exit Sub
        End If

        Dim DblNetREvenue As Double = IIf(Trim(txtNetRevenue.Text) = "", 0, txtNetRevenue.Text)
        If e.ColumnIndex = 4 Then
            Dim vNum As Double = 0
            For cnt = 0 To grdQuickControlStep2.Rows.Count - 1

                If grdQuickControlStep2.Item("Behaviour", cnt).Value = "Positive" Then
                    vNum += grdQuickControlStep2.Item("Amount", cnt).Value

                ElseIf grdQuickControlStep2.Item("Behaviour", cnt).Value = "Negative" Then
                    vNum -= grdQuickControlStep2.Item("Amount", cnt).Value
                End If

            Next
            txtNetRevenue.Text = (CDbl(txtGrossRevenue.Text) + vNum)
            gblNetTotal = CDbl(txtNetRevenue.Text)
        End If


    End Sub

    Public Function SaveQcStep2() As Boolean
        Dim ObjSave As New CWPlusBL.ClsQuickControl
        Dim ObjDt As New DataTable
        SaveQcStep2 = False
        Try
            ObjSave.ControlHeadID = gblControlHeadID
            ObjSave.LicenseID = gblLicenseID
            ObjSave.FromDate = GblFromDate
            ObjSave.ToDate = GblToDate
            ObjSave.GrossRevenue = txtGrossRevenue.Text
            ObjSave.NetRevenue = IIf(Trim(txtNetRevenue.Text) = "", 0, txtNetRevenue.Text)
            ObjSave.ParaMeterID = cmbParameter.SelectedValue
            ObjSave.QcStep2DetailsXml = GenerateXML()
            ObjSave.QcStep1DetailsXml = gblQCSTEP1SaveXMl
            ObjSave.ControlDate = GblPurchaseDate

            ObjSave.UserName = gblUserName
            SaveQcStep2 = ObjSave.FunSaveQcStep2()
            MsgBox(ObjSave.ErrorMsg)

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(ObjSave) = False Then
                ObjSave = Nothing
            End If
            If IsNothing(ObjDt) = False Then
                ObjSave = Nothing

            End If
        End Try
    End Function

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><QCStep2Table></QCStep2Table></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("QcStep2")
        For index = 0 To grdQuickControlStep2.RowCount - 1
            XmlElt = xmldoc.CreateElement("QcStep2")
            XmlElt.SetAttribute("parameterid", grdQuickControlStep2.Item("parameterid", index).Value)
            XmlElt.SetAttribute("ParameterName", grdQuickControlStep2.Item("parametername", index).Value)
            XmlElt.SetAttribute("ParameterDesc", grdQuickControlStep2.Item("parameterDesc", index).Value)
            XmlElt.SetAttribute("behaviour", grdQuickControlStep2.Item("behaviour", index).Value)
            XmlElt.SetAttribute("Amount", grdQuickControlStep2.Item("Amount", index).Value)
            xmldoc.DocumentElement.Item("QCStep2Table").AppendChild(XmlElt)
        Next
        Return xmldoc
    End Function

    Public Sub FetchControls()
        Dim ObjControls As New CWPlusBL.ClsQuickControl
        Dim ObjDt As New DataSet
        Try
            ObjControls.LicenseID = gblLicenseID
            ObjControls.FromDate = GblPurchaseDate
            ObjControls.DblPubControlHeadID = gblControlHeadID

            ObjDt = ObjControls.FunFetchContorlForQCStep2()
            grdQuickControlStep2.Rows.Clear()

            For rwctr = 0 To ObjDt.Tables(1).Rows.Count - 1

                grdQuickControlStep2.Rows.Add()
                grdQuickControlStep2("parameterid", rwctr).Value = ObjDt.Tables(1).Rows(rwctr)("ParameterID")
                grdQuickControlStep2("parametername", rwctr).Value = ObjDt.Tables(1).Rows(rwctr)("ParameterName")
                grdQuickControlStep2("parameterDesc", rwctr).Value = ObjDt.Tables(1).Rows(rwctr)("ParameterDesc")
                grdQuickControlStep2("behaviour", rwctr).Value = ObjDt.Tables(1).Rows(rwctr)("behaviour")
                grdQuickControlStep2("Amount", rwctr).Value = ObjDt.Tables(1).Rows(rwctr)("Amount")
            Next



            If ObjDt.Tables(1).Rows.Count < 0 Then
                Exit Sub

            ElseIf ObjDt.Tables(0).Rows.Count < 0 Then
                Exit Sub

            ElseIf ObjDt.Tables(0).Rows.Count > 0 Then
                txtGrossRevenue.Text = IIf(ObjDt.Tables(0).Rows(0)("GrossRevenue") = Nothing, 0, ObjDt.Tables(0).Rows(0)("GrossRevenue"))
                txtNetRevenue.Text = IIf(ObjDt.Tables(0).Rows(0)("NetRevenue") = Nothing, 0, ObjDt.Tables(0).Rows(0)("NetRevenue"))
                gblGrossTotal = txtGrossRevenue.Text
                gblNetTotal = txtNetRevenue.Text
            End If

            ' End If



        Catch ex As Exception
            Throw ex

        End Try


    End Sub

    Private Sub MkDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdQuickControlStep2.CellContentClick
        If e.ColumnIndex = 5 Then

            Dim i As Integer = grdQuickControlStep2.CurrentRow.Index
            grdQuickControlStep2.Rows.RemoveAt(i)


        End If
    End Sub


End Class
