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
	public partial class TSC_UniqueDays
	{
		private long _uniqueDayId;
		public virtual long UniqueDayId
		{
			get
			{
				return this._uniqueDayId;
			}
			set
			{
				this._uniqueDayId = value;
			}
		}
		
		private DateTime? _date;
		public virtual DateTime? Date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
			}
		}
		
		private short _day;
		public virtual short Day
		{
			get
			{
				return this._day;
			}
			set
			{
				this._day = value;
			}
		}
		
		private string _dayClass;
		public virtual string DayClass
		{
			get
			{
				return this._dayClass;
			}
			set
			{
				this._dayClass = value;
			}
		}
		
		private long _calendarId;
		public virtual long CalendarId
		{
			get
			{
				return this._calendarId;
			}
			set
			{
				this._calendarId = value;
			}
		}
		
		private int _webUserId;
		public virtual int WebUserId
		{
			get
			{
				return this._webUserId;
			}
			set
			{
				this._webUserId = value;
			}
		}
		
		private SignedWebUser _signedWebUser;
		public virtual SignedWebUser SignedWebUser
		{
			get
			{
				return this._signedWebUser;
			}
			set
			{
				this._signedWebUser = value;
			}
		}
		
		private TSC_Calendar _tSC_Calendar;
		public virtual TSC_Calendar TSC_Calendar
		{
			get
			{
				return this._tSC_Calendar;
			}
			set
			{
				this._tSC_Calendar = value;
			}
		}
		
	}
}
#pragma warning restore 1591
