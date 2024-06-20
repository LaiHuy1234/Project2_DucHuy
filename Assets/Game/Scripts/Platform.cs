using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Brick brickPrefab;
    [SerializeField] private Transform[] brickPoints;
    [SerializeField] private Transform startPosition;
    [SerializeField] public GameObject[] List;
    [SerializeField] private ColorData colorData;
    public List<Brick> bricks = new List<Brick>();

    // Start is called before the first frame update

    private void Start()
    {
        RandomBricks();
    }
    internal void OnInit()
    {
        RandomBricks();
    }

    public void RandomBricks()
    {
        float zSpace = 0;
        float xScape = 0;
        for (int x = 0; x < 15; x++)
        {
            xScape += 2f;
            zSpace = 0f;
            for (int y = 0; y < 15; y++)
            {

                zSpace += 2f;
                Vector3 position = new Vector3(startPosition.position.x + xScape, startPosition.position.y, startPosition.position.z + zSpace);
                Brick brick = Instantiate(brickPrefab, position, Quaternion.identity);
                //Renderer renderer = brickPrefab.GetComponent<Renderer>();
                //int ColorRandom = Random.Range(0, 4);
                //ColorEnum ColorRandomColor = (ColorEnum)ColorRandom;
                //renderer.material = colorData.GetColorData(ColorRandomColor);

                int ColorRandom = Random.Range(1, 5);
                brick.ChangeColor((ColorEnum)ColorRandom);
                bricks.Add(brick);
            }

        }
    }

    public void InitColor(ColorEnum colorEnum)
    {
        int amount = brickPoints.Length / LevelManager.Instance.CharacterAmount;

        for (int i = 0; i < amount; i++)
        {
            RandomBricks();
        }
    }

    internal Brick SeekBrickPoint(ColorEnum color)
    {
        Brick brick = null;
        for (int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].ColorEnum == color)
            {
                brick = bricks[i];
                break;
            }
        }
        return brick;
    }
}
