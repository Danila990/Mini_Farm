using UnityEngine;

namespace MiniFarm
{
    public class FPSCounter : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool _showFPS = true;
        [SerializeField] private float _updateRate = 0.5f;

        [Header("Appearance")]
        [SerializeField] private int _fontSize = 35;
        [SerializeField] private Color _normalColor = Color.green;
        [SerializeField] private Color _warningColor = Color.yellow;
        [SerializeField] private Color _criticalColor = Color.red;
        [SerializeField] private int _warningThreshold = 45;
        [SerializeField] private int _criticalThreshold = 20;

        private float _deltaTime = 0.0f;
        private float _updateTimer = 0.0f;
        private float _fps = 0.0f;
        private float _minFps = Mathf.Infinity;
        private float _maxFps = 0.0f;

        private GUIStyle _style;
        private Rect _rect;

        private void Start()
        {
            InitializeStyle();
        }

        private void InitializeStyle()
        {
            _style = new GUIStyle();
            _style.alignment = TextAnchor.LowerRight;
            _style.fontSize = _fontSize;
            _style.fontStyle = FontStyle.Bold;
            _style.normal.textColor = _normalColor;

            int padding = 75;
            _rect = new Rect(padding, padding, Screen.width - padding * 2, Screen.height - padding * 2);
        }

        private void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;

            _updateTimer += Time.unscaledDeltaTime;
            if (_updateTimer >= _updateRate)
            {
                _fps = 1.0f / _deltaTime;
                UpdateMinMaxFps();
                _updateTimer = 0.0f;
            }
        }

        private void UpdateMinMaxFps()
        {
            if (_fps < _minFps) 
                _minFps = _fps;

            if (_fps > _maxFps) 
                _maxFps = _fps;
        }

        private void OnGUI()
        {
            if (!_showFPS) return;

            if (_fps < _criticalThreshold)
                _style.normal.textColor = _criticalColor;
            else if (_fps < _warningThreshold)
                _style.normal.textColor = _warningColor;
            else
                _style.normal.textColor = _normalColor;

            GUI.Label(_rect, GetFpsText(), _style);
        }

        private string GetFpsText()
        {
            return $"FPS: {_fps:0.}\nMin: {_minFps:0.}\nMax: {_maxFps:0.}";
        }

        public void ToggleVisibility()
        {
            _showFPS = !_showFPS;
        }

        public void SetVisibility(bool visible)
        {
            _showFPS = visible;
        }

        public float GetCurrentFPS()
        {
            return _fps;
        }
    }
}