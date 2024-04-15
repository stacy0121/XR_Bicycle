using UnityEngine;
using UnityEngine.Events;

public class FlowerTask3 : MonoBehaviour
{

    [SerializeField]
    private UnityEvent _whenTaskEnd;

    [SerializeField]
    UnityEvent onSuc; // ����

    [SerializeField]
    UnityEvent onFai; // ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flower")   // ���� �־��� ��
        {
            _whenTaskEnd.Invoke();
            onSuc?.Invoke();
            Debug.Log("flower success");
        }

        else if (other.tag == "bomb")   // ���� �־��� ��
        {
            _whenTaskEnd.Invoke();
            onFai?.Invoke();
            Debug.Log(other.tag);
        }
    }
}