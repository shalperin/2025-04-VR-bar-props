using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Q
    {
        // eg: ScaleY(LiquidScaleOrigin, minYScale, drainSpeed); (to drain a cup)
        // or ScaleY(LiquidScaleOrigin, maxYScale, drainSpeed); (to fill a cup)
        public static void ScaleY(GameObject o, float targetY, float speed)
        {
            Vector3 currentScale = o.transform.localScale;
            float newY = Mathf.MoveTowards(currentScale.y, targetY, speed * Time.deltaTime);
            o.transform.localScale = new Vector3(currentScale.x, newY, currentScale.z);
        }
        public static IEnumerator AnimateYScaleTo(GameObject o, float targetY, float speed)
        {
            while (Mathf.Abs(o.transform.localScale.y - targetY) > 0.01f)
            {
                float newY = Mathf.MoveTowards(o.transform.localScale.y, targetY, speed * Time.deltaTime);
                o.transform.localScale = new Vector3(o.transform.localScale.x, newY, o.transform.localScale.z);
                yield return null;
            }
        }
        
        public static bool IsTiltedPastHorizontal(GameObject o)
        {
            Vector3 direction = o.transform.up;
            float dot = Vector3.Dot(direction, Vector3.down);
            if (dot > 0f) // 0 would be horizontal
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}