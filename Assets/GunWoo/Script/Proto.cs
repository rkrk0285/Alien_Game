using UnityEngine;

public class Proto : MonoBehaviour
{
	public GameObject targetImage;
	public Transform targetArea;
	public GameObject otherObject; // �ٸ� ������Ʈ�� �����ϴ� ����
	public float allowedDistance = 0.5f;

	private Vector3 offset;
	private Camera mainCamera;
	private bool isDragging = false;
	private bool isOverTarget = false;

	void Start()
	{
		mainCamera = Camera.main;
		targetImage.SetActive(false);
	}

	void Update()
	{
		if (isDragging)
		{
			Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z);
			transform.position = mainCamera.ScreenToWorldPoint(mousePosition) + offset;
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

		if (isOverTarget)
		{
			targetImage.SetActive(true);
			gameObject.SetActive(false);
			otherObject.SetActive(false); // �ٸ� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
		}
		else
		{
			targetImage.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		float distance = Vector2.Distance(transform.position, targetArea.position);

		if (distance <= allowedDistance)
		{
			isOverTarget = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		float distance = Vector2.Distance(transform.position, targetArea.position);

		if (distance > allowedDistance)
		{
			isOverTarget = false;
		}
	}
}
