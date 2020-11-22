using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ObjetManager : MonoBehaviour
{
    public Objet[] ObjectsList; //Liste des objets pour pouvoir les ajouter en graphique
    public GameObject Prefab; //Prefab de l'objet (partie graphique qu'on instancie à chaque objet de la liste)
    public Transform Parent; //Le parent où instancié les prefabs
    public TextMeshProUGUI locationText; //Le texte de description indiquant la position de l'objet selectionnée
    public Image locationImage; //L'image de description indiquant la position de l'objet selectionnée
    public TextMeshProUGUI searchName; //L'inputfield pour la recherche par nom d'objet

    // Fonction lancée au départ
    void Start()
    {
        //Instancié les objets dans la partie graphique pour chacun présent dans la liste
        foreach (Objet obj in ObjectsList)
        {
            GameObject go = Instantiate(Prefab,Parent);
            ObjetUI objUI = go.GetComponent<ObjetUI>();
            objUI.objet = obj;
            objUI.nameText.text = obj.nom;
            objUI.descriptionText.text = obj.Description;
            objUI.objetImage.sprite = obj.image;
        }

    }
    public void ShowObjList(string sort) //Fonction pour trier les objets par type
    {

        DestroyAll(); //Détruit tout les objets dans la liste
        foreach (Objet obj in ObjectsList) //Tri des objets par leur type
        {
            if (sort == "None")
            {
                GameObject go = Instantiate(Prefab,Parent);
                ObjetUI objUI = go.GetComponent<ObjetUI>();
                objUI.objet = obj;
                objUI.nameText.text = obj.nom;
                objUI.descriptionText.text = obj.Description;
                objUI.objetImage.sprite = obj.image;
            }
            else
            {
                if (obj.Type.ToString() == sort)
                {
                    GameObject go = Instantiate(Prefab,Parent);
                    ObjetUI objUI = go.GetComponent<ObjetUI>();
                    objUI.objet = obj;
                    objUI.nameText.text = obj.nom;
                    objUI.descriptionText.text = obj.Description;
                    objUI.objetImage.sprite = obj.image;
                }
            }
        }
    }


    public void SearchObj() //Fonction pour chercher les objets par leur nom
    {
        string searchingName = searchName.text;
        DestroyAll();
        foreach (Objet obj in ObjectsList)
        {
            if (obj.nom == searchingName)
            {
                print("true");
                GameObject go = Instantiate(Prefab,Parent);
                ObjetUI objUI = go.GetComponent<ObjetUI>();
                objUI.objet = obj;
                objUI.nameText.text = obj.nom;
                objUI.descriptionText.text = obj.Description;
                objUI.objetImage.sprite = obj.image;
            }
        }
    }

    public void DestroyAll() //Fonction pour détruite les objets de la liste
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject go in Objects)
        {
            Destroy(go);
        }
    }
}
