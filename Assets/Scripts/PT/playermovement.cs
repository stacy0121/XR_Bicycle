using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject pedal;
    public float acceleration = 1f; // 가속도를 조절할 변수
    public float deceleration = 0.5f;
    public float maxSpeed = 2f; // 최대 속력을 조절할 변수
    public float rotationSpeed = 180f; // 회전 속도를 조절할 변수
    private float currentSpeed = 0f; // 현재 속력을 저장할 변수
    private float currentAngle = 0f; // 현재 각도를 저장할 변수

    private bool isPedalPressed = false; // 페달이 눌렸는지 여부를 나타내는 변수


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
            currentSpeed = 0f; // 'W' 키를 떼면 현재 속도를 0으로 만들어 멈춤
        }
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine(MoveForwardCoroutine());
            currentSpeed = 0f; // 스페이스바 누르면 현재 속도를 0으로 만들어 멈춤
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
