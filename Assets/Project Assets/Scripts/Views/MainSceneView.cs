using UnityEngine;
using UnityEngine.UI;
using System;
using AAStudio.Diploma.Args;
using AAStudio.Diploma.Enums;

namespace AAStudio.Diploma.Views
{
	public class MainSceneView : MonoBehaviour
	{

		#region data

		[SerializeField] private Button _menuBtn;
		[SerializeField] private NavigationDrawerView _navigationDrawerView;
		[SerializeField] private Canvas _ui;

		#endregion

		#region interface

		public event EventHandler<TypedEventArgs<NavigationDrawerButton>> OnNavigationDrawerButtonClicked;
		#endregion

		#region implementation

		private void Start()
		{
			_menuBtn.onClick.RemoveAllListeners();
			_menuBtn.onClick.AddListener(_navigationDrawerView.Show);

			_navigationDrawerView.OnNavigationDrawerButtonClicked += OnNavigationDrawerBtn;
		}

		private void OnNavigationDrawerBtn(object sender, TypedEventArgs<NavigationDrawerButton> args)
		{
			OnNavigationDrawerButtonClicked?.Invoke(sender, args);
		}

		private void OnDestroy()
		{
			_navigationDrawerView.OnNavigationDrawerButtonClicked -= OnNavigationDrawerBtn;
		}

		#endregion

		#region properties

		public Canvas Ui => _ui;

		#endregion

	}
}
