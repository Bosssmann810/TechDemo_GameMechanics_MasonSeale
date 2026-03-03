using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    public GameObject _exit;
    Vector3 exitLocation;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        exitLocation = _exit.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = exitLocation;
        }
    }
}
