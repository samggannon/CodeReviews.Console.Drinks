using ConsoleTableExt;

namespace Drinks.samggannon;

internal class TableVisualization
{
	public static void ShowTable<T>(List<T> tableData, string title) where T : class
	{
		
		if (tableData == null)
		{
			Console.WriteLine("trouble loading data...");
			return;
		}

		if (title == null)
		{
			title = "---";
			Console.WriteLine("\n\n");
		}

		ConsoleTableBuilder
			.From(tableData)
			.WithColumn(title)
			.WithFormat(ConsoleTableBuilderFormat.Alternative)
			.ExportAndWriteLine(TableAligntment.Center);
		Console.WriteLine("\n\n");

	}
}
