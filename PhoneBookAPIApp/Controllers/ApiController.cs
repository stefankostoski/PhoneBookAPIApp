using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAPIApp.Models;

namespace PhoneBookAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        //CREATE NE CONTACT
        [HttpPost("Add")]
        public IActionResult Create([FromQuery] Guid key, Contact contact)
        {
            if (key == StaticDb.key)
            {
                if (contact != null)
                {
                    StaticDb.Contacts.Add(contact);
                    return Ok("The contact has been created");

                }
                return NotFound("There are not contacts in the phonebook");
            }

            return BadRequest("You don't have access!");
        }

        //GET ALL CONTACTS
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] Guid key)
        {
            if (key == StaticDb.key)
            {
                var response = StaticDb.Contacts;
                if (response.Count < 1)
                {
                    return NotFound("There are no contacts in the Phone Book");
                }
                return Ok(response);
            }
            return BadRequest("You don't have access!");
        }

        //GET CONTACT BY ID
        [HttpGet("GetContact/{id}")]
        public IActionResult GetContactById([FromQuery] Guid key, int id)
        {
            if (key == StaticDb.key)
            {
                var contact = StaticDb.Contacts.FirstOrDefault(a => a.Id == id);

                if (contact == null)
                {
                    return NotFound($"User with id: {id} want not found in the phone book");
                }

                return Ok(contact);
            }
            return BadRequest("You don't have access!");
        }

        //DELETE CONTACT
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteContact([FromQuery] Guid key, int id)
        {
            if (key == StaticDb.key)
            {
                var contact = StaticDb.Contacts.FirstOrDefault(a => a.Id == id);

                if (contact == null)
                {
                    return NotFound($"Contact with Id: {id} was not found in the phone book");
                }

                StaticDb.Contacts.Remove(contact);
                return Ok("The contact was sucesfully deleted from the phone book");
            }
            return BadRequest("You don't have access!");
        }

        //UPDATE CONTACT
        [HttpPut("Update")]
        public IActionResult UpdateContact([FromQuery] Guid key, [FromBody] Contact updateContact)
        {
            if (key == StaticDb.key)
            {
                var oldContact = StaticDb.Contacts.FirstOrDefault(a => a.Id == updateContact.Id);

                if (oldContact != null)
                {
                    oldContact.FullName = updateContact.FullName;
                    oldContact.PhoneNumber = updateContact.PhoneNumber;
                    oldContact.HasViber = updateContact.HasViber;
                    return Ok("Contact has been sucesfully updated!");
                };

                return NotFound("Contact was not found in the phone book.");
            }
            return BadRequest("You don't have access!");
        }

        //FILTER BY FULLNAME
        [HttpGet("FilterByFullName")]
        public IActionResult FilterByFullName([FromQuery] Guid key, string query)
        {
            if (key == StaticDb.key)
            {

                var response = StaticDb.Contacts.FindAll(a => a.FullName.Contains(query) || a.FullName.ToLower().Contains(query));

                if (response == null)
                {
                    return NotFound("Sorry, but nothing matched your search terms. Please try again with some different keywords.");
                }

                return Ok(response);
            }

            return BadRequest("You don't have access!");
        }

        //FILTER BY FULLNAME
        [HttpGet("FilterByViber")]
        public IActionResult FilterByViber([FromQuery] Guid key)
        {
            if (key == StaticDb.key)
            {
                var response = StaticDb.Contacts.FindAll(a => a.HasViber == true);

                if (response == null)
                {
                    return NotFound("There are no contacts with Viber.");
                }

                return Ok(response);
            }
            return BadRequest("You don't have access!");
        }

        //GENERATE GUID
        [HttpGet("GenerateKey")]
        public IActionResult GenerateKey()
        {
            return Ok(StaticDb.key);
        }
    }
}
