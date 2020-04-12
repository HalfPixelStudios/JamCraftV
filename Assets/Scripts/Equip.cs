using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    private List<Item> inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<Item>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            inventory.Add(other.gameObject.GetComponent<Item>());
            Destroy(other.gameObject);
            
        }
    }
}
