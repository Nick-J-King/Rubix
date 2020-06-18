using UnityEngine;
using System.Collections;

public static class NJK
{
    public static void Log(string msg)
    {
        Debug.Log(Time.frameCount + ": " + msg);
    }
}
