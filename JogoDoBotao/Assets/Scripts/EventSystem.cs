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

    public event Action onGoal;
    public void Goal()
    {
        if (onGoal != null)
        {
            onGoal();
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
