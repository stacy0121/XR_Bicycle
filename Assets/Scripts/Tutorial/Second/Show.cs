using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public GameObject button; // ���̵��� ������ ������Ʈ

    public void ShowTargetObject()
    {
        button.SetActive(true); // ������Ʈ�� ���̵��� ����
    }
}
