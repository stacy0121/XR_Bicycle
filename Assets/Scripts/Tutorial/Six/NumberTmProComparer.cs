using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class NumberTmProComparer : MonoBehaviour
{
    
    public TMP_Text tmProText;

    public GameObject spw_bal; // 선택한 오브젝트
    private BallSpanwer ball_spw;
    private int number;

    [SerializeField]
    UnityEvent onSuc; // 성공

    [SerializeField]
    UnityEvent onFai; // 실패

    public void call()
    {
        ball_spw = spw_bal.GetComponent<BallSpanwer>();
        number = ball_spw.result;

        CompareNumberTmPro();
    }

    private void CompareNumberTmPro()
    {
        int tmProValue;
        if (int.TryParse(tmProText.text, out tmProValue))
        {
            if (number > tmProValue)
            {
                Debug.Log(number + " is greater than " + tmProValue);
                onFai?.Invoke();
            }
            else if (number < tmProValue)
            {
                Debug.Log(number + " is less than " + tmProValue);
                onFai?.Invoke();
            }
            else
            {
                Debug.Log(number + " is equal to " + tmProValue);
                onSuc?.Invoke();
            }
        }
        else
        {
            Debug.Log("Unable to parse TMPro value");
        }
    }
}
