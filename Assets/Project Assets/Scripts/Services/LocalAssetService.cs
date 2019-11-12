using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AAStudio.Diploma.Args;
using AAStudio.Diploma.Models;
using AAStudio.Diploma.ScriptableObjects;
using AAStudio.Diploma.Services.Interfaces;

namespace AAStudio.Diploma.Services
{
	public class LocalAssetService : IAssetService
	{
		private AssetModelsData _data;
		public LocalAssetService(AssetModelsData data)
		{
			_data = data;
		}

		public async Task<TypedEventArgs<List<AssetModel>>> GetAssetModels()
		{
			var res = new List<AssetModel>();
			Exception error = null;
			if (_data == null)
			{
				error = new Exception("Null data");
			}
			else
			{
				foreach (var m in _data.Models)
				{
					res.Add(m.ToAssetModel());
				}
			}

			return new TypedEventArgs<List<AssetModel>>(res, error, false);
		}
	}
}
