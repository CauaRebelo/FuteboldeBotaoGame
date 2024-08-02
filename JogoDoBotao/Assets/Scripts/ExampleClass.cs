using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ExampleClass : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LineRenderer lineRend;

    public float power = 10;
    public Vector2 minPower;
    public Vector2 maxPower;
    public bool myTurn = true;
    public bool recentPlay = false;
    public bool player2 = false;
    public bool usable = true;
    public int type = 0;

    public Renderer rend;
    Vector2 force;
    Vector3 mousePos;
    Vector3 linePos;
    Vector3 startPoint;
    Vector3 endPoint;

    [field: SerializeField]
    public UnityEvent<int> OnType { get; set; }

    void Start()
    {
        EventSystem.current.onSwapPlayer += OnSwapPlayer;
        EventSystem.current.onGoalPlayer1 += OnGoalPlayer1;
        EventSystem.current.onGoalPlayer2 += OnGoalPlayer2;
        EventSystem.current.onBallPlay += OnBallPlay;
        EventSystem.current.onEndGame += OnEndGame;
        rend = GetComponent<Renderer>();
        if(player2)
        {
            type = Info_Player.teamp2;
        }
        else
        {
            type = Info_Player.teamp1;
        }
        OnType.Invoke(type);
        if(!usable)
        {
            Destroy(this);
        }
        lineRend.positionCount = 2;

    }

    void OnMouseDown()
    {
        if (myTurn)
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
            linePos = Camera.main.ScreenToWorldPoint(mousePos);
            linePos.z = 15;

            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, new Vector3(2* startPoint.x - linePos.x, 2 * startPoint.y - linePos.y, 0f));
        }
        else
        {
            startPoint = transform.position;
            startPoint.z = 15;
        }
        //mousePos.z = Camera.main.nearClipPlane;
        //Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        //rb.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        //rend.material.color -= Color.white * Time.deltaTime;
    }

    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        if (myTurn)
        {
            Debug.Log("Drag ended!");
            lineRend.SetPosition(1, transform.position);
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

    void OnGoalPlayer1()
    {
        if (player2)
        {
            recentPlay = false;
            myTurn = true;
        }
        else
        {
            recentPlay = true;
            myTurn = false;
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnPoint.position;
        transform.rotation = Quaternion.identity;
    }

    void OnGoalPlayer2()
    {
        if (!player2)
        {
            recentPlay = false;
            myTurn = true;
        }
        else
        {
            recentPlay = true;
            myTurn = false;
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnPoint.position;
        transform.rotation = Quaternion.identity;
    }

    void OnSwapPlayer()
    {
        recentPlay = !recentPlay;
        if (!recentPlay)
        {
            myTurn = !myTurn;
        }
    }

    void OnEndGame()
    {
        myTurn = false;
    }

    private void OnDestroy()
    {
        EventSystem.current.onSwapPlayer -= OnSwapPlayer;
        EventSystem.current.onGoalPlayer1 -= OnGoalPlayer1;
        EventSystem.current.onGoalPlayer2 -= OnGoalPlayer2;
        EventSystem.current.onBallPlay -= OnBallPlay;
        EventSystem.current.onEndGame -= OnEndGame;
    }
}