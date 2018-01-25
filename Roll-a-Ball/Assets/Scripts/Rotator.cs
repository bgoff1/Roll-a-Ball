using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour {

    public Button button;
    private bool canRotate;

    private void Start()
    {
        canRotate = true;
    }
    void Update()
    {
        if (button.GetComponent<Button>().IsActive())
        {
            canRotate = false;
        }
        else
        {
            canRotate = true;
        }
        if (canRotate)
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
}
