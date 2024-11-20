using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EliminarClicked : MonoBehaviour
{
    [SerializeField]
    GameObject eliminarText;

    [SerializeField]
    GameObject deletedObject;

    // Condición de si el objeto está siendo eliminado
    bool isDeletingObject = false;

    // Condición de si el botón "Eliminar" ha sido pulsado
    bool deleteIsClicked = false;


    /// <summary>
    /// Al hacer clic en el botón "Eliminar" de la UI, se activa esta función, que pone la condición en verdadera
    /// </summary>
    public void DeleteObject()
    {
        deleteIsClicked = true;
    }

    private void Update()
    {
        if (deleteIsClicked == true)
        {
            // Si la condición es verdadera, se activa la función
            SelectedObject();

            // Si la condición es verdadera y el objeto a borrar no es nulo, se activa la función
            if (isDeletingObject == true && deletedObject != null)
            {
                DeletingObject();
            }
        }
    }

    /// <summary>
    /// Función para poder seleccionar un objeto usando raycast.
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

                // La condición del objeto en rotación pasa a ser verdadera
                isDeletingObject = true;
            }
        }
    }

    /// <summary>
    /// Función para poder eliminar el objeto seleccionado.
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

                // La condición del objeto siendo eliminado pasa a ser falsa
                isDeletingObject = false;

                // La condición de si se ha pulsado el botón "Eliminar" pasa a ser falsa
                deleteIsClicked = false;

                // Animación que se realiza después de eliminar el objeto
                LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), -200f, 1.0f).setEase(LeanTweenType.easeInOutSine).setDelay(0.25f);
            }
        }
    }
}