using Leguar.TotalJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class RoomWorker : MonoBehaviour
{
    public JSON rooms = null;

    public GameObject RoomToCopy = null;

    private RoomMap roomMap;
    

    // Start is called before the first frame update
    private void Start()
    {
        JSON json = JSON.ParseString(File.OpenText("Assets/ExampleJson.json").ReadToEnd());
        StartRoomGeneration(json, gameObject.transform, this.RoomToCopy);
    }

    public void StartRoomGeneration(JSON input, Transform MapController, GameObject RoomToClone)
    {
        rooms = input.GetJSON("roomBinTree");

        int[] MiddleCoords = { 0, 0 };

        GameObject CentralRoom = GenerateRoom(MiddleCoords, RoomToClone, MapController);

        this.roomMap = new RoomMap(CentralRoom);

        string[] doorTypes = { "x+", "x-", "z+", "z-" };
        foreach (string door in doorTypes)
        {
            CentralRoom.GetComponent<RoomController>().SpawnDoor(door);
        }

        for (int i = 0; i < rooms.GetJArray("children").Length; i++)
        {
            StartCoroutine(RoomGeneration(rooms.GetJArray("children").GetJSON(i), CentralRoom.transform, RoomToClone));
        }
        return;
    }

    IEnumerator RoomGeneration(JSON roomAndChildren, Transform Parent, GameObject RoomToClone)
    {
        Debug.Log("Starting Coroutine");
        int[] coords = GetCorrectlyFormattedPosition(roomAndChildren.GetJArray("roomCoords"));

        GameObject Room = GenerateRoom(coords, RoomToClone, Parent);

        this.roomMap.Add(coords, Room);

        if (roomAndChildren.ContainsKey("children"))
        {
            JArray children = roomAndChildren.GetJArray("children");
            for (int i = 0; i < children.Length; i++)
            {
                if (children.GetJSON(i).GetJArray("roomCoords").ContainsValue("pointer"))
                {
                    int[] pointerCoords = GetCorrectlyFormattedPosition(children.GetJSON(i).GetJArray("roomCoords"));
                    AddDoorToCurrentRoomForNewRoom(Room.GetComponent<RoomController>(), coords, pointerCoords);
                } else
                {
                    int[] newRoomCoords = GetCorrectlyFormattedPosition(children.GetJSON(i).GetJArray("roomCoords"));
                    StartCoroutine(RoomGeneration(children.GetJSON(i), Room.transform, RoomToClone));
                    AddDoorToCurrentRoomForNewRoom(Room.GetComponent<RoomController>(), coords, newRoomCoords);
                }
            }
        }
        yield return null;
    }

    private GameObject GenerateRoom(int[] RoomCoords, GameObject RoomToClone, Transform Parent)
    {
        Vector3 roomPosition = new Vector3(RoomCoords[0] * 10, 0f, RoomCoords[1] * 10);

        GameObject generatedRoom = Instantiate(RoomToClone, roomPosition, RoomToClone.transform.rotation, Parent);

        return generatedRoom;
    }

    private int[] GetCorrectlyFormattedPosition(JArray roomCoords)
    {
        int[] reference = { roomCoords.GetInt(0), roomCoords.GetInt(1) };

        return reference;
    }

    private void AddDoorToCurrentRoomForNewRoom(RoomController currentRoom, int[] currentRoomPosition, int[] newRoom)
    {
        if (currentRoomPosition[0] + 1 == newRoom[0])
        {
            currentRoom.SpawnDoor("x+");
        }
        else if (currentRoomPosition[0] - 1 == newRoom[0])
        {
            currentRoom.SpawnDoor("x-");
        }
        else if (currentRoomPosition[1] + 1 == newRoom[1])
        {
            currentRoom.SpawnDoor("z+");
        }
        else if (currentRoomPosition[1] - 1 == newRoom[1])
        {
            currentRoom.SpawnDoor("z-");
        }
    }
}