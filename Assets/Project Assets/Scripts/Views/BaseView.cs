using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class BaseView : MonoBehaviour
	{

		#region data

		[SerializeField] private Button _closeButton;

		#endregion

		#region implementation

		protected virtual void Start()
		{
			if (null != _closeButton)
			{
				_closeButton.onClick.RemoveAllListeners();
                _closeButton.onClick.AddListener(() =>
                {
                    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                    if (!string.IsNullOrEmpty(SceneToSetActive))
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneToSetActive));
                    }
                });
            }
		}

        protected string SceneToSetActive { get; set; }

		#endregion

	}
}
