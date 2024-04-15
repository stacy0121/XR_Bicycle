using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class fin_ui : MonoBehaviour
{

    public TMP_Text levelText;
    private int cnt;


    [SerializeField]
    UnityEvent onUI; //UI가 끝나고 시작될 함수

    public GameObject level_cnt_0bj;
    private level_cnt level_sci;
    private void Start()
    {
        level_sci = level_cnt_0bj.GetComponent<level_cnt>();
    }


    public void SetLevel(int level)
    {
        int cnt = level_sci.cnt;
        string levelMessage;

        switch (cnt)
        {
            case 0:
                levelMessage = "당신은 1단계입니다.";
                break;
            case 1:
            case 2:
                levelMessage = "당신은 2단계입니다.";
                break;
            case 3:
            case 4:
                levelMessage = "당신은 3단계입니다.";
                break;
            default:
                levelMessage = "알 수 없는 단계입니다.";
                break;
        }

        levelText.text = levelMessage;
        levelText.gameObject.SetActive(true);
    }

    public void start_Deactive()
    {
        Invoke("DeactivateText", 3f); // 5초 뒤에 DeactivateText() 함수 호출
    }

    private void DeactivateText()
    {
        levelText.gameObject.SetActive(false);
        onUI?.Invoke();
    }
}
