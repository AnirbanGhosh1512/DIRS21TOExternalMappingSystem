using System;
namespace DIRS21ToExternalMapperSystem.Exceptions
{

    public class InvalidMappingException : Exception
    {
        // Constructor with just a message
        public InvalidMappingException(string message)
            : base(message)
        {
            SourceType = null;
            TargetType = null;
        }

        // Constructor with message and inner exception (for chaining exceptions)
        public InvalidMappingException(string message, Exception innerException)
            : base(message, innerException)
        {
            SourceType = null;
            TargetType = null;
        }

        // Additional properties for source and target types
        public string? SourceType { get; }
        public string? TargetType { get; }

        // Constructor with message and source/target type for better context
        public InvalidMappingException(string message, string sourceType, string targetType)
            : base(message)
        {
            SourceType = sourceType;
            TargetType = targetType;
        }

        // Override the ToString method to include additional information
        public override string ToString()
        {
            return $"{Message}. Mapping from {SourceType} to {TargetType} failed.";
        }
    }

}

