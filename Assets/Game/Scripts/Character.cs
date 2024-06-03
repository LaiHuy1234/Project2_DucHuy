using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Brick brick;
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Brick"))
        {
            Debug.Log("2");
            Destroy(col.gameObject);
            Addbrick();
        }
    }
}
