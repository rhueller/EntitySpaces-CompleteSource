
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:22 PM
'===============================================================================

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'EmployeeTerritories' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(EmployeeTerritories))> _
	<XmlType("EmployeeTerritories")> _	
	Partial Public Class EmployeeTerritories 
		Inherits esEmployeeTerritories
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New EmployeeTerritories()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal employeeID As System.Int32, ByVal territoryID As System.String)
			Dim obj As New EmployeeTerritories()
			obj.EmployeeID = employeeID
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal employeeID As System.Int32, ByVal territoryID As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New EmployeeTerritories()
			obj.EmployeeID = employeeID
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("EmployeeTerritoriesCollection")> _
	Partial Public Class EmployeeTerritoriesCollection
		Inherits esEmployeeTerritoriesCollection
		Implements IEnumerable(Of EmployeeTerritories)
	
		Public Function FindByPrimaryKey(ByVal employeeID As System.Int32, ByVal territoryID As System.String) As EmployeeTerritories
			Return MyBase.SingleOrDefault(Function(e) e.EmployeeID.HasValue AndAlso e.EmployeeID.Value = employeeID And e.TerritoryID = territoryID)
		End Function


				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(EmployeeTerritories))> _
		Public Class EmployeeTerritoriesCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of EmployeeTerritoriesCollection)
			
			Public Shared Widening Operator CType(packet As EmployeeTerritoriesCollectionWCFPacket) As EmployeeTerritoriesCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As EmployeeTerritoriesCollection) As EmployeeTerritoriesCollectionWCFPacket
				Return New EmployeeTerritoriesCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "EmployeeTerritoriesQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class EmployeeTerritoriesQuery 
		Inherits esEmployeeTerritoriesQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "EmployeeTerritoriesQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As EmployeeTerritoriesQuery) As String
			Return EmployeeTerritoriesQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As EmployeeTerritoriesQuery
			Return DirectCast(EmployeeTerritoriesQuery.SerializeHelper.FromXml(query, GetType(EmployeeTerritoriesQuery)), EmployeeTerritoriesQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esEmployeeTerritories
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal employeeID As System.Int32, ByVal territoryID As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(employeeID, territoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(employeeID, territoryID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal employeeID As System.Int32, ByVal territoryID As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(employeeID, territoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(employeeID, territoryID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal employeeID As System.Int32, ByVal territoryID As System.String) As Boolean
		
			Dim query As New EmployeeTerritoriesQuery()
			query.Where(query.EmployeeID = employeeID And query.TerritoryID = territoryID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal employeeID As System.Int32, ByVal territoryID As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("EmployeeID", employeeID)
						parms.Add("TerritoryID", territoryID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to EmployeeTerritories.EmployeeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeeTerritoriesMetadata.ColumnNames.EmployeeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeeTerritoriesMetadata.ColumnNames.EmployeeID, value) Then
					Me._UpToEmployeesByEmployeeID = Nothing
					Me.OnPropertyChanged("UpToEmployeesByEmployeeID")
					OnPropertyChanged(EmployeeTerritoriesMetadata.PropertyNames.EmployeeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to EmployeeTerritories.TerritoryID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TerritoryID As System.String
			Get
				Return MyBase.GetSystemString(EmployeeTerritoriesMetadata.ColumnNames.TerritoryID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeeTerritoriesMetadata.ColumnNames.TerritoryID, value) Then
					Me._UpToTerritoriesByTerritoryID = Nothing
					Me.OnPropertyChanged("UpToTerritoriesByTerritoryID")
					OnPropertyChanged(EmployeeTerritoriesMetadata.PropertyNames.TerritoryID)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToEmployeesByEmployeeID As Employees
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToTerritoriesByTerritoryID As Territories
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeeTerritoriesMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As EmployeeTerritoriesQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeeTerritoriesQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As EmployeeTerritoriesQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As EmployeeTerritoriesQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As EmployeeTerritoriesQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esEmployeeTerritoriesCollection
		Inherits esEntityCollection(Of EmployeeTerritories)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeeTerritoriesMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "EmployeeTerritoriesCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As EmployeeTerritoriesQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeeTerritoriesQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As EmployeeTerritoriesQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New EmployeeTerritoriesQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As EmployeeTerritoriesQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, EmployeeTerritoriesQuery))
		End Sub
		
		#End Region
						
		Private m_query As EmployeeTerritoriesQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esEmployeeTerritoriesQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return EmployeeTerritoriesMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "EmployeeID" 
					Return Me.EmployeeID
				Case "TerritoryID" 
					Return Me.TerritoryID
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeTerritoriesMetadata.ColumnNames.EmployeeID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property TerritoryID As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeTerritoriesMetadata.ColumnNames.TerritoryID, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class EmployeeTerritories 
		Inherits esEmployeeTerritories
		
	
		#Region "UpToEmployeesByEmployeeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_EmployeeTerritories_Employees
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToEmployeesByEmployeeID As Employees
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeesByEmployeeID Is Nothing _
						 AndAlso Not EmployeeID.Equals(Nothing)  Then
						
					Me._UpToEmployeesByEmployeeID = New Employees()
					Me._UpToEmployeesByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeesByEmployeeID", Me._UpToEmployeesByEmployeeID)
					Me._UpToEmployeesByEmployeeID.Query.Where(Me._UpToEmployeesByEmployeeID.Query.EmployeeID = Me.EmployeeID)
					Me._UpToEmployeesByEmployeeID.Query.Load()
				End If

				Return Me._UpToEmployeesByEmployeeID
			End Get
			
            Set(ByVal value As Employees)
				Me.RemovePreSave("UpToEmployeesByEmployeeID")
				
				Dim changed as Boolean = Me._UpToEmployeesByEmployeeID IsNot value

				If value Is Nothing Then
				
					Me.EmployeeID = Nothing
				
					Me._UpToEmployeesByEmployeeID = Nothing
				Else
				
					Me.EmployeeID = value.EmployeeID
					
					Me._UpToEmployeesByEmployeeID = value
					Me.SetPreSave("UpToEmployeesByEmployeeID", Me._UpToEmployeesByEmployeeID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeesByEmployeeID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToTerritoriesByTerritoryID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_EmployeeTerritories_Territories
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToTerritoriesByTerritoryID As Territories
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToTerritoriesByTerritoryID Is Nothing _
						 AndAlso Not TerritoryID.Equals(Nothing)  Then
						
					Me._UpToTerritoriesByTerritoryID = New Territories()
					Me._UpToTerritoriesByTerritoryID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToTerritoriesByTerritoryID", Me._UpToTerritoriesByTerritoryID)
					Me._UpToTerritoriesByTerritoryID.Query.Where(Me._UpToTerritoriesByTerritoryID.Query.TerritoryID = Me.TerritoryID)
					Me._UpToTerritoriesByTerritoryID.Query.Load()
				End If

				Return Me._UpToTerritoriesByTerritoryID
			End Get
			
            Set(ByVal value As Territories)
				Me.RemovePreSave("UpToTerritoriesByTerritoryID")
				
				Dim changed as Boolean = Me._UpToTerritoriesByTerritoryID IsNot value

				If value Is Nothing Then
				
					Me.TerritoryID = Nothing
				
					Me._UpToTerritoriesByTerritoryID = Nothing
				Else
				
					Me.TerritoryID = value.TerritoryID
					
					Me._UpToTerritoriesByTerritoryID = value
					Me.SetPreSave("UpToTerritoriesByTerritoryID", Me._UpToTerritoriesByTerritoryID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToTerritoriesByTerritoryID")
				End If
			End Set	

		End Property
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeesByEmployeeID Is Nothing Then
				Me.EmployeeID = Me._UpToEmployeesByEmployeeID.EmployeeID
			End If
			
		End Sub
	End Class
	
	<KnownType(GetType(Employees))> _
	<KnownType(GetType(Territories))> _	
	Public Partial Class EmployeeTerritories
		Inherits esEmployeeTerritories
	
	End Class	



	<Serializable> _
	Partial Public Class EmployeeTerritoriesMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(EmployeeTerritoriesMetadata.ColumnNames.EmployeeID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeeTerritoriesMetadata.PropertyNames.EmployeeID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeeTerritoriesMetadata.ColumnNames.TerritoryID, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeeTerritoriesMetadata.PropertyNames.TerritoryID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 20
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As EmployeeTerritoriesMetadata
			Return _meta
		End Function
		
		Public ReadOnly Property DataID() As System.Guid Implements IMetadata.DataID
			Get
				Return MyBase.m_dataID
			End Get
		End Property

		Public ReadOnly Property MultiProviderMode() As Boolean Implements IMetadata.MultiProviderMode
			Get
				Return false
			End Get
		End Property

		Public ReadOnly Property Columns() As esColumnMetadataCollection Implements IMetadata.Columns
			Get
				Return MyBase.m_columns
			End Get
		End Property

#Region "ColumnNames"
		Public Class ColumnNames
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const TerritoryID As String = "TerritoryID"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const TerritoryID As String = "TerritoryID"
		End Class
#End Region	

		Public Function GetProviderMetadata(ByVal mapName As String) As esProviderSpecificMetadata _
			Implements IMetadata.GetProviderMetadata

			Dim mapMethod As MapToMeta = mapDelegates(mapName)

			If (Not mapMethod = Nothing) Then
				Return mapMethod(mapName)
			Else
				Return Nothing
			End If

		End Function
		
#Region "MAP esDefault"

		Private Shared Function RegisterDelegateesDefault() As Integer
		
			' This is only executed once per the life of the application
			SyncLock GetType(EmployeeTerritoriesMetadata)
			
				If EmployeeTerritoriesMetadata.mapDelegates Is Nothing Then
					EmployeeTerritoriesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If EmployeeTerritoriesMetadata._meta Is Nothing Then
					EmployeeTerritoriesMetadata._meta = New EmployeeTerritoriesMetadata()
				End If

				Dim mapMethod As New MapToMeta(AddressOf _meta.esDefault)
				mapDelegates.Add("esDefault", mapMethod)
				mapMethod("esDefault")
				Return 0

			End SyncLock
			
		End Function

		Private Function esDefault(ByVal mapName As String) As esProviderSpecificMetadata

			If (Not m_providerMetadataMaps.ContainsKey(mapName)) Then
			
				Dim meta As esProviderSpecificMetadata = New esProviderSpecificMetadata()
				


				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("TerritoryID", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "EmployeeTerritories"
				meta.Destination = "EmployeeTerritories"
				
				meta.spInsert = "proc_EmployeeTerritoriesInsert"
				meta.spUpdate = "proc_EmployeeTerritoriesUpdate"
				meta.spDelete = "proc_EmployeeTerritoriesDelete"
				meta.spLoadAll = "proc_EmployeeTerritoriesLoadAll"
				meta.spLoadByPrimaryKey = "proc_EmployeeTerritoriesLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As EmployeeTerritoriesMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
