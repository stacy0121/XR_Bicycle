using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpRotation : MonoBehaviour
{

    private Quaternion initialRotation;

    private void Start()
    {
        // ������ �� �ʱ� ȸ�� ���� ����
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // �ʱ� ȸ�� ���¸� ����
        transform.rotation = initialRotation;
    }
}
