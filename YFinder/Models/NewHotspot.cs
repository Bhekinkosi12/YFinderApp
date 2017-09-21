using System;
namespace YFinder.Models
{
    public class NewHotspot
    {
		public int HostId { get; set; }
		public string Title { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public NewHotspot()
		{
			HostId = 99; // temp for testing
		}
    }
}