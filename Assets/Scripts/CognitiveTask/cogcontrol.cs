using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class cogcontrol : MonoBehaviour
{

    [SerializeField]
    UnityEvent one; // ù��°

    [SerializeField]
    UnityEvent two; // �ι�°

    [SerializeField]
    UnityEvent three; // ������

    // Start is called before the first frame update
 
    public void oneStart()
    {
        one?.Invoke();
    }

    public void twoStart()
    {
        two?.Invoke();
    }

    public void threeStart()
    {
        three?.Invoke();
    }
}
