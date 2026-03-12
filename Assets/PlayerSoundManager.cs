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
        if (Input.GetKeyDown(KeyCode.Space) && canjump == true)
        {
            canjump = false;
            Debug.Log("Jumped");
            playerAudio.clip = jumpSound;
            playerAudio.Play();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            playerAudio.clip = DashSound;
            playerAudio.Play();
        }
        if(playerState.CurrentState == PlayerMain.AnimName.Jump )
        {
            canjump =true;
        }
        if(playerState.CurrentState == PlayerMain.AnimName.Land)
        {
            canjump = false;
        }
        
    }


}
