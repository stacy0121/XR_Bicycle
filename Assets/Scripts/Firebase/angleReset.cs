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
    DatabaseReference reference;// DatabaseReference ���� ����
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
        public int angle; //���� ��Ȱ(1) ���� ���� -> 1�� ����,0�� ����
       


        public Data(int angle)
        {
            this.angle = angle;
            
        }
    }
    private void wirteNewData(string name, int angle)
    {
        //Ŭ���� Data ������ ����� �޾ƿ� ������ ����
        Data data = new Data (angle);

        //���� ��Ų Ŭ���� ���� data�� json���Ϸ� ��ȯ
        string json = JsonUtility.ToJson(data);
        angleS = angle.ToString();
        FirebaseDatabase.DefaultInstance.GetReference("angle");
        //DatabaseReference ������ cog1�� �ڽ����� ��ȯ�� json ������ ���ε�
        reference.Child(name).SetRawJsonValueAsync(angleS);
    }

    public void Save()
    {
        
        wirteNewData("angle", 0); //���� �޾ƿͼ� �����ϸ� ��
        Debug.Log("����");
    }
}
*/