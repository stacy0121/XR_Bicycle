using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;


public class VelocityZeor : MonoBehaviour
{
    public Rigidbody bikeRigidbody;
    public float updateInterval = 0.5f; // ������Ʈ ����

    [SerializeField]
    UnityEvent touch_fail; // �ι�° ����

    private bool isUpdating = false;

    // Ÿ�̸�
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
                // Ÿ�̸� �ʱ�ȭ
                startTime = Time.time;
                UpdateTimerText();

                // Ÿ�̸� ����
                StartCoroutine(CountdownCoroutine());

                yield break; // �ڷ�ƾ ����
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

            yield return null; // ������ ������ ��� (���� �����ӿ��� Ÿ�̸� ����)
        }

        // Ÿ�̸� ����
        isTimerRunning = false;
        UpdateTimerText();
        touch_fail?.Invoke();

        // ���ϴ� ���� ����
        // ...
    }

    private void UpdateTimerText()
    {
        // ���� �ð� ǥ��
        float elapsedTime = Time.time - startTime;
        float remainingTime = maxTime - elapsedTime;
        string timeText = Mathf.Max(0f, remainingTime).ToString("F2");
        timerText.text = "���� �ð� : " + timeText + "��";
    }

}
