﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using LawAppModel;

namespace LawAppModel	
{
	public partial class LawApp : OpenAccessContext, ILawAppUnitOfWork
	{
		private static string connectionStringName = @"LawApp15";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
		
		public LawApp()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public LawApp(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public LawApp(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public LawApp(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public LawApp(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<SignedWebUser> SignedWebUsers 
		{
			get
			{
				return this.GetAll<SignedWebUser>();
			}
		}
		
		public IQueryable<WebUser> WebUsers 
		{
			get
			{
				return this.GetAll<WebUser>();
			}
		}
		
		public IQueryable<Application> Applications 
		{
			get
			{
				return this.GetAll<Application>();
			}
		}
		
		public IQueryable<UserRole> UserRoles 
		{
			get
			{
				return this.GetAll<UserRole>();
			}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of LawApp.
		/// </summary>
		/// <param name="config">The BackendConfiguration of LawApp.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface ILawAppUnitOfWork : IUnitOfWork
	{
		IQueryable<SignedWebUser> SignedWebUsers
		{
			get;
		}
		IQueryable<WebUser> WebUsers
		{
			get;
		}
		IQueryable<Application> Applications
		{
			get;
		}
		IQueryable<UserRole> UserRoles
		{
			get;
		}
	}
}
#pragma warning restore 1591
