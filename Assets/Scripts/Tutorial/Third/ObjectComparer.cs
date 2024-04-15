
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
    UnityEvent Compare_fin; //�񱳰� ���� ���� �����ϸ� ����
    [SerializeField]
    UnityEvent Compare_fin_suc; //�񱳰� ���� ���� �����ϸ� ����
    [SerializeField]
    UnityEvent Compare_fin_fail; //�񱳰� ���� ���� �����ϸ� ����
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
            // �� ����Ʈ�� ũ�Ⱑ �ٸ��� �ٸ� ������Ʈ���� ���ԵǾ� ����
            return false;
        }

        // �� ����Ʈ�� �����Ͽ� ������ ��ġ��Ŵ
        List<GameObject> sortedList1 = new List<GameObject>(list1);
        List<GameObject> sortedList2 = new List<GameObject>(list2);
        sortedList1.Sort(CompareGameObjects);
        sortedList2.Sort(CompareGameObjects);

        // ���ĵ� ����Ʈ�� ������Ʈ���� ��
        for (int i = 0; i < sortedList1.Count; i++)
        {
            GameObject obj1 = sortedList1[i];
            GameObject obj2 = sortedList2[i];

            if (obj1 != obj2)
            {
                // ������Ʈ�� �ٸ��� �ٸ� ������Ʈ���� ���ԵǾ� ����
                return false;
            }
        }

        // ��� ������Ʈ�� �����ϴٸ� �� ����Ʈ�� ����
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
            Debug.Log("�� ����Ʈ�� �ٸ� ������Ʈ���� �����ϰ� �ֽ��ϴ�.");
        }
    }

    private int CompareGameObjects(GameObject obj1, GameObject obj2)
    {
        // GameObject�� ���ϴ� ����� �����մϴ�.
        // �ʿ信 ���� ������Ʈ�� Ư�� �Ӽ��� ���ϰų�, ������ �� ������ ������ �� �ֽ��ϴ�.

        // ���������� GameObject�� �ν��Ͻ��� ���ϵ��� �Ͽ����ϴ�.
        return obj1.GetInstanceID().CompareTo(obj2.GetInstanceID());
    }

    public void equal()
    {

        Compare_fin_suc?.Invoke();
    }
}
