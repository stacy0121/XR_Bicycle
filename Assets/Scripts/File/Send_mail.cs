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

    private string jpgFileName = "email.jpg"; // JPG ������ ���� �̸����� �������ּ���.
    private string jpgPath;

    // ���� ���� ���� ����
    public GameObject cog_obj;
    private CogContorller cog_sci;
    // �÷��� �ð� ��������
    public GameObject play_obj;
    private Timer_ play_sci;


    // ���� ���� �ҿ� �ð� ��������
    public GameObject time_obj;
    private cog_time time_sci;

    // ���� �� ���� ����
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
        //jpg �̹��� ��ȯ
        byte[] jpgBytes = File.ReadAllBytes(jpgPath);
        string jpgBase64 = Convert.ToBase64String(jpgBytes);
        string imageDataUrl = "data:image/jpg;base64," + jpgBase64;

        string imageHtml = $"<img src='{imageDataUrl}' alt='Email Image'/>";
        UnityEngine.Debug.Log(imageDataUrl);
        UnityEngine.Debug.Log("����");
        if (!canSend)
        {
            return;
        }

        canSend = false;

        cog1_ = cog_sci.cog1_;
        cog2_ = cog_sci.cog2_;
        cog3_ = cog_sci.cog3_;

        int numTimes = 0; // ����� ���� �� ����� �ð����� ����
        float totalPlayTime = 0f; // �ð��� ����

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
        mail.Subject = "��Ȱ �ȸ_���";

        string message1 = cog1_ ? "����" : "����";
        string message2 = cog2_ ? "����" : "����";
        string message3 = cog3_ ? "����" : "����";


        string body = /*"�ڵ��ϴ� ������ " + "\n" +
                      "���� ���� 1: " + message1 + "\n" +
                      "���� ���� 2: " + message2 + "\n" +
                      "���� ���� 3: " + message3 + "\n" +
                      "���� ���� ��� �ҿ� �ð�: " + cog_time.ToString("F2") + "��" + "\n" +
                      "�÷��� �ð�: " + playTime.ToString("F2") + "��" +*/
                      imageHtml;

        mail.Body = body;
        mail.IsBodyHtml = true; // HTML ������ ������ ����մϴ�.
                                //pdf ÷�� ����
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