using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public float score;
    public ScoreManager scoreManager;
    public AudioManager audioManager;  
    public VFXManager vfxManager;  // Tambahkan referensi ke VFXManager

    private SwitchState state;
    private Renderer renderer;
    private Coroutine blinkCoroutine;  

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();  
        }
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;

            // Tambah skor ketika switch diaktifkan
            if (scoreManager != null)
            {
                scoreManager.AddScore(score);  // Tambahkan skor
            }

            // Mainkan SFX
            if (audioManager != null)
            {
                audioManager.PlaySFX(transform.position);
            }

            // Mainkan VFX
            if (vfxManager != null)
            {
                vfxManager.PlayVFX(transform.position);
            }

            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;  
            }
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;

            // Kurangi skor ketika switch dimatikan
            if (scoreManager != null)
            {
                scoreManager.AddScore(-score);  // Kurangi skor
            }

            if (blinkCoroutine == null)
            {
                blinkCoroutine = StartCoroutine(BlinkTimerStart(5));  
            }
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false); 
        }
        else
        {
            Set(true);   
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        blinkCoroutine = StartCoroutine(BlinkTimerStart(5));  
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);

        if (state == SwitchState.Off)
        {
            blinkCoroutine = StartCoroutine(Blink(2));  
        }
    }
}
