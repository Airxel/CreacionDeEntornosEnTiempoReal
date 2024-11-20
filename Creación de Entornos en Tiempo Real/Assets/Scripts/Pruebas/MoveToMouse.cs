using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    static List<MoveToMouse> moveableObjects = new List<MoveToMouse>();
    float speed = 5f;
    private Vector3 target;
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        moveableObjects.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        selected = true;

        foreach (MoveToMouse obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
            }
        }
    }
}
