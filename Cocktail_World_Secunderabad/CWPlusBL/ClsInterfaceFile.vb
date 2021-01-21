Imports System.Xml
Public Class ClsInterfaceFile
    Inherits ClsCommon



#Region "Variable"
    Dim dtPriDate As DateTime
    Dim blPriIsPriceSeqAvail As Boolean
    Dim ArrInterfaceFileXml As XmlDocument
    Dim xmlbrand, xmlCocktail, xmlPermitholder As XmlDocument

#End Region
#Region "Property"
    Public Property IsPriceSeqAvail As Boolean
        Get
            Return blPriIsPriceSeqAvail
        End Get
        Set(ByVal value As Boolean)
            blPriIsPriceSeqAvail = value
        End Set
    End Property

    Public Property BrandXml As XmlDocument
        Get
            Return xmlbrand
        End Get
        Set(ByVal value As XmlDocument)
            xmlbrand = value
        End Set
    End Property

    Public Property CocktailXml As XmlDocument
        Get
            Return xmlCocktail
        End Get
        Set(ByVal value As XmlDocument)
            xmlCocktail = value
        End Set
    End Property

    Public Property PermitHolderXml As XmlDocument
        Get
            Return xmlPermitholder
        End Get
        Set(ByVal value As XmlDocument)
            xmlPermitholder = value
        End Set
    End Property

    Public Property InterfaceFileXml() As XmlDocument
        Get
            Return ArrInterfaceFileXml
        End Get
        Set(ByVal value As XmlDocument)
            ArrInterfaceFileXml = value
        End Set
    End Property

    Public Property InterfaceFileDate() As DateTime
        Get
            Return dtPriDate
        End Get
        Set(ByVal value As DateTime)
            dtPriDate = value
        End Set
    End Property
#End Region


    Public Overrides Function FunDelete() As Boolean

    End Function

    Public Function FunFetchInterfacefiledata() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchIntFileSale")
            ObjPriDbCommand.CommandTimeout = 999999999
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.DateTime, dtPriDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@IsPriceSeqAvail", DbType.Boolean, blPriIsPriceSeqAvail)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", DbType.Xml, ArrInterfaceFileXml.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userid", DbType.Double, DblPubUserID)
            DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@Outstrbrandcode", DbType.String, 500)
            FunFetchInterfacefiledata = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
            StrPubErrorMsg = Trim(ObjPriDbCommand.Parameters("@Outstrbrandcode").Value)
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

    Public Function FunFetchInterfacefilePurchase() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchInterfaceFilePurchase")

            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", SqlDbType.Xml, ArrInterfaceFileXml.InnerXml)

            FunFetchInterfacefilePurchase = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

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

    Public Function FunFetchPurchaseInterfaceFileTransfer() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchInterfacePurchaseFileTransfer")
            ObjPriDbCommand.CommandTimeout = 0
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", SqlDbType.Xml, ArrInterfaceFileXml.InnerXml)

            FunFetchPurchaseInterfaceFileTransfer = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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

    Public Function FunFetchInterfacefileTransfer() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchInterfaceFileTransfer")
            ObjPriDbCommand.CommandTimeout = 0
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@XmlDocBrand", SqlDbType.Xml, ArrInterfaceFileXml.InnerXml)

            FunFetchInterfacefileTransfer = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

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

    Public Overrides Function FunFetch() As System.Data.DataTable


    End Function

    Public Overrides Function FunSave() As Boolean
        FunSave = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveInterFaceFile")
            ObjPriCommand.CommandTimeout = 999999999
            DbPubDataBase.AddInParameter(ObjPriCommand, "@BillDate", DbType.Date, dtPriDate)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocBrand", SqlDbType.Xml, xmlbrand.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocCocktail", SqlDbType.Xml, xmlCocktail.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocPermit", SqlDbType.Xml, xmlPermitholder.InnerXml)

            DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            FunSave = Trim(ObjPriCommand.Parameters("@Outbit").Value)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            ObjPriTrans.Commit()
        Catch ex As Exception
            ObjPriTrans.Rollback()
            Throw ex

        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try
    End Function


    Public Function UpdateBillMaster() As Boolean
        UpdateBillMaster = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_UpdateCurrentBillNo")
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocBill", SqlDbType.Xml, xmlbrand.InnerXml)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            UpdateBillMaster = Trim(ObjPriCommand.Parameters("@Outbit").Value)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            ObjPriTrans.Commit()
        Catch ex As Exception
            ObjPriTrans.Rollback()
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try
    End Function
End Class
