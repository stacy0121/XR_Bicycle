using UnityEngine;
using UnityEngine.Events;

public class FlowerTask3 : MonoBehaviour
{

    [SerializeField]
    private UnityEvent _whenTaskEnd;

    [SerializeField]
    UnityEvent onSuc; // 성공

    [SerializeField]
    UnityEvent onFai; // 실패

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flower")   // 꽃을 넣었을 때
        {
            _whenTaskEnd.Invoke();
            onSuc?.Invoke();
            Debug.Log("flower success");
        }

        else if (other.tag == "bomb")   // 꽃을 넣었을 때
        {
            _whenTaskEnd.Invoke();
            onFai?.Invoke();
            Debug.Log(other.tag);
        }
    }
}