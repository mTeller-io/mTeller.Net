using Business.DTO;
using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableQuery]
    public class CashInController : ODataController
    {
        private readonly ICashInBusiness _cashInBusiness;

        public CashInController(ICashInBusiness cashInBusiness)
        {
            _cashInBusiness = cashInBusiness;
        }

        // Get api/<CashInController>
        [HttpGet("allCashIn")]
        [EnableQuery(PageSize = 2, MaxExpansionDepth = 4)]
        public async Task<IActionResult> GetCashIn()
        {
            var result = await _cashInBusiness.GetAllCashIn();

            var cashIns = result.Data.FirstOrDefault() as IList<CashInDTO>;
            return Created("Cash in retrieved.", cashIns);
        }

        // Get api/<CashInController>
        [HttpGet("addCashIn")]
        public IActionResult AddCashIn([FromBody] CashInDTO cashInDTO)
        {
            try
            {
                var result = _cashInBusiness.AddCashIn(cashInDTO);
                if (result.Status)
                {
                    var error = result.ErrorList.FirstOrDefault();
                    return Problem(error.ErrorMessage, null, int.Parse(error.ErrorCode));
                }

                return Created("CashIn Created.", cashInDTO);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }
    }
}