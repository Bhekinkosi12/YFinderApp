using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
	public class NewRating
	{
		public string Comment { get; set; }
		public DateTime RatingDate { get; set; }
		public int HotspotId { get; set; }
		public int Public { get; set; } // int as bool
		public int Score { get; set; }
		public float? Speed { get; set; }
		public int UserId { get; set; }
		//public virtual ICollection<RatingDescriptor> RatingDescriptor { get; set; }

		public NewRating()
		{
            RatingDate = DateTime.Now;
            UserId = StaticVariables.activeUser.userId;
		}
	}
}