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
using NAS.DAL.System.Privileage;
using NAS.DAL.Nomenclature.Item;
namespace NAS.DAL.Inventory.StockCart
{

    public partial class StockCartItem : XPCustomObject
    {
        private StockCart _StockCartId;
        private ItemUnit _ItemUnitId;
        private double _Quantity;
        Guid fStockCartItemId;
        [Key(true)]
        public Guid StockCartItemId
        {
            get { return fStockCartItemId; }
            set { SetPropertyValue<Guid>("StockCartItemId", ref fStockCartItemId, value); }
        }

        public double Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                SetPropertyValue("Quantity", ref _Quantity, value);
            }
        }

        [Association("StockCartItemReferencesItemUnit")]
        public ItemUnit ItemUnitId
        {
            get
            {
                return _ItemUnitId;
            }
            set
            {
                SetPropertyValue("ItemUnitId", ref _ItemUnitId, value);
            }
        }

        [Association("StockCartItemReferencesStockCart")]
        public StockCart StockCartId
        {
            get
            {
                return _StockCartId;
            }
            set
            {
                SetPropertyValue("StockCartId", ref _StockCartId, value);
            }
        }
		
	}

}