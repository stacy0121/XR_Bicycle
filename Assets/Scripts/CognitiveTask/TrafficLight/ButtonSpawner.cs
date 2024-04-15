using UnityEngine;
using System.Diagnostics;
using UnityEngine.Events;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject player;

    public void Spawn()
    {
        UnityEngine.Debug.Log("spawn");
        button.SetActive(true);
        // 앞으로 10만큼 떨어진 목표 위치
        //button.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.5f, player.transform.position.z + 1.5f);
    }


}
