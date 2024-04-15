using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField]
    private string targetTag;
    [SerializeField]
    private UnityEvent triggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            triggerEvent.Invoke();
        }
    }
}
