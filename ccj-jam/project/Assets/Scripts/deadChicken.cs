using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadChicken : MonoBehaviour
{
    private GameObject playerPos;
    
     void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        
        //Debug.Log(playerPos);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("��ײ��");
        if (collision.gameObject == playerPos)
        {
            // Debug.Log("����" + collision.gameObject.name);
            Object.Destroy(this.gameObject);
        }





    }
}
