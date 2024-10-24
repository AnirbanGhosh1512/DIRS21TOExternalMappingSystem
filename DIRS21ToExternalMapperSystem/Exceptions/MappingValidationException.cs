using System;
namespace DIRS21ToExternalMapperSystem.Exceptions
{

    public class MappingValidationException : Exception
    {
        // Optional: Property to hold the field that caused the validation failure
        public string FieldName { get; }

        // Constructor with only a message
        public MappingValidationException(string message)
            : base(message)
        {
        }

        // Constructor with message and field name (for field-specific validation failures)
        public MappingValidationException(string message, string fieldName)
            : base(message)
        {
            FieldName = fieldName;
        }

        // Constructor with message and inner exception (for exception chaining)
        public MappingValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Override ToString to include more information
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(FieldName))
            {
                return $"{Message}. Validation failed for field: {FieldName}.";
            }
            return base.ToString();
        }
    }

}

