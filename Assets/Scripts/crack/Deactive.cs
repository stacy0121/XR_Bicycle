using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive : MonoBehaviour
{
    public GameObject targetObject2_1; // �ν����Ϳ��� ������ ��� ������Ʈ, �������� ����
    public GameObject targetObject2_2; // �ν����Ϳ��� ������ ��� ������Ʈ, �������� ����
    void Update()
    {
        // Q Ű�� ������ ��� ������Ʈ�� ��Ȱ��ȭ�Ѵ�.
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
        // ��� ������Ʈ�� null�� �ƴ϶�� ��Ȱ��ȭ�Ѵ�.
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
