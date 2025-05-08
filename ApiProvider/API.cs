namespace ApiProvider
{
    /// <summary>
    /// API for managing records in a CSV file
    /// </summary>
    public static class API
    {
        private static readonly string CsvFilePath = "records.csv";

        /// <summary>
        /// Add a new record to the database
        /// </summary>
        /// <param name="nameAndSurname">First and last name for the item to add</param>
        /// <param name="email">Email address referring to the person</param>
        public static void AddNewRecord(string nameAndSurname, string email)
        {
            var records = Records;
            records.Add((nameAndSurname, email));
            Records = records; // Save and update
        }

        /// <summary>
        /// Get the electronic mail address associated with a name and surname
        /// </summary>
        /// <param name="nameAndSurname">Name and surname of the person whose email address you want to obtain</param>
        /// <returns>Email address</returns>
        public static string GetEmail(string nameAndSurname)
        {
            return Records.FirstOrDefault(x => x.Item1 == nameAndSurname).Item2;
        }

        /// <summary>
        /// Delete a record from the database
        /// </summary>
        /// <param name="nameAndSurname">Name and surname referring to the record to be deleted</param>
        /// <returns>True if the operation was successful</returns>
        public static bool DeleteRecord(string nameAndSurname)
        {
            var records = Records;
            bool removed = records.RemoveAll(x => x.Item1 == nameAndSurname) > 0;
            if (removed)
            {
                Records = records; // Save and update
            }
            return removed;
        }

        /// <summary>
        /// Records stored in a CSV file
        /// </summary>
        internal static List<(string, string)> Records
        {
            get
            {
                if (!File.Exists(CsvFilePath))
                {
                    return new List<(string, string)>();
                }

                return File.ReadAllLines(CsvFilePath)
                           .Where(line => !string.IsNullOrWhiteSpace(line))
                           .Select(line =>
                           {
                               var parts = line.Split(',');
                               return (parts[0], parts[1]);
                           })
                           .ToList();
            }
            set
            {
                var lines = value.Select(record => $"{record.Item1},{record.Item2}");
                File.WriteAllLines(CsvFilePath, lines);
            }
        }
    }
}
