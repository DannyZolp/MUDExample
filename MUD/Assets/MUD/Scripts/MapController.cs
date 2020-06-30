using Oculus.Platform.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Leguar.TotalJSON;
using UnityEngine;

public class MapController : MonoBehaviour
{   
/*    private MapClass mapClass = new MapClass();
    public GameObject RoomToClone;
    void Start()
    {
        JSON json = JSON.ParseString(File.OpenText("Assets/ExampleJson.json").ReadToEnd());

        RoomWorker rw = new RoomWorker(json, gameObject.transform, RoomToClone);
        
    }*/

    // All of this is old code, only for reference!
    /*    public int RoomsToGenerate;
        public GameObject BlankRoom;

        private MapClass MapClass;

        // Start is called before the first frame update
        internal void Start()
        {
            // Instantiate Our MapClass
            this.MapClass = new MapClass(RoomsToGenerate);

            // Instantiate Our Work Queue
            Queue<GameObject> Work = new Queue<GameObject>();

            // Create Our Center Room, which we will be working with
            GameObject CentralRoom = CreateCentralRoom(MapClass, BlankRoom);

            // Add Doors to the Center Room
            CentralRoom = AddDoorsToRoomMiddle(CentralRoom.GetComponent<RoomController>());

            // Add CentralRoom to our MapClass's Room List
            this.MapClass.AddRoom(CentralRoom);

            // Create Rooms In The Doors We Instantiated
            foreach (Transform Door in GetDoorsFromRoom(CentralRoom.transform))
            {
                Work.Enqueue(this.MapClass.AddRoom(AddRoomToDoor(Door, this.BlankRoom, this.MapClass, false)));
            }

            // Sees if we need to generate more rooms
            while (this.MapClass.CanGenerateMoreRooms())
            { // If we can...
                *//*Debug.Log(this.MapClass.GetRoomsGenerated());*//*
                Transform CurrentRoom = Work.Dequeue().transform;

                int AmountOfRoomsToGenerate = this.MapClass.GetRoomsNeeded() - this.MapClass.GetRoomsGenerated();
                Debug.Log(AmountOfRoomsToGenerate);

                CurrentRoom = SetDoorAmountForRoom(CurrentRoom, AmountOfRoomsToGenerate > 3 ? 3 : AmountOfRoomsToGenerate);
                CurrentRoom = AddDoorsToRoom(CurrentRoom.GetComponent<RoomController>(), CurrentRoom.GetComponentInParent<DoorController>().position);

                foreach (Transform Door in GetDoorsFromRoom(CurrentRoom.transform))
                {
                    GameObject NewRoom = AddRoomToDoor(Door, this.BlankRoom, this.MapClass);
                    if (NewRoom != null) 
                    {
                        Work.Enqueue(this.MapClass.AddRoom(NewRoom));
                    }
                }
            }
        }

        private GameObject CreateCentralRoom(MapClass mc, GameObject RoomToCopy)
        {
            GameObject CentralRoom = mc.AddRoom(Instantiate(RoomToCopy, gameObject.transform, true));
            CentralRoom.GetComponent<RoomController>().IsMiddle = true;

            return CentralRoom;
        }

        private Transform SetDoorAmountForRoom(Transform Room, int Doors)
        {
            Room.GetComponent<RoomController>().DoorsToGenerate = Doors;

            return Room;
        }

        private GameObject AddDoorsToRoomMiddle(RoomController Room)
        {
            string[] Doors = { "x+", "x-", "z+", "z-" };
            foreach (string Door in Doors)
            {
                Room.SpawnDoor(Door);
            }

            return Room.gameObject;
        }

        private Transform AddDoorsToRoom(RoomController Room, string DoorComingFrom)
        {
            string[] Doors = { "x+", "x-", "z+", "z-" };
            for (int i = 0; Room.CanGenerateMoreRooms() && i<Doors.Length; i++)
            {
                if (GetOppositeDoor(DoorComingFrom) != Doors[i])
                {
                    Room.SpawnDoor(Doors[i]);
                }
            }
            return Room.transform;
        }

        private string GetOppositeDoor(string door)
        {
            string[] normalDoors = { "x+", "x-", "z+", "z-" };
            string[] oppositeDoors = { "x-", "x+", "z-", "z+" };

            for (int i = 0; i < 4; i++)
            {
                if (normalDoors[i] == door)
                {
                    return oppositeDoors[i];
                }
            }
            throw new ArgumentException("Door String Isn't Correct!", "door");
        }

        private Transform[] GetDoorsFromRoom(Transform Room)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform tf in Room.GetComponentsInChildren<Transform>())
            {
                if (tf.tag == "Door")
                {
                    children.Add(tf);
                }
            }

            return children.ToArray();
        }

        private GameObject AddRoomToDoor(Transform Door, GameObject BlankRoom, MapClass mc, bool DoExistCheck = true)
        {
            if (Door.childCount >= 1)
            {
                Vector3 PositionForRoom = GetPositionForNewRoomFromParentDoor(Door);
                GameObject RoomThatAlreadyExists = null;
                if (DoExistCheck)
                {
                    RoomThatAlreadyExists = IsPositionTaken(PositionForRoom, mc.GetRooms().ToArray());
                }

                if (RoomThatAlreadyExists == null)
                {
                    GameObject room = Instantiate(BlankRoom, PositionForRoom, BlankRoom.transform.rotation, Door);
                    room.name = mc.GetRoomsGenerated().ToString();
                    return room;
                }
                else
                {
                    Door.GetComponent<DoorController>().SetRoomTo(RoomThatAlreadyExists);
                    return null;
                }
            }
            throw new Exception("All Doors Already Have A Room Generated!");
        }

        private Vector3 GetPositionForNewRoomFromParentDoor(Transform parentDoor)
        {
            DoorController dc = parentDoor.GetComponent<DoorController>();
            Vector3 parentPosition = dc.GetVector3();
            if (dc.position == "x+")
            {
                parentPosition.x += 10;
            }
            else if (dc.position == "x-")
            {
                parentPosition.x -= 10;
            }
            else if (dc.position == "z+")
            {
                parentPosition.z += 10;
            }
            else if (dc.position == "z-")
            {
                parentPosition.z -= 10;
            }
            else
            {
                throw new ArgumentException("Door does not have a set position!");
            }
            return parentPosition;
        }

        private GameObject IsPositionTaken(Vector3 Request, GameObject[] RoomList)
        {
            foreach (GameObject Room in RoomList)
            {
                if (Room.transform.position == Request)
                {
                    return Room;
                }
            }
            return null;
        }*/
}