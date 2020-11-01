using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoYoTest.Dtos;
using YoYoTest.Repository;

namespace YoYoTest.Services
{
	public class ParticipantService
	{
		#region Fields

		private static ParticipantRepository _participantRepository;

		#endregion

		#region Constructor

		public ParticipantService(ParticipantRepository participantRepository)
		{
			if (participantRepository == null) throw new ArgumentNullException(nameof(participantRepository));
			_participantRepository = participantRepository;
		}

		#endregion

		#region Public Methods

		public static Task<List<Participant>> GetParticipantsAsync()
		{
			return Task.FromResult(_participantRepository.Participants);
		}

		#endregion
	}
}