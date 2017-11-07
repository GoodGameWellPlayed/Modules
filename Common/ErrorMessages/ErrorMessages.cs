namespace Components.Common
{
    public static class ErrorMessages
    {
        public static string ArgumentsTypeExpectedMessage(string currentTypeName, 
            string expectedArgumentsTypeName)
        {
            return "Arguments sent to the class " + currentTypeName + " should be of type " + expectedArgumentsTypeName;
        }
    }
}

