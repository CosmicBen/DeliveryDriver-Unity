using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;
    [SerializeField] private float destroyDelay = 0.5f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Color32 hasPackageColor = Color.white;
    [SerializeField] Color32 noPackageColor = Color.white;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked up.");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        else if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package delivered.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
