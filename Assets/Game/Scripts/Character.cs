using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Brick brick;
    [SerializeField] private ColorEnum ColorEnum;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private ColorData ColorData;

    float height;
    float offset = 1f;
   public virtual void Move()
    {

    }

   public void Addbrick()
    {
        height += 0.2f;
        Brick bricks = Instantiate(brick, transform);
        bricks.transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z - offset);

    }

    public void RemoveBrick()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        CollideWithBrick(col);
        Addbrick();
    }

    private void CollideWithBrick(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponent<Brick>();
            if (brick != null)
            {
                if (brick.ColorEnum == ColorEnum)
                {
                    // sinh gach sau lung
                    brick.TurnOff();
                }
            }
        }
    }

    public void ChangeColor(ColorEnum colorEnum)
    {
        this.ColorEnum = colorEnum;
        skinnedMeshRenderer.material = ColorData.GetColorData(ColorEnum);
    }
}
