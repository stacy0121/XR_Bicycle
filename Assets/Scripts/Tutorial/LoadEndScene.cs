using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndScene : MonoBehaviour
{
    public void EndScene()
    {
        SceneManager.LoadScene("end");
    }
}
