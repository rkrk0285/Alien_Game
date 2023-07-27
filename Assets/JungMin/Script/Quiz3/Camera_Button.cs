using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Camera_Button : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 originPos;
    Vector3 mousePos;
    Vector3 objPos;

    bool isCollision = false;
    bool isClear = false;
    bool isCircuitCollision = false;
    bool isCircuitClear = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        isCollision = false;
        originPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        objPos = Camera.main.ScreenToWorldPoint(mousePos);
        objPos.z = originPos.z;
        transform.position = objPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCollision == true && isClear == false)
        {
            isClear = true;
            // �߾ӿ� ī�޶� ���� ��, ī�޶� �ִϸ��̼� ����Ʈ ���
            Quiz3_Manager.instance.Start_Camera_Effect();
        }
        if (isCircuitCollision == true && isCircuitClear == false)
        {
            isCircuitClear = true;
            // ��ư Ȱ��ȭ
            Quiz3_Manager.instance.Active_Circuit_Button();
        }
        transform.position = originPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ������ �浹���� ���.
        if (collision.collider.CompareTag("Maple"))
            isCollision = true;
        if (collision.collider.CompareTag("Circuit"))
            isCircuitCollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Maple"))
            isCollision = false;
        if (collision.collider.CompareTag("Circuit"))
            isCircuitCollision = false;
    }
}