using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class AppearUI3 : MonoBehaviour
{
    public TMP_Text tmp;
    public string text_1;

    public void appear_UI()
    {
        Invoke("Appear_UI_start", 0.5f);
        
    }

    public void Appear_UI_start()
    {
        tmp.text = text_1;
        tmp.gameObject.SetActive(true);
        Invoke("DeactivateText", 3f); // 5초 뒤에 DeactivateText() 함수 호출
    }

    private void DeactivateText()
    {
        tmp.gameObject.SetActive(false);
    }
    

}
