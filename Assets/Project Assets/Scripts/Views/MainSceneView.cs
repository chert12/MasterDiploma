using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class MainSceneView : MonoBehaviour
	{

		#region data

		[SerializeField] private Button _menuBtn;
		[SerializeField] private NavigationDrawerView _navigationDrawerView;

		#endregion

		#region implementation

		private void Start()
		{
			_menuBtn.onClick.RemoveAllListeners();
			_menuBtn.onClick.AddListener(_navigationDrawerView.Show);
		}

		#endregion

	}
}
