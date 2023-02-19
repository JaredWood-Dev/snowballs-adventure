using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public static AnimationHandler Instance;


    void Awake()
    {
        Instance = this;
    }
    
    public Animator animator;

    public void animateAbility(Ability ability)
    {

        switch (ability.abilityName)
        {
            case "MagicMissile":
                animator.SetTrigger("castSpell");
                break;
            case "UpCast":
                animator.SetTrigger("castSpell");
                break;
            case "Dagger":
                animator.SetTrigger("throwDagger");
                break;
            case "Dash":
                
                break;
            case "Spear":
                animator.SetTrigger("useSpear");
                break;
            case "Shield":
                animator.SetTrigger("useShield");
                break;
            
        }
    }




}

