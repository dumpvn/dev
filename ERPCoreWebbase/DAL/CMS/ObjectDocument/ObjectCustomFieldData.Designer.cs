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
namespace NAS.DAL.CMS.ObjectDocument
{
     
    public partial class ObjectCustomFieldData : XPCustomObject
    {
        Guid fObjectCustomFieldDataId;
		[Key(true)]
        public Guid ObjectCustomFieldDataId
        {
            get { return fObjectCustomFieldDataId; }
            set { SetPropertyValue<Guid>("ObjectCustomFieldDataId", ref fObjectCustomFieldDataId, value); }
		}
        CustomFieldData fCustomFieldDataId;
        [Association(@"ObjectCustomFieldDataReferencesCustomFieldData")]
        public CustomFieldData CustomFieldDataId
        {
            get { return fCustomFieldDataId; }
            set { SetPropertyValue<CustomFieldData>("CustomFieldDataId", ref fCustomFieldDataId, value); }
        }
        ObjectCustomField fObjectCustomFieldId;
        [Association(@"ObjectCustomFieldDataReferencesObjectCustomField")]
        public ObjectCustomField ObjectCustomFieldId
        {
            get { return fObjectCustomFieldId; }
            set { SetPropertyValue<ObjectCustomField>("ObjectCustomFieldId", ref fObjectCustomFieldId, value); }
        }
	}
}