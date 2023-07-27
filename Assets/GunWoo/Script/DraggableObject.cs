using UnityEngine;

public class DraggableObject : MonoBehaviour
{
	public GameObject targetImage; // �̹��� ���� ������Ʈ�� �����ϴ� ����
	public Transform targetArea;   // ������Ʈ�� ���ƾ� �ϴ� ����
	public float allowedDistance = 0.5f; // ���Ǵ� ���� �Ÿ�

	private Vector3 offset;
	private Camera mainCamera;
	private bool isDragging = false;
	private bool isOverTarget = false;

	void Start()
	{
		mainCamera = Camera.main;
		targetImage.SetActive(false); // �̹����� �ʱ⿡ ��Ȱ��ȭ
	}

	void Update()
	{
		if (isDragging)
		{
			Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z);
			transform.position = mainCamera.ScreenToWorldPoint(mousePosition) + offset;

			// �巡�� �� ������Ʈ�� ��� ���� ������ �Ÿ� Ȯ��
			float distance = Vector2.Distance(transform.position, targetArea.position);

			// �Ÿ��� ���Ǵ� ���� ���� ���� �ִ� ���
			if (distance <= allowedDistance)
			{
				isOverTarget = true;
			}
			else
			{
				isOverTarget = false;
			}
		}
	}

	void OnMouseDown()
	{
		isDragging = true;
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z);
		offset = transform.position - mainCamera.ScreenToWorldPoint(mousePosition);
	}

	void OnMouseUp()
	{
		isDragging = false;

		// ��� ���� ���� ��ӵ� ���
		if (isOverTarget)
		{
			targetImage.SetActive(true); // �̹����� Ȱ��ȭ
			gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
										 // ������Ʈ ������ ���� �ʿ��� �߰� �۾�
			Quiz2_Manager.instance.setText(2);
		}
		else // ��� ���� ������ ��ӵ� ���
		{
			targetImage.SetActive(false); // �̹����� ��Ȱ��ȭ
		}
	}
}
