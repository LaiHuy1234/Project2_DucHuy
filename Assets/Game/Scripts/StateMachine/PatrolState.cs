using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    int targetBrick;
    //public void OnEnter(Bot t)
    //{
    //    targetBrick = Random.Range(2, 7);
    //    SeekTarget(t);
    //}

    //public void OnExcute(Bot t)
    //{
    //    if (t.IsDestination)
    //    {
    //        if(t.BrickCount >= targetBrick)
    //        {
    //            t.ChangeState(new AttackState());
    //        }
    //        else
    //        {
    //            SeekTarget(t);
    //        }
    //    }
    //}

    //public void OnExit(Bot t)
    //{
        
    //}

    //private void SeekTarget(Bot t)
    //{
    //    if (t.platform != null)
    //    {
    //        Brick brick = t.platform.SeekBrickPoint(t.ColorEnum);
    //        if (brick != null)
    //        {
    //            t.ChangeState(new AttackState());
    //        }
    //        else
    //        {
    //            t.SetDestination(brick.transform.position);
    //        }
    //    }
    //    else
    //    {
    //        t.SetDestination(t.transform.position);
    //    }
       
    //}
}
