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

    [Header("Rows sensitivity")]
    [Range(0, 2)]
    public float verticalSensitivity;

    [Range(0, 2)]
    public float horizontalSensitivity;

    private const float horizontalSensitivityScaleFactor = 250;

    // === A: Objects === //

    [Header("Controlled Objects")]
    [Tooltip("Local player controlled by local inputs")]
    public Player player;

    [Tooltip("The only ball at the moment")]
    public Ball Ball;


    // === F: Lifecycle === //

    void Start(){
        MyUtils.IsNotNull(LogTag + ".player", player);
        MyUtils.IsNotNull(LogTag + ".ball", Ball);

        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    void Update(){
        HandleRowsMoves();
        HandleKeyboard();
    }

    protected void HandleRowsMoves()
    {
        player.MoveAllRows(Input.GetAxis("Vertical") * verticalSensitivity,
                           Input.GetAxis("Horizontal") * horizontalSensitivity * horizontalSensitivityScaleFactor);
    }

    protected void HandleKeyboard()
    {
        if (Input.GetButton("Reset Ball"))
        {
           Ball.ResetPosition();
        }

        if (Input.GetButton("Shoot"))
        {
           Ball.Shoot();
        }

        if (Input.GetButton("Pass Forward"))
        {
           Ball.PassForward();
        }

        if (Input.GetButton("Pass Backward"))
        {
           Ball.PassBackward();
        }

        if (Input.GetButton("Pass Left"))
        {
           Ball.PassLeft();
        }

        if (Input.GetButton("Pass Right"))
        {
           Ball.PassRight();
        }
    }
}
