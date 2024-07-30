using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegrasJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.onGoalPlayer1 += OnGoalPlayer1;
        EventSystem.current.onGoalPlayer2 += OnGoalPlayer2;
        EventSystem.current.onBallPlay += OnBallPlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBallPlay()
    {
        StartCoroutine(CheckObjectsHaveStopped());
    }

    void OnGoalPlayer1()
    {
        StopAllCoroutines();
    }

    void OnGoalPlayer2()
    {
        StopAllCoroutines();
    }

    IEnumerator CheckObjectsHaveStopped()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Checking if ball is moving.");
        Rigidbody2D[] GOS = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        bool allSleeping = false;

        while (!allSleeping)
        {
            allSleeping = true;

            foreach (Rigidbody2D GO in GOS)
            {
                if (GO.velocity.magnitude > 0.1f)
                {
                    allSleeping = false;
                    yield return null;
                    break;
                }
            }

        }
        Debug.Log("Pararam de se mexer!");
        EventSystem.current.SwapPlayer();
        //Do something else

    }


}
