using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int pointsDeVie = 100;

    public void RecevoirDegats(int degats)
    {
        pointsDeVie -= degats;

        if (pointsDeVie <= 0)
        {
            // Le personnage est mort, ajoutez ici la logique appropri�e
            // comme afficher un �cran de fin de jeu ou r�initialiser le niveau.
        }
    }
}