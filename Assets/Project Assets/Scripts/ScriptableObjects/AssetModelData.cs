using AAStudio.Diploma.Models;
using UnityEngine;

namespace AAStudio.Diploma.ScriptableObjects
{
	[CreateAssetMenu(fileName = "AssetModelData", menuName = "Asset Model Data", order = 51)]
	public class AssetModelData : ScriptableObject
	{
		[SerializeField] private string _name;
		[SerializeField] private string _description;
		[SerializeField] private string _credentials;
		[SerializeField] private string _previewImagePath;
		[SerializeField] private string _modelPath;

		public AssetModel ToAssetModel()
		{
			return new AssetModel
			{
				Name = _name,
				Description = _description,
				Credentials = _credentials,
				PreviewImagePath = _previewImagePath,
				ModelPath = _modelPath
			};
		}
	}
}
