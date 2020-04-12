using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour
{
    public GameObject player;
    public static GlobalContainer Global;
    public GameObject inventory;
    public float itemAffinity=5;

    private void Awake()
    {
        Global = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
