using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorScript door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GetComponentInParent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            door.OpenDoor();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            door.CloseDoor();
        }
    }
}
