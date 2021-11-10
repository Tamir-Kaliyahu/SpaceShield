using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiledOn : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [Tooltip("sprite render")] [SerializeField] SpriteRenderer rend;
    [SerializeField] Mover prefabToFade;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //rend.color.a = 200;
            Color c = rend.color;
            c.a = 200;
            rend.color = c;
        }
        else
        {
            Debug.Log("Shield triggered by " + other.name);
        }
    }
    private IEnumerator ShieldFadeOut()
    {
        for (float i = 50; i > 0; i--)
        {
            
            yield return new WaitForSeconds(0.1f);
        }
    }
}
