using System.Collections;
using System.Net.Mail;
using UnityEngine;

public class BreakableBlock : MonoBehaviour, IDamageable
{
    bool started = false;
    public int hp = 1000;
    public Sprite currentSprite;
    public Sprite healthySprite;
    public Sprite hurtSprite;
    public Sprite veryHurtSprite;
    public SpriteRenderer renderer;
    
   // public Animation iFrames;
    public void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        currentSprite = healthySprite;
        renderer.sprite = currentSprite;
    }
    public void TakeDamage()
    {
            Debug.Log("ow");
            hp -= 1;
    }

    public void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        SpriteChangeByHP();
    }
    public void SpriteChangeByHP()
    {
        if(hp <= 500)
        {
            currentSprite = hurtSprite;
        }
        if (hp <= 250)
        {
            currentSprite = veryHurtSprite;
        }
        renderer.sprite = currentSprite;
    }
}
