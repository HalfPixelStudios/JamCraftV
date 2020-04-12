using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This component is mainly used as a data container

public class Material : MonoBehaviour
{
    //used for display on ground and in inventory
    public Sprite icon;
    public enum Classification
    {
        ORE,
        GEM,
        WEAPON,

    }
    [SerializeField] private String name;

    public Classification classification;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
