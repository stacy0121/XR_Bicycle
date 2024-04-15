using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialControl : MonoBehaviour
{
    [SerializeField]
    UnityEvent onFirst; //튜토리얼 첫번째 시작 함수

    [SerializeField]
    UnityEvent onFirst_end; //튜토리얼 첫번째 시작 함수

    [SerializeField]
    UnityEvent onSecond; //튜토리얼 두번째 시작 함수

    [SerializeField]
    UnityEvent onSecond_end; //튜토리얼 두번째 시작 함수

    [SerializeField]
    UnityEvent On_second_end_fail;

    [SerializeField]
    UnityEvent onThird; //튜토리얼 세번째 시작 함수

    [SerializeField]
    UnityEvent onThird_end; //튜토리얼 세번째 시작 함수

    [SerializeField]
    UnityEvent onThird_end_fail; //튜토리얼 세번째 시작 함수


    [SerializeField]
    UnityEvent onFourth; //튜토리얼 네번째 시작 함수

    [SerializeField]
    UnityEvent onFourth_end; //튜토리얼 네번째 시작 함수

    [SerializeField]
    UnityEvent onFourth_end_fail; //튜토리얼 네번째 시작 함수



    [SerializeField]
    UnityEvent onFifth; //튜토리얼 다섯번째 시작 함수

    [SerializeField]
    UnityEvent onFifth_end; //튜토리얼 다섯번째 시작 함수


    [SerializeField]
    UnityEvent onFifth_end_fail; //튜토리얼 다섯번째 실패 함수

    [SerializeField]
    UnityEvent onSixth; //튜토리얼 여섯번째 시작함수 


    [SerializeField]
    UnityEvent onSixth_end; //튜토리얼 여섯번째 시작함수 


    [SerializeField]
    UnityEvent onSixth_end_fail; //튜토리얼 여섯번째 시작함수 

    [SerializeField]
    UnityEvent finsih; //튜토리얼 여섯번째 시작함수 

    // Start is called before the first frame update
    void Start()
    {
        onFirst?.Invoke();
    }
    public void first_end()
    {
        onFirst_end?.Invoke();
    }
    // Update is called once per frame

    public void second()
    {
        onSecond?.Invoke();
    }

    public void second_end()
    {
        onSecond_end?.Invoke();
    }

    public void second_end_fail()
    {
        On_second_end_fail?.Invoke();
    }

    public void third()
    {
        onThird?.Invoke();
    }

    public void Third_end_fail()
    {
        onThird_end_fail?.Invoke();
    }

    public void Third_end()
    {
        onThird_end?.Invoke();
    }

    public void fourth()
    {
        onFourth?.Invoke(); 
    }

    public void Fourth_end()
    {
        onFourth_end?.Invoke();
    }
    public void Fourth_end_fail()
    {
        onFourth_end_fail?.Invoke();
    }

    

    public void fifth() 
    {
        onFifth?.Invoke();
    }
    public void Fifth_end()
    {
        onFifth_end?.Invoke();
    }
    public void Fifth_end_fail()
    {
        onFifth_end_fail?.Invoke();
    }

  
    public void sixth() 
    {
        onSixth?.Invoke();
    }
    public void Sixth_end()
    {
        onSixth_end?.Invoke();
    }

    public void Sixth_end_fail()
    {
        onSixth_end_fail?.Invoke();
    }

    public void Onfinsih()
    {
        finsih?.Invoke();
    }

    
}
