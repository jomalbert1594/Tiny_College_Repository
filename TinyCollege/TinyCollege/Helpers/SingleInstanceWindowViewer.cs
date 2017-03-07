using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewGoodReading.Helpers
{
    public class SingleInstanceWindowViewer<T> where T: System.Windows.Window, new()
    {
        private bool _isWindowActive;
        private T _window;
        public T Instance { get; private set; }

        public void Close()
        {
            _window?.Close();
        }

        public void Show()
        {
            if (!_isWindowActive)
            {
                _window = new T
                {
                    Topmost = false,
                    ShowActivated = true
                };
                Instance = _window;
                _window.Closed += OnClosed;
            }
            _window?.Show();
            _window?.Activate();
            _isWindowActive = true;
        }

        public void OnClosed(object sender, EventArgs e)
        {
            _isWindowActive = false;
            _window.Closed -= OnClosed;
        }
    }
}
