using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YoYoTest.Dtos;
using YoYoTest.Repository;

namespace YoYoTest.Services
{
	public class ShuttleService
	{
		#region Fields

		private static ShuttleRepository _shuttleRepository;

		#endregion

		#region Constructor

		public ShuttleService(ShuttleRepository shuttleRepository)
		{
			if (shuttleRepository == null) throw new ArgumentNullException(nameof(shuttleRepository));
			_shuttleRepository = shuttleRepository;
		}

		#endregion

		#region Public Methods

		public static Task<List<Shuttle>> GetShuttlesAsync()
		{
			return Task.FromResult(_shuttleRepository.Shuttles);
		}

		#endregion
	}
}