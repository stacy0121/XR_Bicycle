using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class RandomBallCreate : MonoBehaviour
{
    public GameObject ball; // ������ ������Ʈ
    [SerializeField] UnityEvent onCreate;

    public GameObject target; // �̵��� ��ġ
    public GameObject spawner; // ��ȯ�� ��ġ
    private bool random = true;
    public int result = 0;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        Debug.Log(transform.position);
        agent.enabled = true; // NavMeshAgent Ȱ��ȭ
        agent.SetDestination(target.transform.position);
    }

    public void moveStart()
    {
        Debug.Log("����");
        StartCoroutine("move");
    }

    private IEnumerator move()
    {
        agent.enabled = true; // NavMeshAgent Ȱ��ȭ
        agent.SetDestination(target.transform.position);

        // �ش� ������Ʈ Ȱ��ȭ
        gameObject.SetActive(true);

        yield return null;
    }
}
