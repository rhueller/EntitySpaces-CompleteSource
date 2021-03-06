
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:14 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Products' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Products))]	
	[XmlType("Products")]
	public partial class Products : esProducts
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Products();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 productID)
		{
			var obj = new Products();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 productID, esSqlAccessType sqlAccessType)
		{
			var obj = new Products();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ProductsProxyStub(Products entity)
		{
			return new ProductsProxyStub(entity);
		}

		#endregion
		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("ProductsCollection")]
	public partial class ProductsCollection : esProductsCollection, IEnumerable<Products>
	{
		public Products FindByPrimaryKey(System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.ProductID == productID);
		}

		#region Implicit Casts
		
		public static implicit operator ProductsCollectionProxyStub(ProductsCollection coll)
		{
			return new ProductsCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Products))]
		public class ProductsCollectionWCFPacket : esCollectionWCFPacket<ProductsCollection>
		{
			public static implicit operator ProductsCollection(ProductsCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ProductsCollectionWCFPacket(ProductsCollection collection)
			{
				return new ProductsCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "ProductsQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ProductsQuery : esProductsQuery
	{
		public ProductsQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ProductsQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ProductsQuery query)
		{
			return ProductsQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ProductsQuery(string query)
		{
			return (ProductsQuery)ProductsQuery.SerializeHelper.FromXml(query, typeof(ProductsQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esProducts : esEntity
	{
		public esProducts()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 productID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 productID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 productID)
		{
			ProductsQuery query = new ProductsQuery();
			query.Where(query.ProductID == productID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 productID)
		{
			esParameters parms = new esParameters();
			parms.Add("ProductID", productID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Products.ProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ProductID
		{
			get
			{
				return base.GetSystemInt32(ProductsMetadata.ColumnNames.ProductID);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductsMetadata.ColumnNames.ProductID, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.ProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.ProductName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ProductName
		{
			get
			{
				return base.GetSystemString(ProductsMetadata.ColumnNames.ProductName);
			}
			
			set
			{
				if(base.SetSystemString(ProductsMetadata.ColumnNames.ProductName, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.ProductName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.SupplierID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? SupplierID
		{
			get
			{
				return base.GetSystemInt32(ProductsMetadata.ColumnNames.SupplierID);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductsMetadata.ColumnNames.SupplierID, value))
				{
					this._UpToSuppliersBySupplierID = null;
					this.OnPropertyChanged("UpToSuppliersBySupplierID");
					OnPropertyChanged(ProductsMetadata.PropertyNames.SupplierID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.CategoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? CategoryID
		{
			get
			{
				return base.GetSystemInt32(ProductsMetadata.ColumnNames.CategoryID);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductsMetadata.ColumnNames.CategoryID, value))
				{
					this._UpToCategoriesByCategoryID = null;
					this.OnPropertyChanged("UpToCategoriesByCategoryID");
					OnPropertyChanged(ProductsMetadata.PropertyNames.CategoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.QuantityPerUnit
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String QuantityPerUnit
		{
			get
			{
				return base.GetSystemString(ProductsMetadata.ColumnNames.QuantityPerUnit);
			}
			
			set
			{
				if(base.SetSystemString(ProductsMetadata.ColumnNames.QuantityPerUnit, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.QuantityPerUnit);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(ProductsMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductsMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.UnitsInStock
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int16? UnitsInStock
		{
			get
			{
				return base.GetSystemInt16(ProductsMetadata.ColumnNames.UnitsInStock);
			}
			
			set
			{
				if(base.SetSystemInt16(ProductsMetadata.ColumnNames.UnitsInStock, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsInStock);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.UnitsOnOrder
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int16? UnitsOnOrder
		{
			get
			{
				return base.GetSystemInt16(ProductsMetadata.ColumnNames.UnitsOnOrder);
			}
			
			set
			{
				if(base.SetSystemInt16(ProductsMetadata.ColumnNames.UnitsOnOrder, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsOnOrder);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.ReorderLevel
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int16? ReorderLevel
		{
			get
			{
				return base.GetSystemInt16(ProductsMetadata.ColumnNames.ReorderLevel);
			}
			
			set
			{
				if(base.SetSystemInt16(ProductsMetadata.ColumnNames.ReorderLevel, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.ReorderLevel);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Products.Discontinued
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? Discontinued
		{
			get
			{
				return base.GetSystemBoolean(ProductsMetadata.ColumnNames.Discontinued);
			}
			
			set
			{
				if(base.SetSystemBoolean(ProductsMetadata.ColumnNames.Discontinued, value))
				{
					OnPropertyChanged(ProductsMetadata.PropertyNames.Discontinued);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Categories _UpToCategoriesByCategoryID;
		[CLSCompliant(false)]
		internal protected Suppliers _UpToSuppliersBySupplierID;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ProductsMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ProductsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductsQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductsQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ProductsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ProductsQuery query;		
	}



	[Serializable]
	abstract public partial class esProductsCollection : esEntityCollection<Products>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ProductsMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ProductsCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ProductsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductsQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductsQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ProductsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ProductsQuery)query);
		}

		#endregion
		
		private ProductsQuery query;
	}



	[Serializable]
	abstract public partial class esProductsQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ProductsMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "ProductID": return this.ProductID;
				case "ProductName": return this.ProductName;
				case "SupplierID": return this.SupplierID;
				case "CategoryID": return this.CategoryID;
				case "QuantityPerUnit": return this.QuantityPerUnit;
				case "UnitPrice": return this.UnitPrice;
				case "UnitsInStock": return this.UnitsInStock;
				case "UnitsOnOrder": return this.UnitsOnOrder;
				case "ReorderLevel": return this.ReorderLevel;
				case "Discontinued": return this.Discontinued;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.ProductID, esSystemType.Int32); }
		} 
		
		public esQueryItem ProductName
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.ProductName, esSystemType.String); }
		} 
		
		public esQueryItem SupplierID
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.SupplierID, esSystemType.Int32); }
		} 
		
		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.CategoryID, esSystemType.Int32); }
		} 
		
		public esQueryItem QuantityPerUnit
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.QuantityPerUnit, esSystemType.String); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem UnitsInStock
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.UnitsInStock, esSystemType.Int16); }
		} 
		
		public esQueryItem UnitsOnOrder
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.UnitsOnOrder, esSystemType.Int16); }
		} 
		
		public esQueryItem ReorderLevel
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.ReorderLevel, esSystemType.Int16); }
		} 
		
		public esQueryItem Discontinued
		{
			get { return new esQueryItem(this, ProductsMetadata.ColumnNames.Discontinued, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}


	
	public partial class Products : esProducts
	{

		#region UpToOrdersCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>

		[XmlIgnore]
		public OrdersCollection UpToOrdersCollection
		{
			get
			{
				if(this._UpToOrdersCollection == null)
				{
					this._UpToOrdersCollection = new OrdersCollection();
					this._UpToOrdersCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToOrdersCollection", this._UpToOrdersCollection);
					if (!this.es.IsLazyLoadDisabled && this.ProductID != null)
					{
						OrdersQuery m = new OrdersQuery("m");
						OrderDetailsQuery j = new OrderDetailsQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.OrderID == j.OrderID);
                        m.Where(j.ProductID == this.ProductID);

						this._UpToOrdersCollection.Load(m);
					}
				}

				return this._UpToOrdersCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToOrdersCollection != null) 
				{ 
					this.RemovePostSave("UpToOrdersCollection"); 
					this._UpToOrdersCollection = null;
					this.OnPropertyChanged("UpToOrdersCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
		public void AssociateOrdersCollection(Orders entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.ProductID = this.ProductID;
			obj.OrderID = entity.OrderID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>
		public void DissociateOrdersCollection(Orders entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.ProductID = this.ProductID;
            obj.OrderID = entity.OrderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private OrdersCollection _UpToOrdersCollection;
		private OrderDetailsCollection _OrderDetailsCollection;
		#endregion

		#region OrderDetailsCollectionByProductID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrderDetailsCollectionByProductID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Products.OrderDetailsCollectionByProductID_Delegate;
				map.PropertyName = "OrderDetailsCollectionByProductID";
				map.MyColumnName = "ProductID";
				map.ParentColumnName = "ProductID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void OrderDetailsCollectionByProductID_Delegate(esPrefetchParameters data)
		{
			ProductsQuery parent = new ProductsQuery(data.NextAlias());

			OrderDetailsQuery me = data.You != null ? data.You as OrderDetailsQuery : new OrderDetailsQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.ProductID == me.ProductID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>

		[XmlIgnore]
		public OrderDetailsCollection OrderDetailsCollectionByProductID
		{
			get
			{
				if(this._OrderDetailsCollectionByProductID == null)
				{
					this._OrderDetailsCollectionByProductID = new OrderDetailsCollection();
					this._OrderDetailsCollectionByProductID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrderDetailsCollectionByProductID", this._OrderDetailsCollectionByProductID);
				
					if (this.ProductID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrderDetailsCollectionByProductID.Query.Where(this._OrderDetailsCollectionByProductID.Query.ProductID == this.ProductID);
							this._OrderDetailsCollectionByProductID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrderDetailsCollectionByProductID.fks.Add(OrderDetailsMetadata.ColumnNames.ProductID, this.ProductID);
					}
				}

				return this._OrderDetailsCollectionByProductID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrderDetailsCollectionByProductID != null) 
				{ 
					this.RemovePostSave("OrderDetailsCollectionByProductID"); 
					this._OrderDetailsCollectionByProductID = null;
					this.OnPropertyChanged("OrderDetailsCollectionByProductID");
				} 
			} 			
		}
			
		
		private OrderDetailsCollection _OrderDetailsCollectionByProductID;
		#endregion

				
		#region UpToCategoriesByCategoryID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Products_Categories
		/// </summary>

		[XmlIgnore]
					
		public Categories UpToCategoriesByCategoryID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCategoriesByCategoryID == null && CategoryID != null)
				{
					this._UpToCategoriesByCategoryID = new Categories();
					this._UpToCategoriesByCategoryID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCategoriesByCategoryID", this._UpToCategoriesByCategoryID);
					this._UpToCategoriesByCategoryID.Query.Where(this._UpToCategoriesByCategoryID.Query.CategoryID == this.CategoryID);
					this._UpToCategoriesByCategoryID.Query.Load();
				}	
				return this._UpToCategoriesByCategoryID;
			}
			
			set
			{
				this.RemovePreSave("UpToCategoriesByCategoryID");
				
				bool changed = this._UpToCategoriesByCategoryID != value;

				if(value == null)
				{
					this.CategoryID = null;
					this._UpToCategoriesByCategoryID = null;
				}
				else
				{
					this.CategoryID = value.CategoryID;
					this._UpToCategoriesByCategoryID = value;
					this.SetPreSave("UpToCategoriesByCategoryID", this._UpToCategoriesByCategoryID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCategoriesByCategoryID");
				}
			}
		}
		#endregion
		

				
		#region UpToSuppliersBySupplierID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Products_Suppliers
		/// </summary>

		[XmlIgnore]
					
		public Suppliers UpToSuppliersBySupplierID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToSuppliersBySupplierID == null && SupplierID != null)
				{
					this._UpToSuppliersBySupplierID = new Suppliers();
					this._UpToSuppliersBySupplierID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToSuppliersBySupplierID", this._UpToSuppliersBySupplierID);
					this._UpToSuppliersBySupplierID.Query.Where(this._UpToSuppliersBySupplierID.Query.SupplierID == this.SupplierID);
					this._UpToSuppliersBySupplierID.Query.Load();
				}	
				return this._UpToSuppliersBySupplierID;
			}
			
			set
			{
				this.RemovePreSave("UpToSuppliersBySupplierID");
				
				bool changed = this._UpToSuppliersBySupplierID != value;

				if(value == null)
				{
					this.SupplierID = null;
					this._UpToSuppliersBySupplierID = null;
				}
				else
				{
					this.SupplierID = value.SupplierID;
					this._UpToSuppliersBySupplierID = value;
					this.SetPreSave("UpToSuppliersBySupplierID", this._UpToSuppliersBySupplierID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToSuppliersBySupplierID");
				}
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderDetailsCollectionByProductID":
					coll = this.OrderDetailsCollectionByProductID;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "OrderDetailsCollectionByProductID", typeof(OrderDetailsCollection), new OrderDetails()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToCategoriesByCategoryID != null)
			{
				this.CategoryID = this._UpToCategoriesByCategoryID.CategoryID;
			}
			if(!this.es.IsDeleted && this._UpToSuppliersBySupplierID != null)
			{
				this.SupplierID = this._UpToSuppliersBySupplierID.SupplierID;
			}
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._OrderDetailsCollection != null)
			{
				Apply(this._OrderDetailsCollection, "ProductID", this.ProductID);
			}
			if(this._OrderDetailsCollectionByProductID != null)
			{
				Apply(this._OrderDetailsCollectionByProductID, "ProductID", this.ProductID);
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Products")]
	[XmlType(TypeName="ProductsProxyStub")]	
	[Serializable]
	public partial class ProductsProxyStub
	{
		public ProductsProxyStub() 
		{
			theEntity = this.entity = new Products();
		}

		public ProductsProxyStub(Products obj)
		{
			theEntity = this.entity = obj;
		}

		public ProductsProxyStub(Products obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Products(ProductsProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Products);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.Int32? ProductID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ProductsMetadata.ColumnNames.ProductID);
				else
					return this.Entity.ProductID;
			}
			set { this.Entity.ProductID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String ProductName
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.ProductName))
					return this.Entity.ProductName;
				else
					return null;
			}
			set { this.Entity.ProductName = value; }
		}

		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
		public System.Int32? SupplierID
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.SupplierID))
					return this.Entity.SupplierID;
				else
					return null;
			}
			set { this.Entity.SupplierID = value; }
		}

		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
		public System.Int32? CategoryID
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.CategoryID))
					return this.Entity.CategoryID;
				else
					return null;
			}
			set { this.Entity.CategoryID = value; }
		}

		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.String QuantityPerUnit
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.QuantityPerUnit))
					return this.Entity.QuantityPerUnit;
				else
					return null;
			}
			set { this.Entity.QuantityPerUnit = value; }
		}

		[DataMember(Name="a5", Order=6, EmitDefaultValue=false)]
		public System.Decimal? UnitPrice
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.UnitPrice))
					return this.Entity.UnitPrice;
				else
					return null;
			}
			set { this.Entity.UnitPrice = value; }
		}

		[DataMember(Name="a6", Order=7, EmitDefaultValue=false)]
		public System.Int16? UnitsInStock
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.UnitsInStock))
					return this.Entity.UnitsInStock;
				else
					return null;
			}
			set { this.Entity.UnitsInStock = value; }
		}

		[DataMember(Name="a7", Order=8, EmitDefaultValue=false)]
		public System.Int16? UnitsOnOrder
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.UnitsOnOrder))
					return this.Entity.UnitsOnOrder;
				else
					return null;
			}
			set { this.Entity.UnitsOnOrder = value; }
		}

		[DataMember(Name="a8", Order=9, EmitDefaultValue=false)]
		public System.Int16? ReorderLevel
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.ReorderLevel))
					return this.Entity.ReorderLevel;
				else
					return null;
			}
			set { this.Entity.ReorderLevel = value; }
		}

		[DataMember(Name="a9", Order=10, EmitDefaultValue=false)]
		public System.Boolean? Discontinued
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductsMetadata.ColumnNames.Discontinued))
					return this.Entity.Discontinued;
				else
					return null;
			}
			set { this.Entity.Discontinued = value; }
		}


		[DataMember(Name="a10000", Order=10000)]
		public string esRowState
		{
			get { return TheRowState;  }
			set { TheRowState = value; }
		}
		
		[DataMember(Name="a10001", Order=10001, EmitDefaultValue=false)]
		private List<string> ModifiedColumns
		{
			get { return Entity.es.ModifiedColumns; }
			set 
			{ 
				Entity.es.ModifiedColumns.AddRange(value); 
			}
		}
		
		[DataMember(Name="a10002", Order=10002, EmitDefaultValue=false)]
		[XmlIgnore]		
		public Dictionary<string, object> esExtraColumns
		{
			get { return Entity.GetExtraColumns(); }
			set { Entity.SetExtraColumns(value);   }
		}
		
		[XmlArray("_x_ExtraColumns")]
		[XmlArrayItem("_x_ExtraColumns", Type = typeof(DictionaryEntry))]
		public DictionaryEntry[] _x_ExtraColumns
		{
			get
			{
				Dictionary<string, object> extra = Entity.GetExtraColumns();

				// Make an array of DictionaryEntries to return   
				DictionaryEntry[] ret = new DictionaryEntry[extra.Count];
				int i = 0;
				DictionaryEntry de;

				// Iterate through the extra columns to load items into the array.   
				foreach (KeyValuePair<string, object> kv in extra)
				{
					de = new DictionaryEntry();
					de.Key = kv.Key;
					de.Value = kv.Value;
					ret[i] = de;
					i++;
				}
				return ret;
			}
			set
			{
				Dictionary<string, object> extra = new Dictionary<string, object>();
				for (int i = 0; i < value.Length; i++)
				{
					extra.Add((string)value[i].Key, (int)value[i].Value);
				}
				Entity.SetExtraColumns(extra);
			}
		}	

		[XmlIgnore]
		public Products Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Products();
				}

				return this.entity;
			}

			set
			{
				this.entity = value;
			}
		}
		
		protected string TheRowState
		{
			get
			{
				return theEntity.es.RowState.ToString();
			}

			set
			{
				switch (value)
				{
					case "Unchanged":
						theEntity.AcceptChanges();
						break;

					case "Added":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Added;
						break;

					case "Modified":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Modified;
						break;

					case "Deleted":
						theEntity.AcceptChanges();
						theEntity.MarkAsDeleted();
						break;
				}
			}
		}		
		
		protected bool IncludeColumn(string columnName)
		{
			bool include = false;

			if (dirtyColumnsOnly)
			{
				if (theEntity.es.ModifiedColumns != null &&
					theEntity.es.ModifiedColumns.Contains(columnName))
				{
					include = true;
				}
			}
			else if (!theEntity.es.IsDeleted)
			{
				include = true;
			}

			return include;
		}		

		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		public Products entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ProductsCollection")]
	[XmlType(TypeName="ProductsCollectionProxyStub")]	
	[Serializable]
	public partial class ProductsCollectionProxyStub 
	{
		protected ProductsCollectionProxyStub() {}
		
		public ProductsCollectionProxyStub(esEntityCollection<Products> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ProductsCollectionProxyStub(esEntityCollection<Products> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ProductsCollection(ProductsCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Products);
		}
		
		public ProductsCollectionProxyStub(esEntityCollection<Products> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Products entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ProductsProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ProductsProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Products entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ProductsProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ProductsProxyStub> Collection = new List<ProductsProxyStub>();

		public ProductsCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ProductsCollection();

				foreach (ProductsProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ProductsCollection _coll;
	}



	[Serializable]
	public partial class ProductsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ProductsMetadata.ColumnNames.ProductID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductsMetadata.PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.ProductName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductsMetadata.PropertyNames.ProductName;
			c.CharacterMaxLength = 40;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.SupplierID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductsMetadata.PropertyNames.SupplierID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.CategoryID, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductsMetadata.PropertyNames.CategoryID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.QuantityPerUnit, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductsMetadata.PropertyNames.QuantityPerUnit;
			c.CharacterMaxLength = 20;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.UnitPrice, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductsMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"(0)";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.UnitsInStock, 6, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = ProductsMetadata.PropertyNames.UnitsInStock;
			c.NumericPrecision = 5;
			c.HasDefault = true;
			c.Default = @"(0)";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.UnitsOnOrder, 7, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = ProductsMetadata.PropertyNames.UnitsOnOrder;
			c.NumericPrecision = 5;
			c.HasDefault = true;
			c.Default = @"(0)";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.ReorderLevel, 8, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = ProductsMetadata.PropertyNames.ReorderLevel;
			c.NumericPrecision = 5;
			c.HasDefault = true;
			c.Default = @"(0)";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.Discontinued, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = ProductsMetadata.PropertyNames.Discontinued;
			c.HasDefault = true;
			c.Default = @"(0)";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ProductsMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string ProductID = "ProductID";
			 public const string ProductName = "ProductName";
			 public const string SupplierID = "SupplierID";
			 public const string CategoryID = "CategoryID";
			 public const string QuantityPerUnit = "QuantityPerUnit";
			 public const string UnitPrice = "UnitPrice";
			 public const string UnitsInStock = "UnitsInStock";
			 public const string UnitsOnOrder = "UnitsOnOrder";
			 public const string ReorderLevel = "ReorderLevel";
			 public const string Discontinued = "Discontinued";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ProductID = "ProductID";
			 public const string ProductName = "ProductName";
			 public const string SupplierID = "SupplierID";
			 public const string CategoryID = "CategoryID";
			 public const string QuantityPerUnit = "QuantityPerUnit";
			 public const string UnitPrice = "UnitPrice";
			 public const string UnitsInStock = "UnitsInStock";
			 public const string UnitsOnOrder = "UnitsOnOrder";
			 public const string ReorderLevel = "ReorderLevel";
			 public const string Discontinued = "Discontinued";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(ProductsMetadata))
			{
				if(ProductsMetadata.mapDelegates == null)
				{
					ProductsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductsMetadata.meta == null)
				{
					ProductsMetadata.meta = new ProductsMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ProductName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("SupplierID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("CategoryID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("UnitsInStock", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("ReorderLevel", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("Discontinued", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "Products";
				meta.Destination = "Products";
				
				meta.spInsert = "proc_ProductsInsert";				
				meta.spUpdate = "proc_ProductsUpdate";		
				meta.spDelete = "proc_ProductsDelete";
				meta.spLoadAll = "proc_ProductsLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ProductsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
