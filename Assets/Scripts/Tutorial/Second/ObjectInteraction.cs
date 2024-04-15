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

    public float delayTime = 5f; // UI 변경까지의 지연 시간
    [SerializeField]
    UnityEvent onbutton_des; //UI가 끝나고 시작될 함수


    private bool isDeleteObjectCalled = false; //함수 호출 여부 확인
    public float maxTime = 60f; // 최대 삭제 시간



    public void call()
    {

        float zSpeed = bikeObject.GetComponent<Rigidbody>().velocity.z;

        if (zSpeed == 0f )
        {
            // 오브젝트의 z 속도가 0이 되었을 때
           
            
            DeleteObject();

            
        }
        else if (zSpeed != 0f)
        {
            // 오브젝트의 z 속도가 0이 아닌 경우
            ChangeUI();
           
        }
    }

    private void DeleteObject()
    {
        // 오브젝트 삭제 로직
        if (objectToDelete != null)
        {
            onbutton_des?.Invoke();
            Destroy(objectToDelete);
            Debug.Log("delete");

        }
    }

    private void ChangeUI()
    {
        // UI 변경 로직
        if ( tmp != null) // tmp 변수가 null인지 확인
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
