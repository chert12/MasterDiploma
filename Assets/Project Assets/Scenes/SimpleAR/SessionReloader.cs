using System.Collections;
using AAStudio.Diploma.Views;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Reloads the ARSession by first destroying the ARSession's GameObject
/// and then instantiating a new ARSession from a Prefab.
/// </summary>
public class SessionReloader : MonoBehaviour
{
    public ARSession session;
    public GameObject sessionPrefab;
    public Button pauseButton;
    public Button resumeButton;
    public Button resetButton;
    public PlaceOnPlane placer;

    public void ReloadSession()
    {
        if (session != null)
        {
            StartCoroutine(DoReload());
        }
    }

    IEnumerator DoReload()
    {
        session.Reset();
        Destroy(session.gameObject);
        yield return null;

        if (sessionPrefab != null)
        {
            session = Instantiate(sessionPrefab).GetComponent<ARSession>();
            Debug.LogWarning("Sesion reloaded");
            session.Reset();
            if (null != placer && null != placer.spawnedObjects)
            {
                foreach (var obj in placer.spawnedObjects)
                {
                    GameObject.Destroy(obj.gameObject);
                }
            }
            // Hook the buttons back up
            pauseButton.onClick.AddListener(() => { session.enabled = false; });
            resumeButton.onClick.AddListener(() => { session.enabled = true; });
        }

    }
}
