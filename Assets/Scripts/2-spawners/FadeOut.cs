using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float durration;//7

    public Color targetColor = new Color(1f, 1f, 1f, 0f);
    SpriteRenderer spriteToFade;

    void Start()
    {
        spriteToFade = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(LerpFunction(targetColor, durration));
    }

    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = spriteToFade.color;

        while (time < duration)
        {
            spriteToFade.color = Color.Lerp(startValue, endValue, time / duration);
            Debug.Log("spritecolor.a is: " + spriteToFade.color.a);
            time += Time.deltaTime;
            yield return null;
        }
        spriteToFade.color = endValue;
        this.gameObject.SetActive(false);
    }
}
