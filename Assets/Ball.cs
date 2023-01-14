using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     public float velocidade = 20;

     void FixedUpdate()
     {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward);
     }

     void OnTriggerEnter(Collider collisationObject)
     {
        if(collisationObject.tag == "Inimigo")
        {
            Destroy(collisationObject.gameObject);
        }

        
     }
}
