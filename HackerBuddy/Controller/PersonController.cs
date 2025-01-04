using System;
using HackerBuddy.Sql.Interface;
using HackerBuddy.Sql.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerBuddy.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            var createdPerson = await _personService.CreateAsync(person);
            return CreatedAtAction(nameof(GetById), new { id = createdPerson.PersonID }, createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Person person)
        {
            var updatedPerson = await _personService.UpdateAsync(id, person);
            if (updatedPerson == null) return NotFound();

            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _personService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
