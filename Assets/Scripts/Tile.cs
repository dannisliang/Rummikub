using UnityEngine;

[RequireComponent(typeof(TileManager))]
public class Tile : MonoBehaviour
{
    private TileValue tileValue;
    private Vector3 destination;

    private const float speed = 2f;

    private bool followMouse;
    private SpriteRenderer sr;
    private MeshRenderer childMr;

    private void Start()
    {
        followMouse = false;
        sr = GetComponent<SpriteRenderer>();
        childMr = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (!followMouse)
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
        else
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            transform.position = pos;
        }
    }

    private void OnMouseDown()
    {
        followMouse = true;
        sr.sortingOrder = TileManager.currLayerId;
        childMr.sortingOrder = TileManager.currLayerId;
        TileManager.currLayerId++;
    }

    private void OnMouseUp()
    {
        followMouse = false;
    }

    public void SetDestination(Vector3 dest)
        => destination = dest;
}
