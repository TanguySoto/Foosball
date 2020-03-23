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
    // === A: Properties === //

    private static string LogTag = typeof(InputHandler).Name;

    [Range(0, 2)]
    public float VerticalSensitivity;

    [Range(0, 2)]
    public float HorizontalSensitivity;

    private const float HorizontalSensitivityScaleFactor = 250;

    // === A: Objects === //

    [Tooltip("Local player controlled by local inputs")]
    public Player Player;

    [Tooltip("The only ball at the moment")]
    public Ball Ball;


    // === F: Lifecycle === //

    void Start(){
        MyUtils.IsNotNull(LogTag + ".player", Player);
        MyUtils.IsNotNull(LogTag + ".ball", Ball);

        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    void Update(){
        HandleMouseMoves();
        HandleMouseKeyboard();
    }

    protected void HandleMouseMoves(){
        Player.MoveAllRows(Input.GetAxis("Mouse Y") * VerticalSensitivity,
                           Input.GetAxis("Mouse X") * HorizontalSensitivity * HorizontalSensitivityScaleFactor);
    }

    protected void HandleMouseKeyboard()
    {
        if (Input.GetKeyDown("space"))
        {
           Ball.ResetPosition();
        }
    }
}
