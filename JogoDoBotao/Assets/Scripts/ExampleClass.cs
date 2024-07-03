using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        rb.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        rend.material.color -= Color.white * Time.deltaTime;
    }

    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Drag ended!");
        rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);
    }
}