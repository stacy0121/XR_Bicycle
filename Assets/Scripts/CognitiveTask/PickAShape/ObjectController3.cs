using UnityEngine;
using System.Diagnostics;
using UnityEngine.Events;

public class ObjectController3 : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _whenTriggerEnter;
    [SerializeField]
    private UnityEvent _whenTaskStart;
    [SerializeField]
    private GameObject pickashape;
    public Transform playerHeadTransform;

    private void OnTriggerEnter(Collider other)   // 인지 과제 구간에 충돌했을 때 
    {
        if (other.tag == "Player")
        {
            _whenTriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)   // 충돌한 상태에서
    {
       Invoke("NoPedaling", 5f);   // 페달링 무시
        pickashape.transform.position = playerHeadTransform.position;
    }

    private void NoPedaling()
    {
        // 페달링 무시
        _whenTaskStart.Invoke();
    }


}
