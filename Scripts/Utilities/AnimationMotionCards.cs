using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMotionCards : MonoBehaviour
{
    [SerializeField] private Image imageTarget;
    [SerializeField] private List<Sprite> m_Sprites;
    public float renderAlpha;
    public bool fadeIn;
    public bool fadeOut;

    // Start is called before the first frame update
    private void Start()
    {
        imageTarget.sprite = m_Sprites[0];
        renderAlpha = imageTarget.color.a;

        fadeIn = true;
    }

    
    private void Update()
    {
        if (fadeIn)
        {
            if (renderAlpha < 1)
            {
                renderAlpha += Time.deltaTime * 0.5f;
                imageTarget.color = new Color(renderAlpha, renderAlpha, renderAlpha, renderAlpha);

                if (renderAlpha >= 1)
                {
                    StartCoroutine(DelayCoroutine());
                }
            }
        }

        if(fadeOut)
        {
            if (renderAlpha >= 0)
            {
                renderAlpha -= Time.deltaTime * 0.75f;
                imageTarget.color = new Color(renderAlpha, renderAlpha, renderAlpha, renderAlpha);
                
                if (renderAlpha <= 0)
                {
                    imageTarget.sprite = m_Sprites[Random.Range(0, m_Sprites.Count)];

                    fadeOut = false;
                    fadeIn = true;

                }
            }
        }
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(5);

        ResetService();
    }

    private void ResetService()
    {
        fadeIn = false;
        fadeOut = true;
    }    
}