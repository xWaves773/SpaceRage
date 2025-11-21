using UnityEngine;

public class Checkpoint : PlayerManager
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            startpos = transform.position;
        }
    }

}
