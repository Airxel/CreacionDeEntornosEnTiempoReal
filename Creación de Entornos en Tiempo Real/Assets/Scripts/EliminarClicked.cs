using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EliminarClicked : MonoBehaviour
{
    [SerializeField]
    GameObject eliminarText;

    [SerializeField]
    GameObject deletedObject;

    // Condici�n de si el objeto est� siendo eliminado
    bool isDeletingObject = false;

    // Condici�n de si el bot�n "Eliminar" ha sido pulsado
    bool deleteIsClicked = false;


    /// <summary>
    /// Al hacer clic en el bot�n "Eliminar" de la UI, se activa esta funci�n, que pone la condici�n en verdadera
    /// </summary>
    public void DeleteObject()
    {
        deleteIsClicked = true;
    }

    private void Update()
    {
        if (deleteIsClicked == true)
        {
            // Si la condici�n es verdadera, se activa la funci�n
            SelectedObject();

            // Si la condici�n es verdadera y el objeto a borrar no es nulo, se activa la funci�n
            if (isDeletingObject == true && deletedObject != null)
            {
                DeletingObject();
            }
        }
    }

    /// <summary>
    /// Funci�n para poder seleccionar un objeto usando raycast.
    /// </summary>
    private void SelectedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Si el rayo golpea un objeto que tenga la etiqueta de "Selectable" y se ha hecho clic izquierdo
            if (hit.collider.CompareTag("Selectable") && Input.GetMouseButtonDown(0))
            {
                // Se selecciona el objeto
                deletedObject = hit.collider.gameObject;

                // La condici�n del objeto en rotaci�n pasa a ser verdadera
                isDeletingObject = true;
            }
        }
    }

    /// <summary>
    /// Funci�n para poder eliminar el objeto seleccionado.
    /// </summary>
    private void DeletingObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            // Al hacer clic izquiero
            if (Input.GetMouseButtonDown(0))
            {
                // Se elimina el objeto seleccionado
                Destroy(deletedObject);

                // Deja de haber un objeto seleccionado
                deletedObject = null;

                // La condici�n del objeto siendo eliminado pasa a ser falsa
                isDeletingObject = false;

                // La condici�n de si se ha pulsado el bot�n "Eliminar" pasa a ser falsa
                deleteIsClicked = false;

                // Animaci�n que se realiza despu�s de eliminar el objeto
                LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
            }
        }
    }
}