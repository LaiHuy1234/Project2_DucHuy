using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    int targetBrick;
    public void OnEnter(Bot t)
    {
        Debug.Log("Dang chay ham OnEnter");
        targetBrick = Random.Range(2, 7);
        SeekTarget(t);
    }

    public void OnExcute(Bot t)
    {
       
        if (t.IsDestination)
        {
            if (t.BrickCount >= targetBrick)
            {
                Debug.Log("Da Di");
                t.ChangeState(new AttackState());
            }
            else
            {
                Debug.Log("Tim gach");
                SeekTarget(t);
            }
        }
    }

    public void OnExit(Bot t)
    {

    }

    private void SeekTarget(Bot t)
    {
        Debug.Log("0");
        if (t.platform != null)
        {
            Debug.Log("1");
            Brick brick = t.platform.SeekBrickPoint(t.ColorEnum);
            if (brick != null)
            {
                Debug.Log("2");
                t.ChangeState(new AttackState());
            }
            else
            {
                t.SetDestination(brick.transform.position);
            }
        }
        else
        {
            t.SetDestination(t.transform.position);
        }

    }
}
