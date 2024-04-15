using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;


public class BallSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject BallPrefab; //생성할 오브젝트
    [SerializeField]
    private bool isPlayOnStart = true;      // 게임을 시작하자마자 적을 생성할 것인지?
    [SerializeField]
    private float startFactor = 1;          // 적 생성 숫자 기본 값
    [SerializeField]
    private float additiveFactor = 0.1f;        // 적 생성 숫자에 매 턴 더해지는 값
    [SerializeField]
    private float delayPerSpawnGroup = 3;       // 적 생성 주기

    public GameObject instance;

    [SerializeField]
    UnityEvent onDestroy;


    public int result = 0; //랜덤 숫자

    public GameObject target; //이동할 위치
    public GameObject spanwer;
    [SerializeField]
    UnityEvent onCreate; //공이 생성되었을 때 함수

 


    public void call()
    {
        result = Random.Range(3, 10);
        Debug.Log(result); 
        UI();
    }

    private void UI()
    {
        //스크립트 3초 보여주는 함수 실행
        if (isPlayOnStart)
            {
                Play();
            isPlayOnStart = false;


            }
    }
    

    public void Play()
    {
        StartCoroutine("SpawnProcess");
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnProcess()
    {
        float factor = startFactor;

        while (true)
        {
            yield return new WaitForSeconds(delayPerSpawnGroup);

            yield return StartCoroutine(SpawnEnemy());

         
        }
    }

    public IEnumerator SpawnEnemy()
    {
        int cnt = 0;
       

        for (int i = 0; i < result; ++i)
        {
            
            instance = Instantiate(BallPrefab, spanwer.transform.position, spanwer.transform.rotation, transform);
            instance.SetActive(true);
            onCreate?.Invoke();
            //StartCoroutine(move());
            //StartCoroutine(move());
            yield return new WaitForSeconds(1.0f);
            cnt++;
           
        }
        if (cnt == result)
        {
            StopAllCoroutines();
            onDestroy?.Invoke();

        }
    }

   
  
}
