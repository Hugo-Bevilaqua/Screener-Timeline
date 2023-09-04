using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropZoneMover : MonoBehaviour
{

    public Slider DZSlider;
    private Vector3 pos;
    private Vector3 org;

    void Start()
    {
        org = this.transform.localPosition;
        pos = this.transform.localPosition;
    }

    void Update()
    {
        pos.x=org.x+(DZSlider.value-0.5f)*8080;
        this.transform.localPosition=pos;
    }
}
