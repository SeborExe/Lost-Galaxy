using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void DoMove(Vector3 moveValue)
    {
        transform.Translate(moveValue);
    }
}
