using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Start : MonoBehaviour
{

    public GameObject tutorial;  //튜토리얼 컨트롤러 오브젝트 받아오기
    private TutorialControl tu_control; //스크립트

    public GameObject cntobj;  //튜토리얼 컨트롤러 오브젝트 받아오기
    private Count_control cnt_control; //스크립트

    private int cnt_check = 0;


    private void start()
    {
        tu_control = tutorial.GetComponent<TutorialControl>();
        cnt_control = cntobj.GetComponent<Count_control>();
    }

    public void call()
    {
        StartCoroutine(check());
    }
    public IEnumerator check()
    {

        yield return new WaitForSeconds(0.1f);
        cnt_check = cnt_control.cnt;
        if (cnt_check >= 3)
        {
            Debug.Log(12);
            tu_control.second();
        }
        
    }
}
