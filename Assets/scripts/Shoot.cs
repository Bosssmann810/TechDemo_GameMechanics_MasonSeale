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
    private int facingDirection =1;


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
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingDirection = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingDirection = 1;
        }
        HandleShootingAnimation();
    }
    public void HandleShootingAnimation()
    {
        playerAnimator.SetBool(shoothash, shooting);
    }
    public int GiveDirection()
    {
        return facingDirection;
    }
}
