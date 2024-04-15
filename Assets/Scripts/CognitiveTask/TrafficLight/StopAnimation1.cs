using UnityEngine;
using UnityEngine.Events;

public class StopAnimation1 : MonoBehaviour
{
    private Animator animator;   // animator 컴포넌트 가져오기
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

    private void OnTriggerEnter(Collider other)   // 충돌하면
    {
        if (other.tag == "Player")
        {
           // StartCoroutine(trafficLight.TrafficSignal());   // 신호등 시작
            animator.SetBool("Stop", true);   // 닫힘 애니메이션 시작
            Invoke("Open", 10f);              // 10초 후 열림
            // 페달링이 적용되지 않도록
            //traffic = true;
        }
    }

    private void OnTriggerStay(Collider other)   // 충돌한 상태에서
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
            // 페달링 무시
            _whenTriggerStay.Invoke();
            // 각도가 10도 이내면 통과
            // _afterStopSignal.Invoke();
        }

    }

    private void Open()
    {
        animator.SetBool("Stop", false);
        // 페달링 가능
        _whenAnimationEnd.Invoke();
        traffic = true;
    }
}
