using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public ColorEnum ColorEnum;
    public MeshRenderer MeshRenderer;
    public BoxCollider Collider;
    [SerializeField] private ColorData ColorData;

    private void Awake()
    {
        ChangeColor(ColorEnum.Blue);
    }

    public void ChangeColor(ColorEnum colorEnum)
    {
        this.ColorEnum = colorEnum;
        MeshRenderer.material = ColorData.GetColorData(ColorEnum);
    }

    private IEnumerator CoDelayReAppear()
    {
        yield return new WaitForSeconds(2f);
        MeshRenderer.enabled = true;
        Collider.enabled = true;
    }

    public void TurnOff()
    {
        MeshRenderer.enabled = false;   
        Collider.enabled = false;
        StartCoroutine(CoDelayReAppear());  
    }
}
