README DE ROLL A BALL

L'objectif était de faire un jeu d'arcade, om l'on enchaine les petits niveaux, en essayant d'obtenir le plus haut score possible.

Tout d'abord, j'ai eu de grosses difficultés notamment sur le changement de niveau, pour lequel je voulais au début, faire augmenter le niveau de 1 à chaque fin de niveau. Hors les variable stocké à l'intérieur du component sont réinitialisées à chaque changement de niveau, j'aurais pu les stocker dans un scriptableObject, mais n'y ayant pas pensé, j'ai tenté de faire persister le manager de niveaux. Le problème c'est qu'en faisant ça, je devais vérifier les doublons, pour si je repassais dans le niveau, mais en faisant cette vérification et en supprimant la copie, la moitié des éléments de la scène étaient supprimés au lancement du jeu. Je ne sais pas d'où le problème vient, le gestionnaire de niveau était isolé dans un gameobject seul et parent de personne, et le component n'était nulle part ailleurs. Donc j'ai abandonné cette idée qui m'a fait perdre pas mal de temps, et j'ai directement mis le numéro du prochain niveau dans chaque niveau.
Ensuite, j'ai rencontré des problèmes avec le changement de niveau, le score, et les chargements : déjà je ne savais pas comment faire pour que durant le changement de niveaux, l'écran d'entre-niveau (qui affiche le score actuel) reste. Cela m'a pris un peu de temps pour trouver une solution en mettant le HUD en persistant.

Pour ce qui est de l'effet lié au temps, j'utilise le score pour réduire petit à petit le temps des niveaux (que l'on refait en boucle), jusqu'à 5 secondes minumum.
J'ai ajouté une logique de collection avec une clef, qui lorsqu'elle est ramassée, la fait apparaitre sur l'UI, et fait une apparition conditionnelle de gameobjects bonus (comme les murs dans le cours). Ces bonus lorsqu'ils sont approchés par le joueur, vérifient s'il possède une clef, et si oui, ils disparaissent et ajouteront +1 de score supplémentaire à la fin du niveau (ce score n'est pas ajouté si vous mourrez avant). Donc il y a une clef, qui a pour effet de permettre d'ouvrir le coffre bonus, et donc de gagner du score supplémentaire.

Il y a un menu des options, que j'aurais voulu développer mais qui contient uniquement le volume général. Pour y accéder, il faut appuyer sur échap en jeu (ce qui le met en pause,) puis cliquer sur paramètres.

Pour ce qui est de l'effet environnemental bénéfique, j'ai fait une plaque de pression, qui peut être actionnée par le joueur et par un cube poussable, et qui permet d'accéder à la suite d'un niveau, où d'accéder à une zone bonus.
Il y a aussi un effet lié au temps, avec un piège qui, lorsqu'il est touché, fait ralentir le joueur pendant quelques secondes.

J'avais pour ambition de faire plus de niveaux, car le jeu est vite redondant en l'occurence.


Les problèmes que j'ai rencontré ont souvent été lié à la communication entre les scripts. Ayant eu des difficultés durant plusieurs jours à tenter de bien faire les liens etc., j'ai fini par passer sur beaucoup de lien fort (donc ne mettant directement la référence dans le component), ce qui est plus simple, mais moins optimisé et modulable.

IL y a aussi un nouveau système de déplacement avec le saut, qui permet de passer des trous et ne pas mourir du vide.
Il y a aussi quelques bugs à corriger lié au code qui est parti dans trop de sens, car à chaque correction de bugs, tout devenait un peu plus, un méli-mélo.


Condition de victoire : Le jeu est une boucle où il faut marquer le plus de points : vous gagnez des points en ramassant le collectible final du niveau (qui vous change de niveau (le jeu fait une boucle)).

Conditions de défaite : Vous perdez si le temps qui vous est imparti dans le niveau est écoulé, ou si vous tombez dans un trou (défaite environnementale en touchant le vide).

