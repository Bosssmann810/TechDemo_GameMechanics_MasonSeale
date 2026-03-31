using UnityEditor;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    private GameObject player;
    public Transform respawnPoint;
    bool inrange;
    bool interact;
    public GameObject ball;
    public GameObject currentBall;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inrange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("left");
            inrange = false;
        }

    }
    private void Update()
    {
        interact = Input.GetKeyDown(KeyCode.F);
        if(inrange && interact)
        {
            Debug.Log("respawning ball");
            RespawnBall();
        }
    }

    public void RespawnBall()
    {
        Destroy(currentBall);
        currentBall = Object.Instantiate(ball, respawnPoint.position, respawnPoint.rotation);
        
    }
}
