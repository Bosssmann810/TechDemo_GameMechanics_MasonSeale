using System.Collections;
using UnityEngine;

public class BreakableBlock : MonoBehaviour, IDamageable
{
    bool started = false;
    public int hp;
    public bool invincible;
   // public Animation iFrames;
    public void Start()
    {
       // iFrames = GetComponent<Animation>();
    }
    public IEnumerator TakeDamage()
    {
        while (true)
        {
            Debug.Log("ow");
            hp -= 1;
            invincible = true;
            yield return new WaitForSeconds(2);
            Debug.Log("ended");
            invincible = false;
        }
    }

    public void Update()
    {
        /*
        if(invincible == true)
        {
            iFrames.Play();
        }
        if(invincible == false)
        {
            iFrames.Stop();
        }
        */
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
