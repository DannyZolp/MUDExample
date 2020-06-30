using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Navigator : MonoBehaviour
{
    GameObject user;
    AILerp ai;
    void Start() {
        this.user = GameObject.Find("FirstPerson-AIO");
        this.ai = gameObject.GetComponent<AILerp>();
    }
}
