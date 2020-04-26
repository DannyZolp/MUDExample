using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    private static int roomCount = 0;
    public static void EnterFromRoom(GameObject CurrentRoom, GameObject userCam, GameObject DoorCollision)
    {
        roomCount++;
        string currDoorPos = DoorCollision.tag;
        //Debug.Log("Found tag " + currDoorPos);
        bool[] existings = { false, false, false, false};
        int[] pos = { 0, 0 };
        if (currDoorPos == "XPOS")
        {
            pos[0] = 10;
            existings[1] = true;
        } else if (currDoorPos == "XNEG")
        {
            pos[0] = -10;
            existings[0] = true;
        } else if (currDoorPos == "ZPOS")
        {
            pos[1] = 10;
            existings[3] = true;
        } else if (currDoorPos == "ZNEG")
        {
            pos[1] = -10;
            existings[2] = true;
        } else
        {
            throw new ArgumentException("Incorrect Door Position" + currDoorPos, "currDoorPos");
        }
        GameObject developedRoom = CreateRoom(CurrentRoom, pos);
        AddDoors(developedRoom, existings);
        userCam.transform.position = new Vector3(developedRoom.transform.position.x, 0f, developedRoom.transform.position.z);
    }

    public static GameObject CreateRoom(GameObject oldRoom, int[] relativePosition) // relative position includes an x (bucket 0) and a y (bucket 1)
    {
        //Debug.Log("Creating Room");
        GameObject newRoom = Instantiate(oldRoom, new Vector3(oldRoom.transform.position.x + relativePosition[0], 0f, oldRoom.transform.position.z + relativePosition[1]), oldRoom.transform.rotation);
        newRoom.name = "Room-" + roomCount;
        return newRoom;
    }

    public static void AddDoors(GameObject room, bool[] existings)
    {
        GameObject doorSetup = GameObject.Find("Doors");
        GameObject[] doors = { doorSetup.transform.Find("DoorXPOS").gameObject, doorSetup.transform.Find("DoorXNEG").gameObject, doorSetup.transform.Find("DoorZPOS").gameObject, doorSetup.transform.Find("DoorZNEG").gameObject };
        GameObject newDoors = new GameObject("Doors-" + roomCount);
        for (int i = 0; i <= existings.Length-1; i++)
        {
            if (!existings[i])
            {
                Instantiate(doors[i], new Vector3(doors[i].transform.position.x, 2f, doors[i].transform.position.z), doors[i].transform.rotation).gameObject.transform.parent = newDoors.transform;
                //Debug.Log("Spawning door " + doors[i].name);
            }
        }
        newDoors.transform.position = new Vector3(room.transform.position.x, 0f, room.transform.position.z);
    }
}
