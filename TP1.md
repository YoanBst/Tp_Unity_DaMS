
TP 1 : Initiation à Unity 2D et Création de l'Environnement

Objectifs du TP
    • Se familiariser avec l'interface du moteur Unity.
    • Comprendre le flux de travail (workflow) pour les jeux en 2D.
    • Importer et configurer correctement des ressources graphiques (Pixel Art).
    • Utiliser les outils de création de niveau (Tilemap et Tile Palette).
Prérequis
    • Unity Hub installé sur le poste de travail.
    • Une archive contenant un Tileset (planche de textures 2D) téléchargée au préalable.

PARTIE 1 : Initialisation du Projet et Découverte de l'Interface
1.1. Création du projet
    1. Ouvrez l'application Unity Hub.
    2. Cliquez sur le bouton New Project.
    3. Dans la liste des templates, sélectionnez 2D Core.
    4. Nommez votre projet (ex: MonPremierJeu_2D) et choisissez son emplacement de sauvegarde.
    5. Cliquez sur Create Project

1.2. Prise en main de l'interface Identifiez les 4 fenêtres principales de l'éditeur :
    • Hierarchy (Hiérarchie) : Liste tous les objets (GameObjects) actuellement présents dans votre niveau.
    • Project (Projet) : L'explorateur de fichiers. Contient tous les assets (images, sons, scripts) de votre jeu.
    • Inspector (Inspecteur) : Affiche les propriétés et composants de l'objet sélectionné.
    • Vue Scene / Vue Game : La Scene est votre espace de construction, l'onglet Game correspond au rendu final vu par la caméra du joueur.

PARTIE 2 : Importation et Configuration des Assets (Spécial Pixel Art)
Note : Le Pixel Art demande une configuration spécifique pour ne pas apparaître flou dans le moteur.
2.1. Organisation des dossiers
    1. Dans la fenêtre Project, faites un clic droit > Create > Folder. Nommez-le Art.
    2. À l'intérieur, créez un sous-dossier nommé Backgrounds.
2.2. Importation
    1. Glissez-déposez votre fichier image (le Tileset) depuis votre ordinateur vers le dossier Backgrounds d'Unity.
2.3. Configuration de l'image (L'étape cruciale) Sélectionnez votre image importée. Dans la fenêtre Inspector à droite, appliquez strictement les paramètres suivants :
    • Sprite Mode : Passez de Single à Multiple (car l'image contient plusieurs blocs de décor).
    • Pixels Per Unit (PPU) : Réglez la valeur sur 16 (taille standard d'un bloc pixel art).
    • Advanced > Alpha Is Transparency : Cochez la case (pour gérer les fonds transparents).
    • Filter Mode : Changez pour Point (no filter) afin d'éviter le flou (anti-aliasing).
    • Compression : Mettez sur None.
    • Cliquez impérativement sur le bouton Apply en bas de l'Inspecteur pour valider.

PARTIE 3 : Découpage de l'Image (Slicing)
L'image globale doit maintenant être découpée en tuiles individuelles utilisables pour dessiner le niveau.
    1. Toujours dans l'Inspecteur de votre image, cliquez sur le bouton Sprite Editor.
    2. Cliquez sur le menu déroulant Slice en haut à gauche de la fenêtre.
    3. Modifiez le champ Type pour choisir Grid By Cell Size.
    4. Dans Pixel Size, entrez X: 16 et Y: 16.
    5. Cliquez sur le bouton Slice. Vous devriez voir un quadrillage apparaître sur l'image.
    6. Cliquez sur le bouton Apply (en haut à droite) puis fermez la fenêtre Sprite Editor.

PARTIE 4 : Création du Niveau avec la Tilemap
4.1. Mise en place de la grille
    1. Dans la fenêtre Hierarchy, faites un clic droit.
    2. Allez dans 2D Object > Tilemap > Rectangular.
    3. Unity génère un objet "Grid" contenant une "Tilemap". Renommez cette Tilemap en Background_Sol.
4.2. Création de la Palette de dessin
    1. Allez dans le menu supérieur : Window > 2D > Tile Palette.
    2. Dans la nouvelle fenêtre, cliquez sur Create New Palette.
    3. Nommez-la Palette_Decor et sauvegardez-la dans un nouveau dossier Tiles (à créer dans vos Assets).
4.3. Remplissage et Dessin
    1. Dépliez votre image globale dans le dossier Project pour voir tous les morceaux découpés.
    2. Sélectionnez l'image principale et glissez-la dans la fenêtre Tile Palette. (Choisissez à nouveau le dossier Tiles quand Unity vous le demande).
    3. Vos tuiles apparaissent maintenant dans la palette !
    4. Utilisez l'outil Pinceau (B) dans la Tile Palette, sélectionnez un bloc de sol, et dessinez votre premier environnement dans la vue Scene.

 ATTENTION - Problèmes d'affichage : Si vos objets se chevauchent mal ou clignotent, sélectionnez votre Background_Sol dans la Hiérarchie, allez dans l'Inspecteur (Tilemap Renderer) et vérifiez le paramètre Order in Layer. Le calque du sol doit généralement être à 0 ou -1.



PARTIE 5 : Test et Validation
    1. Assurez-vous d'avoir dessiné un espace suffisant pour que le joueur puisse s'y déplacer.
    2. Cliquez sur le bouton Play au centre supérieur de l'interface.
    3. Vérifiez le rendu dans la vue Game. (Si la caméra est trop proche, sélectionnez Main Camera et augmentez la valeur de Size dans l'Inspecteur).
Fin du TP 1 : Sauvegardez votre scène (Ctrl + S ou Cmd + S). Vous avez désormais un environnement fonctionnel prêt à accueillir un personnage !
