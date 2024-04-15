using UnityEngine;
using UnityEngine.Events;

public class FlowerSpawner3 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _whenTaskStart;

    private void OnTriggerEnter(Collider other)   // 인지 과제 구간에 충돌했을 때 
    {
        if (other.tag == "Player")
        {
            _whenTaskStart.Invoke();
        }
    }
}
