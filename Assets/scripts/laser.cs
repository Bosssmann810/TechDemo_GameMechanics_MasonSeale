using System.Runtime.CompilerServices;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField] float defaultDistance = 150f;
    public IDamageable target;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int facingDirection = 1;
    public Shoot player;
    private void Awake()
    {
        firePoint = GetComponent<Transform>();
    }
    private void Start()
    {
        facingDirection = 1;
    }
    private void FireLazer()
    {
        firePoint = gameObject.transform;
        if (facingDirection > 0)
        {
            if (Physics2D.Raycast(firePoint.position, firePoint.transform.right))
            {
                RaycastHit2D hit = Physics2D.Raycast(firePoint.position, transform.right);
                Debug.Log("hit a thing");
                if (hit.collider.gameObject.TryGetComponent(out IDamageable targethit))
                {
                    DrawLazer(firePoint.position, hit.point);
                    target = hit.collider.gameObject.GetComponent<IDamageable>();
                    target.TakeDamage();
                }
                else
                {
                    DrawLazer(firePoint.position, firePoint.transform.right * defaultDistance);
                    target = null;
                }
            }
            else
            {

                DrawLazer(firePoint.position, firePoint.transform.right * defaultDistance);
            }
        }
        if(facingDirection < 0)
        {
            if (Physics2D.Raycast(firePoint.position, firePoint.transform.right * -1))
            {
                RaycastHit2D hit = Physics2D.Raycast(firePoint.position, transform.right * -1);
                Debug.Log($"laser hit: {hit.collider.gameObject}");
                if (hit.collider.gameObject.TryGetComponent(out IDamageable targethit))
                {
                    DrawLazer(firePoint.position, hit.point);
                    target = hit.collider.gameObject.GetComponent<IDamageable>();
                    target.TakeDamage();
                    Debug.Log($"laser hit & interactable: {hit.collider.gameObject}");
                }
                else
                {
                    DrawLazer(firePoint.position, firePoint.transform.right * -defaultDistance);
                    Debug.Log($"hit it and ignored it {hit.collider.gameObject}");
                    target = null;
                }
            }
            else
            {
                DrawLazer(firePoint.position, firePoint.transform.right * -defaultDistance);
            }

        }
    }
    public void DrawLazer(Vector2 start, Vector2 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

    }





    private void Update()
    {
        
        facingDirection = player.GiveDirection();
        FireLazer();
        

    }
}
