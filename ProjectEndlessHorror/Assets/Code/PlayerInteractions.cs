using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public LoopingRoomMechanic LRM;

    //dont need this but will use it below
    public GameObject Door;
   //How this works,
   //The player shoots a raycast on the door.
   //Then in looping room mechanic, it will check to see if everything is done in the room.
   //If it is, spawn new room, then player goes through.
    void Update()
    {
        //player input
        Ray ray = new Ray(transform.position, transform.forward);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.name == "Door")
                {
                    Debug.Log("gecho ass outta here");
                    //LRM.SpawnBackToStart();
                    Door.transform.position = new Vector3(0, 90, 0);
                    LRM.SpawnNewChunk();
                }

            }
        }
    }
}
