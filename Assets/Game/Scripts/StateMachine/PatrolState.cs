using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    int target;
    public void OnEnter(Bot t)
    {
        target = Random.Range(2, 7);

        Vector3 brickPoin = t.stage.SeekBrickPoint(t.ColorEnum);
    }

    public void OnExcute(Bot t)
    {

    }

    public void OnExit(Bot t)
    {

    }
}
