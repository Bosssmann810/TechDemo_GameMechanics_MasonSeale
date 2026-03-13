using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public ParticleSystem particle;
    public SpriteRenderer sprite;
    public BoxCollider2D trigger;
    public AudioSource sound;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            particle.Play();
            sprite.GetComponent<Renderer>().enabled = false;
            trigger.enabled = false;
            collision.GetComponent<coinManager>().AddCoin();
            sound.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
