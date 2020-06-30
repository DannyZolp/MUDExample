using System.Collections.Generic;
using UnityEngine;

public class RoomClass : MonoBehaviour
{
    private GameObject room;

    private GameObject[] doors = new GameObject[4];

    private List<GameObject> items = new List<GameObject>();

    private List<GameObject> npcs = new List<GameObject>();

    private List<GameObject> players = new List<GameObject>();

    private List<GameObject> childRooms = new List<GameObject>();

    public RoomClass(GameObject room)
    {
        this.room = room;
    }

    // Doors
    public void SetXPOS(GameObject door) => doors[0] = door;

    public GameObject GetXPOS() => doors[0];

    public void SetXNEG(GameObject door) => doors[1] = door;

    public GameObject GetXNEG() => doors[1];

    public void SetZPOS(GameObject door) => doors[2] = door;

    public GameObject GetZPOS() => doors[2];

    public void SetZNEG(GameObject door) => doors[3] = door;

    public GameObject GetZNEG() => doors[3];

    public GameObject[] GetDoors() => doors;

    // Players
    public void AddPlayer(GameObject player) => this.players.Add(player);

    public void AddPlayer(List<GameObject> players) => this.players = players;

    public List<GameObject> Players => this.players;

    // Items
    public void AddItem(GameObject item) => this.players.Add(item);

    public void AddItem(List<GameObject> items) => this.items = items;

    public List<GameObject> Items => this.items;

    // NPCs
    public void AddNPC(GameObject npc) => this.npcs.Add(npc);

    public void AddNPC(List<GameObject> npcs) => this.npcs = npcs;

    public List<GameObject> NPCs => this.npcs;
}