using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public bool frozen = false;
	public Vector3 target;
	
	void Start(){
		//Initialisieren
		target = transform.position;
		this.GetComponent<AudioSource>().volume = GameObject.Find("EventSystem").GetComponent<PublicVariables>().mastervol * GameObject.Find("EventSystem").GetComponent<PublicVariables>().soundvol;
	}
	
	
	void Update(){
		//sorgt dafür, dass sich die Spielfigur bewegt. Überprüft auch, ob mit Maus oder Tastatur gesteuert wird
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().OptionP.gameObject.activeSelf == true){
			this.GetComponent<AudioSource>().volume = GameObject.Find("SoundSlider").GetComponent<Slider>().value * GameObject.Find("MasterSlider").GetComponent<Slider>().value;
		}
		if ((target.x != GameObject.Find("Player").transform.position.x || target.y != GameObject.Find("Player").transform.position.y) && (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater == true || (Mathf.Abs(GameObject.Find("E6").transform.position.x - GameObject.Find("Player").transform.position.x) + (Mathf.Abs(GameObject.Find("E6").transform.position.y - GameObject.Find("Player").transform.position.y)) <= 2.5))){
			if (this.GetComponent<AudioSource>().isPlaying == false && frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
				this.GetComponent<AudioSource>().Play(0);
			}
		}
		if (GameObject.Find("EventSystem").GetComponent<PublicVariables>().inwater != true && (Mathf.Abs(GameObject.Find("E6").transform.position.x - GameObject.Find("Player").transform.position.x) + (Mathf.Abs(GameObject.Find("E6").transform.position.y - GameObject.Find("Player").transform.position.y)) > 2.5)){
			this.GetComponent<AudioSource>().Stop();
		}
		if (frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false){
			transform.position = Vector3.MoveTowards(transform.position, target, GameObject.Find("EventSystem").GetComponent<PublicVariables>().speedmod * 0.1f);
		}
	}
	
	
	public void LaserControl(float hitx, float hity){
		
		if (frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
			target.x = hitx;
			target.y = hity;
			target.z = transform.position.z;
			if (target.y < -13){
				target.y = -13;
			}
			else if (target.y > 13){
				target.y = 13;
			}
			if (target.x > GameObject.Find("Player").transform.position.x){
				GameObject.Find("Player").GetComponent<Image>().sprite = Resources.Load<Sprite>("playerimgright");
			}
			else if (target.x < GameObject.Find("Player").transform.position.x){
				GameObject.Find("Player").GetComponent<Image>().sprite = Resources.Load<Sprite>("playerimgleft");
			}
		}
	}
	
	
	public void CurvedCanvasLeft(){
		
		if (frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
			LaserControl(89.0f, transform.position.y);
		}
	}
	
	
	public void CurvedCanvasRight(){
		
		if (frozen == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().hidden == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().paused == false && GameObject.Find("EventSystem").GetComponent<PublicVariables>().button_active == false){
			LaserControl(-25.0f, transform.position.y);
		}
	}
}