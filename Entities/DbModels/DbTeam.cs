﻿namespace Entities.DbModels
{
	public class DbTeam
	{
		public int id { get; set; }
		public string locationName { get; set; } = string.Empty;
		public string teamName { get; set; } = string.Empty;
		public string logoUri { get; set; } = string.Empty;
    }
}