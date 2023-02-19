using System.Collections.Generic;
using UnityEngine;

public class classController : MonoBehaviour
{
    //this array holds all the possible classes.
    public Class[] classList = new Class[13];
    
    //this List holds classes which can be chosen from (useful on character death) 
    List<Class> possibleClasses = new List<Class>();

    //this List holds classes which have died (useful for cleric)
    List<Class> deadClasses = new List<Class>();


    //these variables hold the current class and its data for ease of access
    public Class currentClass;
    public Ability primary;
    public Ability secondary;
    public float primaryCooldown;
    public float secondaryCooldown;

    //these variables are used to check whether the cooldown has been met.
    private float primaryTimer = 0;
    private float secondaryTimer = 0;

    //these variables hold reference to objects for ease of changing sprites
    public SpriteRenderer hatSR;
    public SpriteRenderer weaponSR;
    public Transform weaponT;



    [Header("Use this to start with a certain class")]
    public int testClass;


    // Start is called before the first frame update
    void Start()
    {
        //sets to the current class to a random class (not the last one (cleric))
        //currentClass = classList[Random.Range(0, 12)];    
        setClass(classList[testClass]);    //this line is used until we have all the clases set up

        foreach (Class i in classList)
        {
            possibleClasses.Add(i);
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        //handles primary ability on mouse button 1 press
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > primaryTimer)
            {
                primary.activateAbility();
                primaryTimer = Time.time + primaryCooldown;
            } else
            {
                primaryTimer -= Time.deltaTime;
            }
        }

        //handles secondary ability on mouse button 2 press
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time > secondaryTimer)
            {
                secondary.activateAbility();
                secondaryTimer = Time.time + secondaryCooldown;
            }
            else
            {
                secondaryTimer -= Time.deltaTime;
            }
        }
    }

    //method used for changing the class, sets the current class and the cooldowns
    public void setClass(Class c) {
        currentClass = c;
        primary = c.primary;
        secondary = c.secondary;
        primaryCooldown = c.primaryCooldown;
        secondaryCooldown = c.secondaryCooldown;
        hatSR.sprite = c.hat;
        weaponSR.sprite = c.weapon;
        weaponT.localScale = c.weaponScale;
}
}
