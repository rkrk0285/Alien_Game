using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class End_Scene : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Sprite[] End_Scene_Set;

    float touchInterval = 0.2f;
    float time = 0;
    // 상속 받아 dialogueManager를 설정해주어야 합니다.
    public bool canClick = true;    
    int Scene_num = 0;
    
    void Update()
    {
        time += Time.deltaTime;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canClick) return;
        if (time < touchInterval) return;

        time = 0;
        next_Scene(Scene_num++);
    }

    void next_Scene(int num)
    {
        if (num < 9)
            this.gameObject.GetComponent<Image>().sprite = End_Scene_Set[num];
        else
            SceneManager.LoadScene("Title");
    }
}

