using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Support support;

    private List<TileValue> tiles;

    private void Start()
    {
        tiles = new List<TileValue>();
        // 14 tiles of each color * 2 + 2 jokers
        for (int i = 0; i < 2; i++)
            for (int y = 0; y < 4; y++)
                for (int z = 1; z < 14; z++)
                    tiles.Add(new TileValue(z, (TileValue.TileColor)(y - 1)));
        tiles.Add(new TileValue(0, TileValue.TileColor.Black));
        tiles.Add(new TileValue(0, TileValue.TileColor.Red));
        for (int i = 0; i < 14; i++)
        {
            TileValue tv = GetRandomTile();
            GameObject go = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
            TextMesh tm = go.GetComponentInChildren<TextMesh>();
            tm.text = tv.value.ToString();
            switch (tv.color)
            {
                case TileValue.TileColor.Black:
                    tm.color = Color.black;
                    break;

                case TileValue.TileColor.Blue:
                    tm.color = Color.blue;
                    break;

                case TileValue.TileColor.Red:
                    tm.color = Color.red;
                    break;

                case TileValue.TileColor.Yellow:
                    tm.color = Color.yellow;
                    break;
            }
            support.AddTile(go.GetComponent<Tile>());
        }
    }

    private TileValue GetRandomTile()
    {
        TileValue t = tiles[Random.Range(0, tiles.Count)];
        tiles.Remove(t);
        return t;
    }
}
