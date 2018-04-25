namespace Soccernation.Models.Enums
{
	public static class EntityStatus
    {
        public const string Active = "Active";
        public const string Deleted = "Deleted";
        public const string Banned = "Banned";
        public const string Inactive = "Inactive";
        public const string Blocked = "Blocked";
    }

	public static class FixtureStatus
	{
		public const string Pending = "PEN";
		public const string Happening = "HAP";
		public const string Finished = "FIN";

        public const string PendingDescription = "Pending";
        public const string HappeningDescription = "Happening";
        public const string FinishedDescription = "Finished";

        public static string GetDescriptionByCode(string code)
        {
            var result = string.Empty;
            switch (code)
            {
                case Pending: result = PendingDescription;
                    break;
                case Happening:
                    result = HappeningDescription;
                    break;
                case Finished:
                    result = FinishedDescription;
                    break;
                default:
                    return string.Empty;
            }
            return result;
        }
    }
}
