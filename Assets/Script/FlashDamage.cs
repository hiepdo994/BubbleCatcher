using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{

    /*
     * script attach to player health if player touch enemy take damage() take place
     *  get sprite of flash damage store original sprite then call coroutine and check if it is null
     *  then dont run coroutine
     */
    public Material flashMaterial;
    public float duration;
    public SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
        Debug.Log("Already flash!");
    }

    public void Flash()
    {
        if(flashRoutine!=null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
}
