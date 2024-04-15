using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class AnimalSpawner3 : MonoBehaviour
{
    [SerializeField]
    private GameObject Animal; //생성할 오브젝트
    [SerializeField]
    private GameObject AnimalTask;
    [SerializeField]
    private bool isPlayOnStart = true;      // 게임을 시작하자마자 적을 생성할 것인지?
    [SerializeField]
    private float startFactor = 1;          // 적 생성 숫자 기본 값
    [SerializeField]
    private float additiveFactor = 0.1f;        // 적 생성 숫자에 매 턴 더해지는 값
    [SerializeField]
    private float delayPerSpawnGroup = 3;       // 적 생성 주기

    private GameObject instance;
    public int result = 0;   //랜덤 숫자
    public long taskTime;
    public int insertSuccess = 0;   // 성공여부
    private bool isFunctionExecuted = false;
    public Transform playerHeadTransform;

    [SerializeField]
    private GameObject num1;
    [SerializeField]
    private GameObject num2;
    [SerializeField]
    private GameObject num3;
    private NumberComparer3 numcom1;
    private NumberComparer3 numcom2;
    private NumberComparer3 numcom3;

    [SerializeField]
    UnityEvent onSucess; // 성공
    [SerializeField]
    UnityEvent onFail; // 실패
    [SerializeField]
    UnityEvent whenTaskEnd;

    private void Awake()
    {
        //watch = new Stopwatch();

        numcom1 = num1.GetComponent<NumberComparer3>();
        numcom2 = num2.GetComponent<NumberComparer3>();
        numcom3 = num3.GetComponent<NumberComparer3>();
    }

    private void Update()
    {
        if (isFunctionExecuted == false)
        {
            if (numcom1.success == 2 || numcom2.success == 2 || numcom3.success == 2)   // 성공하면
            {
                //insertSuccess = 1;      // 성공하면 1
                //_whenTaskSucceess.Invoke();    // 성공 횟수 추가

                onSucess.Invoke();             // 성공 문구
                whenTaskEnd.Invoke();
                isFunctionExecuted = true;
            }
            else if (numcom1.success == 1 || numcom2.success == 1 || numcom3.success == 1)
            {
                onFail.Invoke();               // 실패 문구
                whenTaskEnd.Invoke();
                isFunctionExecuted = true;
            }
        }
    }

    public void Spawn()
    {
        AnimalTask.SetActive(true);
        AnimalTask.transform.position = playerHeadTransform.position;
    }

    public void call()
    {
        result = Random.Range(3, 10);
        UnityEngine.Debug.Log("animal : " + result);
        UI();
        //watch.Start();                // 시간 측정 시작
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
            //onCreate?.Invoke();
            instance = Instantiate(Animal, transform.position, transform.rotation, transform);
            instance.SetActive(true);

            yield return new WaitForSeconds(1.0f);
            cnt++;
        }

        if (cnt == result)
        {
            StopAllCoroutines();
        }
    }
}
