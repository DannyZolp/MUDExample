using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class MapClass
{
    private List<GameObject> Rooms;
    private int RoomsGenerated;
    
    public MapClass()
    {
        this.Rooms = new List<GameObject>();
    }

    public int GetRoomsGenerated() => this.RoomsGenerated;
    public void SetRoomsGenerated(int RoomsGenerated) => this.RoomsGenerated = RoomsGenerated;
    public List<GameObject> GetRoomList() => this.Rooms;
    public void SetRoomList(List<GameObject> rooms) => this.Rooms = rooms;
}