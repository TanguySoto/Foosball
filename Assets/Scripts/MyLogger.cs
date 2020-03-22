using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Tanguy SOTO (https://tanguyso.to)
 *
 * Darmstadt, March 2020
 */

public static class MyLogger
{
    private static ILogger logger = Debug.unityLogger;

    public static void Info(string tag, string message){
        logger.Log(tag, message);
    }

    public static void Warning(string tag, string message){
        logger.LogWarning(tag, message);
    }

    public static void Error(string tag, string message){
        logger.LogError(tag, message);
    }
}
