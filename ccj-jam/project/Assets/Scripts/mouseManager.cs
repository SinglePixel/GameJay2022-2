using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseManager : MonoBehaviour
{
    private Ray ary;
    private RaycastHit hitInfo;
    //int i = 0;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             ary = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ary,out hitInfo)&&hitInfo.collider.tag=="wall")
            {
                transform.GetComponent<Wallmove>().enabled = true;

 
            }

            
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (transform.GetComponent<Wallmove>().enabled == true)

            {
                transform.GetComponent<Wallmove>().enabled = false;
            }
        }

    }
}
