TP 1 : Initiation Unity 2D & Création d'Environnement

Prérequis : Unity Hub installé + un Tileset (planche de textures 2D) téléchargé.
1. Initialisation du Projet

    Ouvrir Unity Hub > New Project > 2D Core.

    Nommer le projet et cliquer sur Create Project.

    Lexique de l'interface :

        Hierarchy : Objets présents dans le niveau actuel.

        Project : Fichiers et assets du jeu.

        Inspector : Réglages de l'objet sélectionné.

        Scene / Game:  Vue de rendu final.

2. Importation & Configuration (Spécial Pixel Art)

    Dans Project, créer un dossier Art/Backgrounds et y glisser le Tileset.

    Sélectionner l'image et appliquer strictement ceci dans l'Inspector :

        Sprite Mode : Multiple

        Pixels Per Unit (PPU) : 16

        Alpha Is Transparency (dans Advanced) : Coché

        Filter Mode : Point (no filter) (évite le flou)

        Compression : None

    Cliquer impérativement sur Apply.

3. Découpage (Slicing)

    Cliquer sur le bouton Sprite Editor (dans l'Inspector).

    Menu Slice (en haut à gauche) :

        Type : Grid By Cell Size

        Pixel Size : X: 16 / Y: 16

    Cliquer sur le bouton Slice, puis sur Apply (en haut à droite) et fermer la fenêtre.

4. Création du Niveau (Tilemap)

    Créer la grille : Clic droit dans Hierarchy > 2D Object > Tilemap > Rectangular. Renommer la en Background.

    Créer la Palette : Menu Window > 2D > Tile Palette. Cliquer sur Create New Palette et sauvegarder dans un nouveau dossier Tiles.

    Préparer les pinceaux : Glisser l'image globale depuis le dossier Project vers la fenêtre Tile Palette.

    Dessiner : Utiliser l'outil Pinceau  dans la Tile Palette et dessiner dans la Scene.

    ⚠️ Bug de chevauchement / clignotement ? > Sélectionner Background_Sol dans la Hierarchy, et dans l'Inspector (Tilemap Renderer), vérifier que le Order in Layer est à 0 ou -1.

5. Test & Sauvegarde

    Appuyer sur Play (▶) en haut au centre pour tester le rendu.

    Astuce : Si la caméra est trop zoomée, sélectionner Main Camera et augmenter la valeur de Size dans l'Inspector.

    Sauvegarder la scène avec Ctrl + S (ou Cmd + S).