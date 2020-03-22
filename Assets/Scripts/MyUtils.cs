using System;
using UnityEngine;

/*
 * Tanguy SOTO (https://tanguyso.to)
 *
 * Darmstadt, March 2020 
 */

public static class MyUtils
{
    public static bool IsNotNull(string tag, System.Object o){
        if(o == null){
            MyLogger.Error(tag, "is null");
            return false;
        }
        return true;
    }

    public static GameObject GetGM(){
        return GameObject.Find("GameManager");
    }
}
