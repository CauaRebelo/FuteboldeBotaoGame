using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;

    void Awake()
    {
        current = this;
    }

    public event Action onBallPlay;
    public void BallPlay()
    {
        if (onBallPlay != null)
        {
            onBallPlay();
        }
    }

    public event Action onGoalPlayer1;
    public void GoalPlayer1()
    {
        if (onGoalPlayer1 != null)
        {
            onGoalPlayer1();
        }
    }

    public event Action onGoalPlayer2;
    public void GoalPlayer2()
    {
        if (onGoalPlayer2 != null)
        {
            onGoalPlayer2();
        }
    }

    public event Action onEndGame;
    public void EndGame()
    {
        if (onEndGame != null)
        {
            onEndGame();
        }
    }

    public event Action onSwapPlayer;

    public void SwapPlayer()
    {
        if (onSwapPlayer != null)
        {
            onSwapPlayer();
        }
    }
}
