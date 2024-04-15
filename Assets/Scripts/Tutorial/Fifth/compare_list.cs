using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class compare_list : MonoBehaviour
{
    public GameObject fif_result; // 선택한 오브젝트
    private result_txt_list res_sci;  //선택 리스트
    public GameObject random_fifth;
    private RandomNumberDisplay lisor; //원본 리스트

    [SerializeField]
    UnityEvent onEqual; //동일할 때 실행

    [SerializeField]
    UnityEvent notEqual; //삽입할 때마다 실행

    public List<int> listA = new List<int>();
    public List<TMPro.TMP_Text> listB = new List<TMPro.TMP_Text>();

   /* private void Start()
    {
    
        listB  = fif_result.GetComponent<result_txt_list>().result_lis;
        listA = fif_result.GetComponent<RandomNumberDisplay>().numbers;


    }*/

    public void Call() 
        {
        listB = fif_result.GetComponent<result_txt_list>().result_lis;
        listA = random_fifth.GetComponent<RandomNumberDisplay>().numbers;
        CompareLists(listA, listB);
        } 
   

    private void CompareLists(List<int> list1, List<TMPro.TMP_Text> list2)
    {
        // 리스트 크기가 같은 경우에만 비교
        if (list1.Count == list2.Count)
        {
            bool listsAreEqual = true;

            for (int i = 0; i < list1.Count; i++)
            {
                // 숫자와 텍스트 요소의 텍스트를 비교
                if (list1[i].ToString() != list2[i].text)
                {
                    listsAreEqual = false;
                    break;
                }
            }

            if (listsAreEqual)
            {
                Debug.Log("Lists are equal.");
                onEqual?.Invoke();
            }
            else
            {
                Debug.Log("Lists are different.");
                notEqual?.Invoke();
            }
        }
        else
        {
            Debug.Log("Lists have different sizes.");
        }
    }
}
