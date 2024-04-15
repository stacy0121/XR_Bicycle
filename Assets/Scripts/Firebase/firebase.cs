using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
public class firebase : MonoBehaviour
{


    DatabaseReference m_Reference;
    private bool m_IsBreak; //무한반복 방지용
    string angle;
    public GameObject pedal;
    public float ft;
    Vector3 TEST;

  //  private float smoothFactor = 0.2f; // 부드러운 변화를 위한 스무딩 계수
//    private Vector3 smoothRotation;

    private Quaternion currentRotation = Quaternion.identity;
    private Vector3 targetEulerAngles;

    public float smoothingFactor = 0.2f; // 스무딩 계수 (조절 가능한 값)

    private Quaternion targetRotation; // 목표 회전값
    private Quaternion smoothRotation; // 부드러운 회전값
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        m_IsBreak = true;
        StartCoroutine("ReadData");

    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_IsBreak = false;
            Debug.Log(12);
        }
        // 무한반복문 종료

    }

    void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("angle")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {

                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    //  Debug.Log("연결됨");
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    //Debug.Log(snapshot.Value);


                }
            });
    }

    void WriteUserData(string userId, string username)
    {
        m_Reference.Child("users").Child(userId).Child("username").SetValueAsync(username);
    }

    IEnumerator ReadData()
    {
        while (m_IsBreak)
        {

            yield return new WaitForSeconds(0.01f);
            FirebaseDatabase.DefaultInstance.GetReference("angle")
           .GetValueAsync().ContinueWithOnMainThread(task =>
           {

               if (task.IsFaulted)
               {
                   // Handle the error...
               }
               else if (task.IsCompleted)
               {
                   //  Debug.Log("연결됨");
                   DataSnapshot snapshot = task.Result;
                   // Do something with snapshot...
                   //Debug.Log(snapshot.Value.ToString());
                   angle = snapshot.Value.ToString();
                   ft = float.Parse(angle);
                   

                  // ft = Mathf.Repeat(ft, 360f);

                   //Debug.Log(ft);




                   /*Vector3 newRotation = new Vector3(ft, 0,0);
                   pedal.transform.rotation = Quaternion.Euler(newRotation);*/

                   targetRotation = Quaternion.Euler(ft, 0, 0);

                   // 스무딩 계산
                   smoothRotation = Quaternion.Slerp(smoothRotation, targetRotation, smoothingFactor);

                   // 오브젝트에 부드러운 회전값 적용
                   pedal.transform.rotation = smoothRotation;




                   //pedal.transform.rotation = Quaternion.Euler(smoothRotation);

                   //pedal.transform.rotation = Quaternion.Euler(ft, 0.0f, 0.0f);

                   //test.transform.Rotate(new Vector3(ft, 0.0f, 0.0f) * 0.3f);
                   //test.transform.Rotate(new Vector3(f, 0.0f, 0.0f));

                   // TEST = (float.Parse(angle),0.0f,0.0f);
                   // test.transform.Rotate(new Vector3(float.Parse(angle), 0f, 0f) * Time.deltaTime);
               }
           });
        }
    }//
}