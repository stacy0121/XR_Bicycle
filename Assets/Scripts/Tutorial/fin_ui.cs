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
    UnityEvent onUI; //UI�� ������ ���۵� �Լ�

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
                levelMessage = "����� 1�ܰ��Դϴ�.";
                break;
            case 1:
            case 2:
                levelMessage = "����� 2�ܰ��Դϴ�.";
                break;
            case 3:
            case 4:
                levelMessage = "����� 3�ܰ��Դϴ�.";
                break;
            default:
                levelMessage = "�� �� ���� �ܰ��Դϴ�.";
                break;
        }

        levelText.text = levelMessage;
        levelText.gameObject.SetActive(true);
    }

    public void start_Deactive()
    {
        Invoke("DeactivateText", 3f); // 5�� �ڿ� DeactivateText() �Լ� ȣ��
    }

    private void DeactivateText()
    {
        levelText.gameObject.SetActive(false);
        onUI?.Invoke();
    }
}
