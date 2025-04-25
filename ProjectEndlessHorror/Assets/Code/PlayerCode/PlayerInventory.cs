using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    [Header("Player inventory")]
    public List<GameObject> PlayersInventoryList;
    public LevelManager LevelManagerRef;

    /// <summary>
    /// Checks to see if the player has the key to open the door to the next level
    /// </summary>
    /// <returns></returns>
    public bool DoesPlayerHaveKey()
    {
        if(PlayersInventoryList.Find(x => x.name.Contains("MainKey")))
            return true;
        else return false;
    }
    /// <summary>
    /// Checks to see if the player has another key to open a side door
    /// </summary>
    /// <returns></returns>
    public bool DoesPlayerHaveSecondDoorKey()
    {
        if(PlayersInventoryList.Find(x => x.name.Contains("SecondDoorKey")))
        {
            Debug.Log("its fuckin true");
            return true;
        }   
        else return false;
    }

    public bool DoesPlayerHaveADollar()
    {
        if (PlayersInventoryList.Find(x => x.name.Contains("Dollar")))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Deletes all gameobjects in the Players inventory list
    /// </summary>
    public void ClearInventoryList() => PlayersInventoryList.Clear(); //this needs to only take out main key object and leave money 

    /// <summary>
    /// This function makes it so when the player has the money, get the key and remove the money from there person, so a bug does not happen
    /// </summary>
    public void RemoveDollarWhenObtainKey()//this throws a argurment..waiting to see if it works..
    {
        if(DoesPlayerHaveADollar())
        {
            foreach(GameObject gameobject in PlayersInventoryList.Reverse<GameObject>())//idk why going backward should work but we will see..
            {
                if(gameobject.name == "Dollar")
                    PlayersInventoryList.Remove(gameobject);
            }
        }
        else
            return;
    }
}
