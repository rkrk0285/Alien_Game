using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Sand_Object : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 originPos;
    Vector3 mousePos;
    Vector3 objPos;    

    bool isCollision = false;
    bool CanDrag = true;
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
        if (isCollision == true)        
            Quiz2_Manager.instance.Sand_Collide();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 폴더와 충돌했을 경우.
        if (collision.collider.CompareTag("Ground"))
            isCollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isCollision = false;
    }
}
