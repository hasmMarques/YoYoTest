using System.Collections.Generic;
using System.IO;
using System.Reflection;
using YoYoTest.Dtos;

namespace YoYoTest.Repository
{
	public class ShuttleRepository
	{
		#region Fields

		private List<Shuttle> _shuttles;

		#endregion

		#region Properties

		public List<Shuttle> Shuttles
		{
			get => _shuttles ??= new List<Shuttle>();
			set => _shuttles = value;
		}

		#endregion

		#region Constructor

		public ShuttleRepository()
		{
			ReadShuttles();
		}

		#endregion

		#region Private Methods

		private void ReadShuttles()
		{
			var res =
				$"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\Repository\\fitnessrating_beeptest.json";

			var text = File.ReadAllText(res);

			//used for test only
			//Shuttles = Shuttle.FromJson(
				//"[{\"AccumulatedShuttleDistance\":\"40\",\"SpeedLevel\":\"5\",\"ShuttleNo\":\"1\",\"Speed\":\"10\",\"LevelTime\":\"14.4\",\"CommulativeTime\":\"00:00:10\",\"StartTime\":\"00:00\",\"ApproxVo2Max\":\"36.74\"},{\"AccumulatedShuttleDistance\":\"80\",\"SpeedLevel\":\"9\",\"ShuttleNo\":\"1\",\"Speed\":\"12\",\"LevelTime\":\"12.5\",\"CommulativeTime\":\"00:00:10\",\"StartTime\":\"00:25\",\"ApproxVo2Max\":\"37.07\"},{\"AccumulatedShuttleDistance\":\"120\",\"SpeedLevel\":\"11\",\"ShuttleNo\":\"1\",\"Speed\":\"13\",\"LevelTime\":\"11.1\",\"CommulativeTime\":\"00:00:10\",\"StartTime\":\"00:47\",\"ApproxVo2Max\":\"37.41\"},{\"AccumulatedShuttleDistance\":\"160\",\"SpeedLevel\":\"11\",\"ShuttleNo\":\"2\",\"Speed\":\"13\",\"LevelTime\":\"11.1\",\"CommulativeTime\":\"00:00:10\",\"StartTime\":\"01:08\",\"ApproxVo2Max\":\"37.74\"},{\"AccumulatedShuttleDistance\":\"200\",\"SpeedLevel\":\"12\",\"ShuttleNo\":\"1\",\"Speed\":\"13.5\",\"LevelTime\":\"10.7\",\"CommulativeTime\":\"00:00:10\",\"StartTime\":\"01:30\",\"ApproxVo2Max\":\"38.08\"},{\"AccumulatedShuttleDistance\":\"240\",\"SpeedLevel\":\"12\",\"ShuttleNo\":\"2\",\"Speed\":\"13.5\",\"LevelTime\":\"10.7\",\"CommulativeTime\":\"00:00:10\",\"StartTime\":\"01:50\",\"ApproxVo2Max\":\"38.42\"}]");
			
			//Get data from json file
			Shuttles = Shuttle.FromJson(text);
		}

		#endregion
	}
}