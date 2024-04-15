using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fisrt : MonoBehaviour
{
    [SerializeField]
    UnityEvent onStart; //튜토리얼 첫번째 시작 함수

    [SerializeField]
    UnityEvent onEnd; //튜토리얼 두번째 시작 함수


    public void Start_first()
    {
        onStart?.Invoke();
    }
    
    public void onEnd_fisrt()
    {
        onEnd?.Invoke();
    }
}
