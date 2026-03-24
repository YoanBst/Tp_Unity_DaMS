# TP 4 — Gestion des collisions (Tilemap + Player)

## 🎯 Objectif

Dans ce TP, vous allez :

- Empêcher le joueur de traverser les murs
- Utiliser les collisions de la Tilemap
- Comprendre le rôle des Layers
- Implémenter une détection de collision dans le PlayerController

À la fin, votre personnage ne pourra plus traverser les obstacles.

---

# PARTIE A — Mise en place des collisions sur la Tilemap

## 1) Créer une Tilemap pour les objets solides

1. Dans la Hierarchy :
   - Clic droit → 2D Object → Tilemap → Rectangular
2. Renommez-la :

   SolidObjects

---

## 2) Configurer les Layers

1. En haut à droite de Unity → cliquez sur **Layer > Add Layer**
2. Ajoutez une nouvelle layer :

   SolidObjects

---

## 3) Assigner la layer

1. Sélectionnez votre Tilemap `SolidObjects`
2. Dans l’Inspector :
   - Layer → `SolidObjects`

---

## 4) Dessiner les zones bloquantes

1. Ouvrez la Tile Palette
2. Sélectionnez la Tilemap `SolidObjects`
3. Dessinez :
   - murs
   - arbres
   - obstacles

💡 Tout ce que vous dessinez ici sera **non traversable**

---

## 5) Ajouter les colliders

Sélectionnez la Tilemap `SolidObjects` :

### Ajouter :

- Tilemap Collider 2D
- Composite Collider 2D
- Rigidbody2D

---

## 6) Configurer le Rigidbody

Dans le Rigidbody2D :

- Body Type → **Static**

💡 Cela empêche les objets de tomber (gravité).

---

## 7) Optimisation avec Composite Collider

Dans le Tilemap Collider 2D :

- Cochez **Used By Composite**

Dans le Composite Collider :

- Geometry Type → **Polygons**

💡 Unity fusionne les collisions → plus performant.

---

# PARTIE B — Configuration du Player

## 8) Ajouter un collider "pieds"

Sur le Player :

1. Ajoutez un **Circle Collider 2D**
2. Placez-le au niveau des pieds
3. Ajustez sa taille (petit cercle)

👉 Renommez-le : `FeetCollider`

---

## 9) Lier le collider au script

Dans l’Inspector du Player :

- Glissez le `FeetCollider` dans le champ :

feetCollider


---

## 10) Assigner la layer des collisions

Toujours dans le Player :

- Dans `solidObjectsLayers`
- Sélectionnez la layer :

SolidObjects


---

# PARTIE C — Code de collision

## 🎯 Principe

Avant de bouger, on vérifie :

👉 "Est-ce que la case devant moi est libre ?"

Si oui → on bouge  
Sinon → on bloque le mouvement  

---

## 11) Vérification avant déplacement

Dans `handleUpdate()` :

```csharp
Vector2 targetPos = rb.position + input * stepSize;

if (IsWalkable(targetPos))
    StartCoroutine(MoveTo(targetPos));

👉 On calcule la position cible
👉 On vérifie si elle est accessible


## 12) Fonction IsWalkable
private bool IsWalkable(Vector2 targetPos)

Cette fonction retourne :

true → on peut marcher
false → il y a un obstacle

## 13) Détection de collision (CircleCast)
RaycastHit2D hit = Physics2D.CircleCast(
    start + (Vector2)feetCollider.offset,
    radius,
    dir,
    dist,
    solidObjectsLayers
);
## 🔎 Explication
On envoie un cercle vers la direction du mouvement
Ce cercle représente les pieds du joueur
Unity vérifie si ce cercle touche un objet
Paramètres :
start → position actuelle
radius → taille des pieds
dir → direction du mouvement
dist → distance à parcourir
solidObjectsLayers → objets à détecter
14) Résultat de la détection
return hit.collider == null;

👉 Si rien n’est touché → on peut avancer
👉 Sinon → on bloque

# PARTIE D — Résultat
✅ Test

Lancez la scène :

Le joueur ne traverse plus les murs
Il s’arrête au contact des obstacles
Le déplacement reste fluide
🧠 À retenir
Les Layers permettent de filtrer les collisions
Les Colliders définissent les zones physiques
Le CircleCast permet d’anticiper une collision
On ne bloque pas après → on bloque AVANT le mouvement
