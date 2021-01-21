Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Public Class encrypt
    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub

    Public Shared Function Decrypt(TextToBeDecrypted As String) As String
        'TextToBeDecrypted.Replace(" ", "+");
        Dim RijndaelCipher As New RijndaelManaged()

        Dim Password As String = "MAK"
        Dim DecryptedData As String

        Try
            Dim EncryptedData As Byte() = Convert.FromBase64String(TextToBeDecrypted)

            Dim Salt As Byte() = Encoding.ASCII.GetBytes(Password.Length.ToString())
            'Making of the key for decryption
            Dim SecretKey As New PasswordDeriveBytes(Password, Salt)
            'Creates a symmetric Rijndael decryptor object.
            Dim Decryptor As ICryptoTransform = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16))

            Dim memoryStream As New MemoryStream(EncryptedData)
            'Defines the cryptographics stream for decryption.THe stream contains decrpted data
            Dim cryptoStream As New CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read)

            Dim PlainText As Byte() = New Byte(EncryptedData.Length - 1) {}
            Dim DecryptedCount As Integer = cryptoStream.Read(PlainText, 0, PlainText.Length)
            memoryStream.Close()
            cryptoStream.Close()

            'Converting to string
            DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount)
        Catch
            DecryptedData = "error"
        End Try
        Return DecryptedData
    End Function

    Public Shared Function Encrypt(TextToBeEncrypted As String) As String
        Dim RijndaelCipher As New RijndaelManaged()
        Dim Password As String = "MAK"
        Dim PlainText As Byte() = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted)
        Dim Salt As Byte() = Encoding.ASCII.GetBytes(Password.Length.ToString())
        Dim SecretKey As New PasswordDeriveBytes(Password, Salt)
        'Creates a symmetric encryptor object. 
        Dim Encryptor As ICryptoTransform = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16))
        Dim memoryStream As New MemoryStream()
        'Defines a stream that links data streams to cryptographic transformations
        Dim cryptoStream As New CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write)
        cryptoStream.Write(PlainText, 0, PlainText.Length)
        'Writes the final state and clears the buffer
        cryptoStream.FlushFinalBlock()
        Dim CipherBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim EncryptedData As String = Convert.ToBase64String(CipherBytes)

        Return EncryptedData
    End Function
End Class
