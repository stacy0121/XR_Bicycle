using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBike : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject buttonObject;
    public float buttonOffset = 30f;

    private Rigidbody rb;
    private bool isCollided = false;
    public GameObject targetObject; //자전거 오브젝트
     
    private void Start()
    {
        rb = targetObject.GetComponent<Rigidbody>(); //자전거 오브젝트의 rb
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("second") && !isCollided)
        {
            uiObject.SetActive(true);
            isCollided = true;
        }
    }

    private void FixedUpdate()
    {
        if (isCollided && rb.velocity.magnitude <= 0f)
        {
            Vector3 buttonPosition = transform.position + transform.forward * buttonOffset;
            buttonObject.transform.position = buttonPosition;
            buttonObject.SetActive(true);
        }
    }
}
