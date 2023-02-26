


namespace Utility
{
    public static class HelperMessage
    {
        #region Response Result
        public static class ResponceResult
        {
            public static string OK = "OK";
            public static string WARNING = "WARNING";
            public static string ERROR = "ERROR";
            public static string DUPLICATE = "DUPLICATE";

        }
        #endregion

        #region By Object Message
        public static string DuplicateByObject = "{0} already exists.";
        public static string RequiredByObject = "{0} field is required.";
        public static string NotFoundByObject = "No {0} found.";
        #endregion

        #region Common Message
        public static string SaveSuccessfully = "Record saved successfully.";
        public static string DeleteSuccessfully = "Record deleted successfully.";
        public static string DeleteRecordsDependency = "Record are used in another table.";
        public static string NoRecordFound = "No Record found.";
        public static string RecordExist = "Record already exist.";
        #endregion

    }
}