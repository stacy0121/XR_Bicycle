using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivation : MonoBehaviour
{
    public void ActivateObject()
    {
        gameObject.SetActive(true); // ������Ʈ Ȱ��ȭ
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
    }
}
