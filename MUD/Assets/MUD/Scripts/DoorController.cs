using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string position;

    private DoorClass dc;

    private MapController mc;

    // Start is called before the first frame update
    void Start()
    {
        this.dc = new DoorClass(position, gameObject.GetComponentInParent<RoomController>().AddDoor(gameObject));
        this.mc = gameObject.transform.root.GetComponent<MapController>();
    }

    public GameObject SetRoomTo(GameObject RoomTo)
    {
        this.dc.setRoomY(RoomTo);

        return RoomTo;
    }
}
