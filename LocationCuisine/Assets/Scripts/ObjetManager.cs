using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjetManager : MonoBehaviour
{
    public Objet[] ObjectsList;
    public GameObject Prefab;
    public Transform Parent;
    public TextMeshProUGUI locationText;
    public Image locationImage;
    public TextMeshProUGUI searchName;

    // Start is called before the first frame update
    void Start()
    {
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
    public void ShowObjList(string sort)
    {
        DestroyAll();
        foreach (Objet obj in ObjectsList)
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
    public void SearchObj()
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
    public void DestroyAll()
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Object");
        foreach (GameObject go in Objects)
        {
            Destroy(go);
        }
    }
}
