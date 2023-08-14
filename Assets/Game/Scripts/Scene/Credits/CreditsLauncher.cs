using Croxxing.Boot;
using Croxxing.Utility;

namespace Croxxing.Scene.Credits
{
    public class CreditsLauncher : SceneLauncher<CreditsLauncher, CreditsView>
    {
        public override string SceneName => GameScenes.CREDITS;
    }
}
