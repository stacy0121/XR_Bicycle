using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class RandomBallCreate : MonoBehaviour
{
    public GameObject ball; // 생성할 오브젝트
    [SerializeField] UnityEvent onCreate;

    public GameObject target; // 이동할 위치
    public GameObject spawner; // 소환할 위치
    private bool random = true;
    public int result = 0;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        Debug.Log(transform.position);
        agent.enabled = true; // NavMeshAgent 활성화
        agent.SetDestination(target.transform.position);
    }

    public void moveStart()
    {
        Debug.Log("시작");
        StartCoroutine("move");
    }

    private IEnumerator move()
    {
        agent.enabled = true; // NavMeshAgent 활성화
        agent.SetDestination(target.transform.position);

        // 해당 오브젝트 활성화
        gameObject.SetActive(true);

        yield return null;
    }
}
