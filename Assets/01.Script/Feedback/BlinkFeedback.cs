using System;
using System.Collections;
using UnityEngine;

public class BlinkFeedback : Feedback
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int blinkCount;
    [SerializeField] private float targetAlpha;
    
    private Coroutine blinkRoutine;
    private WaitForSeconds blinkOnDelay;
    private WaitForSeconds blinkOffDelay;
    
    private Color originColor;
    private Color targetColor;

    private void Awake()
    {
        playerData.OnInvincibleTimeChange += SetDelayTime;
    }

    private void Start()
    {
        SetDelayTime(playerData.InvincibleTime);
        
        originColor = spriteRenderer.color;
        targetColor = new Color(originColor.r, originColor.g, originColor.b, targetAlpha);
    }

    [ContextMenu("Blink")]
    public override void CreateFeedback()
    {
        blinkRoutine = StartCoroutine(CoBlinkRoutine());
    }
    
    public override void FinishFeedback()
    {
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
            spriteRenderer.color = originColor;
        }
    }

    private void SetDelayTime(float invincibleTime)
    {
        float delayTime = invincibleTime / blinkCount;//once time blink
        
        blinkOnDelay = new WaitForSeconds(delayTime/2);
        blinkOffDelay = new WaitForSeconds(delayTime/2);
    }
    
    private IEnumerator CoBlinkRoutine()
    {
        for (int i =  0; i < blinkCount; i++)
        {
            spriteRenderer.color = targetColor;
            yield return blinkOnDelay;
            spriteRenderer.color = originColor;
            yield return blinkOffDelay;
        }
    }
}
