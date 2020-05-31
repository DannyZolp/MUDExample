using System;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject DoorXPOS;

    public GameObject DoorXNEG;

    public GameObject DoorZPOS;

    public GameObject DoorZNEG;

    public int DoorsToGenerate;

    public bool IsMiddle;

    private RoomClass rc;

    private MapController mc;

    public GameObject[] doors;

    // Start is called before the first frame update
    internal void Start()
    {
        this.rc = new RoomClass(gameObject);
        this.mc = gameObject.transform.root.GetComponent<MapController>();
        string[] doors = { "x+", "x-", "z+", "z-" };
        string parentDoorPos = gameObject.GetComponentInParent<DoorController>().position;
    }

    private string GetOppositeDoor(string door)
    {
        if (door == "x+")
        {
            return "x-";
        }
        else if (door == "x-")
        {
            return "x+";
        }
        else if (door == "z+")
        {
            return "z-";
        }
        else if (door == "z-")
        {
            return "z+";
        }
        else
        {
            return null;
        }
    }

    public GameObject SpawnDoor(string position)
    {
        GameObject output;
        if (position == "x+")
        {
            output = Instantiate(DoorXPOS, gameObject.transform);
        }
        else if (position == "x-")
        {
            output = Instantiate(DoorXNEG, gameObject.transform);
        }
        else if (position == "z+")
        {
            output = Instantiate(DoorZPOS, gameObject.transform);
        }
        else if (position == "z-")
        {
            output = Instantiate(DoorZNEG, gameObject.transform);
        }
        else
        {
            throw new ArgumentException("Door does not have a set position!");
        }
        return output;
    }

    public GameObject AddDoor(GameObject door)
    {
        DoorController dc = door.GetComponent<DoorController>();
        if (dc.position == "x+")
        {
            rc.SetXPOS(door);
        }
        else if (dc.position == "x-")
        {
            rc.SetXNEG(door);
        }
        else if (dc.position == "z+")
        {
            rc.SetZPOS(door);
        }
        else if (dc.position == "z-")
        {
            rc.SetZNEG(door);
        }
        else
        {
            throw new ArgumentException("Door does not have a set position!");
        }
        return gameObject;
    }
}
 