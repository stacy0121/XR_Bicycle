using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 1f; // �̵� �ӵ��� ������ ����

    private void Update()
    {
        float zMovement = speed * Time.deltaTime;
        transform.Translate(0f, 0f, zMovement);
    }
}
