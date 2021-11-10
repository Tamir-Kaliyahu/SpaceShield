using System;
using System.Collections;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    //public Boolean isShield = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            //isShield = true;
            Debug.Log("Shield triggered by player");
            var ShieldVisual = other.gameObject.transform.GetChild(0).gameObject;
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();

            if (destroyComponent& destroyComponent.enabled) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent,ShieldVisual));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }
    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent, GameObject g1) {
        destroyComponent.enabled = false;
        g1.SetActive(true);
        var ShieldRender = g1.GetComponent<SpriteRenderer>();
        Color ShieldC = ShieldRender.color;
        float reduceColor = 0.15f;
        ShieldC.a = 0.9f;
        g1.GetComponent<SpriteRenderer>().color = ShieldC;
        
        for (float i = duration; i > 0; i--) {
            ShieldC.a = g1.GetComponent<SpriteRenderer>().color.a;
            ShieldC.a -= reduceColor;
            Debug.Log("ColorShild.a is: " + ShieldC.a + " reduceColor is "+ reduceColor+ "shild render.a is "+ g1.GetComponent<SpriteRenderer>().color.a);
            g1.GetComponent<SpriteRenderer>().color = ShieldC;
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }
        //.SetActive(false);
        //Destroy(newObject);
        Debug.Log("Shield gone!");
        g1.SetActive(false);
        destroyComponent.enabled = true;

    }
    
}
