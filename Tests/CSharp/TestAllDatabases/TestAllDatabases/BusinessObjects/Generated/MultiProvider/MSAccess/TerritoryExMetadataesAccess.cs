/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:27 AM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace BusinessObjects
{
    public partial class TerritoryExMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(TerritoryExMetadata))
			{
				if(TerritoryExMetadata.mapDelegates == null)
				{
					TerritoryExMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryExMetadata.meta == null)
				{
					TerritoryExMetadata.meta = new TerritoryExMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esAccess);
				mapDelegates.Add("esAccess", mapMethod);
				mapMethod("esAccess");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esAccess(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("Notes", new esTypeMap("Text", "System.String"));				
				meta.Catalog = "ForeignKeyTest.mdb";
				
				meta.Source = "TerritoryEx";
				meta.Destination = "TerritoryEx";
				
				meta.spInsert = "proc_TerritoryExInsert";				
				meta.spUpdate = "proc_TerritoryExUpdate";		
				meta.spDelete = "proc_TerritoryExDelete";
				meta.spLoadAll = "proc_TerritoryExLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoryExLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
