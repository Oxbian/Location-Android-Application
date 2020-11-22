using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ObjetType {Couvers, Plat, Casserole, Verre, Spéciaux}
[CreateAssetMenu(fileName = "Objet", menuName = "Objet/Cuisine", order = 1)]

public class Objet : ScriptableObject
{
    public string nom;
    public Sprite image;
    public string Description;
    public string Location;
    public Sprite LocationImage;
    public ObjetType Type;
}