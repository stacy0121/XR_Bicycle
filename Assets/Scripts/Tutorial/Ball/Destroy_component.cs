using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_component : MonoBehaviour
{
    public GameObject destroy_obj; //������ ������Ʈ
   public void call()
    {
        Debug.Log("ȣ��");
        Destroy(destroy_obj);
    }
}
