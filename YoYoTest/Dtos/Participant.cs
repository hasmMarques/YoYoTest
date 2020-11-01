using System.Collections.Generic;

namespace YoYoTest.Dtos
{
	public class Participant
	{
		#region Fields

		private List<Shuttle> _accomplishedShuttles;

		#endregion

		#region Properties

		public int Id { get; set; }
		public string Name { get; set; }

		public bool Disqualified { get; set; }

		public bool Warned { get; set; }

		public bool Finished { get; set; }

		public Shuttle AccomplishedShuttle { get; set; }

		public List<Shuttle> AccomplishedShuttles
		{
			get => _accomplishedShuttles ??= new List<Shuttle>();
			set => _accomplishedShuttles = value;
		}

		#endregion
	}
}