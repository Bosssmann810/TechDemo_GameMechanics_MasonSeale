using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Vector3 _closedPos;
    [SerializeField] Vector3 _openPos;
    [SerializeField] Transform _currentPos;
    [SerializeField] Vector3 _targetPos;
    int speed = 5;
    bool _isOpening;
    bool _isClosing;
    public AudioSource audio = new AudioSource();
    public AudioClip sound;
    bool alreadyPlayingAudio = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alreadyPlayingAudio = false;
        _currentPos = gameObject.transform;
        _closedPos = _currentPos.transform.position;
        _openPos = _currentPos.transform.position + Vector3.up * 4 ;
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {

        if (!_isOpening && !_isClosing)
        {
            audio.Stop();
            alreadyPlayingAudio = false;
            return;
        }
        else
        {
            Debug.Log("HIT IT");
            DoorSound();
        }
         _currentPos.transform.position = Vector3.MoveTowards(_currentPos.transform.localPosition, _targetPos, speed * Time.deltaTime);
        if (Vector3.Distance(_currentPos.transform.localPosition, _targetPos) < 0.01)
        {
            _isClosing = false;
            _isOpening = false;
        }
    }

    public void OpenDoor()
    {
        _isOpening = true;
        _isClosing = false;
        Debug.Log("Opening");
        _targetPos = _openPos;
        
    }
    public void CloseDoor()
    {
        _isOpening = false;
        _isClosing = true;
        Debug.Log("Closing");
        _targetPos = _closedPos;
        
    }
    public void DoorSound()
    {
        if(alreadyPlayingAudio == true)
        {
            return;
        }
        audio.Play();
        alreadyPlayingAudio = true; 
        

    }
}
