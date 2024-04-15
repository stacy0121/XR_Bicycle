using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Timer_ : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool isRunning;

    public int recordedTime; // �Ҽ��� ���� ���ڰ� ���ŵ� ��� �ð��� ������ ����

    /*private void Start()
    {
        StartTimer();
    }*/

    public void StartTimer()
    {
        if (!isRunning)
        {
            elapsedTime = 0f;
            startTime = Time.time;
            isRunning = true;
            Debug.Log("Timer started");
        }
    }

    public void StopTimer()
    {
        if (isRunning)
        {
            elapsedTime += Time.time - startTime;
            isRunning = false;
            recordedTime = Mathf.RoundToInt(elapsedTime); // �Ҽ��� ���� ���� ���� �� ����
            Debug.Log("Timer stopped. Elapsed time: " + elapsedTime.ToString("F2") + " seconds");
            
        }
    }

    public float GetElapsedTime()
    {
        if (isRunning)
        {
            return elapsedTime + (Time.time - startTime);
        }
        else
        {
            return elapsedTime;
        }
    }
}
