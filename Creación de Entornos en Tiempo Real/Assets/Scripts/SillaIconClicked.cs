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
    /// Al hacer clic en el icono de la silla en la UI, se activa esta funci�n
    /// </summary>
    public void SillaClicked()
    {
        CreateObjectAtMousePosition();
    }

    // Update is called once per frame
    private void Update()
    {
        // Si la silla se ha creado, se activa la funci�n
        if (newSilla != null)
        {
            FollowMouse();

            // Si se hace clic izquierdo, se activa la funci�n
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObjectAtMouseClick();
            }
        }
    }

    /// <summary>
    /// Funci�n para poder crear el objeto en la posici�n del rat�n, usando raycast
    /// </summary>
    private void CreateObjectAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si el rayo golpea con alg�n objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Se crea el objeto en la posici�n donde golpee
            newSilla = Instantiate(silla, hit.point, Quaternion.identity);
        }
    }

    /// <summary>
    /// Funci�n para que el objeto seleccionado siga al rat�n usando raycast.
    /// </summary>
    private void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si el rayo golpea con alg�n objeto
        if (Physics.Raycast(ray, out hit))
        {
            // El objeto sigue al rat�n a una distancia algo alejada porque el raycast estaba afectando al propio objeto al moverse,
            // ya que el rat�n estaba sobre el objeto en algunos casos
            newSilla.transform.position = new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z);
        }
    }

    /// <summary>
    /// Funci�n para poder colocar el objeto seleccionado, usando raycast, en alguna superficie concreta al hacer clic izquierdo
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

                // El objeto deja de seguir el rat�n
                newSilla = null;

                // Animaci�n que se realiza despu�s de colocar el objeto
                LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
            }     
        }
    }
}