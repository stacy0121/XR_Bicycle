using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_control : MonoBehaviour
{
    public int cnt = 0;
    public GameObject tutorial;  //Ʃ�丮�� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
    private TutorialControl control; //��ũ��Ʈ
    private bool cnt_bool = true; //�ѹ��� ����


    public void Start()
    {
        control = tutorial.GetComponent<TutorialControl>();
    }

    public void count()
    {
        cnt++;
        Debug.Log(cnt);
        check();
    }

    public void check()
    {
        if (cnt == 3 && cnt_bool == true)
        {
            cnt_bool = false;
            control.first_end();
        }
    }
}
