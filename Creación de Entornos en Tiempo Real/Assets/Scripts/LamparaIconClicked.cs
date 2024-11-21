using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparaIconClicked : MonoBehaviour
{
    [SerializeField]
    GameObject lampara, crearText;

    [SerializeField]
    GameObject newLampara;

    [SerializeField]
    GameObject sombra;

    [SerializeField]
    Vector3 sombraOriginalPosition = new Vector3(-150f, 0f, 20f);

    /// <summary>
    /// Al hacer clic en el icono de la lámpara en la UI, se activa esta función
    /// </summary>
    public void LamparaClicked()
    {
        CreateObjectAtMousePosition();
    }

    // Update is called once per frame
    private void Update()
    {
        // Si la lámpara se ha creado, se activa la función
        if (newLampara != null)
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
            newLampara = Instantiate(lampara, hit.point, Quaternion.identity);

            // Se emparenta la sombra al objeto creado
            sombra.transform.parent = newLampara.transform;
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
            newLampara.transform.position = new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z);

            // La posición de la sombra pasa a ser la del objeto creado
            sombra.transform.position = newLampara.transform.position;
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
                newLampara.transform.position = hit.point;

                // El objeto deja de seguir el ratón
                newLampara = null;

                // La sombra deja de tener emparentado
                sombra.transform.parent = null;

                //La sombra vuelve a su posición original
                sombra.transform.position = sombraOriginalPosition;

                // Animación que se realiza después de colocar el objeto
                LeanTween.moveY(crearText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
            }     
        }
    }
}
