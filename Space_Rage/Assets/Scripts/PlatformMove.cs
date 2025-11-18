using System.Collections;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject PointA;
    [SerializeField] GameObject PointB;
    [SerializeField] float speed = 10f;
    [SerializeField] float delay = 1f;

    private Vector3 targetposition;
    void Start()
    {
        platform.transform.position = PointA.transform.position;
        targetposition = PointB.transform.position;
        StartCoroutine(Moveplatform());
    }

    IEnumerator Moveplatform()
    {
        while (true)
        {
            while ((targetposition - platform.transform.position).sqrMagnitude > 0.01f)
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, 
                    targetposition, speed * Time.deltaTime);
                yield return null;
            }

            targetposition = targetposition == PointA.transform.position 
                ? PointB.transform.position : PointA.transform.position;

            yield return new WaitForSeconds(delay);
        }
    }
}
