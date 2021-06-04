using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Business
{
    public class ProcessorBase<T> : IMtellerProccessor<T> where T : class
    {
        private readonly IMteller _mteller;
        public ProcessorBase([NotNull]IMteller mTeller)
        {
            _mteller = mTeller;
        }

        protected ProcessorBase() { }
        public async void Create(T Tdata)
        {
            await _mteller.Repository<T>().InsertEntityAsync(Tdata);
            await _mteller.SaveChangesAsync();
        }

        public async void Delete(T Tdata)
        {
            _mteller.Repository<T>().DeleteEntity(Tdata);
            await _mteller.SaveChangesAsync();
        }

        public IEnumerable<T> Load()
        {
            throw new NotImplementedException();
        }

        public async void Update(T Tdata)
        {
            _mteller.Repository<T>().UpdateEntity(Tdata);
            await _mteller.SaveChangesAsync();
        }
    }
}
