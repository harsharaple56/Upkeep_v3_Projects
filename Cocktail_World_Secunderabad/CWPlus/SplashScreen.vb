Imports System.Threading
Imports System.Data.SqlClient

Public Class Splashscreen
    Dim tmr As New Windows.Forms.Timer
    Dim FormToShow As Form


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor.Hide()
        Me.Opacity = 0.2
        tmr.Interval = 80
        tmr.Enabled = False
        AddHandler tmr.Tick, AddressOf UpdateUI
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity >= 1 Then tmr.Enabled = True
        Me.Opacity += 0.4
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Public Sub UpdateUI()
        Timer1.Enabled = False
        If ProgBarPlus1.Value >= 100 AndAlso BackgroundWorker1.IsBusy = False Then
                tmr.Enabled = False
                FormToShow.Show()
                Me.Cursor.Show()
                Me.Close()
        End If
        ProgBarPlus1.Value += 2
        Thread.Sleep(60)
    End Sub


    Sub ConnectToDatabase()
        Dim con As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString & ";connection timeout=5")
        Dim cmd As New SqlCommand("SELECT 'cwplus'", con)
        cmd.CommandTimeout = 5
        con.Open()
        Dim result As String = cmd.ExecuteScalar
        con.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ConnectToDatabase()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Not IsNothing(e.Error) Then
            FormToShow = ConnectionSettings
        Else
            FormToShow = MDI
        End If
    End Sub
End Class
