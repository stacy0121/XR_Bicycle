using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AnimalCreate3 : MonoBehaviour
{
    public GameObject animal; //생성할 오브젝트
    public GameObject target; //이동할 위치
    public GameObject spawner; //소환할 위치
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
       Debug.Log("시작");
       StartCoroutine("move");
    }
    private IEnumerator move()
    {
        nav.SetDestination(target.transform.position);
        yield return null;
    }
}
