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
    public PlayerMain playerRB;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player is on");
            //something is going wrong here
            
            playerRB.PlayerData.Physics.localVelocity += velocity;
            
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player is off");
            //something is going wrong here
            
        }
    }
}
