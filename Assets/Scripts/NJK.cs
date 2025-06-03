using UnityEngine;


public static class Njk
{
    public static void Log(string msg)
    {
        Debug.Log(Time.frameCount.ToString() + ": " + msg);
    }
}
