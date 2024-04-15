using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialControl : MonoBehaviour
{
    [SerializeField]
    UnityEvent onFirst; //Ʃ�丮�� ù��° ���� �Լ�

    [SerializeField]
    UnityEvent onFirst_end; //Ʃ�丮�� ù��° ���� �Լ�

    [SerializeField]
    UnityEvent onSecond; //Ʃ�丮�� �ι�° ���� �Լ�

    [SerializeField]
    UnityEvent onSecond_end; //Ʃ�丮�� �ι�° ���� �Լ�

    [SerializeField]
    UnityEvent On_second_end_fail;

    [SerializeField]
    UnityEvent onThird; //Ʃ�丮�� ����° ���� �Լ�

    [SerializeField]
    UnityEvent onThird_end; //Ʃ�丮�� ����° ���� �Լ�

    [SerializeField]
    UnityEvent onThird_end_fail; //Ʃ�丮�� ����° ���� �Լ�


    [SerializeField]
    UnityEvent onFourth; //Ʃ�丮�� �׹�° ���� �Լ�

    [SerializeField]
    UnityEvent onFourth_end; //Ʃ�丮�� �׹�° ���� �Լ�

    [SerializeField]
    UnityEvent onFourth_end_fail; //Ʃ�丮�� �׹�° ���� �Լ�



    [SerializeField]
    UnityEvent onFifth; //Ʃ�丮�� �ټ���° ���� �Լ�

    [SerializeField]
    UnityEvent onFifth_end; //Ʃ�丮�� �ټ���° ���� �Լ�


    [SerializeField]
    UnityEvent onFifth_end_fail; //Ʃ�丮�� �ټ���° ���� �Լ�

    [SerializeField]
    UnityEvent onSixth; //Ʃ�丮�� ������° �����Լ� 


    [SerializeField]
    UnityEvent onSixth_end; //Ʃ�丮�� ������° �����Լ� 


    [SerializeField]
    UnityEvent onSixth_end_fail; //Ʃ�丮�� ������° �����Լ� 

    [SerializeField]
    UnityEvent finsih; //Ʃ�丮�� ������° �����Լ� 

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
