using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive : MonoBehaviour
{
    public GameObject targetObject2_1; // 인스펙터에서 설정할 대상 오브젝트, 인지과제 삭제
    public GameObject targetObject2_2; // 인스펙터에서 설정할 대상 오브젝트, 인지과제 삭제
    void Update()
    {
        // Q 키를 누르면 대상 오브젝트를 비활성화한다.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetObject2_1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetObject2_2.SetActive(false);
        }

    }

  /*  void DeactivateObject()
    {
        // 대상 오브젝트가 null이 아니라면 비활성화한다.
        if (targetObject != null)
        {
            targetObject.SetActive(false);
            Debug.Log("Object Deactivated");
        }
        else
        {
            Debug.LogError("Target Object is not assigned!");
        }
    }*/
}
