using System.Collections;
using System.Collections.Generic;
using AAStudio.Diploma.ScriptableObjects;
using AAStudio.Diploma.Services;
using AAStudio.Diploma.Services.Interfaces;
using UnityEngine;

public class Test : MonoBehaviour
{
	private IAssetService _assetService;

	[SerializeField] private AssetModelsData _modelDatas;

	[SerializeField] private PlaceOnPlane _placer;
    // Start is called before the first frame update
    void Start()
    {
        _assetService = new LocalAssetService(_modelDatas);

        var model = Resources.Load<GameObject>(_assetService.GetAssetModels().Result.Data[0].ModelPath);
        if (null != model)
        {
	        _placer.placedPrefab = model;
        }
        else
        {
	        Debug.LogWarning("Null asset model");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
