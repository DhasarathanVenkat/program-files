using System.ComponentModel.DataAnnotations;

namespace CRUD_TASK.Models
{
	public class Home
	{
		[Key]

		public int Id { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name Should contain only alphabets")]

		public string? Name { get; set; }
		[Required]
		public string? Gender { get; set; }
		[Required]

		public string? DOB { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]


		public long Mobile { get; set; }
		[Required]
		public String? Department { get; set; }
	}

}
