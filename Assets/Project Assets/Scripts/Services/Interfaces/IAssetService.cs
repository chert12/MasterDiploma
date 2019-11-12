using System.Collections.Generic;
using System.Threading.Tasks;
using AAStudio.Diploma.Args;
using AAStudio.Diploma.Models;

namespace AAStudio.Diploma.Services.Interfaces
{
	public interface IAssetService
	{
		Task<TypedEventArgs<List<AssetModel>>> GetAssetModels();
	}
}
