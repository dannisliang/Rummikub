using UnityEngine;

public class Tile : MonoBehaviour
{
    private TileValue tileValue;
    private Vector3? destination;
    private const float distLimit = 0.01f;
    private const float speed = 2f;

    private void Update()
    {
        if (destination != null)
        {
            transform.position = Vector3.Lerp(transform.position, destination.Value, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, destination.Value) < distLimit)
                destination = null;
        }
    }

    public void SetDestination(Vector3 dest)
        => destination = dest;
}
