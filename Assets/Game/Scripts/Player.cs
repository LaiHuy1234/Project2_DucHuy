using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Linq;

public class Player : Character
{
    [SerializeField] private Joystick Joystick;
    [SerializeField] private float Speed;
    [SerializeField] private ColorData ColorData;
    [SerializeField] private ColorEnum ColorEnum;
    [SerializeField] ColorPlayer playerColor;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    //[SerializeField] private MeshRenderer renderer;
    public Material[] colorMats;
    public Platform platform;
    public ColorEnum colorType;

    private void Start()
    {
        RandomColor();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
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

    public void RandomColor()
    {
        int ColorRandom = Random.Range(0, 4);
        playerColor.ChangeColor((ColorEnum)ColorRandom);
    }

   

    


}





