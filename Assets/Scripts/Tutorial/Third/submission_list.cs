using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submission_list : MonoBehaviour
{
    public List<GameObject> submissionList = new List<GameObject>(); // ����� ����Ʈ

    public void AddToSubmissionList(GameObject obj)
    {
        if (!submissionList.Contains(obj))
        {
            submissionList.Add(obj);
        }
    }
}
