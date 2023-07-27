using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraZoomAndFade : MonoBehaviour
{
	public float zoomSpeed = 1.0f;
	public float minFOV = 1f;
	public float fadeInSpeed = 0.5f;
	public float fadeOutSpeed = 0.5f;
	public string sceneToLoad = "Title 4";
	public CanvasGroup fadePanelCanvasGroup;
	private Camera cam;
	private bool activateFade = false;

	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void Update()
	{
		if (activateFade)
		{
			StartCoroutine(FadeAndZoom());
		}
	}

	IEnumerator FadeAndZoom()
	{
		activateFade = false;

		// ī�޶� õõ�� Ȯ��˴ϴ�
		while (cam.fieldOfView > minFOV)
		{
			cam.fieldOfView -= zoomSpeed * Time.deltaTime;
			yield return null;
		}

		// Fade in ������ ȭ��
		while (fadePanelCanvasGroup.alpha < 1f)
		{
			fadePanelCanvasGroup.alpha += fadeInSpeed * Time.deltaTime;
			yield return null;
		}

		// �� �ε�
		SceneManager.LoadScene(sceneToLoad);

		// Fade out ������ ȭ��
		while (fadePanelCanvasGroup.alpha > 0f)
		{
			fadePanelCanvasGroup.alpha -= fadeOutSpeed * Time.deltaTime;
			yield return null;
		}
	}

	public void ActivateFade()
	{
		activateFade = true;
	}
}
