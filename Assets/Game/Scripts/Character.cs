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
    public bool isCanmove = true;



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
            height -= 0.2f;
            Brick bricks = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(bricks.gameObject);
            bricks.transform.position = new Vector3(transform.position.x,transform.position.y - height, transform.position.z - offset);
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
                        //Debug.Log("Da va cham");
                    }
                    if (stair.ColorEnum != ColorEnum && playerBricks.Count == 0)
                    {
                        Debug.Log("da va cham");
                        isCanmove = false;
                    }
                }

            }
            else
            {
                isCanmove = true;
            }
        }
        
    }


    private void OnTriggerEnter(Collider col)
    {
        CollideWithBrick(col);
        CheckStage(col);
    }

    private void CollideWithBrick(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponent<Brick>();
            if (brick != null)
            {
                if (brick.ColorEnum == ColorEnum)s
                {
                    // sinh gach sau lung
                    brick.TurnOff();
                    Addbrick();
                }
            }
        }
    }

    private void CheckStage(Collider col)
    {
        if (col.CompareTag("Stage2"))
        {
            Debug.Log("Da clear");
            ClearBrick();
        }
    }

    public void ChangeColor(ColorEnum colorEnum)
    {
        this.ColorEnum = colorEnum;
        skinnedMeshRenderer.material = ColorData.GetColorData(ColorEnum);
    }

    public virtual void CheckMove()
    {

    }
}
