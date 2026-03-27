using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    public GameObject _exit;
    Vector3 exitLocation;
    bool interact = false;
    bool inrange = false;
    public ParticleSystem exitParitcle;
    public AudioClip exitSound;
    public AudioSource audiosource;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        exitLocation = _exit.transform.position;
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
        if(interact && inrange)
        {
            player.transform.position = exitLocation;
            exitParitcle.Play();
            audiosource.clip = exitSound;
            audiosource.Play();

        }
        
    }
}
