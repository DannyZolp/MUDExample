using System.Collections.Generic;
using UnityEngine;

public class RoomClass : MonoBehaviour
{
    private GameObject room;

    private GameObject[] doors;

    private LinkedList<GameObject> items;

    private LinkedList<GameObject> npcs;

    private LinkedList<GameObject> players;

    public RoomClass(GameObject room)
    {
        this.room = room;
        doors = new GameObject[4];
        items = new LinkedList<GameObject>();
        npcs = new LinkedList<GameObject>();
        players = new LinkedList<GameObject>();
    }

    // Sets and Gets

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
    public void AddPlayer(GameObject player) => this.players.AddLast(player);

    public void AddPlayer(LinkedList<GameObject> players) => this.players = players;

    public LinkedList<GameObject> PlayersLL => this.players;

    // Items
    public void AddItem(GameObject item) => this.players.AddLast(item);

    public void AddItem(LinkedList<GameObject> items) => this.items = items;

    public LinkedList<GameObject> ItemsLL => this.items;

    // NPCs
    public void AddNPC(GameObject npc) => this.npcs.AddLast(npc);

    public void AddNPC(LinkedList<GameObject> npcs) => this.npcs = npcs;

    public LinkedList<GameObject> NPCsLL => this.npcs;
}
