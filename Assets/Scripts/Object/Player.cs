using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // === A: Properties === // 

    private static string LogTag = typeof(Player).Name;

    [Tooltip("Color of this player")]
    public MyUtils.PlayerColor playerColor;


    // === A: Objects === //

    [Header("Rows")]
    [Tooltip("Rows controlled by this player")]
    public Row[] rows;

    [Tooltip("Number of rows the player should control")]
    public int controlledrowsCount;


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
        if(rows.Length != controlledrowsCount)
        {
            MyLogger.Error(LogTag, "player " + playerColor + " must have "+ controlledrowsCount +
                                   " controlled rows, " + rows.Length + " found");
        }

        // Controlled rows' color must match player's color
        for(int i=0; i < rows.Length; i++)
        {
            MyUtils.IsNotNull(LogTag + ".rows[" + i + "]", rows[i]);

            if(rows[i] != null && rows[i].rowColor != playerColor)
            {
                 MyLogger.Error(LogTag, "player " + playerColor + " has row "+ rows[i].rowType +
                                        " with color " + rows[i].rowColor);
            }
        }   
    }


    // === F: Modifiers === //

    public void MoveAllRows(float verticalSpeed, float horizontalSpeed)
    {
        if(playerColor == MyUtils.PlayerColor.RED)
        {
            verticalSpeed *= -1;

        }
        
        for(int i=0; i < rows.Length; i++)
        {
            // Translation
            Vector3 newPosition = rows[i].transform.position + Vector3.right * Time.deltaTime * verticalSpeed;
            rows[i].GetComponent<Rigidbody>().MovePosition(newPosition);

            // Rotation
            Quaternion deltaRotation = Quaternion.Euler(Vector3.right * Time.deltaTime * horizontalSpeed);
            rows[i].GetComponent<Rigidbody>().MoveRotation(rows[i].GetComponent<Rigidbody>().rotation * deltaRotation);
        }
    }
}
