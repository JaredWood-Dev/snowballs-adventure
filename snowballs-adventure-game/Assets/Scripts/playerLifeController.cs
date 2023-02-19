using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLifeController : MonoBehaviour
{
    public int startingLives = 3;
    public int currentLives;
    void Start()
    {
        currentLives = startingLives;
    }

    public void attackPlayer()
    {
        GetComponent<Animator>().SetTrigger("die");
        
        //Update the current class to a new random class
        
        //Play particals
        
        GetComponent<Animator>().SetTrigger("revive");
        
        currentLives--;
    }
    
}
