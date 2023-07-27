using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quiz3_Manager : MonoBehaviour
{
    public static Quiz3_Manager instance = null;

    [SerializeField]
    GameObject WholeQuiz_Field;
    [SerializeField]
    GameObject Maple_Object;
    [SerializeField]
    GameObject Camera_Shutter;
    [SerializeField]
    GameObject Folder;
    [SerializeField]
    GameObject Synchronized_Object;
    [SerializeField]
    GameObject Locked_Folder;
    [SerializeField]
    GameObject Circuit_Canvas;
    [SerializeField]
    TextMeshProUGUI upper_Text;
    [SerializeField]
    GameObject Maple_Leaf;
    
    [Space]
    [Header("���� ó����")]
    [SerializeField]
    GameObject Quiz_Canvas;
    [SerializeField]
    GameObject Higher_Canvas;
    [SerializeField]
    GameObject Maple_Machine;
    [SerializeField]
    GameObject Maple_Button;
    [SerializeField]
    GameObject End_Scene;
    [Space]
    [Header("��ġ ó����")]
    [SerializeField]
    GameObject Touch_Canvas;
    [SerializeField]
    GameObject Maple_Ending_Text;
    float Camera_Time = 0f;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
        SetText(1);
    }

    private void Start()
    {
        Dialogue_Manager.instance.Start_Dialogue("Chapter3");        
    }
    public void Quiz3_Start()
    {
        // ���� 3 ��ŸƮ �Լ�.
        WholeQuiz_Field.SetActive(true);
    }
    public void active_Maple_Canvas(bool toggle)
    {
        Maple_Object.SetActive(toggle);
    }    
    public void Start_Camera_Effect()
    {        
        StartCoroutine(Camera_Effect());
        Maple_Object.transform.GetChild(1).gameObject.SetActive(true);
    }
    IEnumerator Camera_Effect()
    {        
        while(Camera_Time < 0.25f)
        {
            yield return null;
            Camera_Time += Time.deltaTime;

            if(Camera_Time < 0.15f)
                Camera_Shutter.SetActive(true);
            else
                Camera_Shutter.SetActive(false);
        }
        active_Maple_Canvas(false);
        Start_Synchronize();        
        yield return null;
    }

    public void Start_Synchronize()
    {
        SetText(2);
        Synchronized_Object.SetActive(true);
        Synchronized_Object.GetComponent<Animator>().enabled = true;
    }
    public void Synchronize_End()
    {
        Folder.SetActive(false);
        Synchronized_Object.SetActive(false);

        Locked_Folder.SetActive(true);
        SetText(3);
    }
    public void active_Locked_Folder()
    {
        Circuit_Canvas.SetActive(true);
        SetText(4);
    }

    // ȸ�� ���� �����Ƽ� ���⼭ ���� ó����.
    string letter = "";
    public void Active_Circuit_Button()
    {
        for(int i = 0; i < Circuit_Canvas.transform.GetChild(0).transform.childCount; i++)      
            Circuit_Canvas.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(true);
        Circuit_Canvas.transform.GetChild(1).gameObject.SetActive(true);
        Circuit_Canvas.transform.GetChild(2).gameObject.SetActive(true);
        SetText(5);
    }
    public void input_Letter(string s)
    {
        letter += s;
        check_Letter();
    }

    void check_Letter()
    {
        Debug.Log(letter);
        if(letter == "LASTLEAF")        
        {
            // Ŭ����ó��
            Debug.Log("Ŭ����");
            SetText(6);
            // ������Ʈ �� �����, ��ǳ�� ������ ����.
            Clear_Chapter3();
        }
        else if (letter == "L" || letter == "LA" || letter == "LAS" || letter == "LAST" 
                || letter == "LASTL" || letter == "LASTLE" || letter == "LASTLEA" || letter == "LASTLEAF")
        {
            // ���� ���ɼ��� ������ �ʱ�ȭ �н�.
            return;
        }
        // ���� �ش���� ������ �ʱ�ȭ.
        else        
            letter = "";        
    }

    void Clear_Chapter3()
    {
        // ���� ĵ���� ���� �� ����
        // ���̾� ��Ŷ�� �Ѵ� �׳� ��.
        for(int i = 0; i < Quiz_Canvas.transform.childCount; i++)       
            Quiz_Canvas.transform.GetChild(i).gameObject.SetActive(false);
        Higher_Canvas.SetActive(false);
        Circuit_Canvas.SetActive(false);

        // ������ �����ϴ� ��ǳ�� ǥ��
        Maple_Leaf.GetComponent<Animator>().enabled = true;
    }

    public void Active_Maple_Machine(bool toggle)
    {
        Maple_Machine.SetActive(toggle);
    }    
    public void Active_Touch_Canvas(bool toggle)
    {
        Touch_Canvas.SetActive(toggle);
    }
    public void Maple_Ending(int num)
    {
        Maple_Ending_Text.SetActive(true);
        switch (num)
        {
            case 0:
                Maple_Ending_Text.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                Maple_Ending_Text.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                Maple_Ending_Text.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                Maple_Ending_Text.SetActive(false);
                Maple_Leaf.SetActive(false);
                Maple_Machine.SetActive(false);
                Maple_Button.SetActive(true);
                break;
        }
    }
    public void End_Scene_On()
    {
        Quiz_Canvas.SetActive(false);
        End_Scene.SetActive(true);
    }
    void SetText(int num)
    {
        switch (num)
        {
            case 1:
                upper_Text.text = "����ؼ� ���� �� ���� �鿩�ٺ�����.";
                break;
            case 2:
                upper_Text.text = "����ȭ ��Ű����.";
                break;
            case 3:
                upper_Text.text = "������ ������ ����� �����ϼ���.";
                break;
            case 4:
                upper_Text.text = "�߾ӿ� ������ ���߼���";
                break;
            case 5:
                upper_Text.text = "ȸ�� �� ������ �ڵ带 �ϼ��ϼ���.";
                break;
            case 6:
                upper_Text.text = "������ ���� ��� ���� �� 3�ܰ� �Ϸ�.";
                break;
            case 7:
                upper_Text.text = "��ο��� �����ϼ���.\n\n\"CODE NAME: LAST LEAF\"";
                break;
            case 8:
                upper_Text.text = "\"CODE NAME: LAST LEAF\"\n\n������ ������ ���߸� ��� �۵��� �����˴ϴ�.";
                break;
            case 9:
                upper_Text.gameObject.SetActive(false);
                break;
        }
    }
}
