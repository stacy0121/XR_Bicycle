using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Start : MonoBehaviour
{

    public GameObject tutorial;  //Ʃ�丮�� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
    private TutorialControl tu_control; //��ũ��Ʈ

    public GameObject cntobj;  //Ʃ�丮�� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
    private Count_control cnt_control; //��ũ��Ʈ

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
