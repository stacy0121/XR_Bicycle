using UnityEngine;
using UnityEngine.Events;

public class FlowerSpawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject flowerTask;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private UnityEvent _whenTaskStart;
    [SerializeField]
    private UnityEvent _whenTaskEnd;

    //public Vector3 targetPosition;

    private void OnTriggerEnter(Collider other)   // ���� ���� ������ �浹���� �� 
    {
        if (other.tag == "Player")
        {
            Debug.Log(1);
            flowerTask.SetActive(true);   // ���� ���� Ȱ��ȭ
            _whenTaskStart.Invoke();
        }
    }

/*    private void OnTriggerStay(Collider other)   // �浹�� ���¿���
    {
         Invoke("NoPedaling", 5f);   // ��޸� ����

    }

    private void NoPedaling()
    {
        //stopwatch = true;
        // ��޸� ����
        _whenTaskStart.Invoke();
        //watch.Start();                // �ð� ���� ����
    }*/

    public void DestroyObject()
    {
        if (flowerTask != false)
        {
            flowerTask.SetActive(false);   // ���� ���� ��Ȱ��ȭ
            _whenTaskEnd.Invoke();         // ��޸� ����
            //UnityEngine.Debug.Log("object choose" + watch.ElapsedMilliseconds / 1000 + " s");
            //taskTime = watch.ElapsedMilliseconds / 1000;      // ���� ���� �ð�
        }

    }
}
