using System;
namespace YFinder.Models
{
    public class Hotspot
    {
		public int HotspotId { get; set; }
		public int HostId { get; set; }
		public string Title { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
    }
}