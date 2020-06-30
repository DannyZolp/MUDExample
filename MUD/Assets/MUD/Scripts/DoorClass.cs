using UnityEngine;

public class DoorClass : MonoBehaviour
{
    private bool isOpen;

    private string position;

    internal GameObject roomX;

    internal GameObject roomY;

    public DoorClass(string position, GameObject roomX, GameObject roomY = null)
    {
        isOpen = false;
        this.position = position;
        this.roomX = roomX;
        this.roomY = roomY;
    }

    public void changeStatus(bool isOpen)
    {
        this.isOpen = isOpen;
    }

    public bool getStatus()
    {
        return this.isOpen;
    }

    public string getPosition()
    {
        return this.position;
    }

    public void setRoomX(GameObject roomX)
    {
        this.roomX = roomX;
    }

    public GameObject getRoomX()
    {
        return this.roomX;
    }

    public void setRoomY(GameObject roomY)
    {
        this.roomY = roomY;
    }

    public GameObject getRoomY()
    {
        return this.roomY;
    }
}