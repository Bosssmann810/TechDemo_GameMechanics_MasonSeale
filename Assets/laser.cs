using System.Runtime.CompilerServices;
using UnityEngine;

public class laser : MonoBehaviour
{
    public IDamageable target;
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("hit a thing");
        if (other.TryGetComponent(out IDamageable targethit))
        {
            target = targethit;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable targethit))
        {
            target = null;
        }

    }
    private void Update()
    {
        if (target != null)
        {
            target.TakeDamage();
        }
    }
}
