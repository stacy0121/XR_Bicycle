using UnityEngine;
using System.Diagnostics;
using UnityEngine.Events;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pickAShape;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private MeshRenderer shape1;
    [SerializeField]
    private MeshRenderer shape2;
    [SerializeField]
    private MeshRenderer success;
    [SerializeField]
    private MeshRenderer failure;
    //[SerializeField]
    //private float spawnDelay = 3f;
    private float destroyDelay = 30f;

    [SerializeField]
    private UnityEvent _whenTaskStart;
    [SerializeField]
    private UnityEvent _whenTaskEnd;

    private Stopwatch watch;
    public long taskTime;
    private bool isFunctionExecuted = false;
    public int insertSuccess = 0;
    private Vector3 targetPosition;
    private bool stopwatch = false;

    [SerializeField]
    UnityEvent onSuc; // ����

    [SerializeField]
    UnityEvent onFai; // ����

    private void Awake()
    {
        watch = new Stopwatch();
    }

    private void Update()
    {
        if (isFunctionExecuted == false)
        {
            if (shape1 || shape2 == true)   // �� �� �ϳ��� ������
            {
                // 30�� �ִٰ� �������� (���� ���� ����)
                if(watch.ElapsedMilliseconds / 1000 >= 30f) Wait();

                onFai?.Invoke();
            }

            if (shape1.enabled == false && shape2.enabled == false)   // �� ������Ʈ�� �������� (���� ���� ����)
            {
                insertSuccess = 1; //     �����ϸ� 1
                success.enabled = true;        // ���� ����
                //_whenTaskSucceess.Invoke();    // ���� Ƚ�� �߰�
                Invoke("DestroyObject", 3f);   // 3�� �� ������Ʈ ���ֱ�
                onSuc?.Invoke();
            }
        }

        // ������ 10��ŭ ������ ��ǥ ��ġ
        pickAShape.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.8f, player.transform.position.z - 1.5f);
    }

    private void OnTriggerEnter(Collider other)   // ���� ���� ������ �浹���� �� 
    {
        if (other.tag == "Player")
        {
            pickAShape.SetActive(true);   // ���� ���� Ȱ��ȭ
        }
    }

    private void OnTriggerStay(Collider other)   // �浹�� ���¿���
    {
        if (isFunctionExecuted == false && stopwatch == false)
        {
            Invoke("NoPedaling", 5f);   // ��޸� ����
        }
    }

    private void NoPedaling()
    {
        stopwatch = true;
        // ��޸� ����
        _whenTaskStart.Invoke();
        watch.Start();                // �ð� ���� ����
    }

    private void Wait()   // ���� ���� 30�� �� 
    {
        failure.enabled = true;        // ���� ����
        //_whenTaskFailure.Invoke();     // ���� Ƚ�� �߰�
        Invoke("DestroyObject", 3f);   // 3�� �� ������Ʈ ���ֱ�

    }

    private void DestroyObject()
    {
        if (pickAShape != false && isFunctionExecuted == false)
        {
            isFunctionExecuted = true;
            pickAShape.SetActive(false);   // ���� ���� ��Ȱ��ȭ
            watch.Stop();                  // �ð� ���� ��
            _whenTaskEnd.Invoke();         // ��޸� ����
            //UnityEngine.Debug.Log("object choose" + watch.ElapsedMilliseconds / 1000 + " s");
            taskTime = watch.ElapsedMilliseconds / 1000;      // ���� ���� �ð�
        }
        
    }


}
