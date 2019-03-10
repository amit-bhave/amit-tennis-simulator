using System;
using Tennis.Simulator.Services.InterFaces;

namespace Tennis.Simulator.Services
{
	public class ConsolePrinter : IPrintService
	{
		public void Print(string message)
		{
			Console.WriteLine(message);
		}
	}
}
