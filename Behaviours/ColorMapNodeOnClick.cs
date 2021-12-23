using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PeglinGPS.Behaviours
{
    public class ColorMapNodeOnClick : MonoBehaviour
    {
        private Camera _camera;

        private List<MapNodeColorSwapper> swappers;

        public void Init(List<MapNodeColorSwapper> s)
        {
            swappers = s;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = 0;

                swappers.Find(s => s.Get2DDistance(clickPosition) < 1)?.SwapColor();
            }
        }

        private void OnEnable()
        {
            _camera = Camera.main;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _camera = Camera.main;
        }
    }
}