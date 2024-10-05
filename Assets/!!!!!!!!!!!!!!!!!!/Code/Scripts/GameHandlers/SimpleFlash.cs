using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    //TODO: this has to be a normal class

    public class SimpleFlash : MonoBehaviour
    {
        public Material flashMaterial;
        public float duration;

        private SpriteRenderer spriteRenderer;
        private Material originalMaterial;
        private Coroutine flashRoutine;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            originalMaterial = spriteRenderer.material;
        }


        public void Flash()
        {
            // If the flashRoutine is not null, then it is currently running.
            if (flashRoutine != null)
            {
                // In this case, we should stop it first.
                // Multiple FlashRoutines the same time would cause bugs.
                StopCoroutine(flashRoutine);
            }

            // Start the Coroutine, and store the reference for it.
            flashRoutine = StartCoroutine(FlashRoutine());
        }

        private IEnumerator FlashRoutine()
        {
            // Swap to the flashMaterial.
            spriteRenderer.material = flashMaterial;

            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(duration);

            // After the pause, swap back to the original material.
            spriteRenderer.material = originalMaterial;

            // Set the routine to null, signaling that it's finished.
            flashRoutine = null;
        }
    }
}