using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class RailMove : MonoBehaviour
{
    [SerializeField]
    private GameObject firebase;
    private firebase angle;
    private Rigidbody rb;
    private float save = 0;
    public float angleDifference = 0;   //���ϴ� ����
    private bool pedaling = true;
    public static int finish;
    public TextMeshPro velocityUI;
    public float currentSpeedMPS;

    //�ӵ� ���� �Լ� ����
    private float maxVelocityZ = 2;
    private float moveSpeed = 5;

    [SerializeField]
    UnityEvent when_zero; // �ӵ� 0�� �Ǿ��� ��

    private Coroutine saveCoroutine; // Save �ڷ�ƾ ������ ������ ����
    private Coroutine countCoroutine; // Count �ڷ�ƾ ������ ������ ����

    private float angleResetInterval = 3f; // ���� �ʱ�ȭ ����
    private float angleResetTimer = 0f; // ���� �ʱ�ȭ Ÿ�̸�


    // Start is called before the first frame update
    private void Awake()
    {
        angle = firebase.GetComponent<firebase>();
        rb = GetComponent<Rigidbody>();
        save = angle.ft; //�ʱ⿡ ����� �� ������ ������ ������ ���� �����ϱ� ���� �������ڸ��� ���� �������ش�.
    }

    private void Update()
    {
        // �ӵ� ������ ũ��(ũ��)�� ���Ͽ� ���� �ӵ�(����/��) ���
        currentSpeedMPS = rb.velocity.magnitude / Time.deltaTime;
    }

    public void StartSave()   // firebase �̺�Ʈ�� ȣ��
    {
        StartCoroutine("Save");
        Debug.Log(1);
    }
    public IEnumerator Save()
    {
        while (pedaling == true)   // ���� �ݺ�
        {
            yield return new WaitForSeconds(0.3f);   // �����̱� ���� 0.3�� �ڿ� ����
            StartCoroutine("Count");
            if (pedaling == true && angle.ft != 0 && angle.ft != 360)
                save = angle.ft;
            Force();

            // �ӵ� ui
            velocityUI.text = string.Format("{0:0.00} m/s", currentSpeedMPS);
        }

      

    }

    private IEnumerator Count() //���� ���� �Լ� 
    {
      
        yield return new WaitForSeconds(0.3f);

        if (angle.ft > save)
        {
            angleDifference = angle.ft - save;
        }
        else if (save>angle.ft && angle.ft<50 &&save>300)   // ������ �� 300���� ũ��, �������� ���� �� 50���� ���� ���
        {
            angleDifference = angle.ft - (save -360);
            
        }

        StopCoroutine("Count");

        angleResetTimer += 0.3f; // Ÿ�̸� ����
        if (angleResetTimer >= angleResetInterval)
        {
            angleDifference = 0; // ���� �ʱ�ȭ
            angleResetTimer = 0f; // Ÿ�̸� �ʱ�ȭ
            when_zero?.Invoke();
        }


        // �Լ� ����
    }

    // Update is called once per frame
    /*void Update()
    {
        angleDifference = save - angle.ft;
        Invoke("Save", 3.0f);   // 1�� �� ���� ����
    }*/

    /*private void Save()   // 1�� �� ���� ����
    {
        if (pedaling == true && angle.ft != 0 && angle.ft != 180) 
            save = angle.ft;
        Force();

    }*/

    /*  public void Force()
      {
          if (angleDifference >= 5f)
          {
              rb.AddForce(transform.forward * angleDifference * Time.deltaTime, ForceMode.Force);

          }

          else
          {
              rb.AddForce(transform.forward * 0.1f * Time.deltaTime, ForceMode.Force);
              //Debug.Log(2);
              //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z );
          }
      }*/

    
    private void Force()
    {
        
        if (angleDifference >= 3f && pedaling == true)   // �̵�
        {
            if (rb.velocity.z > maxVelocityZ)   // �ִ� �ӵ����� ũ�� 
            {
                rb.velocity = new Vector3(0, 0, maxVelocityZ);
                //Debug.Log(maxVelocityZ);
            }
            else
            {
                Vector3 moveVec = transform.forward * angleDifference * Time.deltaTime * moveSpeed;   // new Vector3(0, 0, 1) * angleDifference
                rb.AddForce(moveVec, ForceMode.Force);
                Debug.Log(moveVec.z);
            }
            //Debug.Log(rigid.velocity);

        }

        else if (angleDifference < 2 && angleDifference >=0)   // ���� ��
        {
            //Debug.Log(rigid.velocity.z);
            if (rb.velocity.z <= 0)   // ������ ���߱�
            {
                rb.velocity = Vector3.zero;
                //Debug.Log("zero");
            }
            else {
                Vector3 moveVec = transform.forward * -1000f * Time.deltaTime;
                rb.AddForce(moveVec, ForceMode.Force);
            }
        }
    }

    public void Stop()   // ����
    {
        pedaling = false;
        rb.velocity = Vector3.zero;
        StopCoroutine(Save());
    }

    public void Pedal()
    {
        pedaling = true;
        angleDifference = 0;
        
    }

    public void StopSave()
    {
        if (saveCoroutine != null) // ���� ���� ��쿡�� ����
        {
            StopCoroutine(saveCoroutine);
            saveCoroutine = null;
            pedaling = false; // �ݺ��� ����
            Debug.Log("Save coroutine stopped");
        }
    }
    //1�� �ȿ� addForce�� �ӵ��� �������� �ʴ´ٸ� �ӵ��� ������ �̷���� ��.

    public void StopCount()
    {
        if (countCoroutine != null) // ���� ���� ��쿡�� ����
        {
            StopCoroutine(countCoroutine);
            countCoroutine = null;
            Debug.Log("Count coroutine stopped");
        }
    }
}


