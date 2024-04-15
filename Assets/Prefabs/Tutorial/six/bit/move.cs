using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 1f; // 이동 속도를 조절할 변수

    private void Update()
    {
        float zMovement = speed * Time.deltaTime;
        transform.Translate(0f, 0f, zMovement);
    }
}
