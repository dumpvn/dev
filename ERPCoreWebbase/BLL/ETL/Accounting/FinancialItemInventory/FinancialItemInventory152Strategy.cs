﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAS.BO.ETL.Accounting.FinancialItemInventory
{
    public class FinancialItemInventory152Strategy: FinancialItemInventoryBase
    {
        private const string ACCOUNT_CODE = "152";

        public FinancialItemInventory152Strategy(Guid transactionId)
            : base(transactionId, ACCOUNT_CODE)
        {
        }

        public override void ExtractTransaction(DevExpress.Xpo.Session session)
        {
            base.GetIsRelatedStrategy(session);
            if (IsRelatedStrategy)
            {
                this.fExtractingData = base.ExtractTransaction(session, TransactionId, ACCOUNT_CODE);
            }
        }

        public override void TransformTransaction(DevExpress.Xpo.Session session)
        {
            if (IsRelatedStrategy)
                this.fTransformData = base.TransformTransaction(session, this.fExtractingData, ACCOUNT_CODE);

        }

        public override void LoadTransaction(DevExpress.Xpo.Session session)
        {
            if (IsRelatedStrategy)
            {
                base.LoadTransaction(session, this.fTransformData);
            }
        }
    }
}
