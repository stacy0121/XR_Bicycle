/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;



public class angleReset : MonoBehaviour
{
    private string angleS;
    //private int angle;
    DatabaseReference reference;// DatabaseReference 변수 선언
    // Start is called before the first frame update
    void Start()
    {
        Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class Data
    {
        public int angle; //인지 재활(1) 성공 여부 -> 1은 성공,0은 실패
       


        public Data(int angle)
        {
            this.angle = angle;
            
        }
    }
    private void wirteNewData(string name, int angle)
    {
        //클래스 Data 변수를 만들고 받아온 값들을 대입
        Data data = new Data (angle);

        //대입 시킨 클래스 변수 data를 json파일로 변환
        string json = JsonUtility.ToJson(data);
        angleS = angle.ToString();
        FirebaseDatabase.DefaultInstance.GetReference("angle");
        //DatabaseReference 변수에 cog1를 자식으로 변환된 json 파일을 업로드
        reference.Child(name).SetRawJsonValueAsync(angleS);
    }

    public void Save()
    {
        
        wirteNewData("angle", 0); //각각 받아와서 저장하면 됨
        Debug.Log("삽입");
    }
}
*/