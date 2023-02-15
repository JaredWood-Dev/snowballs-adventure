using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Ability")]
public class Ability : ScriptableObject
{
    //holds the name of the ability
    [Header("Name")]
    public string abilityName;

    //sets up an enum for the tpye of ability
    public enum Type
    {
        melee,
        ranged,
        util,
        summon
    }

    //holds various important info about the ability
    [Header("Info")]
    public Type abilityType;
    public float damage;
    public bool canMoveWhileUsing;

    //the Ability class should also run the animation trigger of the "abilityName"


}
