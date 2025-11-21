using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector3 startpos;

    private void Start()
    {
        startpos = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        transform.position = startpos;
    }
}
