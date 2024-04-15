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
    UnityEvent bike_start; //바퀴 돌릴 때마다 실행

    public float angleDifference = 0;   //변하는 각도
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
            StartCoroutine("Count");// 움직이기 위해 0.2초 뒤에 측정
            if (pedaling == true && angle.ft != 0 && angle.ft != 360)
                save = angle.ft;
            
        }

    }

    private IEnumerator Count() //각도 측정 함수 
    {

        yield return new WaitForSeconds(0.3f);


        angleDifference = angle.ft - save;
        if (angleDifference>0 && pedaling1 == true)
        {
            bike_start?.Invoke();
            pedaling1 = false;
        }
         

        StopCoroutine("Count");


        // 함수 내용
    }

    
}
