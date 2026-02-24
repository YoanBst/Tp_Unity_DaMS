TP 1 : Initiation Unity & Création du Background

Objectif : Configurer l'environnement de développement et créer votre premier niveau en Pixel Art.

Prérequis : * Unity Hub installé.

    Tileset 2D téléchargé (Trouvable sur ce déport : TilesBackground/cloud_tileset/cloud_tileset.png).


1. Initialisation du Projet

    Ouvrez Unity Hub et créez un nouveau projet.

    Sélectionnez le template : Universal 2D (ou 2D Core).

    Félicitations ! Votre environnement est prêt. Voici quelques repères essentiels :

        À gauche (Hierarchy) : Liste tous les objets présents dans votre scène (ce qui s'affiche à l'écran).

        En bas (Project) : Contient vos dossiers, assets (images, sons), scènes et scripts.

        En haut (Play) : Le bouton "Run" permet de lancer et tester votre jeu en temps réel.


2. Importation et Configuration des Assets

    Organisation : Créez un dossier Art dans l'onglet Project, puis un sous-dossier Floor. Glissez-y vos fichiers de tuiles (tiles).

    Réglages techniques (Inspector) : Sélectionnez vos images et configurez-les ainsi à droite de l'écran :

        Sprite Mode : Multiple (pour découper la planche).

        Pixels Per Unit (PPU) : 16.

        Filter Mode : Point (no filter).

        Compression : None (pour garantir une qualité Pixel Art optimale).

    Validation : Cliquez impérativement sur Apply.


3. Découpage des Tuiles (Slicing)

    Toujours dans l'Inspector, cliquez sur le bouton Sprite Editor.

    Cliquez sur le menu Slice (en haut à gauche) :

        Type : Grid By Cell Size.

        Pixel Size : 16 x 16.

    Cliquez sur le bouton Slice, puis sur Apply avant de fermer la fenêtre.


4. Création du Monde (Tilemap)

    Mise en place : Dans la Hierarchy, faites un clic droit > 2D Object > Tilemap > Rectangular.

    Outil Palette : Allez dans le menu Window > 2D > Tile Palette.

    Configuration de la palette :

        Cliquez sur Create New Palette, donnez-lui un nom et enregistrez-la dans votre dossier.

        Faites glisser votre asset découpé vers cette fenêtre pour afficher les tuiles individuelles.
        

5. Dessiner votre Scène

Vous êtes maintenant parés pour créer votre premier monde !

    Dessiner : Sélectionnez une tuile dans votre palette et cliquez sur la zone correspondante dans la scène.

    Outils : Utilisez les icônes en haut de la palette pour peindre, remplir des zones ou effacer des tuiles.

    Note : Le processus de création de carte peut être long. Si vous souhaitez gagner du temps, vous pouvez importer directement notre scène d'origine (située dans le dossier des cloud assets) via :

    Assets -> Import Package -> Custom Package