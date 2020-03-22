using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Tanguy SOTO (https://tanguyso.to)
 *
 * Darmstadt, March 2020
 */

public class SceneHandler
{
    public void ReloadCurrentScene(){
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
