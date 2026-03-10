using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject _laser;
    [SerializeField] private Animator playerAnimator;
    public int shoothash = Animator.StringToHash("Shoot");
    private bool shooting = false;
    
    void Start()
    {
        _laser.SetActive(false);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        /*
        if (context.started)
        {
            Debug.Log("Shooting");
            _laser.SetActive(false);
            shooting = true;
        }
        if (context.canceled)
        {
            shooting = false;
            _laser.SetActive(false);
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            shooting = true;
            _laser.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            shooting = false;
            _laser.SetActive(false);
        }
        HandleShootingAnimation();
    }
    public void HandleShootingAnimation()
    {
        playerAnimator.SetBool(shoothash, shooting);
    }
}
