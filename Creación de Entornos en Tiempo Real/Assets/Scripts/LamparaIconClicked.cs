using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamparaIconClicked : MonoBehaviour
{
    [SerializeField]
    GameObject lampara;

    [SerializeField]
    private GameObject newLampara;

    // Función que se activa cuando hacemos clic en el icono de la mesa
    public void LamparaClicked()
    {
        CreateObjectAtMousePosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el objeto ha sido creado, lo seguimos con el ratón
        if (newLampara != null)
        {
            FollowMouse();

            // Colocamos el objeto en el lugar donde se hace clic izquierdo
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObjectAtMouseClick();
            }
        }
    }

    // Función para crear el objeto en la posición del ratón
    private void CreateObjectAtMousePosition()
    {
        // Se manda un rayo desde la cámara hacia el ratón
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Vemos si el rayo colisiona con algún objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Se crea el objeto en la posición donde colisione
            newLampara = Instantiate(lampara, hit.point, Quaternion.identity);
        }
    }

    // Función para mover el objeto según el movimiento del ratón
    private void FollowMouse()
    {
        // Se manda un rayo desde la cámara hacia el ratón
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Vemos si el rayo colisiona con algún objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Se coloca el objeto en la posición donde colisione
            newLampara.transform.position = new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z);
        }
    }

    // Función para colocar el objeto donde se hace clic
    private void PlaceObjectAtMouseClick()
    {
        // Se manda un rayo desde la cámara hacia el ratón
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Si el rayo colisiona con una superficie
        if (Physics.Raycast(ray, out hit))
        {
            // Se mira que la superficie tenga la etiqueta de "suelo"
            if (hit.collider.CompareTag("Suelo"))
            {
                // Se coloca el objeto en la posición donde se hizo clic
                newLampara.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                // Y el objeto deja de seguir el ratón
                newLampara = null;
            }     
        }
    }
}
