using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    public ColorEnum ColorEnum;
    public MeshRenderer MeshRenderer;
    public BoxCollider Collider;
    [SerializeField] private ColorData ColorData;

    //private void Awake()
    //{
    //    ChangeColor(ColorEnum.Blue);
    //}

    public void ChangeColor(ColorEnum colorEnum)
    {
        this.ColorEnum = colorEnum;
        MeshRenderer.material = ColorData.GetColorData(ColorEnum);
    }
}
