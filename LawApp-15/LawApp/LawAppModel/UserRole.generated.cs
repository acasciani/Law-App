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
using LawAppModel;

namespace LawAppModel	
{
	public partial class UserRole
	{
		private int _userRoleId;
		public virtual int UserRoleId
		{
			get
			{
				return this._userRoleId;
			}
			set
			{
				this._userRoleId = value;
			}
		}
		
		private string _roleName;
		public virtual string RoleName
		{
			get
			{
				return this._roleName;
			}
			set
			{
				this._roleName = value;
			}
		}
		
		private int _applicationId;
		public virtual int ApplicationId
		{
			get
			{
				return this._applicationId;
			}
			set
			{
				this._applicationId = value;
			}
		}
		
		private Application _application1;
		public virtual Application Application
		{
			get
			{
				return this._application1;
			}
			set
			{
				this._application1 = value;
			}
		}
		
		private IList<SignedWebUser> _signedWebUsers = new List<SignedWebUser>();
		public virtual IList<SignedWebUser> SignedWebUsers
		{
			get
			{
				return this._signedWebUsers;
			}
		}
		
	}
}
#pragma warning restore 1591
