using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float power = 10;
    public Vector2 minPower;
    public Vector2 maxPower;
    public bool myTurn = true;
    public bool recentPlay = false;

    public Renderer rend;
    Vector2 force;
    Vector3 mousePos;
    Vector3 startPoint;
    Vector3 endPoint;

    void Start()
    {
        EventSystem.current.onSwapPlayer += OnSwapPlayer;
        EventSystem.current.onGoal += OnGoal;
        EventSystem.current.onBallPlay += OnBallPlay;
        rend = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        if(myTurn)
        {
            // If your mouse hovers over the GameObject with the script attached, output this message
            Debug.Log("Drag started!");
            mousePos = Input.mousePosition;
            startPoint = Camera.main.ScreenToWorldPoint(mousePos);
            startPoint.z = 15;
        }        
    }
    void OnMouseDrag()
    {
        if (myTurn)
        {
            mousePos = Input.mousePosition;
        }
        //mousePos.z = Camera.main.nearClipPlane;
        //Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        //rb.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        //rend.material.color -= Color.white * Time.deltaTime;
    }

    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        if(myTurn)
        {
            Debug.Log("Drag ended!");
            mousePos = Input.mousePosition;
            endPoint = Camera.main.ScreenToWorldPoint(mousePos);
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            myTurn = !myTurn;
            EventSystem.current.BallPlay();

        }
    }

    void OnBallPlay()
    {
        myTurn = false;
    }
    void OnGoal()
    {
        //Something
    }

    void OnSwapPlayer()
    {
        recentPlay = !recentPlay;
        if (!recentPlay)
        {
            myTurn = !myTurn;
        }
    }
}