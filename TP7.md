# TP 7 — Mise en place d’un système de dialogue avec les PNJ

## 🎯 Objectif

Dans ce TP, vous allez ajouter un système de dialogue à votre jeu.

À la fin, le joueur devra pouvoir :

- s’approcher d’un PNJ
- appuyer sur la touche d’interaction
- afficher une boîte de dialogue
- lire plusieurs lignes de texte
- passer à la ligne suivante avec une touche
- revenir au mode déplacement une fois le dialogue terminé

Le code nécessaire est fourni dans le dépôt Git.  
L’objectif ici est de comprendre comment l’intégrer et comment les différents scripts communiquent entre eux.

---

# PARTIE A — Principe général

Avant de commencer, il faut comprendre le fonctionnement global du système.

Le système de dialogue repose sur plusieurs scripts qui ont chacun un rôle précis :

- `GameController` : gère l’état général du jeu
- `DialogManager` : affiche les dialogues et fait avancer les lignes
- `Dialog` : stocke les lignes de texte
- `NPCController` : déclenche un dialogue lorsqu’on parle à un PNJ
- `PlayerController` : gère le déplacement et l’interaction

L’idée est la suivante :

1. Le joueur est en mode déplacement
2. Il interagit avec un PNJ
3. Le jeu passe en mode dialogue
4. Le texte s’affiche ligne par ligne
5. Quand le dialogue est terminé, le jeu revient au mode déplacement

---

# PARTIE B — Création de l’interface de dialogue

## 1) Importer les assets

Importez dans votre projet les éléments graphiques nécessaires :

- l’image de la boîte de dialogue
- éventuellement la police utilisée pour le texte

Placez-les dans votre dossier `Art`.

---

## 2) Configurer l’image de la boîte de dialogue

Sélectionnez l’image de la boîte de dialogue dans le Project puis, dans l’Inspector :

- **Pixels Per Unit** : `32`
- **Filter Mode** : `Point (no filter)`
- **Compression** : `None`

Si l’image est conçue pour être redimensionnée sans déformer les bords, ouvrez le **Sprite Editor** et configurez les bordures.

Cela permet d’éviter que les coins de la boîte soient étirés.

---

## 3) Créer la boîte de dialogue dans le Canvas

1. Dans la Hierarchy :
   - clic droit → `UI > Image`
2. Renommez l’objet :

   `DialogBox`

3. Placez cette boîte en bas de l’écran
4. Redimensionnez-la pour obtenir une zone large et peu haute

### Conseil

Dans le `Canvas`, changez :

- **UI Scale Mode** → `Scale With Screen Size`

Cela permet à l’interface de mieux s’adapter à la taille de l’écran.

---

## 4) Ajouter le texte de dialogue

1. Clic droit sur `DialogBox`
2. `UI > Text` ou `UI > Text - TextMeshPro` selon votre projet
3. Renommez l’objet :

   `DialogText`

4. Étirez-le à l’intérieur de la boîte
5. Ajoutez un peu de marge (padding)
6. Choisissez une police lisible
7. Réglez la taille du texte

Vous pouvez écrire un texte temporaire comme :

`Hello world`

pour vérifier le rendu.

---

## 5) Désactiver la boîte au démarrage

Dans la Hierarchy, décochez l’objet `DialogBox`.

💡 La boîte ne doit pas être visible dès le lancement du jeu.  
Elle sera affichée uniquement lorsqu’un dialogue commencera.

---

# PARTIE C — Les scripts utilisés

Le code est fourni dans le dépôt Git.  
Dans cette partie, on explique le rôle de chaque script.

---

## 6) Script `Dialog`

Le script `Dialog` sert uniquement à stocker les lignes de texte d’un dialogue.

Il contient une liste de chaînes de caractères, par exemple :

- Bonjour !
- Bienvenue dans le village.
- Fais attention à la forêt.

### À quoi sert ce script ?

Il permet d’écrire les dialogues directement dans l’Inspector, sans modifier le code à chaque fois.

Chaque PNJ pourra donc avoir son propre ensemble de lignes.

---

## 7) Script `DialogManager`

Le `DialogManager` est le script principal du système de dialogue.

Il a plusieurs responsabilités :

- afficher la boîte de dialogue
- afficher le texte
- écrire les phrases lettre par lettre
- passer à la ligne suivante
- fermer la boîte quand le dialogue est terminé

### Ce qu’il contient généralement

- une référence vers `DialogBox`
- une référence vers `DialogText`
- une vitesse d’écriture (`lettersPerSecond`)
- une variable pour savoir quelle ligne est en cours
- un système pour savoir si le texte est encore en train de s’écrire

---

## 8) Effet d’écriture lettre par lettre

Le texte n’apparaît pas d’un seul coup.

Le `DialogManager` utilise une coroutine pour afficher les lettres progressivement.

### Pourquoi faire cela ?

Cela donne un rendu plus vivant, comme dans beaucoup de RPG.

Au lieu d’afficher directement :

`Bonjour aventurier`

Unity affiche :

- B
- Bo
- Bon
- Bonj
- ...

jusqu’à la ligne complète.

---

## 9) Script `NPCController`

Le `NPCController` est attaché aux PNJ.

Son rôle est simple :

- stocker un objet `Dialog`
- appeler le `DialogManager` quand le joueur interagit avec le PNJ

Autrement dit :

- le PNJ ne gère pas l’affichage lui-même
- il dit simplement au `DialogManager` :  
  **"affiche ce dialogue"**

---

## 10) Script `GameController`

Le `GameController` gère l’état global du jeu.

Dans ce TP, il permet de basculer entre plusieurs modes :

- `FreeRoam` : le joueur peut se déplacer
- `Dialogue` : le joueur lit un dialogue
- `Battle` : réservé pour plus tard

### Pourquoi est-ce important ?

Quand un dialogue s’ouvre, on ne veut plus que le joueur continue à marcher en même temps.

Le `GameController` permet donc :

- d’autoriser le déplacement en mode `FreeRoam`
- de bloquer le déplacement en mode `Dialogue`

---

## 11) Script `PlayerController`

Le `PlayerController` contient déjà la logique de déplacement et d’interaction.

Dans ce système, il conserve son rôle habituel :

- déplacer le joueur
- détecter une interaction avec un PNJ
- transmettre l’interaction au bon objet

Le changement important est le suivant :

- l’ancienne méthode `Update()` est souvent remplacée ou déléguée à une méthode comme `HandleUpdate()`
- cette méthode est appelée par le `GameController` uniquement quand le jeu est en mode déplacement

---

# PARTIE D — Mise en place dans Unity

## 12) Ajouter le `GameController`

1. Créez un objet vide dans la scène
2. Renommez-le :

   `GameController`

3. Ajoutez-lui le script `GameController`

---

## 13) Lier le Player au `GameController`

Dans l’Inspector du `GameController`, glissez le Player dans le champ correspondant.

Cela permet au `GameController` d’appeler le `PlayerController` lorsque le jeu est en mode déplacement.

---

## 14) Ajouter le `DialogManager`

1. Créez un objet vide dans la scène
2. Renommez-le :

   `DialogManager`

3. Ajoutez-lui le script `DialogManager`

---

## 15) Relier l’interface au `DialogManager`

Dans l’Inspector du `DialogManager`, associez :

- `DialogBox` → l’objet UI de la boîte de dialogue
- `DialogText` → l’objet texte à l’intérieur
- `Letters Per Second` → une valeur comme `30` ou `40`

---

## 16) Configurer un PNJ

1. Sélectionnez un PNJ dans la scène
2. Ajoutez-lui le script `NPCController`
3. Dans l’Inspector, repérez la partie `Dialog`
4. Ajoutez plusieurs lignes de texte

Exemple :

- Bonjour !
- Bienvenue dans ce village.
- Bonne chance pour la suite.

---

# PARTIE E — Gestion des états du jeu

## 17) Comprendre les états

Le `GameController` repose sur un système d’états.

### État `FreeRoam`

Dans cet état :

- le joueur peut marcher
- il peut interagir avec les objets et PNJ

### État `Dialogue`

Dans cet état :

- le déplacement est bloqué
- la touche d’avancement du dialogue est active

---

## 18) Pourquoi utiliser des états ?

Sans cela, plusieurs problèmes apparaissent :

- le joueur peut marcher pendant un dialogue
- il peut relancer plusieurs fois le même dialogue
- plusieurs systèmes peuvent s’exécuter en même temps

Le système d’états rend le comportement du jeu plus propre et plus prévisible.

---

# PARTIE F — Passage d’une ligne à l’autre

## 19) Faire avancer le dialogue

Une fois le dialogue affiché, il faut permettre au joueur de passer à la ligne suivante.

Dans ce TP, cela se fait avec une touche définie dans le code fourni.

Le `DialogManager` :

1. vérifie si le texte a fini de s’écrire
2. si oui, passe à la ligne suivante
3. si toutes les lignes ont été affichées :
   - ferme la boîte
   - notifie le `GameController`
   - remet le jeu en mode déplacement

---

## 20) Pourquoi empêcher l’avance pendant l’écriture ?

Pendant que les lettres s’affichent, il vaut mieux empêcher de passer trop vite à la suite.

Sinon :

- le texte peut être coupé
- plusieurs lignes peuvent se chevaucher
- le système peut devenir instable

C’est pour cela qu’on utilise souvent une variable du type :

- `isTyping`

Tant que cette variable est vraie, on attend la fin de l’écriture.

---

# PARTIE G — Communication entre scripts

## 21) Rôle des événements

Le `DialogManager` peut signaler :

- quand un dialogue commence
- quand un dialogue se termine

Le `GameController` écoute ces événements et change l’état du jeu.

### Exemple de logique

- début du dialogue → état = `Dialogue`
- fin du dialogue → état = `FreeRoam`

Cela évite de tout coder directement dans un seul script.

---

## 22) Pourquoi cette séparation est utile ?

Chaque script garde un rôle clair :

- le PNJ lance le dialogue
- le `DialogManager` affiche le texte
- le `GameController` décide dans quel mode se trouve le jeu
- le `PlayerController` gère les déplacements

Cette organisation rend le projet plus facile à comprendre et à faire évoluer.

---

# PARTIE H — Test

## 23) Vérifications à effectuer

Lancez la scène et vérifiez que :

- le joueur peut toujours se déplacer normalement
- lorsqu’il interagit avec un PNJ, la boîte de dialogue apparaît
- le texte s’affiche correctement
- les lignes défilent dans le bon ordre
- le joueur ne peut plus marcher pendant le dialogue
- une fois le dialogue terminé, le déplacement redevient possible

---

# PARTIE I — Problèmes fréquents

## 24) La boîte de dialogue ne s’affiche pas

Vérifiez que :

- `DialogBox` est bien lié dans le `DialogManager`
- `DialogText` est bien lié
- l’objet `DialogManager` est présent dans la scène

---

## 25) Le texte ne change pas

Vérifiez que :

- le PNJ contient bien plusieurs lignes dans son `Dialog`
- le `DialogManager` reçoit bien le bon dialogue
- la méthode d’affichage est bien appelée

---

## 26) Le joueur peut encore bouger pendant le dialogue

Vérifiez que :

- le `GameController` change bien l’état en `Dialogue`
- le déplacement est bien géré uniquement en mode `FreeRoam`

---

## 27) Le dialogue se ferme trop vite

Cela arrive souvent si :

- la ligne courante n’est pas réinitialisée
- la touche d’interaction est lue plusieurs fois
- le système avance alors que le texte est encore en cours d’écriture

---

# ✅ Résultat attendu

À la fin de ce TP :

- chaque PNJ peut avoir son propre dialogue
- la boîte de dialogue apparaît correctement
- le texte s’affiche ligne par ligne
- le joueur ne peut plus bouger pendant la conversation
- le jeu revient ensuite à son fonctionnement normal

---

# 🎨 Bonus possibles

Vous pouvez aller plus loin en ajoutant :

- un nom de PNJ dans la boîte de dialogue
- un portrait du personnage qui parle
- un son à chaque lettre
- un choix de réponses
- une animation du PNJ pendant qu’il parle

---

Vous avez maintenant un vrai système de dialogue de base, réutilisable pour tous vos PNJ.





# Ajout d’un prefab pour les PNJ

## 🎯 Objectif

Dans cette partie, nous allons transformer un PNJ déjà configuré en **prefab**.

Cela permet de :

- réutiliser facilement le même PNJ plusieurs fois dans la scène
- garder la même configuration (sprite, collider, script, dialogue)
- gagner du temps pour ajouter de nouveaux personnages

---

## 1) Vérifier que le PNJ est correctement configuré

Avant de créer le prefab, vérifiez que votre PNJ possède bien :

- un **Sprite Renderer**
- un **Collider 2D**
- le script `NPCController`
- éventuellement les autres composants nécessaires à l’interaction
- son dialogue rempli dans l’Inspector

💡 L’idée est simple : le prefab va enregistrer l’état actuel de l’objet.

---

## 2) Créer un dossier pour les prefabs

Dans l’onglet **Project** :

1. Créez un nouveau dossier
2. Nommez-le par exemple :

   `Prefabs`

Vous pourrez aussi créer un sous-dossier :

   `Prefabs/NPC`

pour mieux organiser votre projet.

---

## 3) Transformer le PNJ en prefab

1. Dans la **Hierarchy**, sélectionnez votre PNJ
2. Glissez-déposez cet objet dans le dossier `Prefabs`

Unity crée alors un prefab.

Vous verrez généralement l’objet devenir **bleu** dans la Hierarchy, ce qui indique qu’il est maintenant lié à un prefab.

---

## 4) Renommer le prefab

Dans l’onglet **Project**, renommez votre prefab avec un nom clair, par exemple :

- `NPC_Villager`
- `NPC_Guard`
- `NPC_Merchant`

💡 Évitez les noms trop vagues comme `Prefab1` ou `NPCTest`.

---

## 5) Réutiliser le prefab dans la scène

Pour ajouter un nouveau PNJ à partir du prefab :

1. Glissez le prefab depuis le dossier `Prefabs` vers la **Hierarchy**
2. Placez-le à l’endroit voulu dans la scène

Le nouvel objet possède automatiquement la même configuration que l’original.

---

## 6) Modifier un exemplaire ou le prefab entier

### Modifier uniquement un PNJ dans la scène

Si vous changez seulement le texte du dialogue sur un exemplaire placé dans la scène, cela ne modifie pas forcément le prefab d’origine.

### Modifier tous les PNJ basés sur le prefab

Si vous voulez que tous les PNJ utilisant ce prefab soient mis à jour :

1. Double-cliquez sur le prefab dans le dossier `Project`
2. Modifiez directement ses composants
3. Enregistrez les changements

Tous les objets liés à ce prefab pourront alors récupérer cette mise à jour.

---

## 7) Pourquoi utiliser un prefab ?

Sans prefab, il faudrait :

- recréer chaque PNJ manuellement
- remettre les composants à chaque fois
- rebrancher les scripts et collisions
- reconfigurer l’interaction

Avec un prefab :

- tout est déjà prêt
- on évite les oublis
- le projet est plus propre
- la création de contenu est beaucoup plus rapide

---

## ✅ Résultat attendu

À la fin de cette étape, vous devez avoir :

- un prefab de PNJ enregistré dans votre projet
- plusieurs PNJ réutilisables dans la scène
- une base propre pour créer rapidement d’autres personnages