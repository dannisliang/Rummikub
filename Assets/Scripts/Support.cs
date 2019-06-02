using UnityEngine;

public class Support : MonoBehaviour
{
    [SerializeField]
    private GameObject supportTilePrefab;

    private Tile[,] supportTiles;
    private TileSelector[,] backgroundTiles;
    private TileSelector currentHover;

    // Support size: 2*20 + offset of 10px on each side
    private const float tileWidth = 0.75f;
    private const float tileHeight = 1.02f;

    private void Start()
    {
        currentHover = null;
        supportTiles = new Tile[2, 20];
        backgroundTiles = new TileSelector[2, 20];
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
            {
                GameObject go = Instantiate(supportTilePrefab, transform);
                go.transform.position = new Vector3(transform.position.x + tileWidth * (y - 9), transform.position.y + tileHeight * (1 - i));
                TileSelector ts = go.GetComponent<TileSelector>();
                ts.SetSupport(this);
                backgroundTiles[i, y] = ts;
                supportTiles[i, y] = null;
            }
    }

    public void ResetHover()
        => currentHover = null;

    public void SetHover(TileSelector ts)
        => currentHover = ts;

    public void UnsetHover(TileSelector oldTs)
        => currentHover = (currentHover == oldTs ? null : currentHover);

    public void AddTile(Tile t)
    {
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
                if (supportTiles[i, y] == null)
                {
                    supportTiles[i, y] = t;
                    t.SetDestination(backgroundTiles[i, y].transform.position);
                    t.SetSupport(this);
                    return;
                }
    }

    public void ClickTile(TileSelector ts, bool press)
    {
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
            {
                if (backgroundTiles[i, y] == ts)
                {
                    if (supportTiles[i, y] != null)
                    {
                        if (press) supportTiles[i, y].PressTile();
                        else supportTiles[i, y].ReleaseTile();
                    }
                    break;
                }
            }
    }

    /// Exchange the position of 2 tiles in the support
    public void MoveTile(Tile t)
    {
        if (currentHover == null)
            return;
        int oldX = -1, oldY = -1;
        int newX = -1, newY = -1;
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 20; y++)
            {
                if (supportTiles[i, y] == t)
                {
                    oldX = i;
                    oldY = y;
                }
                if (backgroundTiles[i, y] == currentHover)
                {
                    newX = i;
                    newY = y;
                }
            }
        // Swap 2 tiles
        Tile tmp = supportTiles[newX, newY];
        supportTiles[newX, newY] = t;
        t.SetDestination(backgroundTiles[newX, newY].transform.position);
        supportTiles[oldX, oldY] = tmp;
        if (tmp != null)
        {
            tmp.SetDestination(backgroundTiles[oldX, oldY].transform.position);
            tmp.SetOnTopLayer();
        }
    }
}
