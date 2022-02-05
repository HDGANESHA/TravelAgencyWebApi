using Microsoft.AspNetCore.Authorization;
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
    public class DestinationsController : ControllerBase
    {
        public readonly IDestinationRepo _empRepository;
        public DestinationsController(IDestinationRepo destinationRepository)
        {
            _empRepository = destinationRepository;
        }

        #region Get


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetAll()
        {
            return await _empRepository.GetAllDestination();
        }
        #endregion


        #region Post

       // [Authorize]

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddDestination([FromBody] Destination destination)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var destinationId = await _empRepository.AddDestination(destination);
                    if (destinationId > 0)
                    {
                        return Ok(destinationId);

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
        public async Task<IActionResult> UpdateDestination([FromBody] Destination destination)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _empRepository.UpdateDestination(destination);

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
        public async Task<IActionResult> DeleteDestination(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _empRepository.DeleteDestination(id);
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

        #region Get ALL DESTINATION
        [HttpGet]
        [Route("GetAllDestinations")]
        public async Task<IActionResult> GetAllDestinations()
        {
            try
            {
                var plan = await _empRepository.GetAllDestinationplans();
                if (plan == null)
                {
                    return NotFound();
                }
                return Ok(plan);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
        #endregion
    }
}
