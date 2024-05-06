using Contactly.Data;
using Contactly.Models;
using Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactly.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ContactlyDbContext dbContext;

		public ContactsController(ContactlyDbContext dbContext)
        {
			this.dbContext = dbContext;
		}



        [HttpGet]
		public IActionResult  GetAllContacts()
		{
			var contacts = dbContext.Contacts.ToList();
			return Ok(contacts);
		}

		[HttpPost]
		public IActionResult AddContact(AddContactRequestDTO request)
		{
			var contact = new Contact
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Email = request.Email,
				Phone = request.Phone
			};
			dbContext.Contacts.Add(contact);
			dbContext.SaveChanges();
			return StatusCode(StatusCodes.Status201Created);
		}
	}
}
