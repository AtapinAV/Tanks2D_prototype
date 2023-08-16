using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class SpaunBot : MonoBehaviour
    {
        private bool _canSpaun = true;

        [SerializeField, Range(1f, 100f)]
        private float _timeSpaun = 5f;
        [SerializeField]
        private BotInputComponent _prefabBot;

        private void Update()
        {
            OnSpaun();
        }

        private void OnSpaun()
        {
            if (!_canSpaun) return;

            var bot = Instantiate(_prefabBot, transform.position, transform.rotation);
            bot.BotParams(transform.eulerAngles.ConvertRotationFromType());

            StartCoroutine(OnTimeSpaun());
        }

        private IEnumerator OnTimeSpaun()
        {
            _canSpaun = false;
            yield return new WaitForSeconds(_timeSpaun);
            _canSpaun = true;
        }
    }

}

