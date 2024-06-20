using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { MainMenu, Gameplay, Pause }
public class GameManager : MonoBehaviour
{
    private GameState gameState;

    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public bool IsState(GameState gameState)
    {
        return this.gameState == gameState;
    }
}
