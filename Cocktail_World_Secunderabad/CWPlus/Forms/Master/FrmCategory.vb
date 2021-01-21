Imports System.Xml

Public Class FrmCategory
    Dim Objcategory As CWPlusBL.Master.ClsCategory
    Dim ObjDt As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'SET THEME TO CONTROLS
        AddTheme(SplitContainer1.Panel1)
    End Sub

#Region "Procedures"
    Private Sub ClrScreen()
        txtcategory.Clear()
        lblid.Text = 0
        txtbottle.Clear()
        txtspeg.Clear()
        txtlpeg.Clear()
        ChkIsExcise.Checked = False
        lblCategoryName.Text = ""
        grdPriceSeq.DataSource = Nothing
    End Sub

    Public Sub BindGrid()
        Try
            Objcategory = New CWPlusBL.Master.ClsCategory
            ObjDt = New DataTable
            ObjDt = Objcategory.FunFetch
            grdcategory.Rows.Clear()
            grdcategory.Columns.Clear()

            '############# ADD COLUMNS TO GRID ####################
            For ColCtr = 0 To ObjDt.Columns.Count - 1
                grdcategory.Columns.Add(ObjDt.Columns(ColCtr).ColumnName.ToString.Replace(" ", ""), ObjDt.Columns(ColCtr).ColumnName)
            Next

            '############# ADD ROWS TO GRID ####################

            For rCtr = 0 To ObjDt.Rows.Count - 1
                grdcategory.Rows.Add(ObjDt.Rows(rCtr)(0), ObjDt.Rows(rCtr)(1), ObjDt.Rows(rCtr)(2), ObjDt.Rows(rCtr)(3), ObjDt.Rows(rCtr)(4), ObjDt.Rows(rCtr)(5))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try
        grdcategory.Columns("CategoryID").Visible = False
        grdcategory.Columns("Categorydesc").HeaderText = "CategoryDesc"
        grdcategory.Columns("Categorydesc").Width = 130
    End Sub

    Public Function SaveCategory() As Boolean
        SaveCategory = False
        If lblid.Text = 0 Then
            If Not GblBoolNew Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Category")
                Exit Function
            End If
        Else
            If Not GblBoolEdit Then
                MsgBox("Access Denied", MsgBoxStyle.Information, "Category")
                Exit Function
            End If
        End If
        If txtcategory.Text = "" Then
            MsgBox("Enter Category Name")
            Exit Function
        End If
        Try
            Objcategory = New CWPlusBL.Master.ClsCategory
            Objcategory.CategoryID = lblid.Text
            Objcategory.Categorydesc = txtcategory.Text
            Objcategory.Bottle = IIf(txtbottle.Text = "", 0, txtbottle.Text)
            Objcategory.Speg = IIf(txtspeg.Text = "", 0, txtspeg.Text)
            Objcategory.Lpeg = IIf(txtlpeg.Text = "", 0, txtlpeg.Text)
            Objcategory.IsExcise = ChkIsExcise.Checked
            Objcategory.UserName = gblUserName
            SaveCategory = Objcategory.FunSave
            MsgBox(Objcategory.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try
    End Function

    Public Function SavePriceSeq() As Boolean
        SavePriceSeq = False
        If lblid.Text = 0 Then
            MsgBox("Select Category", MsgBoxStyle.Information, "Category")
            Exit Function
        End If
        Try
            Objcategory = New CWPlusBL.Master.ClsCategory
            Objcategory.CategoryID = lblid.Text
            Objcategory.CatgPriceSeqXML = GenerateXML()
            Objcategory.UserName = gblUserName
            SavePriceSeq = Objcategory.FunSaveCatgPriceSeq
            MsgBox(Objcategory.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try
    End Function

    Public Function FunDelete() As Boolean
        FunDelete = False
        If Not GblBoolDelete Then
            MsgBox("Access Denied", MsgBoxStyle.Information, "Category")
        End If
        If lblid.Text = 0 Then
            MsgBox("Select Category to delete", MsgBoxStyle.Critical, "Category")
            Exit Function
        End If
        Try
            Objcategory = New CWPlusBL.Master.ClsCategory
            Objcategory.CategoryID = lblid.Text
            Objcategory.UserName = gblUserName
            FunDelete = Objcategory.FunDelete
            MsgBox(Objcategory.ErrorMsg)
            ClrScreen()
            BindGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try
    End Function

    Private Function GenerateXML() As XmlDocument
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<Master><Category></Category></Master>")
        Dim XmlElt As XmlElement = xmldoc.CreateElement("PriceSeq")
        For index = 0 To grdPriceSeq.RowCount - 2
            'If CBool(grdBrandOpening.Item("sel", index).Value) Then
            XmlElt = xmldoc.CreateElement("PriceSeq")
            XmlElt.SetAttribute("Bottle", IIf(String.IsNullOrEmpty(Convert.ToString(grdPriceSeq.Item("Bottle", index).Value)), "", grdPriceSeq.Item("Bottle", index).Value))
            XmlElt.SetAttribute("Speg", IIf(String.IsNullOrEmpty(Convert.ToString(grdPriceSeq.Item("Speg", index).Value)), "", grdPriceSeq.Item("Speg", index).Value))
            XmlElt.SetAttribute("Lpeg", IIf(String.IsNullOrEmpty(Convert.ToString(grdPriceSeq.Item("Lpeg", index).Value)), "", grdPriceSeq.Item("Lpeg", index).Value))
            xmldoc.DocumentElement.Item("Category").AppendChild(XmlElt)
            'End If
        Next
        Return xmldoc
    End Function

    Sub FetchPriceSeq()
        Try
            Objcategory = New CWPlusBL.Master.ClsCategory
            ObjDt = New DataTable
            Objcategory.CategoryID = lblid.Text
            ObjDt = Objcategory.FunFetchCatgPriceSeq
            grdPriceSeq.DataSource = Nothing
            grdPriceSeq.DataSource = ObjDt
            grdPriceSeq.Columns("CategoryID").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(Objcategory) Then
                Objcategory = Nothing
            End If
        End Try
    End Sub

#End Region
    Private Sub FrmCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AssignRights(gblMenuDesc)
        'InitScreen()
        BindGrid()
        ' Label6.Text = DateAndTime.Now.ToString("G")
    End Sub

    Private Sub grdcategory_CellDoubleClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcategory.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        lblid.Text = grdcategory("CategoryID", e.RowIndex).Value
        txtcategory.Text = grdcategory("CategoryDesc", e.RowIndex).Value
        lblCategoryName.Text = txtcategory.Text
        FetchPriceSeq()
        txtbottle.Text = grdcategory("Bottle", e.RowIndex).Value
        txtspeg.Text = grdcategory("Speg", e.RowIndex).Value
        txtlpeg.Text = grdcategory("Lpeg", e.RowIndex).Value
        ChkIsExcise.Checked = grdcategory("IsExcise", e.RowIndex).Value
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        SaveCategory()
    End Sub

    Private Sub imgDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgDelete.Click

        FunDelete()
    End Sub


    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        Dim parentNod As New TreeNode("master")
        Dim childNod As New TreeNode("categorysizelinkup")
        parentNod.Nodes.Add(childNod)
        OpenForm(childNod)
        Me.Close()

    End Sub

    Private Sub txtbottle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbottle.KeyPress, txtlpeg.KeyPress, txtspeg.KeyPress, TextBox2.KeyPress, TextBox1.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
             Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SavePriceSeq()
    End Sub
End Class