using UnityEngine;
using UnityEngine.Events;


public class tirgger_player : MonoBehaviour
{
    public UnityEvent onEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onEvent?.Invoke();
        }
    }
}
