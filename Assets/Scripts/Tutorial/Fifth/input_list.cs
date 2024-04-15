using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class input_list : MonoBehaviour
{
    public GameObject fif_result; // 선택한 오브젝트
    private result_txt_list result_list_sci;
    public TMP_Text result;

    [SerializeField]
    UnityEvent when_insert; //삽입할 때마다 실행

    private void Start()
    {
        result_list_sci = fif_result.GetComponent<result_txt_list>();
    }

    public void AddTextToList(TMP_Text text)
    {
        if (result_list_sci != null)
        {
            List<TMP_Text> resultList = result_list_sci.result_lis;
            if (resultList != null)
            {
                resultList.Add(result);
                when_insert?.Invoke();
            }
            else
            {
                Debug.LogError("result_lis is null.");
            }
        }
        else
        {
            Debug.LogError("result_list_sci is null.");
        }
    }

}
