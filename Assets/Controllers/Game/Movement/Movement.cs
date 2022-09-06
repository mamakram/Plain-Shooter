using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement: MonoBehaviour
{
    private bool move = true;

    public void StartMoving() { move = true; }
    public void StopMoving() { move = false; }
    public void Update() { if (move) { Move(); } }
    public abstract void Move();
}
