
using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class AboutView : BaseView
	{
		private enum ButtonAction
		{
			OpenSite,
			OpenEmail
		}

		#region data

		[SerializeField] private Button _nureSiteBtn;
		[SerializeField] private Button _apotSiteBtn;
		[SerializeField] private Button _email1Btn;
		[SerializeField] private Button _email2Btn;

		#endregion

		#region implementation

		private void Start()
		{
			BindButton(_nureSiteBtn, "https://nure.ua", ButtonAction.OpenSite);
			BindButton(_apotSiteBtn, "http://ad.nure.ua", ButtonAction.OpenSite);
			BindButton(_email1Btn, "oleksii.chernov@nure.ua", ButtonAction.OpenEmail);
			BindButton(_email2Btn, "aastudio15@gmail.com", ButtonAction.OpenEmail);
		}

		private void BindButton(Button btn, string data, ButtonAction action)
		{
			btn.onClick.RemoveAllListeners();

			var url = action == ButtonAction.OpenSite ? data : "mailto:" + data;

			btn.onClick.AddListener(() =>
			{
				Application.OpenURL(url);
			});

		}

		#endregion
	}
}
