using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public GameObject firebase;
    public GameObject bike_;
    private RailMove angle;
    private Rigidbody rb;

    private bool saveBol = true; //���� �ݺ� ������

    private float save = 0; //�� ���� ���� ����
    private int cnt = 0; // ���� Ƚ�� ī����
    private float result = 0; // ���� ���� - �� ���� ���� ���尪
    private float angleDifference = 0;
    private int BikeCount = 0;
    private List<float> list =  new List<float>();

    // Count �ڷ�ƾ �Լ� ����
    private bool countBool = true;

    private firebase FirebaseAngle;
    public void Start()
    {
        /*FirebaseAngle = firebase.GetComponent<firebase>();
        angle = pedal.GetComponent<RailMove>();
        //rb = pedal.GetComponent<Rigidbody>();
        StartCoroutine("Save");*/
    }
    //���� �� ����

 
    private IEnumerator Save() //���� ���� �Լ� 
    {
       while (countBool == true) //���� �ݺ� ������
        {
            save = FirebaseAngle.ft;
            yield return new WaitForSeconds(0.3f);// 0.3�� �������� �������ֱ�
            StartCoroutine("Count");// �����̱� ���� 0.2�� �ڿ� ����
            
            
        }
        
        // �Լ� ����
    }

    private IEnumerator Count() //���� ���� �Լ� 
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
        // �Լ� ����
    }

    public void Bike_Count()
    {
        FirebaseAngle = firebase.GetComponent<firebase>();
        angle = bike_.GetComponent<RailMove>();
        //rb = pedal.GetComponent<Rigidbody>();
        StartCoroutine("Save");
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
   
}
