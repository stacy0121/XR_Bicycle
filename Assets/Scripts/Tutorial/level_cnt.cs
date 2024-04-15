using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class level_cnt : MonoBehaviour
{
    public int cnt = 0;
    private Coroutine callCoroutine;

    [SerializeField]
    UnityEvent Level; //���� ����


    public void call()
    {
        if (callCoroutine == null)
        {
            callCoroutine = StartCoroutine(CallCoroutine());
        }
        else
        {
            StopCoroutine(callCoroutine);
            callCoroutine = StartCoroutine(CallCoroutine());
        }
    }

    private IEnumerator CallCoroutine()
    {
        cnt++;
        Debug.Log(cnt);

        yield return new WaitForSeconds(3f);

        // 3�� ��� �� ������ �ڵ� �ۼ�
        StopCoroutine(callCoroutine);
        callCoroutine = null;
    }

    public void level_log()
    {
        Level?.Invoke();
    }
}
