using FestivalManager.Core.Contracts;
using FestivalManager.Core.IO;
using FestivalManager.Core.IO.Contracts;
using FestivalManager.Entities.Contracts;

namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Entities;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new Reader();
		    IWriter writer = new Writer();

			IStage stage = new Stage();
			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

			IEngine engine = new Engine(festivalController, setController, reader, writer);

			engine.Run();
		}
	}
}