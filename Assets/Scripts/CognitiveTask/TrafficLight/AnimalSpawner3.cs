using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class AnimalSpawner3 : MonoBehaviour
{
    [SerializeField]
    private GameObject Animal; //������ ������Ʈ
    [SerializeField]
    private GameObject AnimalTask;
    [SerializeField]
    private bool isPlayOnStart = true;      // ������ �������ڸ��� ���� ������ ������?
    [SerializeField]
    private float startFactor = 1;          // �� ���� ���� �⺻ ��
    [SerializeField]
    private float additiveFactor = 0.1f;        // �� ���� ���ڿ� �� �� �������� ��
    [SerializeField]
    private float delayPerSpawnGroup = 3;       // �� ���� �ֱ�

    private GameObject instance;
    public int result = 0;   //���� ����
    public long taskTime;
    public int insertSuccess = 0;   // ��������
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
    UnityEvent onSucess; // ����
    [SerializeField]
    UnityEvent onFail; // ����
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
            if (numcom1.success == 2 || numcom2.success == 2 || numcom3.success == 2)   // �����ϸ�
            {
                //insertSuccess = 1;      // �����ϸ� 1
                //_whenTaskSucceess.Invoke();    // ���� Ƚ�� �߰�

                onSucess.Invoke();             // ���� ����
                whenTaskEnd.Invoke();
                isFunctionExecuted = true;
            }
            else if (numcom1.success == 1 || numcom2.success == 1 || numcom3.success == 1)
            {
                onFail.Invoke();               // ���� ����
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
        //watch.Start();                // �ð� ���� ����
    }

    private void UI()
    {
        //��ũ��Ʈ 3�� �����ִ� �Լ� ����
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
