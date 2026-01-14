using System.Collections;
using UnityEngine;

public class ChangeMatFeedback : Feedback
{
    private Material originalMat;
    private Coroutine changeMatRoutine;
    private WaitForSeconds wait;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Material changeMat;
    [SerializeField] private float delayTime = 0.1f;

    private void Awake()
    {
        originalMat = spriteRenderer.material;
    }

    private void Start()
    {
        wait = new WaitForSeconds(delayTime);
    }

    public override void CreateFeedback()
    {
        changeMatRoutine = StartCoroutine(CoChangeMatRoutine());
    }

    public override void FinishFeedback()
    {
        if(changeMatRoutine != null)
            StopCoroutine(changeMatRoutine);
    }

    private IEnumerator CoChangeMatRoutine()
    {
        spriteRenderer.material = changeMat;
        yield return wait;
        spriteRenderer.material = originalMat;
    }
}
