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

    /// <summary>
    /// Animaciones que se realizan al hacer clic en el panel donde están los botones
    /// </summary>
    public void ButtonsPanelClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), 150f, 1.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(moverText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(rotarText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
    }

    /// <summary>
    /// Animaciones que se realizan al hacer clic en el botón "Mover"
    /// </summary>
    public void MoverButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(moverText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
    }

    /// <summary>
    /// Animaciones que se realizan al hacer clic en el botón "Rotar"
    /// </summary>
    public void RotarButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(rotarText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
    }

    /// <summary>
    /// Animaciones que se realizan al hacer clic en el botón "Eliminar"
    /// </summary>
    public void EliminarButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
    }

    /// <summary>
    /// Animaciones que se realizan al hacer clic en el botón "Crear"
    /// </summary>
    public void CrearButtonClicked()
    {
        LeanTween.moveY(buttonsPanel.GetComponent<RectTransform>(), -75f, 1.0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), -27.5f, 1.5f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveY(crearText.GetComponent<RectTransform>(), 20f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
    }

    /// <summary>
    /// Animación que se realiza al hacer clic en el icono de la mesa
    /// </summary>
    public void MesaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

    /// <summary>
    /// Animación que se realiza al hacer clic en el icono de la silla
    /// </summary>
    public void SillaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

    /// <summary>
    /// Animación que se realiza al hacer clic en el icono de la lámpara
    /// </summary>
    public void LamparaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

    /// <summary>
    /// Animación que se realiza al hacer clic en el icono de la planta
    /// </summary>
    public void PlantaClicked()
    {
        LeanTween.moveX(objectsPanel.GetComponent<RectTransform>(), 275f, 1.0f).setEase(LeanTweenType.easeInOutSine);
    }

}