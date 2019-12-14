using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class VRUIItem : MonoBehaviour {
	
    private BoxCollider boxCollider;
    private RectTransform rectTransform;
	//Dieses Script stellt sicher, dass alle Buttons automatisch einen Collider bekommen, der der Größe des Buttons entspricht
    private void OnEnable(){
		
        ValidateCollider();
    }

    private void OnValidate(){
		
        ValidateCollider();
    }

    private void ValidateCollider(){
		
        rectTransform = GetComponent<RectTransform>();
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null){
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }
        boxCollider.size = rectTransform.sizeDelta;
    }
}