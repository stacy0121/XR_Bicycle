using UnityEngine;
using System.Collections.Generic;


public class result_list : MonoBehaviour
{
    public List<GameObject> resultObjects = new List<GameObject>(); // 결과 오브젝트 리스트
    public string text;

    public void call()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(text);

        resultObjects.Clear();

        foreach (GameObject obj in objectsWithTag)
        {
            resultObjects.Add(obj);
        }

        ProcessResultObjects();
    }

    private void ProcessResultObjects()
    {
        // 결과 오브젝트 처리 로직 작성
        // resultObjects 리스트에 대한 추가적인 동작을 수행할 수 있습니다.
    }
}
