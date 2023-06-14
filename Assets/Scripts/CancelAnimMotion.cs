using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Explication ChatGPT Le script CancelAnimMotion peut servir dans diverses situations où vous souhaitez annuler le mouvement d'animation d'un objet dans Unity. Voici quelques cas d'utilisation possibles :

Réinitialisation de position : Si vous avez une animation qui déplace un objet à une certaine position pendant l'exécution d'une animation, vous pouvez utiliser ce script pour réinitialiser l'objet à sa position de départ après chaque frame. Cela peut être utile si vous voulez empêcher l'objet de se déplacer à une nouvelle position pendant l'animation.

Élimination de mouvements indésirables : Si vous constatez que certaines animations ou scripts provoquent un mouvement indésirable sur un objet et que vous souhaitez le supprimer, vous pouvez attacher ce script à l'objet pour annuler le mouvement à chaque frame.

Correction de problèmes de synchronisation : Parfois, lorsque vous combinez plusieurs animations ou scripts, vous pouvez rencontrer des problèmes de synchronisation où un mouvement d'animation interfère avec un autre mouvement prévu. En utilisant ce script, vous pouvez maintenir l'objet à sa position de départ, ce qui peut aider à résoudre ces problèmes de synchronisation.

Il est important de noter que ce script n'annule que le mouvement de l'objet pendant l'animation. Les autres aspects de l'animation, tels que les changements d'apparence ou les modifications d'état, ne sont pas affectés par ce script.*/

public class CancelAnimMotion : MonoBehaviour
{
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = startPosition;
    }
}
