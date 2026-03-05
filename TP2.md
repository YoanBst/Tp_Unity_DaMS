TP 2 : Intégration du Joueur et Déplacements

Prérequis : TP 1 terminé (environnement en place) + un spritesheet (planche d'animation) de personnage téléchargé.
1. Importation & Configuration du Sprite

    Dans Project, aller dans le dossier ARt, y crée un dossier player,  et y glisser le spritesheet du personnage (vous trouverez nos personnages dans le dossier TilesCharacters)

    Sélectionner l'image et appliquer strictement ceci dans l'Inspector :

        Sprite Mode : Multiple

        Pixels Per Unit (PPU) : 16 (ou 32 selon la taille de votre image)

        Filter Mode : Point (no filter) (évite le flou)

        Compression : None

    Cliquer ensuite Apply.

2. Découpage du Personnage (Slicing)

    Cliquer sur le bouton Sprite Editor (dans l'Inspector de l'image).

    Cliquer ensuite sur Slice, et modifier les paramètres comme ceci :

        Type : Grid By Cell Size

        Pixel Size : X: 16 / Y: 32 (NB : cela correspond si vous utilisez les personnages que nous vous fournissons, cela peut être légeremment différent pour d'autres modèle)

    Cliquer sur le bouton Slice, puis sur Apply (en haut à droite) et fermer la fenêtre.

3. Ajout du Joueur dans la Scène

    Déplier le spritesheet dans le dossier Project.

    Glisser le premier sprite (le personnage qui regarde vers le bas) dans la Hierarchie.

    Renommer l'objet généré en "Player".

    Dans l'Inspector , vérifier la position et les calques de rendu pour s'assurer qu'il apparait devant le décor (modifier la valeur de Order in layer en lui assignantg une valeur diffèrente de 0 si besoin).


4. Script de Déplacement (Grille par Grid)

    Dans Project, allez dans le dossier Asset et créez un dossier Scripts.

    Clic droit > Create > C# Script et nommer le script PlayerController.

    Double-cliquer pour l'ouvrir dans Visual Studio.

    NB : si le script ne s'ouvre pas directement avec VScode lorsque vous double-cliquez dessus, allez dans Edit -> Preferences -> External Tools, puis dans External Script Editor sélectionnez Visual Studio Editor

   

5. Analyse détaillée de la logique de mouvement

    A. Détection de l'intention du joueur
    Le script utilise la méthode Update(), exécutée à chaque frame (environ 60 fois par seconde). Nous lisons les entrées via Input.GetAxisRaw("Horizontal/Vertical"). Cette fonction renvoie uniquement des entiers (-1, 0, 1), ce qui garantit que le personnage veut se déplacer exactement d'une unité sur la grille.

    B. Calcul de la destination
    Dès qu'une touche est détectée, le script crée une variable targetPos. On prend la position actuelle (transform.position) et on y ajoute l'input pour définir les coordonnées exactes de la prochaine case.

    C. Exécution fluide via Coroutine
    Le mouvement utilise une Coroutine (Move()) lancée par StartCoroutine. Au lieu de téléporter le joueur instantanément, elle divise le trajet sur plusieurs images (frames).

        Vector3.MoveTowards : Calcule la position intermédiaire à chaque frame pour simuler un glissement.

        yield return null : Indique à Unity de faire une pause d'une frame, permettant d'afficher le déplacement à l'écran avant de continuer la boucle while.

        isMoving (Le Verrou) : Ce booléen est passé à true au début du mouvement. Tant qu'il est actif, le script ignore les entrées clavier dans Update(). Cela garantit que le joueur ne peut pas changer de direction ou lancer un nouveau mouvement avant d'avoir atteint précisément la case cible.