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
    UnityEvent onSuc; // 성공

    [SerializeField]
    UnityEvent onFai; // 실패

    private void Awake()
    {
        watch = new Stopwatch();
    }

    private void Update()
    {
        if (isFunctionExecuted == false)
        {
            if (shape1 || shape2 == true)   // 둘 중 하나라도 남으면
            {
                // 30초 있다가 없어지기 (인지 과제 실패)
                if(watch.ElapsedMilliseconds / 1000 >= 30f) Wait();

                onFai?.Invoke();
            }

            if (shape1.enabled == false && shape2.enabled == false)   // 두 오브젝트가 없어지면 (인지 과제 성공)
            {
                insertSuccess = 1; //     성공하면 1
                success.enabled = true;        // 성공 문구
                //_whenTaskSucceess.Invoke();    // 성공 횟수 추가
                Invoke("DestroyObject", 3f);   // 3초 후 오브젝트 없애기
                onSuc?.Invoke();
            }
        }

        // 앞으로 10만큼 떨어진 목표 위치
        pickAShape.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.8f, player.transform.position.z - 1.5f);
    }

    private void OnTriggerEnter(Collider other)   // 인지 과제 구간에 충돌했을 때 
    {
        if (other.tag == "Player")
        {
            pickAShape.SetActive(true);   // 인지 과제 활성화
        }
    }

    private void OnTriggerStay(Collider other)   // 충돌한 상태에서
    {
        if (isFunctionExecuted == false && stopwatch == false)
        {
            Invoke("NoPedaling", 5f);   // 페달링 무시
        }
    }

    private void NoPedaling()
    {
        stopwatch = true;
        // 페달링 무시
        _whenTaskStart.Invoke();
        watch.Start();                // 시간 측정 시작
    }

    private void Wait()   // 인지 과제 30초 후 
    {
        failure.enabled = true;        // 실패 문구
        //_whenTaskFailure.Invoke();     // 실패 횟수 추가
        Invoke("DestroyObject", 3f);   // 3초 후 오브젝트 없애기

    }

    private void DestroyObject()
    {
        if (pickAShape != false && isFunctionExecuted == false)
        {
            isFunctionExecuted = true;
            pickAShape.SetActive(false);   // 인지 과제 비활성화
            watch.Stop();                  // 시간 측정 끝
            _whenTaskEnd.Invoke();         // 페달링 가능
            //UnityEngine.Debug.Log("object choose" + watch.ElapsedMilliseconds / 1000 + " s");
            taskTime = watch.ElapsedMilliseconds / 1000;      // 과제 수행 시간
        }
        
    }


}
