using System.Collections.Generic;

namespace Croxxing.Module.Global.ControlsData
{
    [System.Serializable]
    public class Binding
    {
        public string action;
        public string id;
        public string path;
        public string interactions;
        public string processors;
    }

    [System.Serializable]
    public class Controls
    {
        public List<Binding> bindings;
    }
}
