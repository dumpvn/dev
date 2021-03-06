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
using NAS.DAL.Invoice;
using NAS.DAL.System.Privileage;
using NAS.DAL.Inventory.StockCart;
using NAS.DAL.Vouches;
using NAS.DAL.Inventory.Command;
namespace NAS.DAL.Nomenclature.Organization
{

    public partial class Person : XPCustomObject
    {
        Guid fPersonId;
		[Key(true)]
        public Guid PersonId
        {
            get { return fPersonId; }
            set { SetPropertyValue<Guid>("PersonId", ref fPersonId, value); }
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
        [Association(@"LoginAccountReferencesPerson", typeof(LoginAccount))]
        public XPCollection<LoginAccount> LoginAccounts { get { return GetCollection<LoginAccount>("LoginAccounts"); } }
        [Association(@"DepartmentPersonReferencesPerson", typeof(DepartmentPerson))]
        public XPCollection<DepartmentPerson> DepartmentPersons { get { return GetCollection<DepartmentPerson>("DepartmentPersons"); } }
        [Association(@"BillActorReferencesPerson", typeof(BillActor))]
        public XPCollection<BillActor> BillActors { get { return GetCollection<BillActor>("BillActors"); } }
        [Association(@"InventoryCommandActorReferencesPerson", typeof(InventoryCommandActor))]
        public XPCollection<InventoryCommandActor> InventoryCommandActors { get { return GetCollection<InventoryCommandActor>("InventoryCommandActors"); } }
        [Association(@"SpecialPrivilegeReferencesPerson", typeof(SpecialPrivilege))]
        public XPCollection<SpecialPrivilege> SpecialPrivileges { get { return GetCollection<SpecialPrivilege>("SpecialPrivileges"); } }
        [Association(@"StockCartActorReferencesPerson", typeof(StockCartActor))]
        public XPCollection<StockCartActor> StockCartActors { get { return GetCollection<StockCartActor>("StockCartActors"); } }
        [Association(@"VouchesActorReferencesPerson", typeof(VouchesActor))]
        public XPCollection<VouchesActor> VouchesActors { get { return GetCollection<VouchesActor>("VouchesActors"); } }
        [Association(@"BillTargetOrgainzationReferencesPerson")]
        public XPCollection<Bill> TargetOrgainzationOfBills
        {
            get
            {
                return GetCollection<Bill>("TargetOrgainzationOfBills");
            }
        }
	}

}
