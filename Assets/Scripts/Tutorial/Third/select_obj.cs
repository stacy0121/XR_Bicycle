using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_obj : MonoBehaviour
{
    public GameObject subObject; // 선택한 오브젝트
    private submission_list sub_script;
    public GameObject selectObj;

    private void Start()
    {
        sub_script = subObject.GetComponent<submission_list>();
    }

    public void call()
    {
        input(selectObj);
    }

    private void input(GameObject obj)
    {
        if (obj != null && !sub_script.submissionList.Contains(obj))
        {
            sub_script.submissionList.Add(obj);
        }
    }
}
