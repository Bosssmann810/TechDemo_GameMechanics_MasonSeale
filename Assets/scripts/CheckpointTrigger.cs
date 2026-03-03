using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject checkpoint;
    CheckpointManager manager;

    private void Awake()
    {
        checkpoint = this.gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("entered");
            if(collision.GetComponent<CheckpointManager>() == null)
            {
                Debug.LogError("No checkpoint manager found");
            }
            manager = collision.GetComponent<CheckpointManager>();
            manager.ChangeCheckPoint(checkpoint);
        }
    }
}
