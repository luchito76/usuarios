#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
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

namespace Dominio	
{
	public partial class SSO_GetUsuariosXPerfilResultSet01
	{
		private int _idUsuario;
		public virtual int IdUsuario
		{
			get
			{
				return this._idUsuario;
			}
			set
			{
				this._idUsuario = value;
			}
		}
		
		private int? _dNI;
		public virtual int? DNI
		{
			get
			{
				return this._dNI;
			}
			set
			{
				this._dNI = value;
			}
		}
		
		private string _nombre;
		public virtual string Nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				this._nombre = value;
			}
		}
		
		private string _apellido;
		public virtual string Apellido
		{
			get
			{
				return this._apellido;
			}
			set
			{
				this._apellido = value;
			}
		}
		
		private string _usuario;
		public virtual string Usuario
		{
			get
			{
				return this._usuario;
			}
			set
			{
				this._usuario = value;
			}
		}
		
		private int? _rolId;
		public virtual int? RolId
		{
			get
			{
				return this._rolId;
			}
			set
			{
				this._rolId = value;
			}
		}
		
		private int? _userId;
		public virtual int? UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				this._userId = value;
			}
		}
		
		private string _nombreRol;
		public virtual string NombreRol
		{
			get
			{
				return this._nombreRol;
			}
			set
			{
				this._nombreRol = value;
			}
		}
		
		private int? _parent;
		public virtual int? Parent
		{
			get
			{
				return this._parent;
			}
			set
			{
				this._parent = value;
			}
		}
		
	}
}
#pragma warning restore 1591
