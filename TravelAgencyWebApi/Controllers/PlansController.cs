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
    public class PlansController : ControllerBase
    {
        public readonly IPlansRepo _empRepository;
        public PlansController(IPlansRepo planRepository)
        {
            _empRepository = planRepository;
        }

        #region Get


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plans>>> GetAll()
        {
            return await _empRepository.GetAllPlans();
        }
        #endregion


        #region Post

        [HttpPost]
        public async Task<IActionResult> AddPlans([FromBody] Plans plan)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var planId = await _empRepository.AddPlan(plan);
                    if (planId > 0)
                    {
                        return Ok(planId);

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
        public async Task<IActionResult> UpdatePlan([FromBody] Plans plan)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _empRepository.UpdatePlan(plan);

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
        public async Task<IActionResult> DeletePlan(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _empRepository.DeletePlan(id);
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

        [HttpGet]
        [Route("GetAllPlans")]
        public async Task<IActionResult> GetAllPlans()
        {
            try
            {
                var plan = await _empRepository.GetAllPlansOfBus();
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

    }
}
