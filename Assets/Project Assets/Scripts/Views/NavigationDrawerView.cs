using System;
using AAStudio.Diploma.Args;
using AAStudio.Diploma.Enums;
using AAStudio.Diploma.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavigationDrawerView : MonoBehaviour
{
	#region data

	[SerializeField] private Button _closeNavigationDrawerBtn;
	[SerializeField] private Button _allModelsBtn;
	[SerializeField] private Button _myModelsBtn;
	[SerializeField] private Button _myClassesBtn;
	[SerializeField] private Button _settingsBtn;
	[SerializeField] private Button _aboutBtn;
	[SerializeField] private Animator _animator;

	#endregion

	#region interface

	public event EventHandler<TypedEventArgs<NavigationDrawerButton>> OnNavigationDrawerButtonClicked;

	public void Show()
	{
		_animator.SetBool(AppConstants.AnimationNames.Show, true);
	}

	public void Hide()
	{
		_animator.SetBool(AppConstants.AnimationNames.Hide, true);
	}

	#endregion

	#region implementation

	private void Start()
	{
		BindButton(_allModelsBtn, NavigationDrawerButton.AllModels);
		BindButton(_myModelsBtn, NavigationDrawerButton.MyModels);
		BindButton(_myClassesBtn, NavigationDrawerButton.MyClasses);
		BindButton(_settingsBtn, NavigationDrawerButton.Settings);
		BindButton(_aboutBtn, NavigationDrawerButton.About);

		_closeNavigationDrawerBtn.onClick.RemoveAllListeners();
		_closeNavigationDrawerBtn.onClick.AddListener(Hide);
	}

	private void BindButton(Button btn, NavigationDrawerButton type)
	{
		btn.onClick.RemoveAllListeners();
		btn.onClick.AddListener(() =>
		{
			OnNavigationDrawerButtonClicked?.Invoke(this, new TypedEventArgs<NavigationDrawerButton>(type));
		});
	}

	#endregion
}
