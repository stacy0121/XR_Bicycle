using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crack : MonoBehaviour
{
    public GameObject cog3_button;
    private ObjectComparer cog3_sci;
    public GameObject cog2_coli;
    private FlowerTask cog2_sci;

    private void Start()
    {
        cog2_sci =  cog2_coli.GetComponent<FlowerTask>();
        cog3_sci = cog3_button.GetComponent<ObjectComparer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Function1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Function2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Function3();
        }
    }

    void Function1()
    {
        Debug.Log("�Լ� 1 ����");
        // ���⿡ �Լ� 1�� ������ �߰��ϼ���.
    }

    void Function2()
    {
        cog2_sci.equal();
        // ���⿡ �Լ� 2�� ������ �߰��ϼ���.
        Debug.Log(3);
    }

    void Function3()
    {
        cog3_sci.equal();
        Debug.Log(2);
    }
}
