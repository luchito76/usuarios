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
	public partial class SSO_GetAplicacionesXPerfilResultSet0
	{
		private int _id;
		public virtual int id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}
		
		private int _idAplicacion;
		public virtual int idAplicacion
		{
			get
			{
				return this._idAplicacion;
			}
			set
			{
				this._idAplicacion = value;
			}
		}
		
		private int _target;
		public virtual int target
		{
			get
			{
				return this._target;
			}
			set
			{
				this._target = value;
			}
		}
		
		private bool _allow;
		public virtual bool allow
		{
			get
			{
				return this._allow;
			}
			set
			{
				this._allow = value;
			}
		}
		
	}
}
#pragma warning restore 1591
