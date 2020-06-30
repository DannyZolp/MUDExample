using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;

public class RoomMap
{
    List<RoomMapNode> rmn = new List<RoomMapNode>();
    public RoomMap(GameObject CenterRoom)
    {
        rmn.Add(new RoomMapNode(0, 0, CenterRoom));
    }

    public void Add(int[] RoomCoords, GameObject room)
    {
        rmn.Add(new RoomMapNode(RoomCoords, room));
    }

    public bool Includes(int[] RoomCoords)
    {
        foreach (RoomMapNode rmn in this.rmn)
        {
            if (rmn.GetCoords() == RoomCoords)
            {
                return true;
            }
        }
        return false;
    }

    public GameObject GetRoom(int[] RoomCoords)
    {
        foreach (RoomMapNode rmn in this.rmn)
        {
            if (rmn.GetCoords() == RoomCoords)
            {
                return rmn.GetRoom();
            }
        }
        return null;
    }

    public int Count()
    {
        return this.rmn.Count;
    }

    public List<RoomMapNode> GetList()
    {
        return this.rmn;
    }
}