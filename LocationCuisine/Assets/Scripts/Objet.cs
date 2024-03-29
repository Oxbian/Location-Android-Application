﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Listes des types d'objets possibles. Vous pouvez en ajouter d'autres mais faut pas oublier d'ajouter un bouton avec en donnée le nouveau type.
public enum ObjetType {Couvers, Plat, Casserole, Verre, Spéciaux}
//Emplacement pour avoir accès aux objets et en créer de nouveaux

[System.Serializable]
public class Objet
{
    public string Nom; //Nom de l'objet 
    public Sprite Image; //Image de l'objet
    public string Description; //Description de l'objet
    public string Location; //Texte indiquant la position de l'objet
    public Sprite LocationImage; //Image de la position de l'objet
    public ObjetType Type; //Type de l'objet
}