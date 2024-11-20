using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EliminarClicked : MonoBehaviour
{
    [SerializeField]
    GameObject eliminarText;

    [SerializeField]
    private GameObject selectedObject;  // El objeto seleccionado

    private bool isDeleteMode = false;  // Modo de eliminación

    // Función para activar o desactivar el modo de eliminación
    public void ToggleDeleteMode()
    {
        if (!isDeleteMode)
        {
            isDeleteMode = true;
        }
    }

    // Función para eliminar el objeto seleccionado
    public void TryDeleteObject()
    {
        if (isDeleteMode && selectedObject != null)
        {
            Destroy(selectedObject);  // Eliminar el objeto
            selectedObject = null;  // Limpiar la selección

            // Desactivamos el modo de eliminación después de borrar el objeto
            isDeleteMode = false;

            LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        }
    }

    // Esta función se llama en cada frame para detectar clics
    void Update()
    {
        // Solo intentamos eliminar si estamos en modo de eliminación
        if (isDeleteMode && Input.GetMouseButtonDown(0)) // Clic izquierdo del ratón
        {
            // Realizamos un raycast desde la cámara hacia el cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Miramos si el objeto a borrar tiene la etiqueta de seleccionable
                if (hit.collider.CompareTag("Selectable"))
                {
                    // Si el raycast golpea un objeto, lo asignamos como objeto seleccionado
                    selectedObject = hit.collider.gameObject;
                    TryDeleteObject();  // Intentamos eliminar el objeto seleccionado
                }
                
            }
        }
    }
}