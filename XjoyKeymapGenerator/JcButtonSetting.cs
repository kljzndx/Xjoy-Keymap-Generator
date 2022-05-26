using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XjoyKeymapGenerator
{
    public class JcButtonSetting : INotifyPropertyChanged
    {
        private KeyValuePair<string, string> _xboxKey;

        public JcButtonSetting(KeyValuePair<string, string> jcKey, KeyValuePair<string, string> xboxKey)
        {
            JcKey = jcKey;
            _xboxKey = xboxKey;
        }

        public KeyValuePair<string, string> JcKey { get; }
        public KeyValuePair<string, string> XboxKey
        {
            get { return _xboxKey; }
            set 
            { 
                _xboxKey = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(XboxKey)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToYaml()
        {
            return $"{JcKey.Key}: {XboxKey.Key}";
        }
    }
}
