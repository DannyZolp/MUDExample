using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class InstantinatePre
{
    private GameObject room;
    private Transform door;
    private Vector3 roomPosition;
    public InstantinatePre(GameObject room, Transform door, Vector3 roomPosition) {
        this.room = room;
        this.door = door;
        this.roomPosition = roomPosition;
    }

    public InstantinatePre()
    {

    }

    public void SetRoom(GameObject room) => this.room = room;

    public GameObject GetRoom() => this.room;

    public void SetDoor(Transform door) => this.door = door;

    public Transform GetDoor() => this.door;

    public void SetRoomPosition(Vector3 roomPosition) => this.roomPosition = roomPosition;

    public Vector3 GetRoomPosition() => this.roomPosition;
}
