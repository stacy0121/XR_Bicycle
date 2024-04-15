using UnityEngine;
using UnityEngine.Events;

public class StopAnimation2 : MonoBehaviour
{
    private Animator animator;   // animator 컴포넌트 가져오기
    private TrafficLight trafficLight;
    private TrafficLight1 trafficLight1;
    private TrafficLight1 trafficLight2;
    private TrafficLight1 trafficLight3;
    private TrafficLight1 trafficLight4;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    private bool traffic = false;
    [SerializeField]
    private UnityEvent _whenTriggerEnter;
    [SerializeField]
    private UnityEvent _whenTriggerStay;
    [SerializeField]
    private UnityEvent _whenAnimationEnd;
    /*[SerializeField]
    private UnityEvent _atStopSignal;
    [SerializeField]
    private UnityEvent _afterStopSignal;*/

    [SerializeField]
    private UnityEvent ONstart;

    public int insertSuccess;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        trafficLight = GetComponent<TrafficLight>();
        trafficLight1 = Light1.GetComponent<TrafficLight1>();
        trafficLight2 = Light2.GetComponent<TrafficLight1>();
        trafficLight3 = Light3.GetComponent<TrafficLight1>();
        trafficLight4 = Light4.GetComponent<TrafficLight1>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)   // 충돌하면
    {
        if (other.tag == "Player")
        {
            ONstart?.Invoke();
      /*      StartCoroutine(trafficLight.TrafficSignal());   // 신호등 시작
            StartCoroutine(trafficLight1.TrafficSignal());
            StartCoroutine(trafficLight2.TrafficSignal());
            StartCoroutine(trafficLight3.TrafficSignal());
            StartCoroutine(trafficLight4.TrafficSignal());
*/
            animator.SetBool("Stop", true);   // 닫힘 애니메이션 시작
            // 페달링이 적용되지 않도록
            traffic = false;
            _whenTriggerEnter.Invoke();
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
            //_afterStopSignal.Invoke();
        }

    }

    public void Open()
    {
        animator.SetBool("Stop", false);   // 열림 애니메이션
        // 페달링 가능
        _whenAnimationEnd.Invoke();
        traffic = true;
    }
}
