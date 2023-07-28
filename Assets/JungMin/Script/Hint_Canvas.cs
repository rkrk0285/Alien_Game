using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Hint_Canvas : MonoBehaviour
{
    public string next_Scene;
    float time;    

    private void OnEnable() //힌트 캔버스가 활성화될 때, 코루틴 실행.
    {        
        time = 3f;
        StartCoroutine(Start_Timer());
    }

    IEnumerator Start_Timer() 
    {
        while (time >= 0f) // 3초간 힌트 창을 켜주고
        {
            time -= Time.deltaTime;
            yield return null;            
        }
        gameObject.SetActive(false); // 힌트창 끄고
        Load_Next(); // 다음 퀴즈로
        yield return null;
    }

    void Load_Next()
    {
        switch(next_Scene)
        {
            case "Quiz1":
                Quiz1_Manager.instance.Quiz1_Start();
                break;
            case "Quiz2":
                Quiz2_Manager.instance.Quiz2_Start();
                break;
            case "Quiz3":
                Quiz3_Manager.instance.Quiz3_Start();
                break;
        }
    }
}