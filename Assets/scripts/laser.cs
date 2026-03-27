using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class laser : MonoBehaviour
{
    [SerializeField] float defaultDistance = 150f;
    public IDamageable target;
    public Transform maxRangeObject;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int facingDirection = 1;
    public Shoot player;
    public LayerMask layerMask;
    private void Awake()
    {
        firePoint = GetComponent<Transform>();

    }
    private void Start()
    {
        facingDirection = 1;
    }
    //while the lazer is fireing
    private void FireLazer()
    {
        //update fireing position
        firePoint = gameObject.transform;
        //if facing right
        if (facingDirection > 0)
        {
            //shoot a raycast
            if (Physics2D.Raycast(firePoint.position, firePoint.transform.right,layerMask))
            {
                //ind what we hit
                RaycastHit2D hit = Physics2D.Raycast(firePoint.position, transform.right);

                Debug.Log($"laser hit: {hit.collider.gameObject}");
                //if it can be damaged
                if (hit.collider.gameObject.TryGetComponent(out IDamageable targethit))
                {
                    //draw the lazer to it
                    DrawLazer(firePoint.position, hit.point);
                    //do damage to the target
                    target = hit.collider.gameObject.GetComponent<IDamageable>();
                    target.TakeDamage();
                }
                //if it hits something that is not a damageable
                else
                {
                    Debug.Log("not damageable");
                    //draw the lazer to it but make sure there is no target
                    DrawLazer(firePoint.position, hit.point);
                    target = null;
                }

            }
            //if it dosnt hit 
            else
            {
                //draw the lazer to the max position
                DrawLazer(firePoint.position, maxRangeObject.transform.position);
                target = null;
            }
        }
        //same stuff but for the left side
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
                    DrawLazer(firePoint.position, hit.point);
                    target = null;
                }
            }
            else
            {
                DrawLazer(firePoint.position, maxRangeObject.transform.position);
            }

        }
    }
    //self explanitory
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
