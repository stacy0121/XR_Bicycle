using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;


public class BallSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject BallPrefab; //������ ������Ʈ
    [SerializeField]
    private bool isPlayOnStart = true;      // ������ �������ڸ��� ���� ������ ������?
    [SerializeField]
    private float startFactor = 1;          // �� ���� ���� �⺻ ��
    [SerializeField]
    private float additiveFactor = 0.1f;        // �� ���� ���ڿ� �� �� �������� ��
    [SerializeField]
    private float delayPerSpawnGroup = 3;       // �� ���� �ֱ�

    public GameObject instance;

    [SerializeField]
    UnityEvent onDestroy;


    public int result = 0; //���� ����

    public GameObject target; //�̵��� ��ġ
    public GameObject spanwer;
    [SerializeField]
    UnityEvent onCreate; //���� �����Ǿ��� �� �Լ�

 


    public void call()
    {
        result = Random.Range(3, 10);
        Debug.Log(result); 
        UI();
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
