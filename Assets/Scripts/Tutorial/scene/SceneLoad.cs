using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private string nextSceneName;
    public GameObject level_cnt_0bj;
    private level_cnt level_sci;
    private void Start()
    {
        level_sci = level_cnt_0bj.GetComponent<level_cnt>();
    }
    public void LoadNextScene(int cnt)
    {
        cnt = level_sci.cnt;
        if (cnt == 0)
        {
            nextSceneName = "Step1";
        }
        else if (cnt >= 1 && cnt < 3)
        {
            nextSceneName = "Step2";
        }
        else if (cnt >= 3 && cnt <= 4)
        {
            nextSceneName = "Step3";
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
