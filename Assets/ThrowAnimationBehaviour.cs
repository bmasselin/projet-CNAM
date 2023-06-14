using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThrowAnimationBehaviour : StateMachineBehaviour

/* Explication ChatGPT: ce script permet de déclencher le lancement de l'objet à un moment spécifique de l'animation. Il s'assure que le lancement de l'objet ne se produit qu'une seule fois pendant cet état d'animation spécifique. Il est souvent utilisé lorsque vous souhaitez synchroniser l'action de lancer un objet avec une certaine partie de l'animation, par exemple lorsque le personnage jette une boule de feu ou lance un projectile pendant une animation d'attaque.*/
{
    private bool eventThrowDone = false;
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThrowObject to = animator.GetComponent<ThrowObject>();
        if (stateInfo.normalizedTime > to.MomentToThrow)
        {
            if (!eventThrowDone)
                animator.GetComponent<ThrowObject>().ThrowTheObject();
            eventThrowDone = true;
        }
        else
        {
            eventThrowDone = false;
        }

    }
}
