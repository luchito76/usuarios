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
	public partial class SSO_Application
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
		
		private string Executable1;
		public virtual string Executable
		{
			get
			{
				return this.Executable1;
			}
			set
			{
				this.Executable1 = value;
			}
		}
		
		private string Url1;
		public virtual string Url
		{
			get
			{
				return this.Url1;
			}
			set
			{
				this.Url1 = value;
			}
		}
		
		private bool Intefase_visible1;
		public virtual bool Intefase_visible
		{
			get
			{
				return this.Intefase_visible1;
			}
			set
			{
				this.Intefase_visible1 = value;
			}
		}
		
		private string Version1;
		public virtual string Version
		{
			get
			{
				return this.Version1;
			}
			set
			{
				this.Version1 = value;
			}
		}
		
		private bool Hospital1;
		public virtual bool Hospital
		{
			get
			{
				return this.Hospital1;
			}
			set
			{
				this.Hospital1 = value;
			}
		}
		
		private bool Sips1;
		public virtual bool Sips
		{
			get
			{
				return this.Sips1;
			}
			set
			{
				this.Sips1 = value;
			}
		}
		
		private IList<SSO_Module> SSO_Modules1 = new List<SSO_Module>();
		public virtual IList<SSO_Module> SSO_Modules
		{
			get
			{
				return this.SSO_Modules1;
			}
		}
		
	}
}
#pragma warning restore 1591
