using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TutoBike : MonoBehaviour
{
    public GameObject firebase;
    private firebase angle;
    private float save_cnt = 0;
    private float save = 0;
    Vector3 pos;
    public static int finish;

    private float rotSpeed; //���� �ӵ�


    public float angleDifference = 0;   //���ϴ� ����

    //public GameObject tutorial;  //Ʃ�丮�� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
    //private TutorialControl control; //��ũ��Ʈ


    private Rigidbody rigid;
    private bool pedaling = true;
    private bool cntbool = true;


    //�ӵ� ���� �Լ� ����
    public float movePower;
    public float maxVelocityZ;
    public float minVelocityZ;

    private float currentSpeed = 0f; // ���� �ӵ�

    //ī��Ʈ 
    private int cnt;

    //ī��Ʈ-> ���� ��
    private int rotationCount = 0;


    [SerializeField]
    UnityEvent Count_bike; //���� ���� ������ ����

    // Start is called before the first frame update
    void Start()
    {
        //control = tutorial.GetComponent<TutorialControl>();
        pos = transform.position;
        angle = firebase.GetComponent<firebase>();
        rigid = GetComponent<Rigidbody>();
        save = angle.ft;

    }



    public void StartSave()
    {
        StartCoroutine(Save());
        StartCoroutine(Count_BIKE());
    }

    public IEnumerator Save()
    {
        while (pedaling == true)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(angle_check());
            if (pedaling == true && angle.ft != 0 && angle.ft != 360)
            {
                save = angle.ft;
                save_cnt = angle.ft;
            }

            // Debug.Log(rigid.velocity);

        }
    }

    private IEnumerator angle_check()
    {
        yield return new WaitForSeconds(0.3f);
        if (angle.ft > save)
        {
            angleDifference = angle.ft - save;
        }
        else if (save > angle.ft && angle.ft < 50 && save > 300)
        {
            angleDifference = angle.ft - (save - 360);
        }
        else if (angle.ft == save)
        {
            angleDifference = 0;
        }
        else if (angleDifference == 360)
        {
            angleDifference = 0;
        }
        if (save_cnt > angle.ft)
        {
            if (save_cnt - angle.ft > 5 && cntbool == true)
            {


            }

        }

        Force();

    }



    private void Force()
    {
        if (angleDifference >= 5f)
        {
            currentSpeed += angleDifference * Time.deltaTime;
            ApplyMaxSpeed();

        }

        if (angleDifference < 5 && angleDifference >= 0)
        {
            currentSpeed -= 5f * Time.deltaTime;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;

            }
        }

        MoveObject();
    }

    private void ApplyMaxSpeed()
    {
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxVelocityZ);
    }

    private void MoveObject()
    {
        Vector3 moveVec = transform.forward * currentSpeed;
        rigid.velocity = moveVec;
    }


    private IEnumerator Count_BIKE()
    {
        yield return null;

        float initialAngle = angle.ft; // �ʱ� ���� ����
        float previousAngle = initialAngle; // ���� ���� ����
        bool isFullRotation = false; // �� ���� ���Ҵ��� ����

        while (pedaling == true)
        {
            yield return null;

            float currentAngle = angle.ft;

            if (!isFullRotation && currentAngle < previousAngle)
            {
                if (Mathf.Abs(previousAngle - currentAngle) > 300)
                {
                    rotationCount++;
                    Debug.Log("Rotation Count: " + rotationCount);
                    Count_bike?.Invoke();
                }
                isFullRotation = true; // �� ���� �������� ǥ��
            }

            if (isFullRotation && currentAngle >= initialAngle)
            {
                isFullRotation = false; // �ʱ� ������ �������� �� ���� ���� ���� ���·� �ʱ�ȭ
            }

            previousAngle = currentAngle;
        }

    }
}
