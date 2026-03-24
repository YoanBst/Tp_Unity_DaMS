# Création des premières animations du personnage

## 🎯 Objectif

Dans cette partie, vous allez :

- Créer votre première animation `IdleRight`
- Créer ensuite l’animation `WalkRight`
- Comprendre comment relier des sprites à une animation Unity

⚠️ À ce stade, nous ne touchons pas encore à l’Animator.

---

## 1) Préparer le dossier Animation

1. Copiez le dossier `Animation` fourni.
2. Collez-le dans votre dossier `Assets`.

Vous devez maintenant voir :
Assets/
├── Art/
├── Animation/
└── ...


---

## 2) Ouvrir la fenêtre Animation

1. Allez dans le menu :

   Window > Animation > Animation

2. Une nouvelle fenêtre s’ouvre.
3. Placez cette fenêtre en bas de votre interface (à côté de Console par exemple).

### 🔎 Afficher les "Samples"

Dans la fenêtre Animation :

1. Cliquez sur les **trois petits points** (⋮) en haut à droite.
2. Activez l’option **Show Sample Rate**.

Cela permet d’afficher et modifier la vitesse de lecture de l’animation.

💡 Les "Samples" correspondent au nombre d’images jouées par seconde.

---

## 3) Créer l’animation IdleRight

1. Sélectionnez le **GameObject Player** dans la Hierarchy.
2. Dans la fenêtre Animation, cliquez sur **Create**.
3. Nommez l’animation :



---

## 2) Ouvrir la fenêtre Animation

1. Allez dans le menu :

   Window > Animation > Animation

2. Une nouvelle fenêtre s’ouvre.
3. Placez cette fenêtre en bas de votre interface (à côté de Console par exemple).

### 🔎 Afficher les "Samples"

Dans la fenêtre Animation :

1. Cliquez sur les **trois petits points** (⋮) en haut à droite.
2. Activez l’option **Show Sample Rate**.

Cela permet d’afficher et modifier la vitesse de lecture de l’animation.

💡 Les "Samples" correspondent au nombre d’images jouées par seconde.

---

## 3) Créer l’animation IdleRight

1. Sélectionnez le **GameObject Player** dans la Hierarchy.
2. Dans la fenêtre Animation, cliquez sur **Create**.
3. Nommez l’animation :

IdleRight


4. Enregistrez-la dans votre dossier `Assets/Animation`.

---

### Ajouter le sprite à l’animation

1. Dans l’onglet **Project**, allez dans :

   Art/Char

2. Trouvez le sprite du personnage orienté vers la droite.
3. Glissez-déposez ce sprite dans la fenêtre Animation.

✅ Votre animation `IdleRight` est créée.

---

## 4) Créer l’animation WalkRight

Maintenant, nous allons créer une animation de marche.

1. Dans la fenêtre Animation, cliquez sur le menu déroulant (à côté du nom de l’animation).
2. Cliquez sur **Create New Animation**.
3. Nommez-la :

WalkRight


4. Enregistrez-la dans le même dossier `Animation`.

---

### Ajouter les sprites de marche

1. Dans `Art/Char`, trouvez les **3 images** correspondant à la marche vers la droite.
2. Sélectionnez-les **dans l’ordre**.
3. Glissez-déposez-les dans la fenêtre Animation.

Unity crée automatiquement une animation composée des 3 sprites.

---

## ⚙️ Ajuster la vitesse de l’animation

Dans la fenêtre Animation :

- Modifiez la valeur **Samples** (en haut à droite).

Exemple :
- 6 → animation plus lente
- 12 → animation plus rapide

Testez différentes valeurs pour obtenir un rendu fluide.

---

## ✅ Résultat attendu

Vous devez maintenant avoir :

- Une animation `IdleRight`
- Une animation `WalkRight`

Elles doivent apparaître dans votre dossier `Animation`.

Vous êtes maintenant prêts à passer à la configuration de l’Animator.

# Configuration de l’Animator (Idle / Walk / Transitions)

## 🎯 Objectif

Dans cette partie, nous allons :

- Reconfigurer l’Animator du Player
- Créer deux états : `Idle` et `Walk`
- Utiliser un **Blend Tree 2D**
- Ajouter les paramètres nécessaires (`moveX`, `moveY`, `isMoving`)
- Créer les transitions entre Idle et Walk

À la fin, Unity devra choisir automatiquement la bonne animation selon :
- La direction du joueur
- Le fait qu’il soit en train de marcher ou non

---

## 1) Ouvrir l’Animator du Player

1. Sélectionnez le **GameObject Player**
2. Ouvrez l’onglet **Animator**

Normalement, un Animator Controller nommé `Player` a été créé automatiquement lors de la création de la première animation.

---

## 2) Nettoyer l’Animator

1. Supprimez les animations déjà présentes dans l’Animator
2. Gardez uniquement l’état `Entry`

Nous allons reconstruire la logique proprement.

---

# PARTIE A — Création de l’état Idle

## 3) Créer un nouvel état Idle

1. Clic droit dans l’Animator
2. `Create State > From New Blend Tree`
3. Renommez-le :  

Idle


4. Faites clic droit sur `Idle` → **Set as Layer Default State**

---

## 4) Configurer le Blend Tree

1. Double-cliquez sur `Idle`
2. Dans l’Inspector :
   - Blend Type → **2D Simple Directional**

---

## 5) Ajouter les paramètres

Dans l’onglet **Parameters** (en haut à gauche de l’Animator) :

1. Cliquez sur `+`
2. Ajoutez :
   - `moveX` (Float)
   - `moveY` (Float)

Ces paramètres permettront à Unity de détecter la direction.

---

## 6) Ajouter les 4 motions (Idle)

Dans le Blend Tree :

1. Cliquez sur **Add Motion** (4 fois)
2. Glissez les animations :
   - IdleUp
   - IdleDown
   - IdleLeft
   - IdleRight

---

## 7) Régler les Positions X et Y

Pour chaque animation, ajustez les valeurs :

| Animation   | Pos X | Pos Y |
|-------------|-------|-------|
| IdleUp      | 0     | 1     |
| IdleDown    | 0     | -1    |
| IdleLeft    | -1    | 0     |
| IdleRight   | 1     | 0     |

### Pourquoi ces valeurs ?

Parce que dans le script :

```csharp
animator.SetFloat("moveX", input.x);
animator.SetFloat("moveY", input.y);


4. Faites clic droit sur `Idle` → **Set as Layer Default State**

---

## 4) Configurer le Blend Tree

1. Double-cliquez sur `Idle`
2. Dans l’Inspector :
   - Blend Type → **2D Simple Directional**

---

## 5) Ajouter les paramètres

Dans l’onglet **Parameters** (en haut à gauche de l’Animator) :

1. Cliquez sur `+`
2. Ajoutez :
   - `moveX` (Float)
   - `moveY` (Float)

Ces paramètres permettront à Unity de détecter la direction.

---

## 6) Ajouter les 4 motions (Idle)

Dans le Blend Tree :

1. Cliquez sur **Add Motion** (4 fois)
2. Glissez les animations :
   - IdleUp
   - IdleDown
   - IdleLeft
   - IdleRight

---

## 7) Régler les Positions X et Y

Pour chaque animation, ajustez les valeurs :

| Animation   | Pos X | Pos Y |
|-------------|-------|-------|
| IdleUp      | 0     | 1     |
| IdleDown    | 0     | -1    |
| IdleLeft    | -1    | 0     |
| IdleRight   | 1     | 0     |

### Pourquoi ces valeurs ?

Parce que dans le script :

```csharp
animator.SetFloat("moveX", input.x);
animator.SetFloat("moveY", input.y);

Quand on appuie :

Droite → (1, 0)

Gauche → (-1, 0)

Haut → (0, 1)

Bas → (0, -1)

Le Blend Tree compare ces valeurs aux Positions X/Y et choisit automatiquement la bonne animation.


# PARTIE B — Création de l’état Walk

## 8) Créer un nouvel état Walk

1. Dans l’Animator, faites un clic droit dans la zone vide.
2. Sélectionnez :

   Create State > From New Blend Tree

3. Renommez le nouvel état :

   Walk

---

## 9) Configurer le Blend Tree Walk

1. Double-cliquez sur l’état `Walk` pour entrer dans le Blend Tree.
2. Dans l’Inspector :
   - Blend Type → **2D Simple Directional**
   - Parameters → sélectionnez :
     - `moveX`
     - `moveY`

Ces paramètres sont déjà mis à jour dans le script du Player.

---

## 10) Ajouter les animations de marche

1. Cliquez sur **Add Motion** (4 fois).
2. Glissez les animations suivantes dans les 4 emplacements :

   - WalkUp  
   - WalkDown  
   - WalkLeft  
   - WalkRight  

---

## 11) Régler les Positions X et Y

Pour chaque animation, définissez les valeurs suivantes :

| Animation   | Pos X | Pos Y |
|------------|-------|-------|
| WalkUp     | 0     | 1     |
| WalkDown   | 0     | -1    |
| WalkLeft   | -1    | 0     |
| WalkRight  | 1     | 0     |

---

### Pourquoi utilise-t-on ces valeurs ?

Dans le script `PlayerController`, les lignes suivantes sont exécutées :

```csharp
animator.SetFloat("moveX", input.x);
animator.SetFloat("moveY", input.y);