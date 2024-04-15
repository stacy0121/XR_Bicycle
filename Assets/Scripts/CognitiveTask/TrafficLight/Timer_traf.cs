using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer_traf : MonoBehaviour
{
    public UnityEvent onTimerStart;
    public UnityEvent onTimerFinish;
    public TMP_Text timerText;

    private bool isCounting = false;
    public float timer;
    public void call()
    {
        StartCountdown();
    }
    public void StartCountdown()
    {
        if (!isCounting)
        {
            StartCoroutine(CountdownRoutine());
        }
    }

    private IEnumerator CountdownRoutine()
    {
        isCounting = true;
        onTimerStart.Invoke();


        while (timer > 0f)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
            UpdateTimerText(timer);
        }

        
        isCounting = false;
    }

    private void UpdateTimerText(float time)
    {
        int seconds = Mathf.FloorToInt(time);
        timerText.text = seconds.ToString();

        if (seconds == 0)
        {
            onTimerFinish.Invoke();
        }
    }
}
