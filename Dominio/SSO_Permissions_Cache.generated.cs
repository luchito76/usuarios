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
	public partial class SSO_Permissions_Cache
	{
		private int AutoId1;
		public virtual int AutoId
		{
			get
			{
				return this.AutoId1;
			}
			set
			{
				this.AutoId1 = value;
			}
		}
		
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
		
		private int ApplicationId1;
		public virtual int ApplicationId
		{
			get
			{
				return this.ApplicationId1;
			}
			set
			{
				this.ApplicationId1 = value;
			}
		}
		
		private int TargetType1;
		public virtual int TargetType
		{
			get
			{
				return this.TargetType1;
			}
			set
			{
				this.TargetType1 = value;
			}
		}
		
		private int Target1;
		public virtual int Target
		{
			get
			{
				return this.Target1;
			}
			set
			{
				this.Target1 = value;
			}
		}
		
		private bool Inherited1;
		public virtual bool Inherited
		{
			get
			{
				return this.Inherited1;
			}
			set
			{
				this.Inherited1 = value;
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
		
		private int GroupId1;
		public virtual int GroupId
		{
			get
			{
				return this.GroupId1;
			}
			set
			{
				this.GroupId1 = value;
			}
		}
		
		private int RoleDepthFromUser1;
		public virtual int RoleDepthFromUser
		{
			get
			{
				return this.RoleDepthFromUser1;
			}
			set
			{
				this.RoleDepthFromUser1 = value;
			}
		}
		
		private bool Allow1;
		public virtual bool Allow
		{
			get
			{
				return this.Allow1;
			}
			set
			{
				this.Allow1 = value;
			}
		}
		
		private bool Readonly1;
		public virtual bool Readonly
		{
			get
			{
				return this.Readonly1;
			}
			set
			{
				this.Readonly1 = value;
			}
		}
		
		private DateTime? EndDate1;
		public virtual DateTime? EndDate
		{
			get
			{
				return this.EndDate1;
			}
			set
			{
				this.EndDate1 = value;
			}
		}
		
	}
}
#pragma warning restore 1591