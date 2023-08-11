using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;

namespace Croxxing.Boot
{
    public class SceneLauncher<TLauncher, TView> : BaseLauncher<TLauncher, TView>
        where TLauncher : SceneLauncher<TLauncher, TView>
        where TView : BaseSceneView
    {
        public override string SceneName => throw new System.NotImplementedException();

        protected override ILoad GetLoader()
        {
            throw new System.NotImplementedException();
        }

        protected override IMain GetMain()
        {
            throw new System.NotImplementedException();
        }

        protected override IConnector[] GetSceneConnectors()
        {
            throw new System.NotImplementedException();
        }

        protected override IController[] GetSceneDependencies()
        {
            throw new System.NotImplementedException();
        }

        protected override ISplash GetSplash()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator InitSceneObject()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator LaunchScene()
        {
            throw new System.NotImplementedException();
        }
    }
}