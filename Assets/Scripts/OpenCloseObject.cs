using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseObject : MonoBehaviour
{
    public Image myImage;
    public Sprite[] myPages;
    public FloatValue pageLength;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (index == 0)
        {
            myImage.gameObject.SetActive(true); //show the image
            myImage.sprite = myPages[0]; //load in sprite
            index++;
        } else if (index < (int)pageLength.initialValue )
        {
            myImage.sprite = myPages[index];
            index++;
        } else
        {
            index = 0;
            myImage.gameObject.SetActive(false); //hide the image
        }
    }
     
}
