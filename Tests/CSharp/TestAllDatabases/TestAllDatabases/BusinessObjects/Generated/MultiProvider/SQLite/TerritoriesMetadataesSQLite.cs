/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLite
Date Generated       : 3/17/2012 4:45:16 AM
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
    public partial class TerritoriesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSQLite()
		{
			// This is only executed once per the life of the application
			lock (typeof(TerritoriesMetadata))
			{
				if(TerritoriesMetadata.mapDelegates == null)
				{
					TerritoriesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoriesMetadata.meta == null)
				{
					TerritoriesMetadata.meta = new TerritoriesMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSQLite);
				mapDelegates.Add("esSQLite", mapMethod);
				mapMethod("esSQLite");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSQLite(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TerritoryDescription", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("RegionID", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "main";
				
				meta.Source = "Territories";
				meta.Destination = "Territories";
				
				meta.spInsert = "proc_TerritoriesInsert";				
				meta.spUpdate = "proc_TerritoriesUpdate";		
				meta.spDelete = "proc_TerritoriesDelete";
				meta.spLoadAll = "proc_TerritoriesLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
