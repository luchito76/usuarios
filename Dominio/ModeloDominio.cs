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
		private static string connectionStringName = @"SSO_HOSPITALConnection";
			
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
			
		public IQueryable<SSO_Users_Role> SSO_Users_Roles 
		{
			get
			{
				return this.GetAll<SSO_Users_Role>();
			}
		}
		
		public IQueryable<SSO_User> SSO_Users 
		{
			get
			{
				return this.GetAll<SSO_User>();
			}
		}
		
		public IQueryable<SSO_Role> SSO_Roles 
		{
			get
			{
				return this.GetAll<SSO_Role>();
			}
		}
		
		public IQueryable<SSO_RoleGroup> SSO_RoleGroups 
		{
			get
			{
				return this.GetAll<SSO_RoleGroup>();
			}
		}
		
		public IQueryable<SSO_Permissions_Cache> SSO_Permissions_Caches 
		{
			get
			{
				return this.GetAll<SSO_Permissions_Cache>();
			}
		}
		
		public IQueryable<SSO_Permission> SSO_Permissions 
		{
			get
			{
				return this.GetAll<SSO_Permission>();
			}
		}
		
		public IQueryable<SSO_Module> SSO_Modules 
		{
			get
			{
				return this.GetAll<SSO_Module>();
			}
		}
		
		public IQueryable<SSO_Application> SSO_Applications 
		{
			get
			{
				return this.GetAll<SSO_Application>();
			}
		}
		
		public IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(int? idPerfil, int? idEfector)
		{
			int returnValue;
			return SSO_GetAppByRol(idPerfil, idEfector, out returnValue);
		}
		
		public IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(int? idPerfil, int? idEfector, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdPerfil = new OAParameter();
			parameterIdPerfil.ParameterName = "idPerfil";
			if(idPerfil.HasValue)
			{
				parameterIdPerfil.Value = idPerfil.Value;
			}
			else
			{
				parameterIdPerfil.DbType = DbType.Int32;
				parameterIdPerfil.Value = DBNull.Value;
			}

			OAParameter parameterIdEfector = new OAParameter();
			parameterIdEfector.ParameterName = "idEfector";
			if(idEfector.HasValue)
			{
				parameterIdEfector.Value = idEfector.Value;
			}
			else
			{
				parameterIdEfector.DbType = DbType.Int32;
				parameterIdEfector.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetAppByRolResultSet0> queryResult = this.ExecuteQuery<SSO_GetAppByRolResultSet0>("[dbo].[SSO_GetAppByRol]", CommandType.StoredProcedure, parameterIdPerfil, parameterIdEfector, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> SSO_GetUsuariosXAplicacion(int? idAplicacion)
		{
			int returnValue;
			return SSO_GetUsuariosXAplicacion(idAplicacion, out returnValue);
		}
		
		public IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> SSO_GetUsuariosXAplicacion(int? idAplicacion, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdAplicacion = new OAParameter();
			parameterIdAplicacion.ParameterName = "idAplicacion";
			if(idAplicacion.HasValue)
			{
				parameterIdAplicacion.Value = idAplicacion.Value;
			}
			else
			{
				parameterIdAplicacion.DbType = DbType.Int32;
				parameterIdAplicacion.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> queryResult = this.ExecuteQuery<SSO_GetUsuariosXAplicacionResultSet0>("[dbo].[SSO_GetUsuariosXAplicacion]", CommandType.StoredProcedure, parameterIdAplicacion, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetModulosXAplicacionResultSet0> SSO_GetModulosXAplicacion(int? idEfector, int? idPerfil, int? idAplicacion)
		{
			int returnValue;
			return SSO_GetModulosXAplicacion(idEfector, idPerfil, idAplicacion, out returnValue);
		}
		
		public IEnumerable<SSO_GetModulosXAplicacionResultSet0> SSO_GetModulosXAplicacion(int? idEfector, int? idPerfil, int? idAplicacion, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdEfector = new OAParameter();
			parameterIdEfector.ParameterName = "idEfector";
			if(idEfector.HasValue)
			{
				parameterIdEfector.Value = idEfector.Value;
			}
			else
			{
				parameterIdEfector.DbType = DbType.Int32;
				parameterIdEfector.Value = DBNull.Value;
			}

			OAParameter parameterIdPerfil = new OAParameter();
			parameterIdPerfil.ParameterName = "idPerfil";
			if(idPerfil.HasValue)
			{
				parameterIdPerfil.Value = idPerfil.Value;
			}
			else
			{
				parameterIdPerfil.DbType = DbType.Int32;
				parameterIdPerfil.Value = DBNull.Value;
			}

			OAParameter parameterIdAplicacion = new OAParameter();
			parameterIdAplicacion.ParameterName = "idAplicacion";
			if(idAplicacion.HasValue)
			{
				parameterIdAplicacion.Value = idAplicacion.Value;
			}
			else
			{
				parameterIdAplicacion.DbType = DbType.Int32;
				parameterIdAplicacion.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetModulosXAplicacionResultSet0> queryResult = this.ExecuteQuery<SSO_GetModulosXAplicacionResultSet0>("[dbo].[SSO_GetModulosXAplicacion]", CommandType.StoredProcedure, parameterIdEfector, parameterIdPerfil, parameterIdAplicacion, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetPermisosXUsuarioResultSet0> SSO_GetPermisosXUsuario(int? idPerfil, int? idEfector)
		{
			int returnValue;
			return SSO_GetPermisosXUsuario(idPerfil, idEfector, out returnValue);
		}
		
		public IEnumerable<SSO_GetPermisosXUsuarioResultSet0> SSO_GetPermisosXUsuario(int? idPerfil, int? idEfector, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdPerfil = new OAParameter();
			parameterIdPerfil.ParameterName = "idPerfil";
			if(idPerfil.HasValue)
			{
				parameterIdPerfil.Value = idPerfil.Value;
			}
			else
			{
				parameterIdPerfil.DbType = DbType.Int32;
				parameterIdPerfil.Value = DBNull.Value;
			}

			OAParameter parameterIdEfector = new OAParameter();
			parameterIdEfector.ParameterName = "idEfector";
			if(idEfector.HasValue)
			{
				parameterIdEfector.Value = idEfector.Value;
			}
			else
			{
				parameterIdEfector.DbType = DbType.Int32;
				parameterIdEfector.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetPermisosXUsuarioResultSet0> queryResult = this.ExecuteQuery<SSO_GetPermisosXUsuarioResultSet0>("[dbo].[SSO_GetPermisosXUsuario]", CommandType.StoredProcedure, parameterIdPerfil, parameterIdEfector, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> SSO_GetUsuariosXPerfil()
		{
			int returnValue;
			return SSO_GetUsuariosXPerfil(out returnValue);
		}
		
		public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> SSO_GetUsuariosXPerfil(out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			IEnumerable<SSO_GetUsuariosXPerfilResultSet01> queryResult = this.ExecuteQuery<SSO_GetUsuariosXPerfilResultSet01>("[dbo].[SSO_GetUsuariosXPerfil]", CommandType.StoredProcedure, parameterReturnValue);
		
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
			backend.Logging.MetricStoreSnapshotInterval = 0;
		
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
		IQueryable<SSO_Users_Role> SSO_Users_Roles
		{
			get;
		}
		IQueryable<SSO_User> SSO_Users
		{
			get;
		}
		IQueryable<SSO_Role> SSO_Roles
		{
			get;
		}
		IQueryable<SSO_RoleGroup> SSO_RoleGroups
		{
			get;
		}
		IQueryable<SSO_Permissions_Cache> SSO_Permissions_Caches
		{
			get;
		}
		IQueryable<SSO_Permission> SSO_Permissions
		{
			get;
		}
		IQueryable<SSO_Module> SSO_Modules
		{
			get;
		}
		IQueryable<SSO_Application> SSO_Applications
		{
			get;
		}
		IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(int? idPerfil, int? idEfector);
		IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(int? idPerfil, int? idEfector, out int returnValue);
		IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> SSO_GetUsuariosXAplicacion(int? idAplicacion);
		IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> SSO_GetUsuariosXAplicacion(int? idAplicacion, out int returnValue);
		IEnumerable<SSO_GetModulosXAplicacionResultSet0> SSO_GetModulosXAplicacion(int? idEfector, int? idPerfil, int? idAplicacion);
		IEnumerable<SSO_GetModulosXAplicacionResultSet0> SSO_GetModulosXAplicacion(int? idEfector, int? idPerfil, int? idAplicacion, out int returnValue);
		IEnumerable<SSO_GetPermisosXUsuarioResultSet0> SSO_GetPermisosXUsuario(int? idPerfil, int? idEfector);
		IEnumerable<SSO_GetPermisosXUsuarioResultSet0> SSO_GetPermisosXUsuario(int? idPerfil, int? idEfector, out int returnValue);
		IEnumerable<SSO_GetUsuariosXPerfilResultSet01> SSO_GetUsuariosXPerfil();
		IEnumerable<SSO_GetUsuariosXPerfilResultSet01> SSO_GetUsuariosXPerfil(out int returnValue);
	}
}
#pragma warning restore 1591
