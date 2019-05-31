using UnityEngine;

public class Support : MonoBehaviour
{
    [SerializeField]
    private GameObject supportTilePrefab;

    private Tile[,] supportTiles;
    private Transform[,] backgroundTiles;

    // Support size: 2*20 + offset of 10px on each side
    private const float tileWidth = 0.75f;
    private const float tileHeight = 1.02f;

    private void Start()
    {
        supportTiles = new Tile[2, 20];
        backgroundTiles = new Transform[2, 20];
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
            {
                GameObject go = Instantiate(supportTilePrefab, transform);
                go.transform.position = new Vector3(transform.position.x + tileWidth * (y - 9), transform.position.y + tileHeight * (1 - i));
                backgroundTiles[i, y] = go.transform;
                supportTiles[i, y] = null;
            }
    }

    public void AddTile(Tile t)
    {
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
                if (supportTiles[i, y] == null)
                {
                    supportTiles[i, y] = t;
                    t.SetDestination(backgroundTiles[i, y].position);
                    return;
                }
    }
}
