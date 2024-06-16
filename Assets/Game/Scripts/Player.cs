using UnityEngine;

public class Player : Character
{
    [SerializeField] private Joystick Joystick;
    [SerializeField] private float Speed;

    // Update is called once per frame
   
    public override void Move()
    {
        //Debug.Log("1");
        //Check Input
        float hozizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;

        if (!isCanmove && vertical > 0)
        {
            return;
        }
        //Convert sang vector3
        Vector3 Direction = new Vector3(hozizontal, 0, vertical);

        //H�m Move
        transform.Translate(Direction * Time.deltaTime * Speed, Space.World);
    }


    public override void CheckMove()
    {

    }
}





