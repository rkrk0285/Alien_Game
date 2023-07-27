using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synchronize_Object : MonoBehaviour
{
    private GameObject Synchronize;
    private Animator Synchronize_Animator;

    private void Awake()
    {
        Synchronize = this.gameObject;
        Synchronize_Animator = this.gameObject.GetComponent<Animator>();
    }

    public void Stop_Anima()
    {
        Synchronize_Animator.enabled = false;

        // ��3 �Ŵ������� ����ȭ ��ư ����, �ڽ� 3�� ������ ��� �ڽ� ��
        Quiz3_Manager.instance.Synchronize_End();
    }
}