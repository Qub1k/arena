using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int sceneInd;

    public bool InColl;

    public GameObject hint;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && InColl){
            SceneManager.LoadScene(sceneInd);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            InColl = true;
            hint.SetActive(true);
        }
    }


    public void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            InColl = false;
            hint.SetActive(false);
        }
    }
}
