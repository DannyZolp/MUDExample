using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject room;

    public int roomsNeeded = 4;

    public GameObject door;

    private MapClass mc;

    // Start is called before the first frame update
    internal void Start()
    {
        mc = new MapClass(roomsNeeded);

        GameObject CentralRoom = mc.AddRoom(Instantiate(this.room, gameObject.transform, true));
        CentralRoom.GetComponent<RoomController>().IsMiddle = true;

        CreateRoomsAndDecideDoors(CentralRoom, this.room);
    }

    /*    private Queue<GameObject> MakeRooms()
    {
        Queue<GameObject> output = new Queue<GameObject>();
        string[] doorTypes = { "x+", "x-", "z+", "z-" };
        while (mc.CanGenerateMoreRooms())
        {
            GameObject parent = rooms.Pop();

            GameObject[] parentDoors = parent.GetComponent<RoomController>().doors;
            if (parentDoors.Length < 3)
            {
                parent.GetComponent<RoomController>().SpawnDoor(doorTypes[parentDoors.Length]);
                rooms.Push(parent);
            }
            else if (parentDoors.Length >= 3)
            {
                GameObject[] doorList = parent.GetComponent<RoomController>().doors;
                output.Enqueue(parent);
                for (int i = 0; i <= 3; i++)
                {
                    rooms.Push(AddOneRoom(Instantiate(room, doorList[i].transform, true)));
                }
            }
        }

        while (rooms.Count != 0)
        {
            output.Enqueue(rooms.Pop());
        }

        return output;
    }*/
    private void CreateRoomsAndDecideDoors(GameObject CentralRoom, GameObject RoomToCopy)
    {
        Queue<GameObject> work = new Queue<GameObject>();

        work.Enqueue(CentralRoom);

        while (mc.GetRoomsNeeded() - mc.GetRoomsGenerated() >= 0)
        {
            GameObject goingToFix = work.Dequeue();

            if (goingToFix.GetComponent<RoomController>().IsMiddle)
            {
                goingToFix.GetComponent<RoomController>().DoorsToGenerate = 4;
                goingToFix = AddDoorsToThisRoom(goingToFix);
                for (int i = 0; i < 4; i++)
                {
                    work.Enqueue(mc.AddRoom(InstantinateRoomInADoor(goingToFix, RoomToCopy)));
                }
            }
            else
            {
                int DoorsToGenerate = mc.GetRoomsNeeded() - mc.GetRoomsGenerated() > 3 ? 3 : mc.GetRoomsNeeded() - mc.GetRoomsGenerated();

                goingToFix.GetComponent<RoomController>().DoorsToGenerate = DoorsToGenerate;
                goingToFix = AddDoorsToThisRoom(goingToFix);

                for (int i = 0; i < DoorsToGenerate; i++)
                {
                    work.Enqueue(mc.AddRoom(InstantinateRoomInADoor(goingToFix, RoomToCopy)));
                }
            }
        }
    }

    private GameObject AddDoorsToThisRoom(GameObject Room)
    {
        string[] doorTypes = { "x+", "x-", "z+", "z-" };

        for (int i = 0; i < Room.GetComponent<RoomController>().DoorsToGenerate; i++)
        {
            Room.GetComponent<RoomController>().SpawnDoor(doorTypes[i]);
        }

        return Room;
    }

    private GameObject InstantinateRoomInADoor(GameObject ParentRoom, GameObject NewRoom)
    {
        Transform[] Doors = new Transform[4];
        int DoorCounter = 0;

        for (int i = 0; i < ParentRoom.transform.childCount; i++)
        {
            if (ParentRoom.transform.GetChild(i).CompareTag("Door"))
            {
                Doors[DoorCounter] = ParentRoom.transform.GetChild(i);
                DoorCounter++;
            }
        }

        for (int i = 0; i <= DoorCounter; i++)
        {
            if (Doors[i].childCount <= 1)
            {
                Instantiate(NewRoom, Doors[i], true);
                break;
            }
        }
        return NewRoom;
    }
}
