using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public NavMeshAgent agent;

    private Vector3 destionation;

    public bool IsDestination => Vector3.Distance(destionation, transform.position) < 0.1f;


    IState<Bot> currentState;

    //public override void OnInit()
    //{
    //    base.OnInit();
    //    ChangeState(new PatrolState());
    //}

    public void SetDestination(Vector3 position)
    {
        destionation = position;
        destionation.y = 0;
        agent.SetDestination(position);
        agent.enabled = true;
    }


    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);

            CheckStair();
        }
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void MoveStop()
    {
        agent.enabled = false;
    }
}
