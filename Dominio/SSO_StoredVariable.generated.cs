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
	public partial class SSO_StoredVariable
	{
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
		
		private Object Value1;
		public virtual Object Value
		{
			get
			{
				return this.Value1;
			}
			set
			{
				this.Value1 = value;
			}
		}
		
	}
}
#pragma warning restore 1591
