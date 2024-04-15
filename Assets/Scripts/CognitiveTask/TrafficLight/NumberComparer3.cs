using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class NumberComparer3 : MonoBehaviour
{
    public TMP_Text tmProText;

    public GameObject spawner; // ������ ������Ʈ
    private AnimalSpawner3 spw;
    private int selectedNum;
    public int success = 0;

    /*[SerializeField]
    UnityEvent onSucess; // ����

    [SerializeField]
    UnityEvent onFail; // ����*/

    public void call()
    {
        spw = spawner.GetComponent<AnimalSpawner3>();
        selectedNum = spw.result;   // ������ ����

        CompareNumberTmPro();
    }

    private void CompareNumberTmPro()
    {
        int tmProValue;
        if (int.TryParse(tmProText.text, out tmProValue))
        {
            if (selectedNum > tmProValue)
            {
                Debug.Log(selectedNum + " is greater than " + tmProValue);
                success = 1;
            }
            else if (selectedNum < tmProValue)
            {
                Debug.Log(selectedNum + " is less than " + tmProValue);
                success = 1;
            }
            else
            {
                Debug.Log(selectedNum + " is equal to " + tmProValue);
                //onSucess?.Invoke();
                success = 2;   // ����
            }
        }
        else
        {
            Debug.Log("Unable to parse TMPro value");
        }

    }
}