using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public GameObject firebase;
    public GameObject bike_;
    private RailMove angle;
    private Rigidbody rb;

    private bool saveBol = true; //무한 반복 방지용

    private float save = 0; //그 전에 각도 저장
    private int cnt = 0; // 바퀴 횟수 카운터
    private float result = 0; // 현재 각도 - 그 전에 각도 저장값
    private float angleDifference = 0;
    private int BikeCount = 0;
    private List<float> list =  new List<float>();

    // Count 코루틴 함수 변수
    private bool countBool = true;

    private firebase FirebaseAngle;
    public void Start()
    {
        /*FirebaseAngle = firebase.GetComponent<firebase>();
        angle = pedal.GetComponent<RailMove>();
        //rb = pedal.GetComponent<Rigidbody>();
        StartCoroutine("Save");*/
    }
    //바퀴 수 측정

 
    private IEnumerator Save() //각도 저장 함수 
    {
       while (countBool == true) //무한 반복 방지용
        {
            save = FirebaseAngle.ft;
            yield return new WaitForSeconds(0.3f);// 0.3초 간격으로 저장해주기
            StartCoroutine("Count");// 움직이기 위해 0.2초 뒤에 측정
            
            
        }
        
        // 함수 내용
    }

    private IEnumerator Count() //각도 측정 함수 
    {

        yield return new WaitForSeconds(0.3f);
;
        result =save- FirebaseAngle.ft;
        
        
        if (result >330) 
        {
            cnt++;
            
            
            
            saveBol = false;
        }
        StopCoroutine("Count");
 

        if (cnt == 3)
        {
           
            StopAllCoroutines();
        }
        // 함수 내용
    }

    public void Bike_Count()
    {
        FirebaseAngle = firebase.GetComponent<firebase>();
        angle = bike_.GetComponent<RailMove>();
        //rb = pedal.GetComponent<Rigidbody>();
        StartCoroutine("Save");
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
   
}
