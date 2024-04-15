using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class cogcontrol : MonoBehaviour
{

    [SerializeField]
    UnityEvent one; // 첫번째

    [SerializeField]
    UnityEvent two; // 두번째

    [SerializeField]
    UnityEvent three; // 세번쨰

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
