﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace NAS.DAL.Accounting.Journal
{
    public partial class PaymentVouchesTransaction
    {
        public PaymentVouchesTransaction(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            //IssueDate = pIssueDate;
        }
    }
}
