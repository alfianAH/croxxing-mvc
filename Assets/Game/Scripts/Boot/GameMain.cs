using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Croxxing.Module.Global.ControlsData;
using Croxxing.Module.Global.GameAudioData;
using Croxxing.Module.Global.ProgressData;

namespace Croxxing.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return new IConnector[]
            {
                new ControlsConnector(),
                new GameAudioDataConnector(),
            };
        }

        protected override IController[] GetDependencies()
        {
            return new IController[] 
            {
                new ControlsController(),
                new ProgressDataController(),
                new GameAudioDataController(),
            };
        }

        protected override IEnumerator StartInit()
        {
            yield return null;
        }
    }
}