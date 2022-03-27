using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float time;
    public Color tintColor;
    private Color originalColor;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    public void DoTint()
    {
        spriteRenderer.color = tintColor;
        Invoke("TintBackToOriginalColor", time);
    }

    private void TintBackToOriginalColor()
    {
        spriteRenderer.color = originalColor;
    }
}
