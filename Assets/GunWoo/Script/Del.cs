using System.Collections;
using UnityEngine;

public class Del : MonoBehaviour
{
	// �� ��° �̹��� ���� ������Ʈ�� �����ϴ� ����
	public GameObject objectToRemove;

	void Start()
	{
		Destroy(objectToRemove);
	}
}

