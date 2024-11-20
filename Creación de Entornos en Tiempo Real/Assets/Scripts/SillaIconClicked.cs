using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillaIconClicked : MonoBehaviour
{
    [SerializeField]
    GameObject silla, crearText;

    [SerializeField]
    GameObject newSilla;

    /// <summary>
    /// Al hacer clic en el icono de la silla en la UI, se activa esta función
    /// </summary>
    public void SillaClicked()
    {
        CreateObjectAtMousePosition();
    }

    // Update is called once per frame
    private void Update()
    {
        // Si la silla se ha creado, se activa la función
        if (newSilla != null)
        {
            FollowMouse();

            // Si se hace clic izquierdo, se activa la función
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObjectAtMouseClick();
            }
        }
    }

    /// <summary>
    /// Función para poder crear el objeto en la posición del ratón, usando raycast
    /// </summary>
    private void CreateObjectAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si el rayo golpea con algún objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Se crea el objeto en la posición donde golpee
            newSilla = Instantiate(silla, hit.point, Quaternion.identity);
        }
    }

    /// <summary>
    /// Función para que el objeto seleccionado siga al ratón usando raycast.
    /// </summary>
    private void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si el rayo golpea con algún objeto
        if (Physics.Raycast(ray, out hit))
        {
            // El objeto sigue al ratón a una distancia algo alejada porque el raycast estaba afectando al propio objeto al moverse,
            // ya que el ratón estaba sobre el objeto en algunos casos
            newSilla.transform.position = new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z);
        }
    }

    /// <summary>
    /// Función para poder colocar el objeto seleccionado, usando raycast, en alguna superficie concreta al hacer clic izquierdo
    /// </summary>
    private void PlaceObjectAtMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // La superficie tiene que tener la etiqueta de "Suelo" o el objeto no se puede colocar
            if (hit.collider.CompareTag("Suelo"))
            {
                // Se coloca el objeto donde el rayo golpee al hacer clic
                newSilla.transform.position = hit.point;

                // El objeto deja de seguir el ratón
                newSilla = null;

                // Animación que se realiza después de colocar el objeto
                LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
            }     
        }
    }
}