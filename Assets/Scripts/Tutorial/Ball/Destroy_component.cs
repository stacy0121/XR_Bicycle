using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_component : MonoBehaviour
{
    public GameObject destroy_obj; //삭제할 오브젝트
   public void call()
    {
        Debug.Log("호출");
        Destroy(destroy_obj);
    }
}
