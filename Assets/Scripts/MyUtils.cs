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

    public enum PlayerColor {
        RED,
        BLUE
    }

    public enum RowType {
        GOAL_KEEPER,
        DEFENSE,
        MIDDLE,
        ATTACK
    }

    // List all GameObject tags created in editor
    public static class TAGS {
        public static string BALL   = "Ball";
        public static string ROW    = "Row";
        public static string MAN    = "Man";
        public static string FIELD  = "Field";
    }
}
