using System;
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
				
				Console.WriteLine(" Starting Tennis Match..");

				var matchservice = scope.Resolve<IMatchService>();

				var winner = matchservice.Play();

				var setcounter = 1;

				foreach (var set in matchservice.SetScores)
				{
					Console.WriteLine($"Starting Set # {setcounter}");
					var gamecounter = 1;
					foreach (var game in set.GameScores)
					{
						Console.WriteLine($"Begining Set# {setcounter} Game# {gamecounter}");
						Console.WriteLine("love -love");
						foreach (var point in game.PointsScrore)
						{
							Console.WriteLine(point);
						}

						Console.WriteLine($"Set# {setcounter} Game# {gamecounter} ended. {game.Score}");
						gamecounter++;
					}
					Console.WriteLine($"Set# {setcounter} ended. {set.Score}");
					setcounter++;
				}

				Console.WriteLine(winner == PlayerSide.SideOne ? "Side 1" : "Side 2" + " won the match.");
				Console.ReadKey();
			}

		}
	}
}
