using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    // === A: Properties === // 

    private static string logTag = typeof(Row).Name;

    [Tooltip("Color of the row, should match parent player")]
    public MyUtils.PlayerColor rowColor;

    [Tooltip("Type of the row")]
    public MyUtils.RowType rowType;

    public float maxXDisplacement;

    public float startX;

    // === F: Lifecycle === //

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {

    }
}
