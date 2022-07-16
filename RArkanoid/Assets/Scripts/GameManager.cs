using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    int nBlocks;
    int points;
    int playerLives;
    int roundCount;
    State gameState;

    public Ball ball;
    public Paddle paddle;
    public GenerateBlocks blockGen;

    private UImanager uiMan;
    private int level;
    public void SetUIManager(UImanager uImanager)
    {
        uiMan = uImanager;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
 
    }

    private void Start()
    {
        ResetValues();
        gameState = State.Menu;
        level = 0;
        blockGen.generateBlocks(level, ref nBlocks);
        //uiMan.setLifeTxt(playerLives);
    }
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Return)) //Input.GetAxis("Return");
        {
            switch (gameState)
            {
                case State.StartRound:
                    gameState = State.Play;
                    uiMan.GoToGame();
                    ball.AddInitialForce();
                    break;
            }
        }
        if (gameState == State.Play)
                paddle.Movement();
    }


    public void LifeLost()
    {
        playerLives--;
        roundCount++;
        ball.Reset();
        if (playerLives == 0)
        {
            gameState = State.Done;
            uiMan.GoToEnd(points);
        }
        else
        {       
            paddle.Reset();
            gameState = State.StartRound;
            uiMan.GoToRound(roundCount, playerLives);  //diferent round
        }
       
    }
    public void RemoveBlock()
    {
        nBlocks--;
        points += 100;        
        uiMan.setPointTxt(points);

        if (nBlocks == 0)
        {
            if (level < 10)
            {
                level++;
                blockGen.generateBlocks(level, ref nBlocks);
                ball.Reset();
                paddle.Reset();
                gameState = State.StartRound;
                roundCount = 1;
                uiMan.GoToRound(roundCount, playerLives);  //diferent round
            }
            else
            {
                gameState = State.Done;
                uiMan.GoToEnd(points, true);
            }
        }
    }
    
    public void Reset()
    {
        ball.Reset();
        paddle.Reset();
        ResetValues();
        level = 0;
        blockGen.clearBlocks(level, ref nBlocks);
    }
    public void ResetValues()
    {
        nBlocks = 49;
        points = 0;
        playerLives = 3;
        roundCount = 1;
    }

    public void ChangeState(State ns)
    {
        gameState = ns;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
