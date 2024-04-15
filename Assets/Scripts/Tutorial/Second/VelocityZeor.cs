using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;


public class VelocityZeor : MonoBehaviour
{
    public Rigidbody bikeRigidbody;
    public float updateInterval = 0.5f; // 업데이트 간격

    [SerializeField]
    UnityEvent touch_fail; // 두번째 실패

    private bool isUpdating = false;

    // 타이머
    public TMP_Text timerText;
    private float maxTime = 60f;
    private float startTime;
    private bool isTimerRunning = false;

    public void call()
    {
        timerText.gameObject.SetActive(true);
        StartCoroutine(StartVelocity());
    }

    private IEnumerator StartVelocity()
    {
        yield return new WaitForSeconds(1f);
        isUpdating = true;

        while (isUpdating)
        {
            float speed_bike = bikeRigidbody.velocity.magnitude;

            if (speed_bike == 0)
            {
                // 타이머 초기화
                startTime = Time.time;
                UpdateTimerText();

                // 타이머 시작
                StartCoroutine(CountdownCoroutine());

                yield break; // 코루틴 종료
            }

            yield return new WaitForSeconds(updateInterval);
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        isTimerRunning = true;

        while (true)
        {
            float elapsedTime = Time.time - startTime;
            float remainingTime = maxTime - elapsedTime;

            if (remainingTime <= 0f)
                break;

            UpdateTimerText();

           // Debug.Log("Remaining Time: " + remainingTime.ToString("F2"));

            yield return null; // 프레임 단위로 대기 (다음 프레임에서 타이머 갱신)
        }

        // 타이머 종료
        isTimerRunning = false;
        UpdateTimerText();
        touch_fail?.Invoke();

        // 원하는 동작 수행
        // ...
    }

    private void UpdateTimerText()
    {
        // 남은 시간 표시
        float elapsedTime = Time.time - startTime;
        float remainingTime = maxTime - elapsedTime;
        string timeText = Mathf.Max(0f, remainingTime).ToString("F2");
        timerText.text = "남은 시간 : " + timeText + "초";
    }

}
