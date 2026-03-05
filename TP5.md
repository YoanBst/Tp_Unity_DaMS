TP5 : Ajouter un PNG et du dialogue (partie 1)

Nous allons maintenant ajouter notre premier PNG à notre jeu.
1. Importation et configuration visuelle

    Ouvrez votre dossier de personnage et ajoutez-en un.

    NB : Pensez encore une fois à définir le bon nombre de pixel à 16, la compression à none, etc.

    Renommez le personnage en 'PNG1' et mettez son Order in Layer à 3.

2. Configuration physique et Layers

    Nous allons ajouter deux components à notre personnage :

        Rigidbody2D (définissez-le à static).

        Box Collider 2D.

    Dans l'inspector de ce nouveau personnage, allez sur Layer -> Add Layer... et créez un layer nommé Interactable.

    Revenez sur l'inspector du PNG et choisissez le nouveau layer : Interactable.

3. Implémentation de la logique

    Nous allons maintenant implémenter l'interaction de notre personnage avec ce PNG.

    Pour cela, définissons une condition dans notre fonction Update, qui appellera la fonction Interact à chaque fois que nous appuyons sur la touche C de notre clavier (et uniquement si nous sommes proches du PNG).

    Nous devons maintenant définir notre fonction Interact, qui permettra à notre personnage de détecter le PNG.

4. Réglages du Player

    Pour finir, cliquez sur Player, et regardez l'inspector.

    Dans l'onglet PlayerController (Script) et juste en dessous de Collision, définissez Interactable Layer sur Interactable.

C'est tout bon ! Ton texte est maintenant bien aéré et facile à lire pour tes étudiants.



