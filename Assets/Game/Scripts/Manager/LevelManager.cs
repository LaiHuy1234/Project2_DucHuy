using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    readonly List<ColorEnum> colorType = new List<ColorEnum>() { ColorEnum.Yellow, ColorEnum.Red, ColorEnum.Green, ColorEnum.Blue };
    public Level[] levelPrefabs;
    [SerializeField] public Bot botPrefab;
    public Player player;
    public List<Bot> bots = new List<Bot>();

    private Level currentLevel;

    public Vector3 FinishPoint => currentLevel.finishPoint.position;
    public int CharacterAmount => currentLevel.botAmount + 1;

    

    private void Start()
    {
        LoadLevel(0);
        OnInit();
        UIManager.Instance.OpenUI<MainMenu>();
    }
    public void OnInit()
    {
        //init vi tri bat dau game
        Vector3 index = currentLevel.startPoint.position;

        float space = 2f;

        Vector3 leftPoint = ((CharacterAmount / 2) + (CharacterAmount % 2) * 0.5f - 0.5f) * space * Vector3.left + index;
        List<Vector3> startPoint = new List<Vector3>();         

        for (int i = 0; i < CharacterAmount; i++)
        {
            startPoint.Add(leftPoint + space * Vector3.right * i);
        }

        
        //init random mau
        List<ColorEnum> colorDatas = Utilities.SortOrder(colorType, CharacterAmount);
        //

        //set vi tri player
        int rand = Random.Range(0, CharacterAmount);
        player.transform.position = startPoint[0];
        startPoint.RemoveAt(rand);
        //set color player
        player.ChangeColor(colorDatas[rand]);
        colorDatas.RemoveAt(rand);

        
        for (int i = 0; i < CharacterAmount - 1; i++)
        {
            Bot bot = Instantiate(botPrefab, startPoint[i], Quaternion.identity);
            bot.ChangeColor(colorDatas[i]);
            bots.Add(bot);
        }
    }

    public void LoadLevel(int level)
    {
        if (currentLevel == null)
        {
           // Destroy(currentLevel.gameObject);
        }

        if (level < levelPrefabs.Length)
        {
            currentLevel = Instantiate(levelPrefabs[level]);
            currentLevel.OnInit();
        }
        else
        {
            //TODO: Level vuot qua limit
        }
    }

    public void OnStartGame()
    {
        GameManager.Instance.ChangeState(GameState.Gameplay);
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(new PatrolState());
        }
    }

    public void OnFinishGame()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].ChangeState(null);
            bots[i].MoveStop();
        }
    }

    public void OnReset()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            Destroy(bots[i]);
        }
        bots.Clear();
    }
}
