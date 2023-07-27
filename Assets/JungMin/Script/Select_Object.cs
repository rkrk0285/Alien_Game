using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Select_Object : MonoBehaviour
{    
    public string action;
    int idx;    
    
    // �������� �� �ؽ�Ʈ�� �����ϰ� OnclickListener�� �߰��մϴ�.
    public void SetText(Dialogue dialogue, int i)
    {        
        action = dialogue.action;
        idx = i;

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogue.text;
        transform.GetComponent<Button>().onClick.AddListener(OnClickButton);
    }

    // �������� ������, �� ������ �ؽ�Ʈ �ڿ� �Էµ� action���� ���̾�α� ���� ����.
    public void OnClickButton()
    {                
        Dialogue_Manager.instance.Select_Box(idx);        
    }    
}
