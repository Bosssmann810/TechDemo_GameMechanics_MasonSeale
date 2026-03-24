using System.Collections;
using UltimateCC;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioSource laserAudio;
    public AudioClip laserSound;
    public AudioClip jumpSound;
    public AudioClip DashSound;
    public PlayerMain playerState;
    public SpriteRenderer sprite;
    public Sprite currentsprite;
   public Sprite lastsprite;
    public Sprite jumpA;
    public Sprite jumpB;
    public Sprite jumpC;


    public bool canjump = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        
    }

    public void LaserAudioOn()
    {
        laserAudio.clip = laserSound;
        laserAudio.Play();
    }

    public void LaserAudioOff()
    {
        laserAudio.Stop();
    }
    // Update is called once per frame
    void Update()
    {
     
           
       JumpSound();

        //constintly check if the current sprite
        currentsprite = sprite.sprite;
        //make sure last sprite is effectively cleared if you stop jumping (YES THIS IS NESSASARY)
        if (playerState.CurrentState != PlayerMain.AnimName.Jump)
        {
            lastsprite = sprite.sprite;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAudio.clip = DashSound;
            playerAudio.Play();
        }
    }
    //you have no idea how much effort went into making the jump sound work
    public void JumpSound()
    {
        //first of all, if the last sprite is equal to the current sprite dont play the sounds, (this prevents it from spamming the sound every frame)
        if(currentsprite == lastsprite)
        {
            
            return;
        }
        //then if the sprite is equal to one of the jump sprites, then you cna play the sound 
        if (currentsprite == jumpA || currentsprite == jumpB || currentsprite == jumpC)
        {
            //change the last sprite to prevent spam
            lastsprite = currentsprite;
            Debug.Log("Jumped");
            playerAudio.clip = jumpSound;
            playerAudio.Play();
        }

    }


}
