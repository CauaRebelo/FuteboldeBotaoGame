using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioClip[] ballTouch;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.onGoalPlayer1 += OnGoalPlayer1;
        EventSystem.current.onGoalPlayer2 += OnGoalPlayer2;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SoundFXManager.instance.PlayRandomSoundFXClip(ballTouch, transform, 1f);
        }
    }

    void OnGoalPlayer1()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnPoint.position;
    }

    void OnGoalPlayer2()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnPoint.position;
    }
}
