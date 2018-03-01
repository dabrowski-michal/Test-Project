using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//optional class implementing crouching ability
public class Crouching : PlayerAbility
{

    protected override void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Crouching");
        }
    }
}
