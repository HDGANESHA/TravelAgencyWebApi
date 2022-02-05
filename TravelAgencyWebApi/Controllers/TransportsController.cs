using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyWebApi.Models;
using TravelAgencyWebApi.Repository;

namespace TravelAgencyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        public readonly ITransportRepo _empRepository;
        public TransportsController(ITransportRepo transportRepository)
        {
            _empRepository = transportRepository;
        }

        #region Get


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transpordmode>>> GetAll()
        {
            return await _empRepository.GetAlltravelmode();
        }
        #endregion


        #region Post

        [HttpPost]
        public async Task<IActionResult> Addtransportmode([FromBody] Transpordmode mode)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var ModeId = await _empRepository.Addtravelmode(mode);
                    if (ModeId > 0)
                    {
                        return Ok(ModeId);

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }

        #endregion

        #region Update

        [HttpPut]
        public async Task<IActionResult> UpdateTravelMode([FromBody] Transpordmode mode)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _empRepository.Updatetravelmode(mode);

                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelMode(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _empRepository.Deletetravelmode(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
