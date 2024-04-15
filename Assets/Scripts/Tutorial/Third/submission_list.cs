using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submission_list : MonoBehaviour
{
    public List<GameObject> submissionList = new List<GameObject>(); // 제출용 리스트

    public void AddToSubmissionList(GameObject obj)
    {
        if (!submissionList.Contains(obj))
        {
            submissionList.Add(obj);
        }
    }
}
