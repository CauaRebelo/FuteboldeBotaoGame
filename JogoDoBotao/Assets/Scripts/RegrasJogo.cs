using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegrasJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.onGoal += OnGoal;
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

    void OnGoal()
    {
        StopAllCoroutines();
        EventSystem.current.SwapPlayer();
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
