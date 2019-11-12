using System;

namespace AAStudio.Diploma.Models
{
	[Serializable]
	public class AssetModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Credentials { get; set; }
		public string PreviewImagePath { get; set; }
		public string ModelPath { get; set; }
	}
}
