using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goalies : MonoBehaviour
{
    public bool goalP2 = false;
    [SerializeField] private AudioClip goalSFX;
    void Start()
    {
        EventSystem.current.onGoalPlayer1 += OnGoalPlayer1;
        EventSystem.current.onGoalPlayer2 += OnGoalPlayer2;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ball")
        {
            SoundFXManager.instance.PlaySoundFXClip(goalSFX, transform, 1f);
            if (goalP2)
            {
                EventSystem.current.GoalPlayer1();
            }
            else
            {
                EventSystem.current.GoalPlayer2();
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            SoundFXManager.instance.PlaySoundFXClip(goalSFX, transform, 1f);
            if (goalP2)
            {
                EventSystem.current.GoalPlayer1();
            }
            else
            {
                EventSystem.current.GoalPlayer2();
            }

        }
    }

    void OnGoalPlayer1()
    {
        //Something
    }
    void OnGoalPlayer2()
    {
        //Something
    }
}
