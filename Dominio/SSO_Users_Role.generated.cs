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
using Dominio;

namespace Dominio	
{
	public partial class SSO_Users_Role
	{
		private int UserId1;
		public virtual int UserId
		{
			get
			{
				return this.UserId1;
			}
			set
			{
				this.UserId1 = value;
			}
		}
		
		private int RoleId1;
		public virtual int RoleId
		{
			get
			{
				return this.RoleId1;
			}
			set
			{
				this.RoleId1 = value;
			}
		}
		
		private int IdUserRol1;
		public virtual int IdUserRol
		{
			get
			{
				return this.IdUserRol1;
			}
			set
			{
				this.IdUserRol1 = value;
			}
		}
		
		private SSO_User SSO_User1;
		public virtual SSO_User SSO_User
		{
			get
			{
				return this.SSO_User1;
			}
			set
			{
				this.SSO_User1 = value;
			}
		}
		
	}
}
#pragma warning restore 1591
