using System.Collections.Generic;
using YoYoTest.Dtos;

namespace YoYoTest.Repository
{
	public class ParticipantRepository
	{
		#region Fields

		public List<Participant> Participants = new List<Participant>
		{
			new Participant {Id = 1, Name = "Peter"},
			new Participant {Id = 2, Name = "John"},
			new Participant {Id = 3, Name = "Jane"},
		};

		#endregion
	}
}