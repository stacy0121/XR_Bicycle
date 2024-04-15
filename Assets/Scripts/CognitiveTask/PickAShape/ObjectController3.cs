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

    private void OnTriggerEnter(Collider other)   // ���� ���� ������ �浹���� �� 
    {
        if (other.tag == "Player")
        {
            _whenTriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)   // �浹�� ���¿���
    {
       Invoke("NoPedaling", 5f);   // ��޸� ����
        pickashape.transform.position = playerHeadTransform.position;
    }

    private void NoPedaling()
    {
        // ��޸� ����
        _whenTaskStart.Invoke();
    }


}
