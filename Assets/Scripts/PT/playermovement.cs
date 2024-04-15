using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject pedal;
    public float acceleration = 1f; // ���ӵ��� ������ ����
    public float deceleration = 0.5f;
    public float maxSpeed = 2f; // �ִ� �ӷ��� ������ ����
    public float rotationSpeed = 180f; // ȸ�� �ӵ��� ������ ����
    private float currentSpeed = 0f; // ���� �ӷ��� ������ ����
    private float currentAngle = 0f; // ���� ������ ������ ����

    private bool isPedalPressed = false; // ����� ���ȴ��� ���θ� ��Ÿ���� ����


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            isPedalPressed = true;
            StartCoroutine(MoveForwardCoroutine());
        }

        else if (Input.GetKeyUp(KeyCode.W))
        {
            isPedalPressed = false;
            currentSpeed = 0f; // 'W' Ű�� ���� ���� �ӵ��� 0���� ����� ����
        }
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine(MoveForwardCoroutine());
            currentSpeed = 0f; // �����̽��� ������ ���� �ӵ��� 0���� ����� ����
            Debug.Log(1);
        }*/
    }

    IEnumerator MoveForwardCoroutine()
    {
        while (isPedalPressed)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            float moveAmount = currentSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveAmount, Space.Self);

            float targetAngle = (360f / 2f) * Time.deltaTime;

            currentAngle += targetAngle;
            currentAngle = Mathf.Repeat(currentAngle, 360f);

            Quaternion targetRotation = Quaternion.Euler(currentAngle, 0f, 0f);
            pedal.transform.rotation = Quaternion.Lerp(pedal.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            //print(pedal.transform.rotation);
            yield return null;
        }

        while (isPedalPressed == false && currentSpeed >= 0)
        {
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0f);

            float moveAmount = currentSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveAmount, Space.Self);

            /*float targetAngle = (360f / 2f) * Time.deltaTime;

            currentAngle += targetAngle;
            currentAngle = Mathf.Repeat(currentAngle, 360f);

            Quaternion targetRotation = Quaternion.Euler(currentAngle, 0f, 0f);
            pedal.transform.rotation = Quaternion.Lerp(pedal.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);*/
            yield return null;
        }
    }
}
