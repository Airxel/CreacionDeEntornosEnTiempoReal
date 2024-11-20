using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ManagerGeneral : MonoBehaviour
{

    [SerializeField]
    GameObject buttonsPanel, objectsPanel, crearText, moverText, rotarText, eliminarText;

    // Referencia al script que tiene la funcionalidad de selección y eliminación
    public EliminarClicked objectDeleted;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
       
    }

    public void ButtonsPanelClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), 150f, 1.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(moverText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(rotarText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
    }

    public void MoverButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(moverText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.5f);
    }

    public void RotarButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(rotarText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.5f);
    }

    public void EliminarButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.5f);
    }

    public void CrearButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), -27.5f, 1.5f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.5f);
    }

    public void MesaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void SillaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void LamparaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void PlantaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

}