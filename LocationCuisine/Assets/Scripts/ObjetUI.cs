using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjetUI : MonoBehaviour
{
    public Objet objet;
    public TextMeshProUGUI nameText; 
    public TextMeshProUGUI descriptionText; 
    public Image objetImage; 
    public void GetDesc()
    {
        ObjetManager go = GameObject.FindGameObjectWithTag("GameController").GetComponent<ObjetManager>();
        go.locationText.text = objet.Location;
        go.locationImage.sprite = objet.LocationImage;
    }
}
