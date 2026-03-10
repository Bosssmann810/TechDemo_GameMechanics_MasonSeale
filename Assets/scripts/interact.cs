using UnityEngine;
using UnityEngine.InputSystem;

public class interact : MonoBehaviour
{
    public bool interaction = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interaction = true;
        }
        if (context.canceled)
        {
            interaction = false;
        }
    }
    public bool GetInteraction()
    {
        return interaction;
    }


}
