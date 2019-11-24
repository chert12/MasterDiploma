using AAStudio.Diploma.Services;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class PopUp : MonoBehaviour
	{

		#region data

		[SerializeField] private Text _titleTxt;
		[SerializeField] private Text _messageTxt;
		[SerializeField] private Text _okButtonTxt;
		[SerializeField] private Text _cancelButtonTxt;
		[SerializeField] private Button _okButton;
		[SerializeField] private Button _cancelButton;

		#endregion

		#region interface

		public event EventHandler OnSubmitBtnClicked;
		public event EventHandler OnCancelBtnClicked;

		public static PopUp Create(Transform parent, string title, string message, bool isCancelButton = false, 
			string submitBtnTxt = AppConstants.Strings.OkTxt, string cancelBtnTxt = AppConstants.Strings.CancelTxt)
		{
			if (parent == null)
			{
				Debug.LogError("Popup:Create - Unable to create Popup: null parent");
				return null;
			}


			var prefabPath = Path.Combine(AppConstants.FileNames.PrefabsFolderName,
				AppConstants.FileNames.PopupPrefabName);
			var prefab = Resources.Load<PopUp>(prefabPath);
			if (prefab == null)
			{
				Debug.LogError($"Popup:Create - Unable to load popup prefab from {prefabPath}");
				return null;
			}

			PopUp res = GameObject.Instantiate(prefab, parent.transform);
			res.Init(title, message, isCancelButton, submitBtnTxt, cancelBtnTxt);
			return res;
		}

		public void Hide()
		{
			GameObject.Destroy(this.gameObject);
		}

		#endregion

		#region implementation

		private void Start()
		{
			_okButton.onClick.RemoveAllListeners();
			_okButton.onClick.AddListener(OnSubmitBtnCLick);

			_cancelButton.onClick.RemoveAllListeners();
			_cancelButton.onClick.AddListener(OnCancelBtnCLick);
		}

		private void OnSubmitBtnCLick()
		{
			OnSubmitBtnClicked?.Invoke(this, EventArgs.Empty);
			Hide();
		}

		private void OnCancelBtnCLick()
		{
			OnCancelBtnClicked?.Invoke(this, EventArgs.Empty);
			Hide();
		}

		private void Init(string title,
			string description,
			bool isCancelButton,
			string submitButtonText,
			string cancelButtonText)
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("Null popup title");
				_titleTxt.text = string.Empty;
			}
			else
			{
				_titleTxt.text = title;
			}

			if (string.IsNullOrEmpty(description))
			{
				Debug.LogWarning("Null popup description");
				_messageTxt.text = string.Empty;
			}
			else
			{
				_messageTxt.text = description;
			}

			_okButtonTxt.text = submitButtonText;
			_cancelButtonTxt.text = cancelButtonText;

			_cancelButton.gameObject.SetActive(isCancelButton);
		}


		#endregion

	}
}
