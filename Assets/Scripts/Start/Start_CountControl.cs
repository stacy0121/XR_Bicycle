using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_CountControl : MonoBehaviour
{
    public int cnt = 0;
    private bool cnt_bool = true; //�ѹ��� ����

    public void count()
    {
        cnt++;
        Debug.Log(cnt);
        check();
    }

    public void check()
    {
        if (cnt == 1 && cnt_bool == true)
        {
            cnt_bool = false;
            SceneManager.LoadScene("Tutorial");
        }
    }
}
