using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) //if it is the player
        {
            cam.minPosition += cameraChange; //adjust new boundaries for camera
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            Debug.Log("Had collision");
            if(needText){
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo(){
        text.SetActive(true);
        placeText.text = placeName;
        placeText.GetComponent<Text>().CrossFadeAlpha(0, 3.5f, false);
  // Adds fade to text
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
