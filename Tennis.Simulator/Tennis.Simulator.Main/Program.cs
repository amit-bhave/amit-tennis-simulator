using System;
using System.Configuration;
using Autofac;
using Tennis.Simulator.Models;
using Tennis.Simulator.Services;
using Tennis.Simulator.Services.InterFaces;

namespace Tennis.Simulator.Main
{
	internal class Program
	{
		private static IContainer Container { get; set; }

		private static void BuildDiContainer()
		{
			// Build IoC Container
			var builder = new ContainerBuilder();

			// Register Models
			builder.RegisterType<Game>().AsSelf();
			builder.RegisterType<Set>().AsSelf();
			builder.RegisterType<Match>().AsSelf();

			// Register Services
			builder.RegisterType<GetPointWinnerService>().As<IGetPointWinnerService>();
			builder.RegisterType<GameService>().As<IGameService>();
			builder.RegisterType<SetService>().As<ISetService>();
			builder.RegisterType<MatchService>().As<IMatchService>();

			if (ConfigurationManager.AppSettings["PrintToFile"].ToUpperInvariant() == "YES")
			{
				builder.RegisterType<FilePrinter>().As<IPrintService>();
			}
			else
			{
				builder.RegisterType<ConsolePrinter>().As<IPrintService>();
			}
			

			Container = builder.Build();
		}

		private static void Main(string[] args)
		{			

			BuildDiContainer();

			using (var scope = Container.BeginLifetimeScope())
			{
				var playerOne = new Player
				{
					Side = PlayerSide.SideOne,
					Name = "Rafa"
				};

				var playerTwo = new Player
				{
					Side = PlayerSide.SideTwo,
					Name = "Fed"
				};
				

				var matchservice = scope.Resolve<IMatchService>();
				var printService = scope.Resolve<IPrintService>();

				printService.Print("***************************************************");
				printService.Print($" Starting Tennis Match {playerOne.Name} vs {playerTwo.Name}");
				printService.Print("***************************************************");

				printService.Print("");

				var winner = matchservice.Play();

				var setcounter = 1;

				foreach (var set in matchservice.SetScores)
				{
					printService.Print("");
					printService.Print($"Starting Set # {setcounter}");
					var gamecounter = 1;
					foreach (var game in set.GameScores)
					{
						printService.Print("");
						printService.Print($"Begining Set# {setcounter} Game# {gamecounter}");
						printService.Print("love -love");
						foreach (var point in game.PointsScrore)
						{
							printService.Print(point);
						}

						printService.Print($"Set# {setcounter} Game# {gamecounter} ended. {game.Score}");
						printService.Print("");
						gamecounter++;
					}
					printService.Print($"Set# {setcounter} ended. {set.Score}");
					printService.Print("");
					setcounter++;
				}

				printService.Print("***************************************************");
				printService.Print(winner == PlayerSide.SideOne ? $"{playerOne.Name} won the match." : $"{playerTwo.Name} won the match.");
				printService.Print("***************************************************");

				Console.ReadKey();
			}

		}
	}
}
