using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class AppearUI : MonoBehaviour
{
    public TMP_Text tmp;
    public string text_1;

    [SerializeField]
    UnityEvent onUI; //UI�� ������ ���۵� �Լ�


    // Start is called before the first frame update

    public void Start()
    {
        
    }
    public void appear_UI()
    {
        Invoke("Appear_UI_start", 0.5f);
        
    }

    public void Appear_UI_start()
    {
        tmp.text = text_1;
        tmp.gameObject.SetActive(true);
    }

    public void start_Deactive()
    {
        Invoke("DeactivateText", 3f); // 5�� �ڿ� DeactivateText() �Լ� ȣ��
    }

    private void DeactivateText()
    {
        tmp.gameObject.SetActive(false);
        onUI?.Invoke();
    }
    

}
