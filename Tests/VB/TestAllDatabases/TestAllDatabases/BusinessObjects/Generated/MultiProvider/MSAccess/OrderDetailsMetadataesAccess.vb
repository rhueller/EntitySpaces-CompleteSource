'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:04 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class OrderDetailsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrderDetailsMetadata)
			
				If OrderDetailsMetadata.mapDelegates Is Nothing Then
					OrderDetailsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrderDetailsMetadata._meta Is Nothing Then
                    OrderDetailsMetadata._meta = New OrderDetailsMetadata()
                End If

                Dim mapMethod As New MapToMeta(AddressOf _meta.esAccess)
                mapDelegates.Add("esAccess", mapMethod)
                mapMethod("esAccess")
                Return 0

            End SyncLock			
		
        End Function

        Private Function esAccess(ByVal mapName As String) As esProviderSpecificMetadata

            If (Not m_providerMetadataMaps.ContainsKey(mapName)) Then		

				Dim meta As esProviderSpecificMetadata = new esProviderSpecificMetadata()
			

				meta.AddTypeMap("OrderID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("ProductID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"))
				meta.AddTypeMap("Quantity", new esTypeMap("Integer", "System.Int16"))
				meta.AddTypeMap("Discount", new esTypeMap("Single", "System.Single"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Order Details"
				meta.Destination = "Order Details"
				
				meta.spInsert = "proc_Order DetailsInsert"
				meta.spUpdate = "proc_Order DetailsUpdate"
				meta.spDelete = "proc_Order DetailsDelete"
				meta.spLoadAll = "proc_Order DetailsLoadAll"
				meta.spLoadByPrimaryKey = "proc_Order DetailsLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
