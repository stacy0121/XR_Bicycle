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
    public float angleDifference = 0;   //변하는 각도
    private bool pedaling = true;
    public static int finish;
    public TextMeshPro velocityUI;
    public float currentSpeedMPS;

    //속도 제한 함수 변수
    private float maxVelocityZ = 2;
    private float moveSpeed = 5;

    [SerializeField]
    UnityEvent when_zero; // 속도 0이 되었을 때

    private Coroutine saveCoroutine; // Save 코루틴 참조를 저장할 변수
    private Coroutine countCoroutine; // Count 코루틴 참조를 저장할 변수

    private float angleResetInterval = 3f; // 각도 초기화 간격
    private float angleResetTimer = 0f; // 각도 초기화 타이머


    // Start is called before the first frame update
    private void Awake()
    {
        angle = firebase.GetComponent<firebase>();
        rb = GetComponent<Rigidbody>();
        save = angle.ft; //초기에 저장된 값 때문에 앞으로 나가는 것을 방지하기 위해 시작하자마자 값을 지정해준다.
    }

    private void Update()
    {
        // 속도 벡터의 크기(크기)를 취하여 현재 속도(미터/초) 얻기
        currentSpeedMPS = rb.velocity.magnitude / Time.deltaTime;
    }

    public void StartSave()   // firebase 이벤트로 호출
    {
        StartCoroutine("Save");
        Debug.Log(1);
    }
    public IEnumerator Save()
    {
        while (pedaling == true)   // 저장 반복
        {
            yield return new WaitForSeconds(0.3f);   // 움직이기 위해 0.3초 뒤에 측정
            StartCoroutine("Count");
            if (pedaling == true && angle.ft != 0 && angle.ft != 360)
                save = angle.ft;
            Force();

            // 속도 ui
            velocityUI.text = string.Format("{0:0.00} m/s", currentSpeedMPS);
        }

      

    }

    private IEnumerator Count() //각도 측정 함수 
    {
      
        yield return new WaitForSeconds(0.3f);

        if (angle.ft > save)
        {
            angleDifference = angle.ft - save;
        }
        else if (save>angle.ft && angle.ft<50 &&save>300)   // 저장한 건 300보다 크고, 저장하지 않은 건 50보다 작은 경우
        {
            angleDifference = angle.ft - (save -360);
            
        }

        StopCoroutine("Count");

        angleResetTimer += 0.3f; // 타이머 증가
        if (angleResetTimer >= angleResetInterval)
        {
            angleDifference = 0; // 각도 초기화
            angleResetTimer = 0f; // 타이머 초기화
            when_zero?.Invoke();
        }


        // 함수 내용
    }

    // Update is called once per frame
    /*void Update()
    {
        angleDifference = save - angle.ft;
        Invoke("Save", 3.0f);   // 1초 전 각도 저장
    }*/

    /*private void Save()   // 1초 전 각도 저장
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
        
        if (angleDifference >= 3f && pedaling == true)   // 이동
        {
            if (rb.velocity.z > maxVelocityZ)   // 최대 속도보다 크면 
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

        else if (angleDifference < 2 && angleDifference >=0)   // 멈출 때
        {
            //Debug.Log(rigid.velocity.z);
            if (rb.velocity.z <= 0)   // 완전히 멈추기
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

    public void Stop()   // 정지
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
        if (saveCoroutine != null) // 실행 중인 경우에만 중지
        {
            StopCoroutine(saveCoroutine);
            saveCoroutine = null;
            pedaling = false; // 반복문 중지
            Debug.Log("Save coroutine stopped");
        }
    }
    //1초 안에 addForce의 속도를 더해주지 않는다면 속도의 감속이 이루어질 것.

    public void StopCount()
    {
        if (countCoroutine != null) // 실행 중인 경우에만 중지
        {
            StopCoroutine(countCoroutine);
            countCoroutine = null;
            Debug.Log("Count coroutine stopped");
        }
    }
}


