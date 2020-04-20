using System.Collections;
using Lib;
using UnityEngine;
using UnityEngine.UI;

namespace TankProject
{
    public sealed class HealthBar : MonoBehaviour
    {
        private enum VisionMode
        {
            Always,
            AutoHide
        }

        [SerializeField] private VisionMode visionMode = VisionMode.Always;
        [SerializeField] private Health health;
        [SerializeField] private Image background;
        [SerializeField] private Image mainHealthIndicator;
        [SerializeField] private Image secondHealthIndicator;
        [SerializeField] private float changeTime = 0.2f;
        [SerializeField] private float delayBetweenIndicators = 0.2f;
        
        private float _maxHealth;
        
        private Coroutine _mainSlideCoroutine;
        private Coroutine _secondSlideCoroutine;
        
        private Wait _secondIndicatorDelay;

        private void Awake()
        {
            _maxHealth = health.MaxHealth;
            _secondIndicatorDelay = this.WaitForSeconds(delayBetweenIndicators);
        }

        private void OnEnable()
        {
            OnChangeHealth(health.CurrentHealth);
            health.OnHealthChanged += OnChangeHealth;
        }

        private void OnDisable()
        {
            health.OnHealthChanged -= OnChangeHealth;
        }

        private void Start()
        {
            Hide(visionMode == VisionMode.AutoHide);
        }

        private void OnChangeHealth(float newHealth)
        {
            float fill = newHealth / _maxHealth;
            Hide(visionMode == VisionMode.AutoHide && !(fill < 1f));
            UpdateBar(fill);
        }

        private void Hide(bool hide)
        {
            background.enabled = !hide;
            mainHealthIndicator.enabled = !hide;
            secondHealthIndicator.enabled = !hide;
        }

        private void UpdateBar(float fill)
        {
            SlideIndicator(ref _mainSlideCoroutine, mainHealthIndicator, fill);
            
            _secondIndicatorDelay.SetAction(() => SlideIndicator(ref _secondSlideCoroutine, secondHealthIndicator, fill));
            _secondIndicatorDelay.Start();
        }
        
        private void SlideIndicator(ref Coroutine coroutine, Image indicator, float fill)
        {
            if(coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(SlidingIndicator(indicator, fill));
        }

        private IEnumerator SlidingIndicator(Image target, float fill)
        {
            fill = Mathf.Clamp01(fill);
            float currentFill = target.fillAmount;
            float speed = (fill - currentFill) / changeTime;
            float timer = 0;
            while (timer < changeTime)
            {
                target.fillAmount += speed * Time.deltaTime;
                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}
