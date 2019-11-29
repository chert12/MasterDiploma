using UnityEngine;
using UnityEngine.UI;
using System;
using AAStudio.Diploma.Args;
using AAStudio.Diploma.Enums;
using AAStudio.Diploma.Models;
using System.Collections.Generic;

namespace AAStudio.Diploma.Views
{
	public class MainSceneView : MonoBehaviour
	{

		#region data

		[SerializeField] private Button _menuBtn;
		[SerializeField] private Button _modelsMenuBtn;
		[SerializeField] private NavigationDrawerView _navigationDrawerView;
		[SerializeField] private GameObject _modelsMenu;
		[SerializeField] private HorizontalLayoutGroup _modelsLayout;
		[SerializeField] private Canvas _ui;

		private List<ModelMainSceneElement> _modelsElements;

		#endregion

		#region interface

		public event EventHandler<TypedEventArgs<NavigationDrawerButton>> OnNavigationDrawerButtonClicked;
		public event EventHandler<TypedEventArgs<AssetModel>> OnNewModelSelected;
		public event EventHandler OnModelsMenuButtonClicked;

		public void ToggleModelsView()
		{
			_modelsMenu.SetActive(!_modelsMenu.activeInHierarchy);
		}

		public void InitModelsView(List<AssetModel> models)
		{
			if(null == models)
			{
				Debug.LogWarning("MainSceneView:InitModelsView - Unable to init models lsit. Null data");
				return;
			}

			_modelsElements = new List<ModelMainSceneElement>();

			for(int i = 0; i < _modelsLayout.transform.childCount; i++)
			{
				var child = _modelsLayout.transform.GetChild(i);
				Destroy(child.gameObject);
			}

			foreach(var model in models)
			{
				var newModel = ModelMainSceneElement.Create(_modelsLayout.transform, model);
				newModel.OnSelected += OnModelSelectedBtnClick;
				_modelsElements.Add(newModel);
			}

			if(_modelsElements.Count > 0)
			{
				_modelsElements[0].SetSelected(true);
			}

		}

		private void OnModelSelectedBtnClick(object sender, TypedEventArgs<AssetModel> e)
		{
			OnNewModelSelected?.Invoke(this, e);

			foreach(var m in _modelsElements)
			{
				m.SetSelected(m == sender);
			}

		}

		#endregion

		#region implementation

		private void Start()
		{
			_modelsMenu.SetActive(false);

			_menuBtn.onClick.RemoveAllListeners();
			_menuBtn.onClick.AddListener(_navigationDrawerView.Show);
			_modelsMenuBtn.onClick.RemoveAllListeners();
			_modelsMenuBtn.onClick.AddListener(OnModelsMenuBtn);

			_navigationDrawerView.OnNavigationDrawerButtonClicked += OnNavigationDrawerBtn;
		}

		private void OnNavigationDrawerBtn(object sender, TypedEventArgs<NavigationDrawerButton> args)
		{
			OnNavigationDrawerButtonClicked?.Invoke(sender, args);
		}

		private void OnModelsMenuBtn()
		{
			ToggleModelsView();
			OnModelsMenuButtonClicked?.Invoke(this, EventArgs.Empty);
		}

		private void OnDestroy()
		{
			_navigationDrawerView.OnNavigationDrawerButtonClicked -= OnNavigationDrawerBtn;
		}

		#endregion

		#region properties

		public Canvas Ui => _ui;
		public GameObject ModelsMenu => _modelsMenu;

		#endregion

	}
}
