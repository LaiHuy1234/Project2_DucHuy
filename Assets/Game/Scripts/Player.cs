using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class Player : Character
{
    [SerializeField] private Joystick Joystick;
    [SerializeField] private ColorPlayer playerColor;
    [SerializeField] private float Speed;
    //[SerializeField] private MeshRenderer renderer;
    public Material[] colorMats;
    public Platform platform;
    public bool isMoving;

    private void Start()
    {
        RandomColor();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckStair();
    }

    public override void Move()
    {
        if(!isMoving)
        {
            Debug.Log("1");
            //Check Input
            float hozizontal = Joystick.Horizontal;
            float vertical = Joystick.Vertical;

            //Convert sang vector3
            Vector3 Direction = new Vector3(hozizontal, 0, vertical);

            //H�m Move
            transform.Translate(Direction * Time.deltaTime * Speed, Space.World);

        }
        return;
    }

    public void RandomColor()
    {
        int ColorRandom = Random.Range(0, 4);
       ChangeColor((ColorEnum)ColorRandom);
    }
}





