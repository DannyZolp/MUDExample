using UnityEngine;

public class RoomMapNode
{
    private int x;
    private int y;
    private GameObject room;
    public RoomMapNode(int x, int y, GameObject room)
    {
        this.x = x;
        this.y = y;
        this.room = room;
    }

    public RoomMapNode(int[] coords, GameObject room)
    {
        this.x = coords[0];
        this.y = coords[1];
        this.room = room;
    }

    public int[] GetCoords()
    {
        int[] reference = { x, y };
        return reference;
    }

    public int GetXCoord()
    {
        return this.x;
    }

    public int GetYCoord()
    {
        return this.y;
    }

    public GameObject GetRoom()
    {
        return this.room;
    }
}
