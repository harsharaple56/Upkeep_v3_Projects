Imports System.Xml
Public Class frmEvalLicense
    Dim ObjEvalLicense As CWPlusBL.Accor.ClsEvalLicense
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTROLS
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtLicenseName.Clear()
        lblid.Text = 0
        lblCategoryName.Text = ""

        grdLicenseCode.DataSource = Nothing
    End Sub

    Public Sub BindGrid()
        Try
            ObjEvalLicense = New CWPlusBL.Accor.ClsEvalLicense
            ObjDt = New DataTable
            ObjDt = ObjEvalLicense.FunFetch
            grdLicense.Rows.Clear()
            grdLicense.Columns.Clear()

            '############# ADD COLUMNS TO GRID ####################
            For ColCtr = 0 To ObjDt.Columns.Count - 1
                grdLicense.Columns.Add(ObjDt.Columns(ColCtr).ColumnName.ToString.Replace(" ", ""), ObjDt.Columns(ColCtr).ColumnName)
            Next

            '############# ADD ROWS TO GRID ####################

            For rCtr = 0 To ObjDt.Rows.Count - 1
                grdLicense.Rows.Add()
                For clctr = 0 To ObjDt.Columns.Count - 1
                    grdLicense(clctr, rCtr).Value = ObjDt.Rows(rCtr)(clctr)
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjEvalLicense) Then
                ObjEvalLicense = Nothing
            End If
        End Try
        grdLicense.Columns("EvalLicenseID").Visible = False

    End Sub

    Public Function SaveLicense() As Boolean
        SaveLicense = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Eval License")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Eval License")
                Exit Function
            End If
        End If
        If txtLicenseName.Text = "" Then
            MsgBox("Enter License Name")
            Exit Function
        End If
        Try
            ObjEvalLicense = New CWPlusBL.Accor.ClsEvalLicense
            ObjEvalLicense.EvalLicenseID = lblid.Text
            ObjEvalLicense.LicenseName = txtLicenseName.Text
            ObjEvalLicense.UserName = gblUserName
            SaveLicense = ObjEvalLicense.FunSave
            MsgBox(ObjEvalLicense.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjEvalLicense) Then
                ObjEvalLicense = Nothing
            End If
        End Try
    End Function

    Public Function SavePriceSeq() As Boolean
        SavePriceSeq = False
        If lblid.Text = 0 Then
            MsgBox("Select License", MsgBoxStyle.Information, "Eval License")
            Exit Function
        End If
        Try
            ObjEvalLicense = New CWPlusBL.Accor.ClsEvalLicense
            ObjEvalLicense.EvalLicenseID = lblid.Text
            ObjEvalLicense.LicenseCodeXML = GenerateXML()
            ObjEvalLicense.UserName = gblUserName
            SavePriceSeq = ObjEvalLicense.FunSaveLicenseCode
            MsgBox(ObjEvalLicense.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjEvalLicense) Then
                ObjEvalLicense = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Eval License")
        End If
        If lblid.Text = 0 Then
            MsgBox("Select License to delete", MsgBoxStyle.Critical, "Eval License")
            Exit Function
        End If
        Try
            ObjEvalLicense = New CWPlusBL.Accor.ClsEvalLicense
            ObjEvalLicense.EvalLicenseID = lblid.Text
            ObjEvalLicense.UserName = gblUserName
            FunDelete = ObjEvalLicense.FunDelete
            MsgBox(ObjEvalLicense.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjEvalLicense) Then
                ObjEvalLicense = Nothing
            End If
        End Try
    End Function

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><Category></Category></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("PriceSeq")
        For index = 0 To grdLicenseCode.RowCount - 2
            'If CBool(grdBrandOpening.Item("sel", index).Value) Then
            XmlElt = xmldoc.CreateElement("PriceSeq")
            XmlElt.SetAttribute("Licensecode", IIf(IsNothing(grdLicenseCode.Item("Licensecode", index).Value), 0, grdLicenseCode.Item("Licensecode", index).Value))
            XmlElt.SetAttribute("OperationType", IIf(IsNothing(grdLicenseCode.Item("OperationType", index).Value), 0, grdLicenseCode.Item("OperationType", index).Value))
            xmldoc.DocumentElement.Item("Category").AppendChild(XmlElt)
            'End If
        Next
        Return xmldoc
    End Function

    Sub FetchLicenseCode()
        Try
            ObjEvalLicense = New CWPlusBL.Accor.ClsEvalLicense
            ObjDt = New DataTable
            ObjEvalLicense.EvalLicenseID = lblid.Text
            ObjDt = ObjEvalLicense.FunFetchLicenseCode
            grdLicenseCode.DataSource = Nothing
            grdLicenseCode.DataSource = ObjDt
            grdLicenseCode.Columns("EvalLicenseID").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjEvalLicense) Then
                ObjEvalLicense = Nothing
            End If
        End Try
    End Sub

#End Region
    Private Sub FrmCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        AssignRights(gblMenuDesc)
        'InitScreen()
        BindGrid()
        ' Label6.Text = DateAndTime.Now.ToString("G")
    End Sub

    Private Sub grdcategory_CellDoubleClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLicense.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdLicense("EvalLicenseID", e.RowIndex).Value
        txtLicenseName.Text = grdLicense("LicenseName", e.RowIndex).Value
        lblCategoryName.Text = txtLicenseName.Text
        FetchLicenseCode()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SavePriceSeq()
    End Sub

    Private Sub imgSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveLicense()
    End Sub

    Private Sub imgDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click
        FunDelete()
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Me.Close()
    End Sub

    Private Sub imgNew_Click(sender As System.Object, e As System.EventArgs) Handles imgNew.Click
        ClrScreen()
    End Sub
End Class