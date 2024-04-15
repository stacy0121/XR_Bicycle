using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogContorller : MonoBehaviour
{
    public bool cog1_ = false;
    public bool cog2_ = false;
    public bool cog3_ = false;
    public void cog1_suc()
    {
        cog1_ = true;
    }

    public void cog1_fail()
    {
        cog1_ = false;
    }

    public void cog2_suc()
    {
        cog2_ = true;
    }

    public void cog2_fail()
    {
        cog2_ = false;
    }


    public void cog3_suc()
    {
        cog3_ = true;
    }

    public void cog3_fail()
    {
        cog3_ = false;
    }

}
