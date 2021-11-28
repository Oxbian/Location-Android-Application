using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

[System.Serializable]
public class Inventaire
{
	public List<Objet> objets = new List<Objet>();
}
public class ObjetManager : MonoBehaviour
{
    public Inventaire inventory = new Inventaire();
    public GameObject[] listCanvas; //Liste des canvas d'UI

    [Header("Canvas Principale")]
    public GameObject Prefab; //Prefab de l'objet (partie graphique qu'on instancie à chaque objet de la liste)
    public Transform Parent; //Le parent où instancié les prefabs
    public TextMeshProUGUI locationText; //Le texte de description indiquant la position de l'objet selectionnée
    public Image locationImage; //L'image de description indiquant la position de l'objet selectionnée
    public TextMeshProUGUI searchName; //L'inputfield pour la recherche par nom d'objet

    [Header("Canvas d'ajout d'objet")]
    public TextMeshProUGUI addNameText;
    public TextMeshProUGUI addDescriptionText;
    public TextMeshProUGUI addLocationText;
    public TMP_Dropdown dropdown;


    // Fonction lancée au départ
    void Start()
    {
        listCanvas[0].SetActive(true);
        listCanvas[1].SetActive(false);
        //Vérification si des données sont déjà existante
        loadData();
        //Instancié les objets dans la partie graphique pour chacun présent dans la liste
        foreach (Objet obj in inventory.objets)
        {
            GameObject go = Instantiate(Prefab,Parent);
            ObjetUI objUI = go.GetComponent<ObjetUI>();
            objUI.objet = obj;
            objUI.nameText.text =obj.Nom;
            objUI.descriptionText.text = obj.Description;
            objUI.objetImage.sprite = obj.Image;
        }

    }

    /// <summary>
    /// Fonction pour trier les objets par type
    /// </summary>
    /// <param name="sort">Nom du type à trier</param>
    public void ShowObjList(string sort)
    {

        DestroyAll(); //Détruit tout les objets dans la liste
        loadData();
        foreach (Objet obj in inventory.objets) //Tri des objets par leur type
        {
            if (sort == "None")
            {
                GameObject go = Instantiate(Prefab,Parent);
                ObjetUI objUI = go.GetComponent<ObjetUI>();
                objUI.objet = obj;
                objUI.nameText.text = obj.Nom;
                objUI.descriptionText.text = obj.Description;
                objUI.objetImage.sprite = obj.Image;
            }
            else
            {
                if (obj.Type.ToString() == sort)
                {
                    GameObject go = Instantiate(Prefab,Parent);
                    ObjetUI objUI = go.GetComponent<ObjetUI>();
                    objUI.objet = obj;
                    objUI.nameText.text = obj.Nom;
                    objUI.descriptionText.text = obj.Description;
                    objUI.objetImage.sprite = obj.Image;
                }
            }
        }
    }

    /// <summary>
    /// Fonction pour chercher les objets par nom
    /// </summary>
    public void SearchObj()
    {
        string searchingName = searchName.text;
        DestroyAll();
        loadData();
        foreach (Objet obj in inventory.objets)
        {
            if (obj.Nom == searchingName)
            {
                print("true");
                GameObject go = Instantiate(Prefab,Parent);
                ObjetUI objUI = go.GetComponent<ObjetUI>();
                objUI.objet = obj;
                objUI.nameText.text = obj.Nom;
                objUI.descriptionText.text = obj.Description;
                objUI.objetImage.sprite = obj.Image;
            }
        }
        listCanvas[0].SetActive(true);
        listCanvas[1].SetActive(false);
    }

    /// <summary>
    /// Fonction pour afficher le canvas d'ajout
    /// </summary>
    public void addCanvas()
    {
        listCanvas[0].SetActive(false);
        listCanvas[1].SetActive(true);
    }

    /// <summary>
    /// Fonction pour retourner au canvas principal
    /// </summary>
    public void mainCanvas()
    {
        listCanvas[0].SetActive(true);
        listCanvas[1].SetActive(false);
    }

    /// <summary>
    /// Fonction pour ajouter des objets à notre liste
    /// </summary>
    public void addObject()
    {
        Objet newItem = new Objet();
        newItem.Nom = addNameText.text;
        newItem.Description = addDescriptionText.text;
        newItem.Location = addLocationText.text;

        int value = dropdown.value;
        Debug.Log("Valeur: " + value);
        switch (value)
        {
            case 0:
                newItem.Type = ObjetType.Couvers;
                break;
            case 1:
                newItem.Type = ObjetType.Plat;
                break;
            case 2:
                newItem.Type = ObjetType.Casserole;
                break;
            case 3:
                newItem.Type = ObjetType.Verre;
                break;
            case 4:
                newItem.Type = ObjetType.Spéciaux;
                break;
        }
        inventory.objets.Add(newItem);
        saveData();
        loadData();
        listCanvas[0].SetActive(true);
        listCanvas[1].SetActive(false);
    }
    public void saveData()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/SavedData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Sauvegard effectuée");
    }

    public void loadData()
    {
        string filePath = Application.persistentDataPath + "/SavedData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        inventory = JsonUtility.FromJson<Inventaire>(inventoryData);
        Debug.Log("Chargement effectué");
    }

    /// <summary>
    /// Fonction pour détruire tout les objets de liste d'UI
    /// </summary>
    public void DestroyAll()
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject go in Objects)
        {
            Destroy(go);
        }
    }
}
