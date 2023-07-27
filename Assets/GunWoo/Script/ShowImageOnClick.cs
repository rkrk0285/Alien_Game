using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnClick : MonoBehaviour
{
	public Button button; // ��ư�� ������ �����Դϴ�.
	public GameObject image; // �̹��� ���� ������Ʈ�� ������ �����Դϴ�.

	void Start()
	{
		button.onClick.AddListener(ShowImage);
	}

	void ShowImage()
	{
		image.SetActive(true); // �̹����� Ȱ��ȭ�մϴ�.
	}
}

