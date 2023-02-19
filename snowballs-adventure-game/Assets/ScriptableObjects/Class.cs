using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewClass", menuName = "Class")]
public class Class : ScriptableObject
{
    //holds the name of the class, note that this is separate from "name" which is the default name unity gives to an object
    [Header("Name")]
    public string className;

    //These hold the ability objects. These will be called to in the "ClassController"
    [Header("Abilities")]
    public Ability primary;
    public Ability secondary;

    //Hold the values which detail how long before the abilities can be used again
    [Header("Cooldowns")]
    public float primaryCooldown;
    public float secondaryCooldown;

    //Hold the images which the player uses when putting on the hat, and when displaying the hat on the player
    [Header("Sprites")]
    public Sprite hat;
    public Sprite weapon;

    [Header("Scale")]
    public Vector2 weaponScale;

}
