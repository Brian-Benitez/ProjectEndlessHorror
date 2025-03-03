
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EasterEggController : MonoBehaviour
{
    [Header("Booleans")]
    public bool IsEasterEggEnabled = false;

 
    public void EnableEasterEggBool() => IsEasterEggEnabled = true;

    public void DisableEasterEggBool() => IsEasterEggEnabled = false;

    public void EasterEggState()
    {

    }

}
