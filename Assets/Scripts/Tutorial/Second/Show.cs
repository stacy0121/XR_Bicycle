using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public GameObject button; // 보이도록 설정할 오브젝트

    public void ShowTargetObject()
    {
        button.SetActive(true); // 오브젝트를 보이도록 설정
    }
}
