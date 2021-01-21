Imports System.Data.SqlClient

Public Class frmSendReport


    Public Sub SaveMailSettings()
        Try
            Dim con As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString)
            Dim cmd As New SqlCommand("UPDATE MailSetup SET SmtpHost=@host,smtpuser=@user,smtppass=@pass,smtpport=@port,usessl=@ssl,smtpfrom=@from,smtpto=@to " & _
                                      "where SetupID = 1", con)
            cmd.Parameters.AddWithValue("@host", txtserver.Text)
            cmd.Parameters.AddWithValue("@user", txtUser.Text)
            cmd.Parameters.AddWithValue("@pass", txtPass.Text)
            cmd.Parameters.AddWithValue("@port", txtPort.Text)
            cmd.Parameters.AddWithValue("@ssl", chkEnableSSL.Checked)
            cmd.Parameters.AddWithValue("@from", txtFrom.Text)
            cmd.Parameters.AddWithValue("@to", txtTo.Text)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetSmtpSetup() As DataTable
        Try
            Dim con As New SqlConnection(Configuration.ConfigurationManager.ConnectionStrings("StrSqlConn").ConnectionString)
            Dim dap As New SqlDataAdapter("select * from MailSetup", con)
            Dim dt As New DataTable
            dap.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub CheckForValues()
        Dim dt As DataTable = GetSmtpSetup()
        Dim dr As DataRow = dt.Rows(0)
        txtFrom.Text = dr("smtpfrom")
        txtserver.Text = dr("smtphost")
        txtUser.Text = dr("smtpuser")
        txtPass.Text = dr("smtppass")
        txtPort.Text = dr("smtpport")
        chkEnableSSL.Checked = dr("usessl")
        txtTo.Text = dr("smtpto")
    End Sub


    Private Sub frmSendReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckForValues()
    End Sub


    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Try
            SaveMailSettings()
            smtpFrom = txtFrom.Text
            tomail = txtTo.Text
            smtpPort = txtPort.Text
            smtpHost = txtserver.Text
            smtpuser = txtUser.Text
            smtpPass = txtPass.Text
            enableSSL = chkEnableSSL.Checked
            SendMail("CWPlus Report", "<br / > Please find the attachment", Application.StartupPath & "\CW_Report.pdf")
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class