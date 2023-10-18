using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Credits.GameCredits
{
    public interface IGameCreditsModel: IBaseModel
    {
        public string Title { get; }
        public string Body { get; }
    }
}