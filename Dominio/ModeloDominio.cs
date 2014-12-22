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
		
		public IQueryable<SSO_StoredVariables_Template> SSO_StoredVariables_Templates 
		{
			get
			{
				return this.GetAll<SSO_StoredVariables_Template>();
			}
		}
		
		public IQueryable<SSO_StoredVariable> SSO_StoredVariables 
		{
			get
			{
				return this.GetAll<SSO_StoredVariable>();
			}
		}
		
		public IQueryable<Sys_Profesional> Sys_Profesionals 
		{
			get
			{
				return this.GetAll<Sys_Profesional>();
			}
		}
		
		public IQueryable<Guardia_Medicos_Funcione> Guardia_Medicos_Funciones 
		{
			get
			{
				return this.GetAll<Guardia_Medicos_Funcione>();
			}
		}
		
		public IQueryable<SSO_Config> SSO_Configs 
		{
			get
			{
				return this.GetAll<SSO_Config>();
			}
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
		
		public IEnumerable<SSO_GetModulosXUsuarioResultSet0> SSO_GetModulosXUsuario(int? idEfector, int? idUsuario, int? idAplicacion)
		{
			int returnValue;
			return SSO_GetModulosXUsuario(idEfector, idUsuario, idAplicacion, out returnValue);
		}
		
		public IEnumerable<SSO_GetModulosXUsuarioResultSet0> SSO_GetModulosXUsuario(int? idEfector, int? idUsuario, int? idAplicacion, out int returnValue)
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

			OAParameter parameterIdUsuario = new OAParameter();
			parameterIdUsuario.ParameterName = "idUsuario";
			if(idUsuario.HasValue)
			{
				parameterIdUsuario.Value = idUsuario.Value;
			}
			else
			{
				parameterIdUsuario.DbType = DbType.Int32;
				parameterIdUsuario.Value = DBNull.Value;
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

			IEnumerable<SSO_GetModulosXUsuarioResultSet0> queryResult = this.ExecuteQuery<SSO_GetModulosXUsuarioResultSet0>("[dbo].[SSO_GetModulosXUsuario]", CommandType.StoredProcedure, parameterIdEfector, parameterIdUsuario, parameterIdAplicacion, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetProfesionalesResultSet0> SSO_GetProfesionales()
		{
			int returnValue;
			return SSO_GetProfesionales(out returnValue);
		}
		
		public IEnumerable<SSO_GetProfesionalesResultSet0> SSO_GetProfesionales(out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			IEnumerable<SSO_GetProfesionalesResultSet0> queryResult = this.ExecuteQuery<SSO_GetProfesionalesResultSet0>("[dbo].[SSO_GetProfesionales]", CommandType.StoredProcedure, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetProfesionalXIdResultSet0> SSO_GetProfesionalXId(int? idProfesional)
		{
			int returnValue;
			return SSO_GetProfesionalXId(idProfesional, out returnValue);
		}
		
		public IEnumerable<SSO_GetProfesionalXIdResultSet0> SSO_GetProfesionalXId(int? idProfesional, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdProfesional = new OAParameter();
			parameterIdProfesional.ParameterName = "idProfesional";
			if(idProfesional.HasValue)
			{
				parameterIdProfesional.Value = idProfesional.Value;
			}
			else
			{
				parameterIdProfesional.DbType = DbType.Int32;
				parameterIdProfesional.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetProfesionalXIdResultSet0> queryResult = this.ExecuteQuery<SSO_GetProfesionalXIdResultSet0>("[dbo].[SSO_GetProfesionalXId]", CommandType.StoredProcedure, parameterIdProfesional, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public int SSO_BorrarStoredVariable(int? idUsuario)
		{
			int returnValue;
			return SSO_BorrarStoredVariable(idUsuario, out returnValue);
		}
		
		public int SSO_BorrarStoredVariable(int? idUsuario, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdUsuario = new OAParameter();
			parameterIdUsuario.ParameterName = "idUsuario";
			if(idUsuario.HasValue)
			{
				parameterIdUsuario.Value = idUsuario.Value;
			}
			else
			{
				parameterIdUsuario.DbType = DbType.Int32;
				parameterIdUsuario.Value = DBNull.Value;
			}

			int queryResult = this.ExecuteNonQuery("[dbo].[SSO_BorrarStoredVariable]", CommandType.StoredProcedure, parameterIdUsuario, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> SSO_GetProfesionalesXGuardia(int? idProfesional)
		{
			int returnValue;
			return SSO_GetProfesionalesXGuardia(idProfesional, out returnValue);
		}
		
		public IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> SSO_GetProfesionalesXGuardia(int? idProfesional, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterIdProfesional = new OAParameter();
			parameterIdProfesional.ParameterName = "idProfesional";
			if(idProfesional.HasValue)
			{
				parameterIdProfesional.Value = idProfesional.Value;
			}
			else
			{
				parameterIdProfesional.DbType = DbType.Int32;
				parameterIdProfesional.Value = DBNull.Value;
			}

			IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> queryResult = this.ExecuteQuery<SSO_GetProfesionalesXGuardiaResultSet0>("[dbo].[SSO_GetProfesionalesXGuardia]", CommandType.StoredProcedure, parameterIdProfesional, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> Sp_SSO_AllowedAppsByEfector(int? userId, int? roleId)
		{
			int returnValue;
			return Sp_SSO_AllowedAppsByEfector(userId, roleId, out returnValue);
		}
		
		public IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> Sp_SSO_AllowedAppsByEfector(int? userId, int? roleId, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterUserId = new OAParameter();
			parameterUserId.ParameterName = "userId";
			if(userId.HasValue)
			{
				parameterUserId.Value = userId.Value;
			}
			else
			{
				parameterUserId.DbType = DbType.Int32;
				parameterUserId.Value = DBNull.Value;
			}

			OAParameter parameterRoleId = new OAParameter();
			parameterRoleId.ParameterName = "roleId";
			if(roleId.HasValue)
			{
				parameterRoleId.Value = roleId.Value;
			}
			else
			{
				parameterRoleId.DbType = DbType.Int32;
				parameterRoleId.Value = DBNull.Value;
			}

			IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> queryResult = this.ExecuteQuery<sp_SSO_AllowedAppsByEfectorResultSet0>("[dbo].[sp_SSO_AllowedAppsByEfector]", CommandType.StoredProcedure, parameterUserId, parameterRoleId, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
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
		
		public Int16 SSO_Set_PermissionCache(int? idPerfil, int? idAplicacion, int? groupId)
		{
			int returnValue;
			return SSO_Set_PermissionCache(idPerfil, idAplicacion, groupId, out returnValue);
		}
		
		public Int16 SSO_Set_PermissionCache(int? idPerfil, int? idAplicacion, int? groupId, out int returnValue)
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

			OAParameter parameterGroupId = new OAParameter();
			parameterGroupId.ParameterName = "groupId";
			if(groupId.HasValue)
			{
				parameterGroupId.Value = groupId.Value;
			}
			else
			{
				parameterGroupId.DbType = DbType.Int32;
				parameterGroupId.Value = DBNull.Value;
			}

			Int16 queryResult = this.ExecuteScalar<Int16>("[dbo].[SSO_Set_PermissionCache]", CommandType.StoredProcedure, parameterIdPerfil, parameterIdAplicacion, parameterGroupId, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<SSO_GetUsuariosXPerfilResultSet02> SSO_GetUsuariosXPerfil()
		{
			int returnValue;
			return SSO_GetUsuariosXPerfil(out returnValue);
		}
		
		public IEnumerable<SSO_GetUsuariosXPerfilResultSet02> SSO_GetUsuariosXPerfil(out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			IEnumerable<SSO_GetUsuariosXPerfilResultSet02> queryResult = this.ExecuteQuery<SSO_GetUsuariosXPerfilResultSet02>("[dbo].[SSO_GetUsuariosXPerfil]", CommandType.StoredProcedure, parameterReturnValue);
		
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
			backend.ConnectionPool.MaxActive = 50;
			backend.Runtime.CommandTimeout = 120;
		
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
		IQueryable<SSO_StoredVariables_Template> SSO_StoredVariables_Templates
		{
			get;
		}
		IQueryable<SSO_StoredVariable> SSO_StoredVariables
		{
			get;
		}
		IQueryable<Sys_Profesional> Sys_Profesionals
		{
			get;
		}
		IQueryable<Guardia_Medicos_Funcione> Guardia_Medicos_Funciones
		{
			get;
		}
		IQueryable<SSO_Config> SSO_Configs
		{
			get;
		}
		IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> SSO_GetUsuariosXAplicacion(int? idAplicacion);
		IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> SSO_GetUsuariosXAplicacion(int? idAplicacion, out int returnValue);
		IEnumerable<SSO_GetModulosXAplicacionResultSet0> SSO_GetModulosXAplicacion(int? idEfector, int? idPerfil, int? idAplicacion);
		IEnumerable<SSO_GetModulosXAplicacionResultSet0> SSO_GetModulosXAplicacion(int? idEfector, int? idPerfil, int? idAplicacion, out int returnValue);
		IEnumerable<SSO_GetPermisosXUsuarioResultSet0> SSO_GetPermisosXUsuario(int? idPerfil, int? idEfector);
		IEnumerable<SSO_GetPermisosXUsuarioResultSet0> SSO_GetPermisosXUsuario(int? idPerfil, int? idEfector, out int returnValue);
		IEnumerable<SSO_GetModulosXUsuarioResultSet0> SSO_GetModulosXUsuario(int? idEfector, int? idUsuario, int? idAplicacion);
		IEnumerable<SSO_GetModulosXUsuarioResultSet0> SSO_GetModulosXUsuario(int? idEfector, int? idUsuario, int? idAplicacion, out int returnValue);
		IEnumerable<SSO_GetProfesionalesResultSet0> SSO_GetProfesionales();
		IEnumerable<SSO_GetProfesionalesResultSet0> SSO_GetProfesionales(out int returnValue);
		IEnumerable<SSO_GetProfesionalXIdResultSet0> SSO_GetProfesionalXId(int? idProfesional);
		IEnumerable<SSO_GetProfesionalXIdResultSet0> SSO_GetProfesionalXId(int? idProfesional, out int returnValue);
		int SSO_BorrarStoredVariable(int? idUsuario);
		int SSO_BorrarStoredVariable(int? idUsuario, out int returnValue);
		IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> SSO_GetProfesionalesXGuardia(int? idProfesional);
		IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> SSO_GetProfesionalesXGuardia(int? idProfesional, out int returnValue);
		IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> Sp_SSO_AllowedAppsByEfector(int? userId, int? roleId);
		IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> Sp_SSO_AllowedAppsByEfector(int? userId, int? roleId, out int returnValue);
		IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(int? idPerfil, int? idEfector);
		IEnumerable<SSO_GetAppByRolResultSet0> SSO_GetAppByRol(int? idPerfil, int? idEfector, out int returnValue);
		Int16 SSO_Set_PermissionCache(int? idPerfil, int? idAplicacion, int? groupId);
		Int16 SSO_Set_PermissionCache(int? idPerfil, int? idAplicacion, int? groupId, out int returnValue);
		IEnumerable<SSO_GetUsuariosXPerfilResultSet02> SSO_GetUsuariosXPerfil();
		IEnumerable<SSO_GetUsuariosXPerfilResultSet02> SSO_GetUsuariosXPerfil(out int returnValue);
	}
}
#pragma warning restore 1591
