using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    private GameObject portalpos;
    private void Start()
    {
        portalpos = GameObject.FindGameObjectWithTag("Player");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == portalpos)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                
            }
        }

    }
}
