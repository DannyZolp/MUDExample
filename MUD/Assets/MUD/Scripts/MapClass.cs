using System.Collections.Generic;
using UnityEngine;

public class MapClass : MonoBehaviour
{
    private LinkedList<GameObject> rooms;

    private int roomsNeeded;

    private int roomsGenerated;

    public MapClass(int roomsNeeded)
    {
        rooms = new LinkedList<GameObject>();
        this.roomsNeeded = roomsNeeded;
        this.roomsGenerated = 0;
    }

    public GameObject AddRoom(GameObject room)
    {
        this.rooms.AddLast(room);
        IncreaseRoomsGenerated();
        return room;
    }

    public LinkedList<GameObject> GetRooms()
    {
        return this.rooms;
    }

    public int GetRoomsNeeded()
    {
        return this.roomsNeeded;
    }

    public void IncreaseRoomsGenerated()
    {
        this.roomsGenerated++;
    }

    public void SetRoomsGenerated(int roomsGenerated)
    {
        this.roomsGenerated = roomsGenerated;
    }

    public int GetRoomsGenerated()
    {
        return this.roomsGenerated;
    }

    public bool CanGenerateMoreRooms()
    {
        return !(GetRoomsGenerated() >= GetRoomsNeeded());
    }
}
