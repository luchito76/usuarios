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
	public partial class SSO_GetUsuariosXAplicacionResultSet0
	{
		private int _idUsuario;
		public virtual int idUsuario
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
		
	}
}
#pragma warning restore 1591