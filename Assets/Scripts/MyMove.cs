﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMove : MonoBehaviour
{
    public Text text;

/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/

    public void ClickMove()
    {
        Debug.Log($"Click '{text.text}'");
    }

}