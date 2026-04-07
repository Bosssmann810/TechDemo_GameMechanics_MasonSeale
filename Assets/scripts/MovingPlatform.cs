using UltimateCC;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public Transform target;
    private Rigidbody2D body;
    public float speed;
    public Vector2 previousPos;
    public Vector2 velocity;
    public GameObject test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        target = PointB;
        previousPos = body.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 newpos = Vector2.MoveTowards(body.position, target.position, speed * Time.deltaTime);
        body.MovePosition(newpos);
        velocity = (body.position - previousPos) / Time.fixedDeltaTime;
        if(Vector3.Distance(body.transform.position, PointA.position) < 0.01)
        {
            target = PointB;
        }
        if(Vector3.Distance(body.transform.position, PointB.position) < 0.01)
        {
            target = PointA;
        }
        previousPos = body.position;
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("ball is on");

            collision.gameObject.transform.SetParent(gameObject.transform);
            collision.gameObject.GetComponent<BallReset>().OnPlatform();
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("ball is off");
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.GetComponent<BallReset>().OffPlatform();

        }

    }
}
