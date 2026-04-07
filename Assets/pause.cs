using UnityEngine;
using UnityEngine.InputSystem;

public class pause : MonoBehaviour
{
    public bool paused = false;

    public void OnPause(InputAction.CallbackContext context)
    {
        if(paused == false)
        {
            Debug.Log("Paused");
            paused = true;
            Time.timeScale = 0;
            return;
        }
        if(paused == true)
        {
            Debug.Log("Unpaused");
            paused = false;
            Time.timeScale = 1;
            return;
        }
        
    }
}
