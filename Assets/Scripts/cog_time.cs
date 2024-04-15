using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cog_time : MonoBehaviour
{
    public float cog1_time;
    public float cog2_time;
    public float cog3_time;


    public GameObject timer_obj;
    private Timer_ timer_;

    private void Start()
    {
        timer_ = timer_obj.GetComponent<Timer_>();
    }

    public void startcog1()
    {
        StartCoroutine(StartCog1Timer());
    }

    public void cog1_fail_time()
    {
        cog1_time = 120;
    }
    public void SaveCog2Time()
    {
        StartCoroutine(StartCog2Timer());
    }
    public void cog2_fail_time()
    {
        cog2_time = 120;
    }

    public void SaveCog3Time()
    {
        StartCoroutine(StartCog3Timer());
    }

    public void cog3_fail_time()
    {
        cog3_time = 120;
    }
    public IEnumerator StartCog1Timer()
    {
        yield return new WaitForSeconds(1f);

        cog1_time = timer_.recordedTime;   // Timer_로 잰 시간을 받아옴 (인지과제마다 분리)
        Debug.Log(cog1_time);

        StopCoroutine(StartCog1Timer());
    }

    public IEnumerator StartCog2Timer()
    {
        yield return new WaitForSeconds(1f);

        cog2_time = timer_.recordedTime;
        Debug.Log(cog2_time);
        StopCoroutine(StartCog2Timer());
    }
    public IEnumerator StartCog3Timer()
    {
        yield return new WaitForSeconds(1f);

        cog3_time = timer_.recordedTime;
        Debug.Log(cog3_time);
        StopCoroutine(StartCog3Timer());
    }
}
