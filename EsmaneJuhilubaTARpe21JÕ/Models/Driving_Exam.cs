using System.ComponentModel.DataAnnotations;

namespace EsmaneJuhilubaTARpe21JÕ.Models
{
	public class Driving_Exam
	{
		public int Id { get; set; }

		[StringLength(64)]
		[Required]
		public string Firstname { get; set; }

		[StringLength(64)]
		[Required]
		public string Lastname { get; set; }

        [Range(16, 100)]
        [Required]
		public int? Age { get; set; }

        [Range(-1, 10)]
		public int? Driving_School { get; set; } = -1;
		public int? Theory_Exam { get; set; } = -1;
		public int? Driving_Test { get; set; } = -1;
		public int? License { get; set; } = -1;
	}
}
