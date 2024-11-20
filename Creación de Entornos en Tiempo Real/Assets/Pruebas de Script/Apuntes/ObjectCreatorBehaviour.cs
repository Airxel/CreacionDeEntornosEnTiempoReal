using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreatorBehaviour : MonoBehaviour
{
    [SerializeField] GameObject prefabCubeRed;
    [SerializeField] GameObject prefabCubeBlue;
    [SerializeField] LeanTweenType animType1;
    [SerializeField] LeanTweenType animType2;
    [SerializeField] LeanTweenType animType3;

    bool firstCreated;

    [SerializeField] GameObject objectCreated;
    void Start()
    {
        firstCreated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (firstCreated)
            {
                Destroy(objectCreated);
                objectCreated = Instantiate(prefabCubeRed, Vector3.zero, Quaternion.identity);
            }
            else if (firstCreated == false)
            {
                objectCreated = Instantiate(prefabCubeRed, Vector3.zero, Quaternion.identity);
                firstCreated = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (firstCreated)
            {
                Destroy(objectCreated);
                objectCreated = Instantiate(prefabCubeBlue, Vector3.zero, Quaternion.identity);
            }
            else if (firstCreated == false)
            {
                objectCreated = Instantiate(prefabCubeBlue, Vector3.zero, Quaternion.identity);
                firstCreated = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            LeanTween.moveY(objectCreated, 40f, 1f).setEase(animType1).setOnComplete(() =>
            {
                LeanTween.rotateY(objectCreated, 2000f, 10f).setEase(animType2);
                LeanTween.scale(objectCreated, new Vector3(0f, 0f, 0f), 10f).setEase(animType3).setOnComplete(() =>
                {
                    Destroy(objectCreated);
                    firstCreated = false;
                });
            });
        }
        objectCreated.SetActive(false);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            objectCreated.transform.position = hitPoint;
        }
        objectCreated.SetActive(true);
    }
}
