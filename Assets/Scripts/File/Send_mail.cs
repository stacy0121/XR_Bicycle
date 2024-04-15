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
using System.Collections;

public class Send_mail : MonoBehaviour
{
    private bool cog1_ = true;
    private bool cog2_ = false;
    private bool cog3_ = true;
    public float playTime;

    private float cog_time;

    [SerializeField]
    private string emailAddress;
    private string emailPath = Path.Combine(Application.streamingAssetsPath, "Result.txt");

    private string jpgFileName = "email.jpg"; // JPG 파일의 실제 이름으로 변경해주세요.
    private string jpgPath;

    // 인지 과제 성공 여부
    public GameObject cog_obj;
    private CogContorller cog_sci;
    // 플레이 시간 가져오기
    public GameObject play_obj;
    private Timer_ play_sci;


    // 인지 과제 소요 시간 가져오기
    public GameObject time_obj;
    private cog_time time_sci;

    // 메일 한 번만 전송
    private bool canSend = true;

    private void Start()
    {
        cog_sci = cog_obj.GetComponent<CogContorller>();
        play_sci = play_obj.GetComponent<Timer_>();
        time_sci = time_obj.GetComponent<cog_time>();
        canSend = true;
        jpgPath = Path.Combine(Application.streamingAssetsPath, jpgFileName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Send();
        }
    }
    public async void Send()
    {
        //jpg 이미지 변환
        byte[] jpgBytes = File.ReadAllBytes(jpgPath);
        string jpgBase64 = Convert.ToBase64String(jpgBytes);
        string imageDataUrl = "data:image/jpg;base64," + jpgBase64;

        string imageHtml = $"<img src='{imageDataUrl}' alt='Email Image'/>";
        UnityEngine.Debug.Log(imageDataUrl);
        UnityEngine.Debug.Log("전송");
        if (!canSend)
        {
            return;
        }

        canSend = false;

        cog1_ = cog_sci.cog1_;
        cog2_ = cog_sci.cog2_;
        cog3_ = cog_sci.cog3_;

        int numTimes = 0; // 평균을 구할 때 사용할 시간들의 개수
        float totalPlayTime = 0f; // 시간의 총합

        if (time_sci.cog1_time != 120)
        {
            totalPlayTime += time_sci.cog1_time;
            numTimes++;
        }

        if (time_sci.cog2_time != 120)
        {
            totalPlayTime += time_sci.cog2_time;
            numTimes++;
        }

        if (time_sci.cog3_time != 120)
        {
            totalPlayTime += time_sci.cog3_time;
            numTimes++;
        }

        float cog_time = totalPlayTime / numTimes;

        playTime = play_sci.recordedTime;

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("codingcellduk@gmail.com");
        mail.To.Add(emailAddress);
        mail.Subject = "재활 운동회_결과";

        string message1 = cog1_ ? "성공" : "실패";
        string message2 = cog2_ ? "성공" : "실패";
        string message3 = cog3_ ? "성공" : "실패";


        string body = /*"코딩하는 세포들 " + "\n" +
                      "인지 과제 1: " + message1 + "\n" +
                      "인지 과제 2: " + message2 + "\n" +
                      "인지 과제 3: " + message3 + "\n" +
                      "인지 과제 평균 소요 시간: " + cog_time.ToString("F2") + "초" + "\n" +
                      "플레이 시간: " + playTime.ToString("F2") + "초" +*/
                      imageHtml;

        mail.Body = body;
        mail.IsBodyHtml = true; // HTML 형식의 본문을 사용합니다.
                                //pdf 첨부 파일
        /*    Attachment attachment = new Attachment(pdfPath);
            mail.Attachments.Add(attachment);*/

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("codingcellduk@gmail.com", "dgfwwlwuewvkbhrd") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

        await smtpServer.SendMailAsync(mail);

        StartCoroutine(ResetSendFlagAfterDelay(10f));
    }

    private IEnumerator ResetSendFlagAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canSend = true;
    }
}