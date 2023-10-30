using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoredSquares : MonoBehaviour
{
    [SerializeField] GameObject[] Alkali_metals, Alkaline_earth_metals, Transition_metals, 
        Post_Transition_metals, Metalloids, Nonmetals, 
        Halogens, Noble_gases, Lanthanides, Actinides;

    [SerializeField] GameObject periodicTable, UIArrows;

    private Image image;
    private Image[] allImagesOfElements;

    private void Start()
    {
        Alkali_metals = GameObject.FindGameObjectsWithTag("Alkali_metals");
        Alkaline_earth_metals = GameObject.FindGameObjectsWithTag("Alkaline_earth_metals");
        Transition_metals = GameObject.FindGameObjectsWithTag("Transition_metals");
        Post_Transition_metals = GameObject.FindGameObjectsWithTag("Post_Transition_metals");
        Metalloids = GameObject.FindGameObjectsWithTag("Metalloids");
        Nonmetals = GameObject.FindGameObjectsWithTag("Nonmetals");
        Halogens = GameObject.FindGameObjectsWithTag("Halogens");
        Noble_gases = GameObject.FindGameObjectsWithTag("Noble_gases");
        Lanthanides = GameObject.FindGameObjectsWithTag("Lanthanides");
        Actinides = GameObject.FindGameObjectsWithTag("Actinides");

        allImagesOfElements = periodicTable.GetComponentsInChildren<Image>();
    }

    private void OnMouseOver()
    {
        switch (gameObject.name)
        {
            case "RedShapeTable": //Alkali_metals
                HideAllImages();
                ShowAllImagesOfThisElement(Alkali_metals);
            break;

            case "OrangeShapeTable": // Alkaline_earth_metals
                HideAllImages();
                ShowAllImagesOfThisElement(Alkaline_earth_metals);
            break;

            case "YellowShapeTable": // Transition_metals
                HideAllImages();
                ShowAllImagesOfThisElement(Transition_metals);
            break;

            case "GreenShapeTable": // Post_Transition_metals
                HideAllImages();
                ShowAllImagesOfThisElement(Post_Transition_metals);
            break;

            case "CyanShapeTable": // Metalloids
                HideAllImages();
                ShowAllImagesOfThisElement(Metalloids);
            break;

            case "BlueShapeTable": // Nonmetals
                HideAllImages();
                ShowAllImagesOfThisElement(Nonmetals);
            break;

            case "LightPurpleShapeTable": // Halogens
                HideAllImages();
                ShowAllImagesOfThisElement(Halogens);
            break;

            case "PurpleShapeTable": // Noble_gases
                HideAllImages();
                ShowAllImagesOfThisElement(Noble_gases);
            break;

            case "GrayShapeTable": // Lanthanides
                HideAllImages();
                ShowAllImagesOfThisElement(Lanthanides);
            break;

            case "TulipanVioletShapeTable": // Actinides
                HideAllImages();
                ShowAllImagesOfThisElement(Actinides);
            break;
        }
    }

    private void OnMouseExit()
    {
        ShowAllImages();
    }

    private void ShowAllImages()
    {
        for (int i = 0; i < allImagesOfElements.Length; i++)
        {
            image = allImagesOfElements[i].GetComponent<Image>();
            Color tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            UIArrows.GetComponent<Image>().enabled = true;
        }
    }

    private void HideAllImages()
    {
        for (int i = 0; i < allImagesOfElements.Length; i++)
        {
            image = allImagesOfElements[i].GetComponent<Image>();
            Color tempColor = image.color;
            tempColor.a = 0.3f;
            image.color = tempColor;
            UIArrows.GetComponent<Image>().enabled = false;
        }
    }

    private void ShowAllImagesOfThisElement(GameObject[] ElementList)
    {
        foreach (GameObject element in ElementList)
        {
            image = element.GetComponent<Image>();
            Color tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
        }
    }
}