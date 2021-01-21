Public Class frmMenuEngineeringMaster
    Dim ObjMenuEng As CWPlusBL.Master.ClsMenuEngineering
    Dim ObjDt As DataTable
#Region "Procedures"
    Private Sub ClrScreen()
        txtChallenge.Text = 0
        txtDog.Text = 0
        txtHorse.Text = 0
        txtStar.Text = 0
        lblID.Text = 0
    End Sub

    Public Function FetchData() As DataTable
        Try
            ObjMenuEng = New CWPlusBL.Master.ClsMenuEngineering
            ObjMenuEng.MethodID = lblID.Text
            Return ObjMenuEng.FunFetch

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjMenuEng) Then
                ObjMenuEng = Nothing
            End If
        End Try

    End Function

    Public Sub Init()
        Try
            ObjDt = New DataTable
            ObjDt = FetchData()

            If ObjDt.Rows.Count > 0 Then
                cmbDefault.SelectedValue = ObjDt.Rows(0)("defaultmethod")
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(ObjDt) Then
                ObjDt = Nothing
            End If
            If Not IsNothing(ObjMenuEng) Then
                ObjMenuEng = Nothing
            End If
        End Try
    End Sub

    Public Function Save() As Boolean
        Save = False

        Try
            ObjMenuEng = New CWPlusBL.Master.ClsMenuEngineering
            ObjMenuEng.MethodID = lblID.Text
            ObjMenuEng.MethodName = cmbMethod.Text
            ObjMenuEng.Challenge = txtChallenge.Text
            ObjMenuEng.Star = txtStar.Text
            ObjMenuEng.Dog = txtDog.Text
            ObjMenuEng.Horse = txtHorse.Text
            ObjMenuEng.DefaultMethod = cmbDefault.SelectedValue

            ObjMenuEng.UserName = gblUserName
            Save = ObjMenuEng.FunSave
            MsgBox(ObjMenuEng.ErrorMsg)
            ClrScreen()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If Not IsNothing(ObjMenuEng) Then
                ObjMenuEng = Nothing
            End If
        End Try
    End Function

    Public Sub BindMethod()
        ObjDt = New DataTable
        ObjDt = FetchData()
        cmbMethod.DataSource = Nothing
        ComboBindingTemplate(cmbMethod, ObjDt, "methodname", "methodid")

        ObjDt = New DataTable
        ObjDt = FetchData()
        cmbDefault.DataSource = Nothing
        With cmbDefault
            .DisplayMember = "methodname"
            .ValueMember = "methodid"
            .DataSource = ObjDt
        End With
    End Sub
#End Region

#Region "Events"

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgClose.Click
        frmMenuEngineering.Close()
        Dim parentNod As New TreeNode("controls")
        Dim childNod As New TreeNode("menu engineering")
        parentNod.Nodes.Add(childNod)
        OpenForm(childNod)
        Me.Close()
    End Sub

    Private Sub imgSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgSave.Click
        Save()
    End Sub

    Private Sub txtChallenge_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChallenge.KeyPress, txtDog.KeyPress, txtHorse.KeyPress, txtStar.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 46) Then
            e.Handled = False
        End If
    End Sub

    Private Sub cmbMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMethod.SelectedIndexChanged
        If Not TypeOf (cmbMethod.SelectedValue) Is Integer Then
            ClrScreen()
            Exit Sub
        End If
        lblID.Text = cmbMethod.SelectedValue
        If lblID.Text = 0 Then
            ClrScreen()
            Exit Sub
        End If
        ObjDt = New DataTable
        ObjDt = FetchData()

        If ObjDt.Rows.Count > 0 Then
            txtChallenge.Text = ObjDt.Rows(0)("challenge")
            txtStar.Text = ObjDt.Rows(0)("star")
            txtDog.Text = ObjDt.Rows(0)("dog")
            txtHorse.Text = ObjDt.Rows(0)("horse")
        Else
            ClrScreen()
        End If

    End Sub

    Private Sub frmMenuEngineeringMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindMethod()
        Init()
    End Sub

#End Region
End Class