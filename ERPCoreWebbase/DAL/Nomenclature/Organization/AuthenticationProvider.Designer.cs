//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
namespace NAS.DAL.Nomenclature.Organization
{

    public partial class AuthenticationProvider : XPCustomObject
    {
        Guid fAuthenticationProviderId;
		[Key(true)]
        public Guid AuthenticationProviderId
        { 
            get { return fAuthenticationProviderId; }
            set { SetPropertyValue<Guid>("AuthenticationProviderId", ref fAuthenticationProviderId, value); }
		}
		string fCode;
		[Size(36)]
		public string Code {
			get { return fCode; }
			set { SetPropertyValue<string>("Code", ref fCode, value); }
		}
        string fName;
        [Size(255)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }
        string fDescription;
        [Size(1024)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }
		DateTime fRowCreationTimeStamp;
		public DateTime RowCreationTimeStamp {
			get { return fRowCreationTimeStamp; }
			set { SetPropertyValue<DateTime>("RowCreationTimeStamp", ref fRowCreationTimeStamp, value); }
		}
        short fRowStatus;
        public short RowStatus
        {
            get { return fRowStatus; }
            set { SetPropertyValue<short>("RowStatus", ref fRowStatus, value); }
        }
        [Association(@"LoginAccountReferencesAuthenticationProvider", typeof(LoginAccount))]
        public XPCollection<LoginAccount> LoginAccounts { get { return GetCollection<LoginAccount>("LoginAccounts"); } }
	}

}
