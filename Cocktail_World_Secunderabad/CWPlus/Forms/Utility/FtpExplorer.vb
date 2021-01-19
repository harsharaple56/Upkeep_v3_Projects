Public Class FtpExplorer

    Private Sub FtpExplorer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("ftp://cwplus:cwplus@192.168.1.111")
    End Sub
End Class