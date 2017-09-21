using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
	public class Rating
	{
		public int RatingId { get; set; }
		public string Comment { get; set; }
		public DateTime RatingDate { get; set; }
		public int HotspotId { get; set; }
		public Hotspot Hotspot { get; set; }
		public int Public { get; set; } // int as bool
		public int Score { get; set; }
		public float? Speed { get; set; }
		public int UserId { get; set; }
		//public virtual ICollection<RatingDescriptor> RatingDescriptor { get; set; }
	}
}