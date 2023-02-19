using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public Collider2D SpearCollider;

    public void hit(Ability ability)
    {
        switch (ability.abilityName)
        {
            case "Spear":
                foreach (NPCClass i in enemyManager.Instance.enemies)
                {
                    if(Physics2D.IsTouching(SpearCollider, i.npc.GetComponent<Collider2D>()))
                        i.Damage((int)ability.damage);
                }
                break;
        }

    }
}
