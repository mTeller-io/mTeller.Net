using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class AccountChartTypeProcessor : ProcessorBase<AccountChartType>
    {
        public AccountChartTypeProcessor(IMteller mTeller) : base(mTeller)
        { }
    }
}
