using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Tanguy SOTO (https://tanguyso.to)
 *
 * Darmstadt, March 2020
 */

public class InputHandler : MonoBehaviour
{
    // === F: Lifecycle === //

    void Start(){
       
    }

    void Update(){
        HandleMouseClick();
    }

    protected void HandleMouseClick(){
        if(Input.GetButtonDown("Fire1")){
            
        }
        if(Input.GetButtonUp("Fire1")){
            
        }
    }
}
