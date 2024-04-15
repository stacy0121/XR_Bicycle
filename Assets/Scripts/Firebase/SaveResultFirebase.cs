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
    private int resultCount; // Firebase에 저장된 결과 개수

    // 인지 성공여부 가져오기
    public GameObject cog_obj;
    private CogContorller cog_sci;

    // 인지 과제 소요 시간 가져오기
    public GameObject time_obj;
    private cog_time time_sci;

    public float playTime;
    // 플레이 시간 가져오기
    public GameObject play_obj;
    private Timer_ play_sci;


    [SerializeField]
    UnityEvent fin; //끝났을 때

    async void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        cog_sci = cog_obj.GetComponent<CogContorller>();
        time_sci = time_obj.GetComponent<cog_time>();
        play_sci = play_obj.GetComponent<Timer_>();

        // Firebase에 저장된 결과 개수 가져오기
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
        // 결과를 저장할 노드 이름 설정 (result1, result2, result3, ...)
        string resultKey = "result" + (resultCount + 1);

        // 결과 데이터 생성
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

        // Firebase에 데이터 저장
        await reference.Child(resultKey).SetRawJsonValueAsync(json);

        // 결과 개수 업데이트
        resultCount++;
    }

    public async Task<int> GetResultCountFromFirebase()
    {
        // Firebase에서 데이터를 가져오는 코드를 작성하여 저장된 결과 개수를 반환
        // 아래는 간단한 예제이며, 실제 코드에 적합한 Firebase 쿼리를 사용해야 합니다.
        // 쿼리 예제: await reference.Child("results").GetValueAsync();
        // 결과 개수를 가져오는 부분을 해당 쿼리 결과에 맞게 수정해야 합니다.
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