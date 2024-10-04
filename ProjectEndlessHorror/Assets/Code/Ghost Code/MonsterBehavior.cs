using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [Header("Monsters Info")]
    [SerializeField] private float _speed = 1.5f;//Monsters speed to points or to the player

    [Header("Positions")]
    public Transform JumpScarePos;
    public GameObject EndPoint;

    private void Update()
    {
        MoveMonster();
    }

    public void MoveMonster()
    {
        if(this.transform.position == EndPoint.transform.position)
        {
            this.transform.gameObject.SetActive(false);
            return;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, _speed * Time.deltaTime);
    }

    public void MonstersJumpScarePosition()
    {
        this.transform.position = JumpScarePos.transform.position;
        //Play jump scare animation here.
    }
}
