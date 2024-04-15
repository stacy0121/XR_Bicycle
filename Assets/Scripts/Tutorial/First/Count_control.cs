using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_control : MonoBehaviour
{
    public int cnt = 0;
    public GameObject tutorial;  //튜토리얼 컨트롤러 오브젝트 받아오기
    private TutorialControl control; //스크립트
    private bool cnt_bool = true; //한번만 실행


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
