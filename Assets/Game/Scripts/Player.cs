using UnityEngine;

public class Player : Character
{
    [SerializeField] private Joystick Joystick;
    [SerializeField] private ColorPlayer playerColor;
    [SerializeField] private float Speed;
    //[SerializeField] private MeshRenderer renderer;
    public Material[] colorMats;
    public Platform platform;
    public bool isMoving = false;

    private void Start()
    {
        RandomColor();
    }
    // Update is called once per frame
    void Update()
    {
        CheckStair();
        Move();
    }

    public override void Move()
    {
        Debug.Log("1");
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

    public void RandomColor()
    {
        int ColorRandom = Random.Range(0, 4);
        ChangeColor((ColorEnum)ColorRandom);
    }

    public override void CheckMove()
    {

    }
}





