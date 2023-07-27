using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeLoadingScreen : MonoBehaviour
{
    public float delayTime = 5.0f;
    public string nextSceneName; // ���ο� ������ �߰��Ͻʽÿ�.

    void Start()
    {
        StartCoroutine(DelayedLoad());
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(nextSceneName); // ������ �ڵ�.
    }
}
