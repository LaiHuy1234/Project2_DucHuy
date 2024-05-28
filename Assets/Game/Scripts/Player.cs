using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Joystick Joystick;
    [SerializeField] private float Speed;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        //Check Input
        float hozizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;

        //Convert sang vector3
        Vector3 Direction = new Vector3(hozizontal, 0, vertical);


        //Hàm move
        transform.Translate(Direction * Time.deltaTime * Speed);
    }
}
