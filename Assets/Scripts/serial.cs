using UnityEngine;
using System.IO.Ports;

public class serial : MonoBehaviour
{
    SerialPort m_SerialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    // Start is called before the first frame update
    
    void Start()
    {
        // 포트 이름 가져오기
        string[] portNames = SerialPort.GetPortNames();

        // 포트 이름이 존재하는 경우에만 시리얼 포트 열기
        if (portNames.Length > 0)
        {
        
            
            m_SerialPort.Open();

            if (m_SerialPort.IsOpen)
            {
                Debug.Log("시리얼 포트가 성공적으로 열렸습니다. 포트 이름: " + m_SerialPort.PortName);
                SerialPortWrite("HIGH");
            }
            else
            {
                Debug.Log("시리얼 포트 열기 실패");
            }
        }
        else
        {
            Debug.Log("사용 가능한 시리얼 포트가 없습니다.");
        }

        /*
                if (m_SerialPort.IsOpen)  //시리얼포트가 열려 있지 않으면
                {
                    Debug.Log("열림");
                }

                Debug.Log(12);
                m_SerialPort.Open();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SerialPortWrite("LOW"); // 아두이노에 저장되어 있는 string을 보냅니다.
            Debug.Log(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SerialPortWrite("HIGH"); // 아두이노에 저장되어 있는 string을 보냅니다.
            Debug.Log(2);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end")){
            SerialPortWrite("LOW"); // 아두이노에 저장되어 있는 string을 보냅니다.

            print("END");
            
        }
    }

    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("end")){
            SerialPortWrite("LOW"); // 아두이노에 저장되어 있는 string을 보냅니다.
            print(1);
        }
    }

    void SerialPortWrite(string message)
    {
        if (m_SerialPort.IsOpen)
        {
            m_SerialPort.Write(message);
            
        }
        else
        {
            Debug.Log("시리얼 포트가 열려 있지 않습니다.");
        }
    }
    void sendLow()
    {
        SerialPortWrite("LOW");
    }
}
