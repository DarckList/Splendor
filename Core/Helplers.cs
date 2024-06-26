using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;
internal class Helplers
{
	internal static void RenderCollenction<T>(IEnumerable<T> collection, ConsoleColor color) where T : IRendable
	{
		var previewColor = Console.ForegroundColor;
		Console.ForegroundColor = color;
		foreach (var item in collection)
		{
			item.Render();
		}
		Console.ForegroundColor = previewColor;
	}
}
