namespace InvoicesInCloudBackEnd.Panels
{
    /// <summary>
    /// Your name in a QR code
    /// </summary>
    public class MatrixCode
    {
        /// <summary>
        /// Your name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Your surname
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Your full name in the QR code is:
        /// </summary>
        public string QR => Name + " " + Surname;
    }
}
