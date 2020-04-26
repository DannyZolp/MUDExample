using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public GameObject roomTo;
    public GameObject roomFrom;
    private GameObject roomIn;

    void Update()
    {
        this.roomIn = UserCollision.RoomIn;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == GameObject.Find("FPV"))
        {
            if (roomTo == null)
            {
                RoomHandler.EnterFromRoom(this.roomIn, GameObject.Find("FPV"), gameObject);
            }
            else
            {
                if (this.roomIn == roomTo)
                {
                    GameObject.Find("FPV").transform.position = new Vector3(roomFrom.transform.position.x, 0f, roomFrom.transform.position.z);
                }
                else if (this.roomIn == roomFrom)
                {
                    GameObject.Find("FPV").transform.position = new Vector3(roomTo.transform.position.x, 0f, roomTo.transform.position.z);
                }
                else
                {
                    throw new System.Exception("DoorHandler Error: " + roomTo.name + roomFrom.name + roomIn.name);
                }
            }
        } else
        {
            if (roomFrom == null)
            {
                if (collision.collider.transform.parent.gameObject.tag == GameObject.Find("Home").tag)
                {
                    roomFrom = collision.collider.gameObject.transform.parent.gameObject;
                }
            }
            else if (GameObject.Find("Home").CompareTag(collision.collider.transform.parent.gameObject.tag) & roomFrom != collision.collider.gameObject.transform.parent.gameObject)
            {
                roomTo = collision.collider.gameObject.transform.parent.gameObject;
            }
        }
    }
}
