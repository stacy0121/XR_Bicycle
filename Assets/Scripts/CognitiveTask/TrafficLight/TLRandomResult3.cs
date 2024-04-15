using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TLRandomResult3 : MonoBehaviour
{
    private AnimalSpawner3 ballSpanwer; //result값을 받아올 스크립트
    public GameObject result; //result값을 가지고 있는 오브젝특

    public TMP_Text tmp;
    public TMP_Text tmp1;
    public TMP_Text tmp2;

    private int random;
    
    
    public void call()
    {
        ballSpanwer = result.GetComponent<AnimalSpawner3>();
        List<int> result_list = new List<int>();
        result_list.Add(ballSpanwer.result);
        while (result_list.Count !=3) {
            HashSet<int> uniqueNumbers = new HashSet<int>(result_list);
            random = Random.Range(3, 10);
            if (uniqueNumbers.Add(random))
            {
                uniqueNumbers.Add(random);
                result_list = new List<int>(uniqueNumbers);
            }
            else
            {
                result_list = new List<int>(uniqueNumbers);
            }
                }

        int random1, random2;
        int temp;

        for (int i = 0; i < result_list.Count; ++i)
        {
            random1 = Random.Range(0, result_list.Count);
            random2 = Random.Range(0, result_list.Count);

            temp = result_list[random1];
            result_list[random1] = result_list[random2];
            result_list[random2] = temp;
        }

        tmp.text = result_list[0].ToString();
        tmp1.text = result_list[1].ToString();
        tmp2.text = result_list[2].ToString();

        Debug.Log(1);
        Debug.Log(result_list[0]);

    }

   
}
