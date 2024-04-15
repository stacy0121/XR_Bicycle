using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    public GameObject bike;
    private RailMove railMoveScript;


    public void Start()
    {
        railMoveScript = bike.GetComponent<RailMove>();
    }
    public void call()
    {
        if (railMoveScript != null)
        {
            railMoveScript.enabled = false;
            Debug.Log("Movement stopped");
         
        }
    }
}
