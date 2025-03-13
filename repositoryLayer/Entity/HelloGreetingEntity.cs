using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace repositoryLayer.Entity
{
    [Table("Greetings")]
    public class HelloGreetingEntity
	{
		[Key]
		public string Key { get; set; }
		[Required]
		public string Value { get; set; }
	}
}

