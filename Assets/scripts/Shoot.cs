using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject _laser;
    [SerializeField] private Animator playerAnimator;
    public int shoothash = Animator.StringToHash("Shoot");
    private bool shooting = false;
    public PlayerSoundManager SoundManager;
    
    void Start()
    {
        _laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("pewpew");
            shooting = true;
            _laser.SetActive(true);
            SoundManager.LaserAudioOn();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            shooting = false;
            _laser.SetActive(false);
            SoundManager.LaserAudioOff();
        }
        HandleShootingAnimation();
    }
    public void HandleShootingAnimation()
    {
        playerAnimator.SetBool(shoothash, shooting);
    }
}
