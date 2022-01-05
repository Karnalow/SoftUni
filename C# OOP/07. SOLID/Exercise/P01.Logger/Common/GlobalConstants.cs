using System.Runtime.Serialization;

namespace P01.Logger.Common
{
    public static class GlobalConstants
    {
        public const string DateTimeFormat = "M/dd/yyyy h:mm:ss tt";

        public const string InvaidLevelType = "Invalid threshold level provided!";

        public const string IvalidLayoutType = "Invalid layout type provided!";

        public const string InvalidAppenderType = "Invalid appender type provided!";

        public const string InvalidDateTimeFormat = "Invalid DateTime format!";

        public static string InvalidLevelType { get; internal set; }
        public static SerializationInfo InvalidLayoutType { get; internal set; }
    }
}
