using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class Furnace : MonoBehaviour
{
    private bool touching;
    private bool building = true;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Time.timeScale = 0;
                Global.inventory.SetActive(true);
                

            }
        }
        
        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touching = true;

        }
        
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            touching = false;

        }
        
    }
}
