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

    private void OnTriggerEnter(Collider other)   // 인지 과제 구간에 충돌했을 때 
    {
        if (other.tag == "Player")
        {
            Debug.Log(1);
            flowerTask.SetActive(true);   // 인지 과제 활성화
            _whenTaskStart.Invoke();
        }
    }

/*    private void OnTriggerStay(Collider other)   // 충돌한 상태에서
    {
         Invoke("NoPedaling", 5f);   // 페달링 무시

    }

    private void NoPedaling()
    {
        //stopwatch = true;
        // 페달링 무시
        _whenTaskStart.Invoke();
        //watch.Start();                // 시간 측정 시작
    }*/

    public void DestroyObject()
    {
        if (flowerTask != false)
        {
            flowerTask.SetActive(false);   // 인지 과제 비활성화
            _whenTaskEnd.Invoke();         // 페달링 가능
            //UnityEngine.Debug.Log("object choose" + watch.ElapsedMilliseconds / 1000 + " s");
            //taskTime = watch.ElapsedMilliseconds / 1000;      // 과제 수행 시간
        }

    }
}
