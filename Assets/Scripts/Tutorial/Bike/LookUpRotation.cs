using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpRotation : MonoBehaviour
{

    private Quaternion initialRotation;

    private void Start()
    {
        // 시작할 때 초기 회전 상태 저장
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // 초기 회전 상태를 유지
        transform.rotation = initialRotation;
    }
}
