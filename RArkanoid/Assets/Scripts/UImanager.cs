using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UImanager : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject RoundUI;
    public GameObject GameUI;
    public GameObject EndUI;
    public Text pointTxt;
    public Text liveText;
    public Text roundText;
    public Text scoreText;
    public TMP_Text finishText;

    private void Start()
    {
        GameManager.instance.SetUIManager(this);
    }
    public void GoToMainMenu()
    {
        MainMenuUI.SetActive(true);
        RoundUI.SetActive(false);
        GameUI.SetActive(false);
        EndUI.SetActive(false);
        GameManager.instance.ChangeState(State.Menu);
    }
    public void StartGame() //Replay option
    {
        int one = 1;
        MainMenuUI.SetActive(false);
        RoundUI.SetActive(true);
        GameUI.SetActive(false);
        EndUI.SetActive(false);
        GameManager.instance.ChangeState(State.StartRound);
        roundText.text = one.ToString();
    }
    public void GoToRound(int round, int lives) //Replay option
    {
        MainMenuUI.SetActive(false);
        RoundUI.SetActive(true);
        GameUI.SetActive(false);
        EndUI.SetActive(false);
        GameManager.instance.ChangeState(State.StartRound);
        roundText.text = round.ToString();
        liveText.text = lives.ToString();
    }
    public void GoToGame()
    {
        MainMenuUI.SetActive(false);
        RoundUI.SetActive(false);
        GameUI.SetActive(true);
        EndUI.SetActive(false);
    }
    public void GoToEnd(int score, bool wins = false)
    {
        MainMenuUI.SetActive(false);
        RoundUI.SetActive(false);
        GameUI.SetActive(false);
        EndUI.SetActive(true);
        scoreText.text = score.ToString();
        if (wins)
            finishText.text = "Game Completed, Congrats!";
        else
            finishText.text = "Game Over";
    }
    public void setPointTxt(int n)
    {
        pointTxt.text = n.ToString();
    }

}
