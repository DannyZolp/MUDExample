using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string position;

    private GameObject RoomYHold;

    private DoorClass dc;

    private MapController mc;

    // Start is called before the first frame update
    private void Start()
    {
        if (RoomYHold != null)
        {
            this.dc = new DoorClass(position, RoomYHold);
        } else
        {
            this.dc = new DoorClass(position, gameObject.GetComponentInParent<RoomController>().AddDoor(gameObject));
        }
        this.mc = gameObject.transform.root.GetComponent<MapController>();
    }

    public Vector3 GetVector3()
    {
        return gameObject.transform.position;
    }

    public GameObject SetRoomTo(GameObject RoomTo)
    {
        this.RoomYHold = RoomTo;
        return RoomTo;
    }
}