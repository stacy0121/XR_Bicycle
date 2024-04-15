using UnityEngine;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.Events;

public class SaveResultFirebase : MonoBehaviour
{
    public ResultData LastResultData { get; private set; }
    DatabaseReference reference;
    private int resultCount; // Firebase�� ����� ��� ����

    // ���� �������� ��������
    public GameObject cog_obj;
    private CogContorller cog_sci;

    // ���� ���� �ҿ� �ð� ��������
    public GameObject time_obj;
    private cog_time time_sci;

    public float playTime;
    // �÷��� �ð� ��������
    public GameObject play_obj;
    private Timer_ play_sci;


    [SerializeField]
    UnityEvent fin; //������ ��

    async void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        cog_sci = cog_obj.GetComponent<CogContorller>();
        time_sci = time_obj.GetComponent<cog_time>();
        play_sci = play_obj.GetComponent<Timer_>();

        // Firebase�� ����� ��� ���� ��������
        resultCount = await GetResultCountFromFirebase();
        await GetLastSavedDataFromFirebase();
        fin?.Invoke();
    }

    public async void call()
    {
        Debug.Log("send");
        playTime = play_sci.recordedTime;
        bool cog1Success = cog_sci.cog1_;
        bool cog2Success = cog_sci.cog2_;
        bool cog3Success = cog_sci.cog3_;
        float cog1Time = time_sci.cog1_time;
        float cog2Time = time_sci.cog2_time;
        float cog3Time = time_sci.cog3_time;
        await SendDataToFirebase(playTime, cog1Success, cog2Success,
 cog3Success, cog1Time, cog2Time, cog3Time);
    }


    public async void send()
    {
        playTime = play_sci.recordedTime;
        bool cog1Success = cog_sci.cog1_;
        bool cog2Success = cog_sci.cog2_;
        bool cog3Success = cog_sci.cog3_;
        float cog1Time = time_sci.cog1_time;
        float cog2Time = time_sci.cog2_time;
        float cog3Time = time_sci.cog3_time;
        await SendDataToFirebase(playTime, cog1Success, cog2Success,
cog3Success, cog1Time, cog2Time, cog3Time);
    }
    public async Task SendDataToFirebase(float playTime, bool
 cog1Success, bool cog2Success, bool cog3Success, float cog1Time, float
 cog2Time, float cog3Time)
    {
        // ����� ������ ��� �̸� ���� (result1, result2, result3, ...)
        string resultKey = "result" + (resultCount + 1);

        // ��� ������ ����
        ResultData resultData = new ResultData
        {
            PlayTime = playTime,
            Cog1Success = cog1Success,
            Cog2Success = cog2Success,
            Cog3Success = cog3Success,
            Cog1Time = cog1Time,
            Cog2Time = cog2Time,
            Cog3Time = cog3Time
        };

        string json = JsonUtility.ToJson(resultData);

        // Firebase�� ������ ����
        await reference.Child(resultKey).SetRawJsonValueAsync(json);

        // ��� ���� ������Ʈ
        resultCount++;
    }

    public async Task<int> GetResultCountFromFirebase()
    {
        // Firebase���� �����͸� �������� �ڵ带 �ۼ��Ͽ� ����� ��� ������ ��ȯ
        // �Ʒ��� ������ �����̸�, ���� �ڵ忡 ������ Firebase ������ ����ؾ� �մϴ�.
        // ���� ����: await reference.Child("results").GetValueAsync();
        // ��� ������ �������� �κ��� �ش� ���� ����� �°� �����ؾ� �մϴ�.
        DataSnapshot snapshot = await reference.GetValueAsync();
        Dictionary<string, object> results = snapshot.Value as
 Dictionary<string, object>;

        if (results != null)
        {
            return results.Count;
        }

        return 0;
    }

    public async Task GetLastSavedDataFromFirebase()
    {

        DataSnapshot snapshot = await reference.GetValueAsync();
        if (snapshot.Exists && snapshot.ChildrenCount > 0)
        {
            // Get the last child in the snapshot
            DataSnapshot lastChild = null;
            foreach (DataSnapshot child in snapshot.Children)
            {
                lastChild = child;
            }

            if (lastChild != null)
            {
                LastResultData =
 JsonUtility.FromJson<ResultData>(lastChild.GetRawJsonValue());
                Debug.Log("PlayTime: " + LastResultData.PlayTime);
                Debug.Log("Cog1Success: " + LastResultData.Cog1Success);
                Debug.Log("Cog2Success: " + LastResultData.Cog2Success);
                Debug.Log("Cog3Success: " + LastResultData.Cog3Success);
                Debug.Log("Cog1Time: " + LastResultData.Cog1Time);
                Debug.Log("Cog2Time: " + LastResultData.Cog2Time);
                Debug.Log("Cog3Time: " + LastResultData.Cog3Time);
            }
        }
        else
        {
            Debug.LogError("No data exists at the specified reference");
        }
    }
}


[System.Serializable]
public class ResultData
{
    public float PlayTime;
    public bool Cog1Success;
    public bool Cog2Success;
    public bool Cog3Success;
    public float Cog1Time;
    public float Cog2Time;
    public float Cog3Time;
}