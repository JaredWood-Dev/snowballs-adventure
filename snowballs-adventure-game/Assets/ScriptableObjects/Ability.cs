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
    public int amount;
    public bool canMoveWhileUsing;

    //the Ability class should also run the animation trigger of the "abilityName"
    public void activateAbility()
    {
        
        Debug.Log(abilityName);
        switch (abilityType)
        {
            case Type.melee:
                AnimationHandler.Instance.animateAbility(this);
                //this should call to the weapon controller and the animation handler (for the arms)
                break;
            case Type.ranged:
                AnimationHandler.Instance.animateAbility(this);
                ProjectileSpawner.Instance.spawnProjectile(this, damage);
                //this should call to the animation handler (for the arms) and the projectile spawner
                break;
            case Type.util:
                AnimationHandler.Instance.animateAbility(this);
                //this should call to the animation handler (for the arms) and character controller?
                break;
            case Type.summon:
                AnimationHandler.Instance.animateAbility(this);
                //this should call to the animation handler (for the arms) and the npc spawner
                break;

        }
    }

}
