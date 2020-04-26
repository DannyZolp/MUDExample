using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCollision : MonoBehaviour
{
    public static GameObject RoomIn;
    private GameObject FPV;
    private string DoorMaterial;
    private string RoomMaterial;

    void Start()
    {
        this.FPV = GameObject.Find("FPV");
        this.DoorMaterial = GameObject.Find("DoorXPOS").GetComponent<Renderer>().material.name;
        this.RoomMaterial = GameObject.Find("WallXPOS").GetComponent<Renderer>().material.name;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject colliderGO = collision.collider.gameObject;
        if (colliderGO.transform.parent.gameObject.tag == GameObject.Find("Home").gameObject.tag)
        {
            RoomIn = colliderGO.transform.parent.gameObject;
            //Debug.Log("Found New Room " + RoomIn.name);
        }
    }
}
