using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Brick brick;
    [SerializeField] private ColorEnum ColorEnum;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private ColorData ColorData;
    [SerializeField] private Vector3 Point;
    public List<Brick> playerBricks = new List<Brick>();
    private bool isMoving;


    float height;
    float offset = 1f;
   public virtual void Move()
    {

    }

   public void Addbrick()
    {
        height += 0.2f;
        Brick bricks = Instantiate(brick, transform);
        bricks.ChangeColor(ColorEnum);
        bricks.transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z - offset);
        playerBricks.Add(bricks);
    }

    public void RemoveBrick()
    {
        if (playerBricks.Count > 0)
        {
            Brick bricks = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(bricks.gameObject);
        }
    }

    public void ClearBrick()
    {
        for (int i = 0; i < playerBricks.Count; i++)
        {
            Destroy(playerBricks[i]);
        }
        playerBricks.Clear();
    }

    public void CheckStair()
    {
        Vector3 originPos = transform.position + Vector3.forward + Vector3.down * 1.5f;
        Ray ray = new Ray(originPos, Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Stair"))
            {
                Stair stair = hit.collider.GetComponent<Stair>();
                if (stair != null)
                {
                    if (stair.ColorEnum != ColorEnum && playerBricks.Count > 0)
                    {
                        stair.ChangeColor(ColorEnum);
                        RemoveBrick();
                        Debug.Log("Da va cham");
                    }
                }
            }
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        CollideWithBrick(col);
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
                    Addbrick();
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
