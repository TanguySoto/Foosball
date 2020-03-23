using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // === A: Properties === // 

    private static string LogTag = typeof(Player).Name;

    [Tooltip("Color of this player")]
    public MyUtils.PlayerColor PlayerColor;


    // === A: Objects === //

    [Tooltip("Rows controlled by this player")]
    public Row[] Rows;

    [Tooltip("Number of rows the player should control")]
    public int ControlledRowsCount;


    // === F: Lifecycle === //

    void Start()
    {
        StartChecks();        
    }

    void Update()
    {
        
    }

    private void StartChecks()
    {
        // Number of controlled rows
        if(Rows.Length != ControlledRowsCount)
        {
            MyLogger.Error(LogTag, "player " + PlayerColor + " must have "+ ControlledRowsCount +
                                   " controlled rows, " + Rows.Length + " found");
        }

        // Controlled rows' color must match player's color
        for(int i=0; i < Rows.Length; i++)
        {
            MyUtils.IsNotNull(LogTag + ".Rows[" + i + "]", Rows[i]);

            if(Rows[i] != null && Rows[i].RowColor != PlayerColor)
            {
                 MyLogger.Error(LogTag, "player " + PlayerColor + " has row "+ Rows[i].RowType +
                                        " with color " + Rows[i].RowColor);
            }
        }   
    }


    // === F: Modifiers === //

    public void MoveAllRows(float verticalSpeed, float horizontalSpeed)
    {
        if(PlayerColor == MyUtils.PlayerColor.RED)
        {
            verticalSpeed *= -1;

        }
        
        for(int i=0; i < Rows.Length; i++)
        {
            // Translation
            Rows[i].GetComponent<Rigidbody>().MovePosition(Rows[i].transform.position + Vector3.right * Time.deltaTime * verticalSpeed);

            // Rotation
            Quaternion deltaRotation = Quaternion.Euler(Vector3.right * Time.deltaTime * horizontalSpeed);
            Rows[i].GetComponent<Rigidbody>().MoveRotation(Rows[i].GetComponent<Rigidbody>().rotation * deltaRotation);
        }
    }
}
