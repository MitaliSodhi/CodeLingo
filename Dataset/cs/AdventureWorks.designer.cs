﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chapter_30___Linq_to_SQL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AdventureWorks2012")]
	public partial class AdventureWorksDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPerson(Person instance);
    partial void UpdatePerson(Person instance);
    partial void DeletePerson(Person instance);
    partial void InsertCurrency(Currency instance);
    partial void UpdateCurrency(Currency instance);
    partial void DeleteCurrency(Currency instance);
    partial void InsertSalesPerson(SalesPerson instance);
    partial void UpdateSalesPerson(SalesPerson instance);
    partial void DeleteSalesPerson(SalesPerson instance);
    #endregion
		
		public AdventureWorksDataContext() : 
				base(global::Chapter_30___Linq_to_SQL.Properties.Settings.Default.AdventureWorks2012ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Person> Persons
		{
			get
			{
				return this.GetTable<Person>();
			}
		}
		
		public System.Data.Linq.Table<Currency> Currencies
		{
			get
			{
				return this.GetTable<Currency>();
			}
		}
		
		public System.Data.Linq.Table<SalesPerson> SalesPersons
		{
			get
			{
				return this.GetTable<SalesPerson>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspSearchCandidateResumes", IsComposable=true)]
		public object uspSearchCandidateResumes([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(1000)")] string searchString, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> useInflectional, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> useThesaurus, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> language)
		{
			return ((object)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), searchString, useInflectional, useThesaurus, language).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspGetManagerEmployees")]
		public ISingleResult<uspGetManagerEmployeesResult> uspGetManagerEmployees([global::System.Data.Linq.Mapping.ParameterAttribute(Name="BusinessEntityID", DbType="Int")] System.Nullable<int> businessEntityID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), businessEntityID);
			return ((ISingleResult<uspGetManagerEmployeesResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Person.Person")]
	public partial class Person : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BusinessEntityID;
		
		private string _PersonType;
		
		private bool _NameStyle;
		
		private string _Title;
		
		private string _FirstName;
		
		private string _MiddleName;
		
		private string _LastName;
		
		private string _Suffix;
		
		private int _EmailPromotion;
		
		private System.Xml.Linq.XElement _AdditionalContactInfo;
		
		private System.Xml.Linq.XElement _Demographics;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBusinessEntityIDChanging(int value);
    partial void OnBusinessEntityIDChanged();
    partial void OnPersonTypeChanging(string value);
    partial void OnPersonTypeChanged();
    partial void OnNameStyleChanging(bool value);
    partial void OnNameStyleChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnMiddleNameChanging(string value);
    partial void OnMiddleNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnSuffixChanging(string value);
    partial void OnSuffixChanged();
    partial void OnEmailPromotionChanging(int value);
    partial void OnEmailPromotionChanged();
    partial void OnAdditionalContactInfoChanging(System.Xml.Linq.XElement value);
    partial void OnAdditionalContactInfoChanged();
    partial void OnDemographicsChanging(System.Xml.Linq.XElement value);
    partial void OnDemographicsChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public Person()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessEntityID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BusinessEntityID
		{
			get
			{
				return this._BusinessEntityID;
			}
			set
			{
				if ((this._BusinessEntityID != value))
				{
					this.OnBusinessEntityIDChanging(value);
					this.SendPropertyChanging();
					this._BusinessEntityID = value;
					this.SendPropertyChanged("BusinessEntityID");
					this.OnBusinessEntityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonType", DbType="NChar(2) NOT NULL", CanBeNull=false)]
		public string PersonType
		{
			get
			{
				return this._PersonType;
			}
			set
			{
				if ((this._PersonType != value))
				{
					this.OnPersonTypeChanging(value);
					this.SendPropertyChanging();
					this._PersonType = value;
					this.SendPropertyChanged("PersonType");
					this.OnPersonTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NameStyle", DbType="Bit NOT NULL")]
		public bool NameStyle
		{
			get
			{
				return this._NameStyle;
			}
			set
			{
				if ((this._NameStyle != value))
				{
					this.OnNameStyleChanging(value);
					this.SendPropertyChanging();
					this._NameStyle = value;
					this.SendPropertyChanged("NameStyle");
					this.OnNameStyleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(8)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)")]
		public string MiddleName
		{
			get
			{
				return this._MiddleName;
			}
			set
			{
				if ((this._MiddleName != value))
				{
					this.OnMiddleNameChanging(value);
					this.SendPropertyChanging();
					this._MiddleName = value;
					this.SendPropertyChanged("MiddleName");
					this.OnMiddleNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Suffix", DbType="NVarChar(10)")]
		public string Suffix
		{
			get
			{
				return this._Suffix;
			}
			set
			{
				if ((this._Suffix != value))
				{
					this.OnSuffixChanging(value);
					this.SendPropertyChanging();
					this._Suffix = value;
					this.SendPropertyChanged("Suffix");
					this.OnSuffixChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailPromotion", DbType="Int NOT NULL")]
		public int EmailPromotion
		{
			get
			{
				return this._EmailPromotion;
			}
			set
			{
				if ((this._EmailPromotion != value))
				{
					this.OnEmailPromotionChanging(value);
					this.SendPropertyChanging();
					this._EmailPromotion = value;
					this.SendPropertyChanged("EmailPromotion");
					this.OnEmailPromotionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdditionalContactInfo", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement AdditionalContactInfo
		{
			get
			{
				return this._AdditionalContactInfo;
			}
			set
			{
				if ((this._AdditionalContactInfo != value))
				{
					this.OnAdditionalContactInfoChanging(value);
					this.SendPropertyChanging();
					this._AdditionalContactInfo = value;
					this.SendPropertyChanged("AdditionalContactInfo");
					this.OnAdditionalContactInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Demographics", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement Demographics
		{
			get
			{
				return this._Demographics;
			}
			set
			{
				if ((this._Demographics != value))
				{
					this.OnDemographicsChanging(value);
					this.SendPropertyChanging();
					this._Demographics = value;
					this.SendPropertyChanged("Demographics");
					this.OnDemographicsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Sales.Currency")]
	public partial class Currency : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _CurrencyCode;
		
		private string _Name;
		
		private System.DateTime _ModifiedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCurrencyCodeChanging(string value);
    partial void OnCurrencyCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public Currency()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrencyCode", DbType="NChar(3) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string CurrencyCode
		{
			get
			{
				return this._CurrencyCode;
			}
			set
			{
				if ((this._CurrencyCode != value))
				{
					this.OnCurrencyCodeChanging(value);
					this.SendPropertyChanging();
					this._CurrencyCode = value;
					this.SendPropertyChanged("CurrencyCode");
					this.OnCurrencyCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Sales.SalesPerson")]
	public partial class SalesPerson : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BusinessEntityID;
		
		private System.Nullable<int> _TerritoryID;
		
		private System.Nullable<decimal> _SalesQuota;
		
		private decimal _Bonus;
		
		private decimal _CommissionPct;
		
		private decimal _SalesYTD;
		
		private decimal _SalesLastYear;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBusinessEntityIDChanging(int value);
    partial void OnBusinessEntityIDChanged();
    partial void OnTerritoryIDChanging(System.Nullable<int> value);
    partial void OnTerritoryIDChanged();
    partial void OnSalesQuotaChanging(System.Nullable<decimal> value);
    partial void OnSalesQuotaChanged();
    partial void OnBonusChanging(decimal value);
    partial void OnBonusChanged();
    partial void OnCommissionPctChanging(decimal value);
    partial void OnCommissionPctChanged();
    partial void OnSalesYTDChanging(decimal value);
    partial void OnSalesYTDChanged();
    partial void OnSalesLastYearChanging(decimal value);
    partial void OnSalesLastYearChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public SalesPerson()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessEntityID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BusinessEntityID
		{
			get
			{
				return this._BusinessEntityID;
			}
			set
			{
				if ((this._BusinessEntityID != value))
				{
					this.OnBusinessEntityIDChanging(value);
					this.SendPropertyChanging();
					this._BusinessEntityID = value;
					this.SendPropertyChanged("BusinessEntityID");
					this.OnBusinessEntityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TerritoryID", DbType="Int")]
		public System.Nullable<int> TerritoryID
		{
			get
			{
				return this._TerritoryID;
			}
			set
			{
				if ((this._TerritoryID != value))
				{
					this.OnTerritoryIDChanging(value);
					this.SendPropertyChanging();
					this._TerritoryID = value;
					this.SendPropertyChanged("TerritoryID");
					this.OnTerritoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SalesQuota", DbType="Money")]
		public System.Nullable<decimal> SalesQuota
		{
			get
			{
				return this._SalesQuota;
			}
			set
			{
				if ((this._SalesQuota != value))
				{
					this.OnSalesQuotaChanging(value);
					this.SendPropertyChanging();
					this._SalesQuota = value;
					this.SendPropertyChanged("SalesQuota");
					this.OnSalesQuotaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bonus", DbType="Money NOT NULL")]
		public decimal Bonus
		{
			get
			{
				return this._Bonus;
			}
			set
			{
				if ((this._Bonus != value))
				{
					this.OnBonusChanging(value);
					this.SendPropertyChanging();
					this._Bonus = value;
					this.SendPropertyChanged("Bonus");
					this.OnBonusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CommissionPct", DbType="SmallMoney NOT NULL")]
		public decimal CommissionPct
		{
			get
			{
				return this._CommissionPct;
			}
			set
			{
				if ((this._CommissionPct != value))
				{
					this.OnCommissionPctChanging(value);
					this.SendPropertyChanging();
					this._CommissionPct = value;
					this.SendPropertyChanged("CommissionPct");
					this.OnCommissionPctChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SalesYTD", DbType="Money NOT NULL")]
		public decimal SalesYTD
		{
			get
			{
				return this._SalesYTD;
			}
			set
			{
				if ((this._SalesYTD != value))
				{
					this.OnSalesYTDChanging(value);
					this.SendPropertyChanging();
					this._SalesYTD = value;
					this.SendPropertyChanged("SalesYTD");
					this.OnSalesYTDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SalesLastYear", DbType="Money NOT NULL")]
		public decimal SalesLastYear
		{
			get
			{
				return this._SalesLastYear;
			}
			set
			{
				if ((this._SalesLastYear != value))
				{
					this.OnSalesLastYearChanging(value);
					this.SendPropertyChanging();
					this._SalesLastYear = value;
					this.SendPropertyChanged("SalesLastYear");
					this.OnSalesLastYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class uspGetManagerEmployeesResult
	{
		
		private System.Nullable<int> _RecursionLevel;
		
		private string _OrganizationNode;
		
		private string _ManagerFirstName;
		
		private string _ManagerLastName;
		
		private System.Nullable<int> _BusinessEntityID;
		
		private string _FirstName;
		
		private string _LastName;
		
		public uspGetManagerEmployeesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecursionLevel", DbType="Int")]
		public System.Nullable<int> RecursionLevel
		{
			get
			{
				return this._RecursionLevel;
			}
			set
			{
				if ((this._RecursionLevel != value))
				{
					this._RecursionLevel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrganizationNode", DbType="NVarChar(4000)")]
		public string OrganizationNode
		{
			get
			{
				return this._OrganizationNode;
			}
			set
			{
				if ((this._OrganizationNode != value))
				{
					this._OrganizationNode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerFirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ManagerFirstName
		{
			get
			{
				return this._ManagerFirstName;
			}
			set
			{
				if ((this._ManagerFirstName != value))
				{
					this._ManagerFirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagerLastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ManagerLastName
		{
			get
			{
				return this._ManagerLastName;
			}
			set
			{
				if ((this._ManagerLastName != value))
				{
					this._ManagerLastName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessEntityID", DbType="Int")]
		public System.Nullable<int> BusinessEntityID
		{
			get
			{
				return this._BusinessEntityID;
			}
			set
			{
				if ((this._BusinessEntityID != value))
				{
					this._BusinessEntityID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
