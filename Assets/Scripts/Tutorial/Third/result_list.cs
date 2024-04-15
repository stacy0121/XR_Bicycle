using UnityEngine;
using System.Collections.Generic;


public class result_list : MonoBehaviour
{
    public List<GameObject> resultObjects = new List<GameObject>(); // ��� ������Ʈ ����Ʈ
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
        // ��� ������Ʈ ó�� ���� �ۼ�
        // resultObjects ����Ʈ�� ���� �߰����� ������ ������ �� �ֽ��ϴ�.
    }
}
