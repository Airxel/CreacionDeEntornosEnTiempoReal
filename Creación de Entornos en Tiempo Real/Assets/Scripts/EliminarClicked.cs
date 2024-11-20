using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EliminarClicked : MonoBehaviour
{
    [SerializeField]
    GameObject eliminarText;

    [SerializeField]
    private GameObject selectedObject;  // El objeto seleccionado

    private bool isDeleteMode = false;  // Modo de eliminaci�n

    // Funci�n para activar o desactivar el modo de eliminaci�n
    public void ToggleDeleteMode()
    {
        if (!isDeleteMode)
        {
            isDeleteMode = true;
        }
    }

    // Funci�n para eliminar el objeto seleccionado
    public void TryDeleteObject()
    {
        if (isDeleteMode && selectedObject != null)
        {
            Destroy(selectedObject);  // Eliminar el objeto
            selectedObject = null;  // Limpiar la selecci�n

            // Desactivamos el modo de eliminaci�n despu�s de borrar el objeto
            isDeleteMode = false;

            LeanTween.moveY(eliminarText.GetComponent<RectTransform>(), -200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
        }
    }

    // Esta funci�n se llama en cada frame para detectar clics
    void Update()
    {
        // Solo intentamos eliminar si estamos en modo de eliminaci�n
        if (isDeleteMode && Input.GetMouseButtonDown(0)) // Clic izquierdo del rat�n
        {
            // Realizamos un raycast desde la c�mara hacia el cursor
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