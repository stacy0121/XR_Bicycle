using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "target")
        {
            Debug.Log("�ı�");
            Destroy(other.gameObject);
        }
    }
}
