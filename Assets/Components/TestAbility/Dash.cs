using System.Collections;
using UnityEngine;

public class Dash : Ability
{
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;

    protected override void ActivateAbility(GameObject user)
    {
        Rigidbody2D rb = user.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Start the dash
            Vector2 dashDirection = new Vector2(Mathf.Sign(user.transform.localScale.x), 0);
            rb.velocity = dashDirection * dashSpeed;

            // Stop the dash after the duration
            user.GetComponent<MonoBehaviour>().StartCoroutine(StopDash(rb));
        }
    }

    private IEnumerator StopDash(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector2.zero;
    }
}
