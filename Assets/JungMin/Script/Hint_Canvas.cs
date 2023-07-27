using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Hint_Canvas : MonoBehaviour
{
    public string next_Scene;
    float time;    

    private void OnEnable()
    {        
        time = 3f;
        StartCoroutine(Start_Timer());
    }

    IEnumerator Start_Timer()
    {
        while (time >= 0.9f)
        {
            time -= Time.deltaTime;
            yield return null;            
        }
        gameObject.SetActive(false);
        Load_Next();
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