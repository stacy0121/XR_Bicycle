using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject destroy_obj;
    public void Destroy_obj()
    {
        Destroy(destroy_obj);
    }
}
