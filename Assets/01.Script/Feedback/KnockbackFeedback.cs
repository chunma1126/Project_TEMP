using System.Collections;
using UnityEngine;

public class KnockbackFeedback : Feedback
{
    private Vector2 knockbackDirection;
    private float knockbackPower;
    private Coroutine knockbackRoutine; 
    private WaitForSeconds knockbackWait;
    
    [SerializeField] private Enemy enemy;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float knockbackDelay;

    private void Awake()
    {
        knockbackWait = new WaitForSeconds(knockbackDelay);
    }

    public void PlayFeedback(ActionData actionData)
    {
        knockbackDirection = actionData.knockbackDirection;
        knockbackPower = actionData.knockbackPower;
        
        FinishFeedback();
        CreateFeedback();
    }
    
    public override void CreateFeedback()
    {
        knockbackRoutine = StartCoroutine(CoKnockbackRoutine());
    }
    
    public override void FinishFeedback()
    {
        if (knockbackRoutine == null)
        {
            return;
        }
        
        StopCoroutine(knockbackRoutine);
        enemy.SetMove(true);
        rigid.linearVelocity = Vector2.zero;
    }

    private IEnumerator CoKnockbackRoutine()
    {
        enemy.SetMove(false);
        rigid.linearVelocity = Vector2.zero;
        rigid.linearVelocity = knockbackDirection * knockbackPower;
        yield return knockbackWait;
        FinishFeedback();
    }
    
}
