using UnityEngine;
using System.IO.Ports;

public class serial : MonoBehaviour
{
    SerialPort m_SerialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    // Start is called before the first frame update
    
    void Start()
    {
        // ��Ʈ �̸� ��������
        string[] portNames = SerialPort.GetPortNames();

        // ��Ʈ �̸��� �����ϴ� ��쿡�� �ø��� ��Ʈ ����
        if (portNames.Length > 0)
        {
        
            
            m_SerialPort.Open();

            if (m_SerialPort.IsOpen)
            {
                Debug.Log("�ø��� ��Ʈ�� ���������� ���Ƚ��ϴ�. ��Ʈ �̸�: " + m_SerialPort.PortName);
                SerialPortWrite("HIGH");
            }
            else
            {
                Debug.Log("�ø��� ��Ʈ ���� ����");
            }
        }
        else
        {
            Debug.Log("��� ������ �ø��� ��Ʈ�� �����ϴ�.");
        }

        /*
                if (m_SerialPort.IsOpen)  //�ø�����Ʈ�� ���� ���� ������
                {
                    Debug.Log("����");
                }

                Debug.Log(12);
                m_SerialPort.Open();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SerialPortWrite("LOW"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
            Debug.Log(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SerialPortWrite("HIGH"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
            Debug.Log(2);
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end")){
            SerialPortWrite("LOW"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.

            print("END");
            
        }
    }

    

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("end")){
            SerialPortWrite("LOW"); // �Ƶ��̳뿡 ����Ǿ� �ִ� string�� �����ϴ�.
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
            Debug.Log("�ø��� ��Ʈ�� ���� ���� �ʽ��ϴ�.");
        }
    }
    void sendLow()
    {
        SerialPortWrite("LOW");
    }
}
