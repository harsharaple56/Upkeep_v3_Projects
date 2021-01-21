Public Class frmStats
    Dim ArrayOfColumns, ArrGrp, ArrAnalysis As Array

    Private Sub frmStats_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SET THE SPLITTER DISTANCE
        SplitContainer2.SplitterDistance = Me.Height - 42


    End Sub
#Region "List Focus Change"

    Private Sub listGroupFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listGroupM1.GotFocus
        btnGroupM1.Image = My.Resources.arrow_left__1_
        btnGroupM1.Tag = "grp"
    End Sub

    Private Sub listAnalysisFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listAnalysisM1.GotFocus
        btnAnalysisM1.Image = My.Resources.arrow_left__1_
        btnAnalysisM1.Tag = "ana"
    End Sub

    Private Sub listVarsFoucs(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listVarsM1.GotFocus
        btnGroupM1.Image = My.Resources.arrow_right__1_
        btnAnalysisM1.Image = My.Resources.arrow_right__1_
        btnAnalysisM1.Tag = "var"
        btnGroupM1.Tag = "var"
    End Sub

#End Region

    Public Sub AddRemoveLists(ByVal listFrom As ListBox, ByVal listTo As ListBox)
        Dim srcTable As New DataTable
        'srcTable = gblDtDashboard
        If listFrom.SelectedIndex >= 0 Then
            Dim arItems(listFrom.Items.Count) As Object
            listFrom.SelectedItems.CopyTo(arItems, 0)
            For listCtr = 0 To listFrom.SelectedItems.Count - 1
                listTo.Items.Add(listFrom.SelectedItems(listCtr))
            Next
            'listFrom.ClearSelectedLists()
        End If
    End Sub

    Private Sub bntGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupM1.Click
        If btnGroupM1.Tag = "var" Then
            AddRemoveLists(listVarsM1, listGroupM1)
        ElseIf btnGroupM1.Tag = "grp" Then
            AddRemoveLists(listGroupM1, listVarsM1)
        End If
    End Sub

    Private Sub btnAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalysisM1.Click
        If btnAnalysisM1.Tag = "var" Then
            AddRemoveLists(listVarsM1, listAnalysisM1)
        ElseIf btnAnalysisM1.Tag = "ana" Then
            AddRemoveLists(listAnalysisM1, listVarsM1)
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetM1.Click
        listGroupM1.Items.Clear()
        listAnalysisM1.Items.Clear()
        listVarsM1.Items.Clear()
        listVarsM1.Items.AddRange(Me.ArrayOfColumns)
    End Sub
End Class