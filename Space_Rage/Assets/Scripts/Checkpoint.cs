using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var playermg = collision.collider.GetComponent<PlayerManager>();
            if (playermg != null)
            {
                playermg.startpos = transform.position;
                Debug.Log("Checkpoint");
            }
        }
    }
}
