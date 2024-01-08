using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public LoopingRoomMechanic LRM;

    //dont need this but will use it below
    public GameObject Door;

    public bool CanOpenDoor = false;
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
                    LRM.LevelChecker();
                }
                else if(hit.transform.name == "Key")
                {
                    LRM.PlayerInventory.Add(hit.transform.gameObject);
                    hit.transform.gameObject.SetActive(false);
                    Debug.Log("added key to inventory");
                }

            }
        }
    }
    /// <summary>
    /// Checks if the bool is true, if it is, spawn new chunk into map.
    /// NOTE: need to put can open door to false somewhere else.
    /// </summary>
    public void AddNewChunk()
    {
        if (CanOpenDoor == true)
        {
            Door.transform.position = new Vector3(0, 90, 0);
            LRM.SpawnNewChunk();
            LRM.CurrentLevel++;
            Debug.Log("new current level is " + LRM.CurrentLevel);
        }
        else
        {
            Debug.Log("Does not have everything to move forward");
        }
    }
}
