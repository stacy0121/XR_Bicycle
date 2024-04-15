using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System;
using TMPro;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;


public class PlayTime : MonoBehaviour
{
    //private Fire_InsertData insert;
    public Stopwatch watch;
    public float playTime;
    //public TextMeshPro playTimeUI;
    public TextMeshPro playTimeUIText; // Play 시간을 표시할 TMP_Text 객체
    public TextMeshPro cog1UIText; // 인지과제 1 결과를 표시할 TMP_Text 객체
    public TextMeshPro cog2UIText; // 인지과제 2 결과를 표시할 TMP_Text 객체
    public TextMeshPro cog3UIText; // 인지과제 3 결과를 표시할 TMP_Text 객체
                                   // Play 시간을 표시할 TMP_Text 객체
    public TextMeshPro cog1TimeText; // 인지과제 1 결과를 표시할 TMP_Text 객체
    public TextMeshPro cog2TimeText; // 인지과제 2 결과를 표시할 TMP_Text 객체
    public TextMeshPro cog3TimeText; // 인지과제 3 결과를 표시할 TMP_Text 객체
    private string textPath =
 Path.Combine(Application.streamingAssetsPath, "Result.txt");
    StreamWriter sw;

    [SerializeField]
    private String emailAddress;
    private String emailPath =
 Path.Combine(Application.streamingAssetsPath, "Result.txt");


    //인지 과제

    private bool cog1_ = true;
    private bool cog2_ = false;
    private bool cog3_ = true;




    //인지 성공여부 가져오기
    public GameObject cog_obj;
    private SaveResultFirebase cog_sci;





    [SerializeField]
    UnityEvent fin; //끝났을 때
    private void Start()
    {
        cog_sci = cog_obj.GetComponent<SaveResultFirebase>();



    }
    public void call()
    {


        playTime =168;
        UnityEngine.Debug.Log("playTime : " + playTime);

        string playTimeText = string.Format("{0} 초", playTime);

        bool cog1Success = false;
        bool cog2Success = true;
        bool cog3Success = true;

        string cog1Text = cog1Success ? "O" : "X";
        string cog2Text = cog2Success ? "O" : "X";
        string cog3Text = cog3Success ? "O" : "X";

        float cog1_time = 5;
        float cog2_time = 9;
        float cog3_time = 8;

        if (playTimeUIText != null)
        {
            playTimeUIText.text = playTimeText; // Play 시간 텍스트를 할당합니다.
        }

        if (cog1UIText != null)
        {
            cog1UIText.text = cog1Text; // 인지과제 1 결과 텍스트를 할당합니다.
        }

        if (cog2UIText != null)
        {
            cog2UIText.text = cog2Text; // 인지과제 2 결과 텍스트를 할당합니다.
        }

        if (cog3UIText != null)
        {
            cog3UIText.text = cog3Text; // 인지과제 3 결과 텍스트를 할당합니다.
        }
        string cog1TimeTextValue = cog1_time != 120 ?
 cog1_time.ToString() : "-";
        string cog2TimeTextValue = cog2_time != 120 ?
 cog2_time.ToString() : "-";
        string cog3TimeTextValue = cog3_time != 120 ?
 cog3_time.ToString() : "-";

        if (cog1TimeText != null)
        {
            cog1TimeText.text = cog1TimeTextValue; // 인지과제 1 시간을 텍스트에 할당합니다.
        }

        if (cog2TimeText != null)
        {
            cog2TimeText.text = cog2TimeTextValue; // 인지과제 2 시간을 텍스트에 할당합니다.
        }

        if (cog3TimeText != null)
        {
            cog3TimeText.text = cog3TimeTextValue; // 인지과제 3 시간을 텍스트에 할당합니다.
        }
    }



}