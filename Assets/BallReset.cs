using UnityEngine;

public class BallReset : MonoBehaviour
{
    public Vector3 normal = new Vector3(1, 1, 1);
    public Vector3 platformScale; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platformScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnPlatform()
    {
        gameObject.transform.localScale = platformScale;
    }

    public void OffPlatform()
    {
        gameObject.transform.localScale = normal;
    }
}
