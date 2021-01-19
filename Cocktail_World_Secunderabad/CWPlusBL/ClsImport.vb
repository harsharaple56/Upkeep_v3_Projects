Public Class ClsImport
    Inherits ClsCommon

    Public Function FetchImportSetup() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Import_FetchSetup")
            FetchImportSetup = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function


    Public Function ExportMaster(ProcName As String, xmlData As Xml.XmlDocument) As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand(ProcName)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@params", DbType.Xml, xmlData.InnerXml)
            ExportMaster = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
        End Try
    End Function

    Public Function ImportMaster(ProcName As String, IsSave As Boolean, xmlData As Xml.XmlDocument) As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand(ProcName)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@xmldata", DbType.Xml, xmlData.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@IsSave", DbType.Boolean, IsSave)
            DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@Outbit", SqlDbType.Bit, 1)
            DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@OutStatus", DbType.String, 100)
            ImportMaster = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@OutStatus").Value)

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Overrides Function FunDelete() As Boolean

    End Function

    Public Overrides Function FunFetch() As System.Data.DataTable

    End Function

    Public Overrides Function FunSave() As Boolean

    End Function
End Class
