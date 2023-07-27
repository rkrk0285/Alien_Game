//using System.Collections;
//using UnityEngine;

//public class ImageController : MonoBehaviour
//{
//	public GameObject firstImage; // ù ��° �̹��� ���� ������Ʈ�� �����ϴ� ����
//	public GameObject secondImage; // �� ��° �̹��� ���� ������Ʈ�� �����ϴ� ����

//	void Start()
//	{
//		firstImage.SetActive(true); // ù ��° �̹����� Ȱ��ȭ�մϴ�.
//		secondImage.SetActive(false); // �� ��° �̹����� ��Ȱ��ȭ�մϴ�.
//		StartCoroutine(SwitchImagesAfterDelay(2f)); // 3�� �Ŀ� �̹����� �����ϴ� �ڷ�ƾ�� �����մϴ�.
//	}

//	IEnumerator SwitchImagesAfterDelay(float delay)
//	{
//		yield return new WaitForSeconds(delay); // ���� �ð��� ���� ������ ��ٸ��ϴ�.
//		firstImage.SetActive(false); // ù ��° �̹����� ��Ȱ��ȭ�մϴ�.
//		secondImage.SetActive(true); // �� ��° �̹����� Ȱ��ȭ�մϴ�.
//	}
//}using System.Collections;
//using System.Collections;
//using UnityEngine;

//public class ImageController : MonoBehaviour
//{
//	public GameObject firstImage;
//	public GameObject secondImage;
//	public GameObject objectToRemove;

//	void Start()
//	{
//		firstImage.SetActive(true);
//		secondImage.SetActive(false);
//		StartCoroutine(SwitchImagesAfterDelay(3f));
//	}

//	IEnumerator SwitchImagesAfterDelay(float delay)
//	{
//		yield return new WaitForSeconds(delay);
//		firstImage.SetActive(false);
//		secondImage.SetActive(true);

//		// ������Ʈ�� ��Ȱ��ȭ�ϰų� �ı��մϴ�.
//		// objectToRemove.SetActive(false); // ������Ʈ�� ��Ȱ��ȭ
//		Destroy(objectToRemove); // ������Ʈ�� �ı�
//	}
//}
using System.Collections;
using UnityEngine;

public class ImageController : MonoBehaviour
{
	public GameObject firstImage;
	public GameObject secondImage;
	public GameObject thirdImage; // �� ��° �̹��� ���� ������Ʈ�� �����ϴ� ����
	public GameObject objectToRemove;

	void Start()
	{
		firstImage.SetActive(true);
		secondImage.SetActive(false);
		thirdImage.SetActive(false); // �� ��° �̹����� ��Ȱ��ȭ�մϴ�.
		StartCoroutine(SwitchImagesAfterDelay(3f));
	}

	IEnumerator SwitchImagesAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		firstImage.SetActive(false);
		secondImage.SetActive(true);
		thirdImage.SetActive(true); // �� ��° �̹����� ���ÿ� �� ��° �̹����� Ȱ��ȭ�մϴ�.
		Destroy(objectToRemove);
	}
}



