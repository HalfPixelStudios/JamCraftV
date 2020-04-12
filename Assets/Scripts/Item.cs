using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class Item : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = GetComponent<Material>().icon;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //slight affinity towards player
        if (Vector3.Distance(Global.player.transform.position, transform.position)<Global.itemAffinity)
        {
            
            
        }
        
        
    }
}
