using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivation : MonoBehaviour
{
    public void ActivateObject()
    {
        gameObject.SetActive(true); // 오브젝트 활성화
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false); // 오브젝트 비활성화
    }
}
