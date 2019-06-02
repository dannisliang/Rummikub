using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TileSelector : MonoBehaviour
{
    private Support support;

    public void SetSupport(Support newSupport)
        => support = newSupport;

    private void OnMouseEnter()
    {
        support.SetHover(this);
    }

    private void OnMouseExit()
    {
        support.UnsetHover(this);
    }

    private void OnMouseDown()
    {
        support.ClickTile(this, true);
    }

    private void OnMouseUp()
    {
        support.ClickTile(this, false);
    }
}
