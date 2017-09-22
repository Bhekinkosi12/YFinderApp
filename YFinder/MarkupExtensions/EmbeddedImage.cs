using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YFinder.MarkupExtensions
{
	[ContentProperty("ResourceId")]
	public class EmbeddedImage : IMarkupExtension
	{

		public string ResourceId { get; set; }
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return ImageSource.FromResource("YFinder.iOS.Resources.letterY.png");
		}
	}
}
