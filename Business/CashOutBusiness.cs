using Business.DTO;
using Business.Exceptions;
using Business.Interface;
using DataAccess.Models;
using DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class CashOutBusiness : ICashOutBusiness
    {
        private readonly ImTellerRepository<CashOut> _cashOutRepository;

        public CashOutBusiness(ImTellerRepository<CashOut> cashOutRepository)
        {
            _cashOutRepository = cashOutRepository;
        }

        public async Task<OperationalResult<CashOut>> GetCashOut(int CashOutId)
        {
            var result = new OperationalResult<CashOut>
            {
                Status = false
            };

            var cashOut = await _cashOutRepository.GetAsync(CashOutId);

            result.Status = cashOut != null && cashOut.CashOutId > 0;

            if (result.Status)
                result.Data = cashOut;
            else
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<OperationalResult<IList<CashOut>>> GetAllCashOut()
        {
            var result = new OperationalResult<IList<CashOut>>
            {
                Status = false
            };

            var list = await _cashOutRepository.GetAllAsync();

            if (list.Any())
            {
                result.Status = true;
                result.Data = list.ToList();
            }
            else
            {
                throw new NotFoundException("Transaction not found");
            }

            return result;
        }

        public OperationalResult<CashOut> AddCashOut(CashOut cashOut)
        {
            var result = new OperationalResult<CashOut>
            {
                Status = false
            };

            //TODO: 1. Get customer data from MTN API
            //      2. If data retrieval succeeds
            //          2.1. Check if customers account balance is enough (Including 1% charge)
            // _ = await client.GetAsync("https://sandbox.momodeveloper.mtn.com/collection/v1_0/account/balance");
            //          2.2. Initiate authorization process for customer to approve (MTN)
            //          2.3. If approval succeeds, subtract cashout amount from customers balance and send.
            //          2.4. Log the transaction details and or print out a receipt.
            //      3. If data retrieval fails
            //          3.1. log the exception
            //          3.2. throw a user friendly error message for user
            result.Status = _cashOutRepository.Add(cashOut);

            if (!result.Status)
                throw new ForbiddenException("Error adding new cashout transaction");

            return result;
        }

        public OperationalResult<CashOut> UpdateCashOut(CashOut cashOut)
        {
            var result = new OperationalResult<CashOut>

            {
                Status = false
            };

            return result;
        }

        public async Task<OperationalResult<CashOut>> DeleteCashOut(int id)
        {
            var result = new OperationalResult<CashOut>
            {
                Status = false
            };

            result.Status = await _cashOutRepository.DeleteAsync(id);

            if (!result.Status)
                throw new ForbiddenException("Sorry. Transaction could not be deleted");

            return result;
        }
    }
}