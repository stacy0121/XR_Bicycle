using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fisrt : MonoBehaviour
{
    [SerializeField]
    UnityEvent onStart; //Ʃ�丮�� ù��° ���� �Լ�

    [SerializeField]
    UnityEvent onEnd; //Ʃ�丮�� �ι�° ���� �Լ�


    public void Start_first()
    {
        onStart?.Invoke();
    }
    
    public void onEnd_fisrt()
    {
        onEnd?.Invoke();
    }
}
