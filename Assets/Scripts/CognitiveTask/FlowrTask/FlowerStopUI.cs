using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class FlowerStopUI : MonoBehaviour
{
    [SerializeField] UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)   // 충돌하면
    {
        if (other.tag == "Player")
        {
            onTrigger.Invoke();
        }
    }
}
