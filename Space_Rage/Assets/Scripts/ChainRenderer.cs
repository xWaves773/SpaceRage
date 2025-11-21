using UnityEngine;

public class ChainRenderer : MonoBehaviour
{
    public Transform playerA;
    public Transform playerB;
    private LineRenderer line;

    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.blue;
        line.endColor = Color.blue;
    }

    void Update()
    {
        line.SetPosition(0, playerA.position);
        line.SetPosition(1, playerB.position);
    }
}
