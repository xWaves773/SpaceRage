using UnityEngine;

public class PlayerChain : MonoBehaviour
{
    public Rigidbody otherPlayer;
    public float maxDistance = 6f;
    public float springForce = 50f;

    void Start()
    {
        SpringJoint joint = gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = otherPlayer;
        joint.maxDistance = maxDistance;
        joint.spring = springForce;
    }
}
