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
	public partial class SSO_Module
	{
		private int Id1;
		public virtual int Id
		{
			get
			{
				return this.Id1;
			}
			set
			{
				this.Id1 = value;
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
		
		private int Module1;
		public virtual int Module
		{
			get
			{
				return this.Module1;
			}
			set
			{
				this.Module1 = value;
			}
		}
		
		private string Name1;
		public virtual string Name
		{
			get
			{
				return this.Name1;
			}
			set
			{
				this.Name1 = value;
			}
		}
		
		private string Description1;
		public virtual string Description
		{
			get
			{
				return this.Description1;
			}
			set
			{
				this.Description1 = value;
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
		
		private bool Protected1;
		public virtual bool Protected
		{
			get
			{
				return this.Protected1;
			}
			set
			{
				this.Protected1 = value;
			}
		}
		
		private bool NeedsView1;
		public virtual bool NeedsView
		{
			get
			{
				return this.NeedsView1;
			}
			set
			{
				this.NeedsView1 = value;
			}
		}
		
		private int? GroupId1;
		public virtual int? GroupId
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
		
		private int? Interfase_priority1;
		public virtual int? Interfase_priority
		{
			get
			{
				return this.Interfase_priority1;
			}
			set
			{
				this.Interfase_priority1 = value;
			}
		}
		
		private bool Interfase_visible1;
		public virtual bool Interfase_visible
		{
			get
			{
				return this.Interfase_visible1;
			}
			set
			{
				this.Interfase_visible1 = value;
			}
		}
		
		private string Interfase_image1;
		public virtual string Interfase_image
		{
			get
			{
				return this.Interfase_image1;
			}
			set
			{
				this.Interfase_image1 = value;
			}
		}
		
		private int? Log_Group1;
		public virtual int? Log_Group
		{
			get
			{
				return this.Log_Group1;
			}
			set
			{
				this.Log_Group1 = value;
			}
		}
		
		private int? Log_Key1;
		public virtual int? Log_Key
		{
			get
			{
				return this.Log_Key1;
			}
			set
			{
				this.Log_Key1 = value;
			}
		}
		
		private SSO_Application SSO_Application1;
		public virtual SSO_Application SSO_Application
		{
			get
			{
				return this.SSO_Application1;
			}
			set
			{
				this.SSO_Application1 = value;
			}
		}
		
		private IList<SSO_Permission> SSO_Permissions1 = new List<SSO_Permission>();
		public virtual IList<SSO_Permission> SSO_Permissions
		{
			get
			{
				return this.SSO_Permissions1;
			}
		}
		
	}
}
#pragma warning restore 1591
