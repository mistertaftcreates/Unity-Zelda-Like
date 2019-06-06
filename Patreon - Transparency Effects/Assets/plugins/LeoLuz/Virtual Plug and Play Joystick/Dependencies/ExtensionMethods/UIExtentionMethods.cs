using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LeoLuz.Extensions
{
    public static class UIExtensions
    {
        /// <summary>
        /// Compare if this layerNumber is in layermask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static WaitForSecondsRealtime FadeIn(this Graphic obj, float duration)
        {
            obj.StopAllCoroutines();
            //  obj.cross
            obj.StartCoroutine(FadeInCo(obj, duration));
            return new WaitForSecondsRealtime(duration);
        }


        public static IEnumerator FadeInCo(Graphic obj, float duration)
        {
            float t = 0f;
            Color bkColor = obj.color;
            Color transColor = bkColor;
            while (t < duration)
            {
                t += Time.unscaledDeltaTime;
                transColor.a = t / duration;
                obj.color = transColor;
                yield return new WaitForEndOfFrame();
            }
            transColor.a = 1f;
            obj.color = transColor;
        }

        public static WaitForSecondsRealtime FadeOut(this Graphic obj, float duration, bool disableOnExit = false)
        {
            obj.StartCoroutine(FadeOutCo(obj, duration, disableOnExit));
            return new WaitForSecondsRealtime(duration);
        }

        public static IEnumerator FadeOutCo(Graphic obj, float duration, bool disableOnExit)
        {
            float t = duration;
            Color bkColor = obj.color;
            Color transColor = bkColor;
            while (t > 0f)
            {
                t -= Time.unscaledDeltaTime;
                transColor.a = t / duration;
                obj.color = transColor;
                yield return new WaitForEndOfFrame();
            }
            transColor.a = 0f;
            if (disableOnExit)
                obj.enabled = false;

            obj.color = transColor;
        }

        public static void SetAlpha(this Graphic obj, float alpha)
        {
            Color color = obj.color;
            color.a = alpha;
            obj.color = color;
        }

        public static WaitForSecondsRealtime FadeIn(this CanvasGroup obj, float duration)
        {
            Debug.Log("FadeIn canvas");
            obj.GetComponent<MonoBehaviour>().StartCoroutine(FadeInCo(obj, duration));
            return new WaitForSecondsRealtime(duration);
        }

        public static IEnumerator FadeInCo(CanvasGroup obj, float duration)
        {
            float t = 0f;
            obj.alpha = 0f;
            while (t < duration)
            {
                t += Time.fixedUnscaledDeltaTime;
                obj.alpha = t / duration;
                yield return new WaitForEndOfFrame();
            }
            obj.alpha = 1f;
        }

        public static WaitForSecondsRealtime Pulse(this CanvasGroup obj, float size, float duration)
        {
            obj.GetComponent<MonoBehaviour>().StartCoroutine(PulseCo(obj.GetComponent<Transform>(), obj.transform.localScale, size, duration));
            return new WaitForSecondsRealtime(duration);
        }

        public static WaitForSecondsRealtime Pulse(this RectTransform obj, float PulseSize, float duration)
        {
            obj.GetComponent<MonoBehaviour>().StartCoroutine(PulseCo(obj.GetComponent<Transform>(), obj.transform.localScale, PulseSize, duration));
            return new WaitForSecondsRealtime(duration);
        }

        public static WaitForSecondsRealtime Pulse(this RectTransform obj, Vector3 startSize, float PulseSize, float duration)
        {
            obj.GetComponent<MonoBehaviour>().StartCoroutine(PulseCo(obj.GetComponent<Transform>(), startSize, PulseSize, duration));
            return new WaitForSecondsRealtime(duration);
        }

        private static IEnumerator PulseCo(Transform obj, Vector3 startSize, float size, float duration)
        {
            float t = 0f;

            while (t < duration)
            {
                if (Time.timeScale == 0f)
                    t += Time.unscaledDeltaTime;
                else
                    t += Time.deltaTime;

                obj.transform.localScale = Vector3.Lerp(startSize, startSize * size, t / duration);
                yield return new WaitForEndOfFrame();
            }

            t = duration;
            while (t > 0f)
            {
                t -= Time.unscaledDeltaTime;
                obj.transform.localScale = Vector3.Lerp(startSize, startSize * size, t / duration);
                yield return new WaitForEndOfFrame();
            }
            obj.transform.localScale = startSize;

        }

        public static WaitForSecondsRealtime SlideFromTo(this RectTransform obj, Vector2 From, Vector2 to, float duration)
        {
            obj.GetComponentInChildren<MonoBehaviour>().StartCoroutine(SlideInCo(obj, From, to, duration));
            return new WaitForSecondsRealtime(duration);
        }

        public static IEnumerator SlideInCo(RectTransform rectTransform, Vector2 From, Vector2 to, float duration)
        {
            rectTransform.anchoredPosition = From;
            float t = 0f;
            while (t < duration)
            {
                if (Time.timeScale == 0f)
                    t += Time.unscaledDeltaTime;
                else
                    t += Time.deltaTime;
                rectTransform.anchoredPosition = Vector2.Lerp(From, to, Mathf.Sin((t / duration) * Mathf.PI * 0.5f));
                yield return new WaitForEndOfFrame();
            }

            rectTransform.anchoredPosition = to;
        }



    }
}