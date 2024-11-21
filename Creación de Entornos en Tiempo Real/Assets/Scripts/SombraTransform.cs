using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombraTransform : MonoBehaviour
{

    [SerializeField]
    GameObject sombra;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(sombra, new Vector3(7.5f, 0f, 7.5f), 1.5f).setEase(LeanTweenType.easeInOutSine).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
