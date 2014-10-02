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
using Dominio;

namespace Dominio	
{
	public partial class ModeloDominio : OpenAccessContext, IModeloDominioUnitOfWork
	{
		private static string connectionStringName = @"SSOConnection";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("ModeloDominio.rlinq");
		
		public ModeloDominio()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public ModeloDominio(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public ModeloDominio(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public ModeloDominio(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public ModeloDominio(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<SSO_Application> SSO_Applications 
		{
			get
			{
				return this.GetAll<SSO_Application>();
			}
		}
		
		public IQueryable<SSO_RoleGroup> SSO_RoleGroups 
		{
			get
			{
				return this.GetAll<SSO_RoleGroup>();
			}
		}
		
		public IQueryable<SSO_Permission> SSO_Permissions 
		{
			get
			{
				return this.GetAll<SSO_Permission>();
			}
		}
		
		public IQueryable<SSO_Roler> SSO_Roles 
		{
			get
			{
				return this.GetAll<SSO_Roler>();
			}
		}
		
		public IQueryable<SSO_Module> SSO_Modules 
		{
			get
			{
				return this.GetAll<SSO_Module>();
			}
		}
		
		public IQueryable<SSO_RoleGroups_Member> SSO_RoleGroups_Members 
		{
			get
			{
				return this.GetAll<SSO_RoleGroups_Member>();
			}
		}
		
		public IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(string perfil, string efector)
		{
			int returnValue;
			return SSO_GetAppByRol(perfil, efector, out returnValue);
		}
		
		public IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(string perfil, string efector, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterPerfil = new OAParameter();
			parameterPerfil.ParameterName = "perfil";
			parameterPerfil.Size = 100;
			if(perfil != null)
			{
				parameterPerfil.Value = perfil;
			}	
			else
			{
				parameterPerfil.DbType = DbType.String;
				parameterPerfil.Value = DBNull.Value;
			}

			OAParameter parameterEfector = new OAParameter();
			parameterEfector.ParameterName = "efector";
			parameterEfector.Size = 100;
			if(efector != null)
			{
				parameterEfector.Value = efector;
			}	
			else
			{
				parameterEfector.DbType = DbType.String;
				parameterEfector.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetAppByRolResultSet0> queryResult = this.ExecuteQuery<SSO_GetAppByRolResultSet0>("[dbo].[SSO_GetAppByRol]", CommandType.StoredProcedure, parameterPerfil, parameterEfector, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
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
		/// Allows you to customize the BackendConfiguration of ModeloDominio.
		/// </summary>
		/// <param name="config">The BackendConfiguration of ModeloDominio.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IModeloDominioUnitOfWork : IUnitOfWork
	{
		IQueryable<SSO_Application> SSO_Applications
		{
			get;
		}
		IQueryable<SSO_RoleGroup> SSO_RoleGroups
		{
			get;
		}
		IQueryable<SSO_Permission> SSO_Permissions
		{
			get;
		}
		IQueryable<SSO_Roler> SSO_Roles
		{
			get;
		}
		IQueryable<SSO_Module> SSO_Modules
		{
			get;
		}
		IQueryable<SSO_RoleGroups_Member> SSO_RoleGroups_Members
		{
			get;
		}
		IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(string perfil, string efector);
		IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(string perfil, string efector, out int returnValue);
	}
}
#pragma warning restore 1591
