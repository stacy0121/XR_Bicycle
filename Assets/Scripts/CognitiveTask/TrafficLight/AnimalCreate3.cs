using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AnimalCreate3 : MonoBehaviour
{
    public GameObject animal; //������ ������Ʈ
    public GameObject target; //�̵��� ��ġ
    public GameObject spawner; //��ȯ�� ��ġ
    public int result = 0;

    private NavMeshAgent nav;

    private void Awake()
    {
        nav = this.GetComponent<NavMeshAgent>();
        Debug.Log(transform.position);
        nav.SetDestination(target.transform.position);
    }

    public void moveStart()
    {
       Debug.Log("����");
       StartCoroutine("move");
    }
    private IEnumerator move()
    {
        nav.SetDestination(target.transform.position);
        yield return null;
    }
}
