using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject objectToDelete;
   // public GameObject uiObject;
    public TMP_Text tmp;
    public string originalText;
    public GameObject bikeObject;
    public string newText;

    private bool hasInteracted = false;

    public float delayTime = 5f; // UI ��������� ���� �ð�
    [SerializeField]
    UnityEvent onbutton_des; //UI�� ������ ���۵� �Լ�


    private bool isDeleteObjectCalled = false; //�Լ� ȣ�� ���� Ȯ��
    public float maxTime = 60f; // �ִ� ���� �ð�



    public void call()
    {

        float zSpeed = bikeObject.GetComponent<Rigidbody>().velocity.z;

        if (zSpeed == 0f )
        {
            // ������Ʈ�� z �ӵ��� 0�� �Ǿ��� ��
           
            
            DeleteObject();

            
        }
        else if (zSpeed != 0f)
        {
            // ������Ʈ�� z �ӵ��� 0�� �ƴ� ���
            ChangeUI();
           
        }
    }

    private void DeleteObject()
    {
        // ������Ʈ ���� ����
        if (objectToDelete != null)
        {
            onbutton_des?.Invoke();
            Destroy(objectToDelete);
            Debug.Log("delete");

        }
    }

    private void ChangeUI()
    {
        // UI ���� ����
        if ( tmp != null) // tmp ������ null���� Ȯ��
        {
            tmp.text = newText;
            Debug.Log("again");
            Invoke("RestoreOriginalUI", delayTime);
        }
    }


    private void RestoreOriginalUI()
    {
        if (tmp != null)
        {
            tmp.text = originalText;
            Debug.Log("Restored to original UI");
        }
    }
}
