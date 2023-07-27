using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public GameObject loadingScreenPrefab;

	// ���� ���� �Ϸ� ����
	public int completionScore = 100;
	private int currentScore = 0;

	void Update()
	{
		// ���� �Ϸ� ���� Ȯ�� (��: ���� ������ �Ϸ� ���� �̻��� ���)
		if (currentScore >= completionScore)
		{
			LevelCompleted();
		}
	}

	public void AddScore(int points)
	{
		// ���� �߰� �޼��� (��: ���� ������ ��ǥ�� �����ϰų� �׸��� ������ �� ���� �߰�)
		currentScore += points;
	}

	public void LevelCompleted()
	{
		StartCoroutine(ShowLoadingScreenAndLoadNextLevel());
	}

	IEnumerator ShowLoadingScreenAndLoadNextLevel()
	{
		// �ε� ȭ�� Prefab�� ȭ�鿡 �߰�
		GameObject loadingScreen = Instantiate(loadingScreenPrefab);
		// �ε� ȭ���� ǥ�õǴ� ���� ��� (�� 5��) ���
		yield return new WaitForSeconds(5f);
		// ���� �� �ε�
		SceneManager.LoadScene(loadingScreen.GetComponent<FakeLoadingScreen>().nextSceneName);
	}
}
