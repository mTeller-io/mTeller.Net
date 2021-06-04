using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class BranchMerchantNumberProcessor : ProcessorBase<BranchMerchantNumber>
    {
        public BranchMerchantNumberProcessor(IMteller mTeller) : base(mTeller)
        { }
    }
}
