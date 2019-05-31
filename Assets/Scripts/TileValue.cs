public struct TileValue
{
    public enum TileColor
    {
        Red,
        Black,
        Yellow,
        Blue
    }

    public TileValue(int cvalue, TileColor ccolor)
    {
        value = cvalue;
        color = ccolor;
    }

    public int value; // 0: Joker
    public TileColor color;
}