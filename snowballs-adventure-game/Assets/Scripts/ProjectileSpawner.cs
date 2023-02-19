
using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public static ProjectileSpawner Instance;

    void Awake()
    {
        Instance = this;
    }

    public GameObject magicMissilePrefab;

    public void spawnProjectile(Ability ability, float damage)
    {
        
        switch (ability.abilityName)
        {
            case "MagicMissile":
                for (int i = 0; i < ability.amount; i++)
                {
                    //instead of spawning at the magic missile prefab transform, will instead spawn at the Weapon position
                    Instantiate(magicMissilePrefab, new Vector2(-3,-3), Quaternion.identity);
                }

                break;
            case "Dagger":
                


                break;
            case "Fireball":
                
                break;
            case "Ukulele":

                break;
            case "Longbow":

                break;
            case "EldritchBlast":

                break;
            case "GuidingBolt":

                break;
        }
    }



    
}
