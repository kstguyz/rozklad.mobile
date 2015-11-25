namespace Rozklad.Mobile.Core.Configuration
{
	public static class Parameters
	{
		public const string Limit = "limit";
		public const string Offset = "offset";
		public const string Search = "search";

		public static class Room
		{
			public const string Name = "name";
			public const string Building = "building";
		}

		public static class Group
		{
			public const string Name = "name";
			public const string GroupType = "type";
			public const string GroupDegree = "okr";
		}

		public static class Teacher
		{
			public const string LastName = "last_name";
			public const string FirstName = "last_name";
			public const string MiddleName = "middle_name";
			public const string Degree = "degree";
		}

		public static class Lesson
		{
			public const string Number = "number";
			public const string Day = "day";
			public const string Week = "week";
			public const string Type = "type";
			public const string Discipline = "discipline";
			public const string Groups = "groups";
			public const string Teachers = "teachers";
			public const string Rooms = "rooms";
		}
	}
}
