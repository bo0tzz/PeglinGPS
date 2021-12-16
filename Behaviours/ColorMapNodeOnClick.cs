using UnityEngine;
using UnityEngine.SceneManagement;
using Worldmap;

namespace PeglinGPS.Behaviours
{
    public class ColorMapNodeOnClick : MonoBehaviour
    {
        private Camera _camera;
        private MapController _mapController;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = 0;

                foreach (var node in _mapController._nodes)
                {
                    var rend = Utils.GetSpriteRenderer(node);
                    var d = Utils.Get2DDistance(clickPosition, rend.transform.position);
                    if (d < 1)
                    {
                        rend.color = rend.color == Color.green ? Color.white : Color.green;
                        break;
                    }
                }
            }
        }

        private void OnEnable()
        {
            _camera = Camera.main;
            _mapController = GetComponentInParent<MapController>();

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