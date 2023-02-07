using KeyPathAPI.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using KeyPathAPI.OutputModels;
using Microsoft.EntityFrameworkCore;

namespace KeyPathAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }      

        [HttpGet]
        [ActionName("GetRecords")]
        public async Task<IActionResult> FetchRecords(string stringToMatch, int searchCriteria = 1)
        {            
            List<PersonModel> filteredPersons = new List<PersonModel>();

            try
            {
                if (!string.IsNullOrEmpty(stringToMatch))
                {
                    switch (searchCriteria)
                    {
                        case 1:
                        default:
                            filteredPersons = await _context.Person
                                                            .Where(x => x.FullName.ToLower()
                                                            .Contains(stringToMatch.ToLower())).ToListAsync();
                            break;
                        case 2:
                            filteredPersons = await _context.Person
                                                            .Where(x => x.FullName.ToLower()
                                                            .Equals(stringToMatch.ToLower())).ToListAsync();
                            break;
                    }
                }
                else
                {
                    filteredPersons = await _context.Person
                                                    .OrderBy(x => x.ModifiedOnUtc)                       
                                                    .Take(100).ToListAsync();
                }

                return Ok(filteredPersons);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                // Since we are not implementing a logger or a Errorhandling Middleware
                // Returning error message from exception directly                
                return BadRequest(errorMessage);
            }
        }

        // Accept data in query string format
        [HttpPost]
        [ActionName("CreatePerson")]
        public async Task<IActionResult> CreatePersonFromString([FromQuery] string fullName, int age = 0)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new NullReferenceException("Request did not have the mandatory Query parameter : firstName");
            }

            try
            {
                var person = new PersonModel()
                {
                    FullName = fullName,
                    Age = age,
                    CreatedOnUtc = DateTime.UtcNow,
                    ModifiedOnUtc = DateTime.UtcNow
                };

                _context.Person.Add(person);
                await _context.SaveChangesAsync();
                return Ok(person);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                // Since we are not implementing a logger or a Errorhandling Middleware
                // Returning error message from exception directly                
                return BadRequest(errorMessage);
            }

        }

        // Accept data in form-data format
        [HttpPost]
        [ActionName("CreatePerson")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreatePersonFromForm([FromForm] PersonOutputModel data)
        {
            try
            {
                if (data != null)
                {
                    var personEntity = new PersonModel()
                    {
                        FullName = data.FullName,
                        Age = data.Age,
                        CreatedOnUtc = DateTime.UtcNow,
                        ModifiedOnUtc = DateTime.UtcNow
                    };

                    _context.Person.Add(personEntity);
                    await _context.SaveChangesAsync();
                    return Ok(personEntity);
                }
                else
                {
                    throw new NullReferenceException("Provided Inputs were null");
                }

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                // Since we are not implementing a logger or a Errorhandling Middleware
                // Returning error message from exception directly                
                return BadRequest(errorMessage);
            }

        }

        // Accept data in JSON format
        [HttpPost]
        [ActionName("CreatePerson")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreatePersonFromJson([FromBody] PersonOutputModel data)
        {
            try
            {
                // Additional net for null handling even though .Net Core handles it
                // during request processing
                if (data != null)
                {
                    PersonModel personEntity = new PersonModel()
                    {
                        FullName = data.FullName,
                        Age = data.Age,
                        CreatedOnUtc = DateTime.UtcNow,
                        ModifiedOnUtc = DateTime.UtcNow
                    };
                    _context.Person.Add(personEntity);
                    await _context.SaveChangesAsync();
                    return Ok(personEntity);
                }
                else
                {
                    throw new NullReferenceException("Provided Inputs were null");
                }

            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                // Since we are not implementing a logger or a Errorhandling Middleware
                // Returning error message from exception directly                
                return BadRequest(errorMessage);
            }

        }

    }
}
