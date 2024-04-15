
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectComparer : MonoBehaviour
{
    public GameObject res;
    private result_list res_sci;
    private submission_list sub_sci;
    public List<GameObject> list1;
    public List<GameObject> list2;

    [SerializeField]
    UnityEvent Compare_fin; //비교가 끝난 것이 성공하면 실행
    [SerializeField]
    UnityEvent Compare_fin_suc; //비교가 끝난 것이 성공하면 실행
    [SerializeField]
    UnityEvent Compare_fin_fail; //비교가 끝난 것이 실패하면 실행
    private void Start()
    {
        res_sci = res.GetComponent<result_list>();
        sub_sci = res.GetComponent<submission_list>();

        list1 = sub_sci.submissionList;
        list2 = res_sci.resultObjects;
    }

    public bool CompareLists()
    {
        if (list1.Count != list2.Count)
        {
            // 두 리스트의 크기가 다르면 다른 오브젝트들이 포함되어 있음
            return false;
        }

        // 두 리스트를 정렬하여 순서를 일치시킴
        List<GameObject> sortedList1 = new List<GameObject>(list1);
        List<GameObject> sortedList2 = new List<GameObject>(list2);
        sortedList1.Sort(CompareGameObjects);
        sortedList2.Sort(CompareGameObjects);

        // 정렬된 리스트의 오브젝트들을 비교
        for (int i = 0; i < sortedList1.Count; i++)
        {
            GameObject obj1 = sortedList1[i];
            GameObject obj2 = sortedList2[i];

            if (obj1 != obj2)
            {
                // 오브젝트가 다르면 다른 오브젝트들이 포함되어 있음
                return false;
            }
        }

        // 모든 오브젝트가 동일하다면 두 리스트는 같음
        return true;
    }

    public void CompareListsCaller()
    {
        bool listsAreEqual = CompareLists();

        Compare_fin?.Invoke();

        if (listsAreEqual)
        {
          
            Compare_fin_suc?.Invoke();
        }
        else
        {
            Compare_fin_fail?.Invoke();
            Debug.Log("두 리스트는 다른 오브젝트들을 포함하고 있습니다.");
        }
    }

    private int CompareGameObjects(GameObject obj1, GameObject obj2)
    {
        // GameObject를 비교하는 방법을 정의합니다.
        // 필요에 따라서 오브젝트의 특정 속성을 비교하거나, 고유한 비교 로직을 구현할 수 있습니다.

        // 예제에서는 GameObject의 인스턴스를 비교하도록 하였습니다.
        return obj1.GetInstanceID().CompareTo(obj2.GetInstanceID());
    }

    public void equal()
    {

        Compare_fin_suc?.Invoke();
    }
}
