using UnityEngine;

public class killzone : MonoBehaviour
{
    public CheckpointManager manager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("entered");
            if (collision.GetComponent<CheckpointManager>() == null)
            {
                Debug.LogError("No checkpoint manager found");
            }
            manager = collision.GetComponent<CheckpointManager>();
            manager.Respawn();
            
        }
    }

}
