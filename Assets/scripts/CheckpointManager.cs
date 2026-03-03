using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Vector3 _currentCheckPoint;

    [SerializeField] GameObject _player;
    void Awake()
    {
        _currentCheckPoint = this.transform.position;
        _player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCheckPoint(GameObject newCheckPoint)
    {
        _currentCheckPoint = newCheckPoint.transform.position;
    }

    public void Respawn()
    {
        _player.transform.position = _currentCheckPoint;
    }
    
}
