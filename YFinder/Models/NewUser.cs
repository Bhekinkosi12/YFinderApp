using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
	public class NewUser
	{
		public object bio { get; set; }
		public string email { get; set; }
		public string fullName { get; set; }
		public int host { get; set; }
		public string userName { get; set; }
		public string zip { get; set; }
		public object favorite { get; set; }
		//public virtual ICollection<Favorite> Favorite { get; set ; }

		public NewUser()
		{
			host = 0;
		}
	}
}