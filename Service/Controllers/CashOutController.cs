using Business.DTO;
using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using DataAccess.Models;

namespace Service.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CashOutController : ControllerBase//ODataController
    {
        private readonly ICashOutBusiness _cashOutBusiness;

        public CashOutController(ICashOutBusiness cashOutBusiness)
        {
            _cashOutBusiness = cashOutBusiness;
        }

        [HttpGet]
        [Route("GetCashIn")]
        public async Task<IActionResult> GetCashOut()
        {
            try
            {
                var result = await _cashOutBusiness.GetAllCashOut();
                if (!result.Status)
                {
                    var cashOuts = result.Data.FirstOrDefault() as IList<CashOutDTO>;
                    return Ok(cashOuts);
                }
                else
                {
                    var error = result.ErrorList.FirstOrDefault();
                    return Problem(error.ErrorMessage, null, int.Parse(error.ErrorCode));
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }

        [HttpPost]
        [Route("AddCashOut")]
        public async Task<IActionResult> AddCashOut([FromBody] CashOut cashOut)
        {
            try
            {
                var result = await _cashOutBusiness.AddCashOut(cashOut);
                if (!result.Status)
                {
                    var error = result.ErrorList.FirstOrDefault();
                    return Problem(error.ErrorMessage, null, int.Parse(error.ErrorCode));
                }

                return Created("Cash out Created.", cashOut);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }
    }
}