using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class compare_list : MonoBehaviour
{
    public GameObject fif_result; // ������ ������Ʈ
    private result_txt_list res_sci;  //���� ����Ʈ
    public GameObject random_fifth;
    private RandomNumberDisplay lisor; //���� ����Ʈ

    [SerializeField]
    UnityEvent onEqual; //������ �� ����

    [SerializeField]
    UnityEvent notEqual; //������ ������ ����

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
        // ����Ʈ ũ�Ⱑ ���� ��쿡�� ��
        if (list1.Count == list2.Count)
        {
            bool listsAreEqual = true;

            for (int i = 0; i < list1.Count; i++)
            {
                // ���ڿ� �ؽ�Ʈ ����� �ؽ�Ʈ�� ��
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
