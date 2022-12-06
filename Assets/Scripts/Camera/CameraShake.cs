using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = this.transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            this.transform.localPosition = new Vector3(x+ originalPos.x, originalPos.y, y + originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        this.transform.localPosition = originalPos;
      //  yield return null;
        //yield return true;
    }
}
