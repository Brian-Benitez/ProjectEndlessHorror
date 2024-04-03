using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [Header("Scripts")]
    public MonsterBehavior monster;
    public MonsterAnimations monsterAnimations;


    private void Start()
    {
        //Probably wanna set the ghost and player stuff on start.
    }

    //Adding more code here so I can check on the level and what the player has done.
    //Also just realized that I cant add the puzzle here...
    //It would be doing too much.
}
