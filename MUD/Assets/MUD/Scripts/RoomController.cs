using System;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject DoorXPOS;

    public GameObject DoorXNEG;

    public GameObject DoorZPOS;

    public GameObject DoorZNEG;

    private RoomClass rc;

    // Start is called before the first frame update
    void Start()
    {
        this.rc = new RoomClass(gameObject);
    }

    public GameObject SpawnDoor(string position)
    {
        if (position == "x+")
        {
            return Instantiate(DoorXPOS, gameObject.transform);
        }
        else if (position == "x-")
        {
            return Instantiate(DoorXNEG, gameObject.transform);
        }
        else if (position == "z+")
        {
            return Instantiate(DoorZPOS, gameObject.transform);
        }
        else if (position == "z-")
        {
            return Instantiate(DoorZNEG, gameObject.transform);
        }
        else
        {
            throw new ArgumentException("Door does not have a set position!");
        }
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