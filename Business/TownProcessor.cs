using System;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class TownProcessor : ProcessorBase<Town>
    {
        public TownProcessor(IMteller mTeller) : base(mTeller)
        {}
    }
}
