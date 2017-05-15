using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
    
   

    // Use this for initialization
    private void Update()
    {
        
   if(Input.GetKey(KeyCode.E))
 {
            GetComponent <Collider2D>().enabled = false;
 }
       
    }

    

 
}
