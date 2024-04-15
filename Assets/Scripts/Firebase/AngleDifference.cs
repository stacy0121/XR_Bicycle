using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AngleDifference : MonoBehaviour
{

    public GameObject firebase;
    private firebase angle;
    private float save = 0;
    private bool pedaling = true;
    private bool pedaling1 = true;
    [SerializeField]
    UnityEvent bike_start; //���� ���� ������ ����

    public float angleDifference = 0;   //���ϴ� ����
    // Start is called before the first frame update
    void Start()
    {
        angle = firebase.GetComponent<firebase>();
        StartCoroutine(Save()); 

    }

    public IEnumerator Save()
    {
       
        while (pedaling == true)
        {

            yield return new WaitForSeconds(0.3f);
            StartCoroutine("Count");// �����̱� ���� 0.2�� �ڿ� ����
            if (pedaling == true && angle.ft != 0 && angle.ft != 360)
                save = angle.ft;
            
        }

    }

    private IEnumerator Count() //���� ���� �Լ� 
    {

        yield return new WaitForSeconds(0.3f);


        angleDifference = angle.ft - save;
        if (angleDifference>0 && pedaling1 == true)
        {
            bike_start?.Invoke();
            pedaling1 = false;
        }
         

        StopCoroutine("Count");


        // �Լ� ����
    }

    
}
