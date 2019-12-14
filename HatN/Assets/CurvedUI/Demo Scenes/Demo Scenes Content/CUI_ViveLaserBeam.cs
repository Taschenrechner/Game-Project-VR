using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CurvedUI
{
    /// <summary>
    /// This class contains code that controls the mockup vive controller. 
    /// Its made to make demo sceen look better. Its not made to be used with actual vive controller.
    /// </summary>
    public class CUI_ViveLaserBeam : MonoBehaviour
    {

        [SerializeField]
        Transform LaserBeamTransform;
        [SerializeField]
        Transform LaserBeamDot;

        

        // Update is called once per frame
        protected void Update()
        {

            //get direction of the controller
            Ray myRay = new Ray(this.transform.position, this.transform.forward);


            //make laser beam hit stuff it points at.
            if(LaserBeamTransform && LaserBeamDot) {
                //change the laser's length depending on where it hits
                float length = 10000;

                RaycastHit hit;
				
                if (Physics.Raycast(myRay, out hit, length))
                {
                    length = Vector3.Distance(hit.point, this.transform.position);
					//Der nachfolgende Code sorgt dafür, dass mit dem Eventpanel und den FertigkeitenPanel bei dem GUI interagiert werden kann
					if (hit.collider.name == "RandomButton"){
						GameObject.Find("RandomButton").GetComponent<Button>().Select();
						if (Input.GetButtonDown("ViveSubmit")){
							GameObject.Find("RandomButton").GetComponent<Button>().onClick.Invoke();
						}
					}
					if (hit.collider.name == "SelectionA"){
						GameObject.Find("SelectionA").GetComponent<Button>().Select();
						if (Input.GetButtonDown("ViveSubmit")){
							GameObject.Find("SelectionA").GetComponent<Button>().onClick.Invoke();
						}
					}
					if (hit.collider.name == "SelectionB"){
						GameObject.Find("SelectionB").GetComponent<Button>().Select();
						if (Input.GetButtonDown("ViveSubmit")){
							GameObject.Find("SelectionB").GetComponent<Button>().onClick.Invoke();
						}
					}
					

                    //If we hit a canvas, we only want transforms with graphics to block the pointer. (that are drawn by canvas => depth not -1)
                    if (hit.transform.GetComponent<CurvedUIRaycaster>() != null)  {
                        int SelectablesUnderPointer = hit.transform.GetComponent<CurvedUIRaycaster>().GetObjectsUnderPointer().FindAll(x => x.GetComponent<Graphic>() != null && x.GetComponent<Graphic>().depth != -1).Count;

                        //Debug.Log("found graphics: " + SelectablesUnderPointer);
                        length = SelectablesUnderPointer == 0 ? 10000 : Vector3.Distance(hit.point, this.transform.position);
						if (Input.GetButtonDown("ViveSubmit") && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
							//Berechnung von dem Bogenmaß, notwendig, damit die Koordinate auf dem Curved Screen in die wirkliche Koordinate umgerechnet werden kann
							float x = hit.point.x - 32.5f;
							float z = 30.558f + hit.point.z;
							float c = Mathf.Sqrt(x * x + z * z);
							c = Mathf.Rad2Deg * Mathf.Acos(z/c);
							if (x < 0){
								c = - c;
							}
							x = ((c / 360) * 2 * 30.5577f * Mathf.PI) + 32.5f;
							if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
								GameObject.Find("Player").GetComponent<PlayerController>().LaserControl(x, hit.point.y);
							}
							GameObject.Find("E1").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E2").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E3").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E4").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E5").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E6").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E7").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E8").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E9").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("E10").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("T1").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("T2").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("T3").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("T4").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("T5").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("K1").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("K2").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("M1").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("M2").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("V1P1").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("V2P3").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("V3P4").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("P2").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
							GameObject.Find("P5").GetComponent<Interactable>().LaserInteract(x, hit.point.y);
						}
                    }
                }

                LaserBeamTransform.localScale = LaserBeamTransform.localScale.ModifyZ(length);
            }
           

        }
    }
}
