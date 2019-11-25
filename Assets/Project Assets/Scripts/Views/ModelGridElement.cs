using AAStudio.Diploma.Args;
using AAStudio.Diploma.Models;
using AAStudio.Diploma.Services;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class ModelGridElement : MonoBehaviour
	{

		#region data

		[SerializeField] private Text _modelName;
		[SerializeField] private Image _modelImage;
		[SerializeField] private Button _modelInfoButton;
		private AssetModel _data;

		#endregion

		#region interface

		public event EventHandler<TypedEventArgs<AssetModel>> OnInfoBtnClicked;

		public static ModelGridElement Create(Transform parent, AssetModel data)
		{
			if (parent == null)
			{
				Debug.LogError("ModelGridElement:Create - Unable to create ModelGridElement: null parent");
				return null;
			}

			if(data == null)
			{
				Debug.LogError("ModelGridElement:Create - Unable to create ModelGridElement: null AssetModel");
				return null;
			}

			var prefabPath = Path.Combine(AppConstants.FileNames.PrefabsFolderName,
				AppConstants.FileNames.ModelGridElementPrefabName);
			var prefab = Resources.Load<ModelGridElement>(prefabPath);
			if (prefab == null)
			{
				Debug.LogError($"ModelGridElement:Create - Unable to load ModelGridElement prefab from {prefabPath}");
				return null;
			}

			ModelGridElement res = GameObject.Instantiate(prefab, parent.transform);
			res._data = data;
			return res;
		}

		#endregion

		#region implementation

		private void Start()
		{
			_modelName.text = _data.Name;

			_modelInfoButton.onClick.RemoveAllListeners();
			_modelInfoButton.onClick.AddListener(OnInfoBtnClick);

			var img = Resources.Load<Sprite>(_data.PreviewImagePath);
	
			if(img == null)
			{
				Debug.LogWarning($"ModelGridElement:Start - Unable to load image from {_data.PreviewImagePath}");
			}
			else
			{
				_modelImage.sprite = img;
				_modelImage.preserveAspect = true;
			}

		}

		private void OnDestroy()
		{
			_modelInfoButton.onClick.RemoveListener(OnInfoBtnClick);
		}

		private void OnInfoBtnClick()
		{
			OnInfoBtnClicked?.Invoke(this, new TypedEventArgs<AssetModel>(_data));
		}

		#endregion

	}
}
