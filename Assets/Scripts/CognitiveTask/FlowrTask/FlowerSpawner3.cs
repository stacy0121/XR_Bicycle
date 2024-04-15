using UnityEngine;
using UnityEngine.Events;

public class FlowerSpawner3 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _whenTaskStart;

    private void OnTriggerEnter(Collider other)   // ���� ���� ������ �浹���� �� 
    {
        if (other.tag == "Player")
        {
            _whenTaskStart.Invoke();
        }
    }
}
