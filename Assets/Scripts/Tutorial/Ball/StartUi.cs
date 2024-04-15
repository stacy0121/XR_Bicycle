using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StartUi : MonoBehaviour
{
    public TMP_Text tmp;
    public TMP_Text tmp1;
    public TMP_Text tmp2;
    // Start is called before the first frame update
   
    public void destroy_tmp()
    {
        Destroy(tmp);
        Destroy(tmp1);
        Destroy(tmp2);
        Debug.Log("»£√‚");
        Destroy(this);
    }
}
