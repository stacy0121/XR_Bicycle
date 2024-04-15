using UnityEngine;
using UnityEngine.Events;

public class StopAnimation1 : MonoBehaviour
{
    private Animator animator;   // animator ������Ʈ ��������
    private TrafficLight trafficLight;
    private bool traffic = false;
    [SerializeField]
    private UnityEvent _whenTriggerStay;
    [SerializeField]
    private UnityEvent _whenAnimationEnd;

    public int insertSuccess;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        trafficLight = GetComponent<TrafficLight>();
    }

    private void OnTriggerEnter(Collider other)   // �浹�ϸ�
    {
        if (other.tag == "Player")
        {
           // StartCoroutine(trafficLight.TrafficSignal());   // ��ȣ�� ����
            animator.SetBool("Stop", true);   // ���� �ִϸ��̼� ����
            Invoke("Open", 10f);              // 10�� �� ����
            // ��޸��� ������� �ʵ���
            //traffic = true;
        }
    }

    private void OnTriggerStay(Collider other)   // �浹�� ���¿���
    {
        if (other.tag == "Player" && traffic == false)
        {
            
            Invoke("NoPedaling", 5f); 
        }

    }

    private void NoPedaling()
    {
        if (traffic == false)
        {
            // ��޸� ����
            _whenTriggerStay.Invoke();
            // ������ 10�� �̳��� ���
            // _afterStopSignal.Invoke();
        }

    }

    private void Open()
    {
        animator.SetBool("Stop", false);
        // ��޸� ����
        _whenAnimationEnd.Invoke();
        traffic = true;
    }
}
