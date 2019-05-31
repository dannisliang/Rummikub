using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Support : MonoBehaviour
{
    private Tile[,] supportTiles;
    private SpriteRenderer sr;

    // Support size: 2*20 + offset of 10px on each side
    private const float tileWidth = 0.71f;
    private const float tileHeight = 0.98f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        supportTiles = new Tile[2,20];
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
                supportTiles[i, y] = null;
    }

    public void AddTile(Tile t)
    {
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
                if (supportTiles[i, y] == null)
                {
                    supportTiles[i, y] = t;
                    t.SetDestination(new Vector3(transform.position.x + (-13.5f * tileWidth + y) * tileWidth, transform.position.y + (tileHeight * 0.5f - i) * tileHeight));
                    return;
                }
    }
}
