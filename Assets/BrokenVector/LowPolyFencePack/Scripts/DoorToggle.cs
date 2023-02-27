using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace BrokenVector.LowPolyFencePack
{
    /// <summary>
    /// This class toggles the door animation.
    /// The gameobject of this script has to have the DoorController script which needs an Animator component
    /// and some kind of Collider which detects your mouse click applied.
    /// </summary>
    [RequireComponent(typeof(DoorController))]
	public class DoorToggle : MonoBehaviour
    {

        private DoorController doorController;

        void Awake()
        {
            doorController = GetComponent<DoorController>();
        }

	    void OnCollisionEnter(Collision collision)
	    {
            if(collision.gameObject.tag == "Player"){
                if(Global.level == 0 && Global.gemCount == 3){
                    doorController.ToggleDoor();
                    Global.gemCount = 0; 
                    StartCoroutine(NextLevelAfterWait()); 
                    Global.level += 1; 
                }

                if(Global.level ==1 && Global.gemCount == 6){
                    doorController.ToggleDoor();
                    Global.gemCount = 0; 
                    StartCoroutine(NextLevelAfterWait()); 
                    Global.level += 1; 
                }
            }
	    }

        IEnumerator NextLevelAfterWait() {
            yield return new WaitForSeconds(1.0f);
            if(Global.level == 1){
                SceneManager.LoadScene("level2");
            }
            
            if(Global.level == 2){
                SceneManager.LoadScene("endscreen");
            }
        }

	}
}