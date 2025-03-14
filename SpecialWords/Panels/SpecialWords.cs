namespace SpecialWords.Panels
{
    /// <summary>
    /// A class containing a collection of static properties to represent special information and configurations.
    /// Notes on this example project: The code file that is rendered in the panel, whose entry appears in the side menu, is the one in the project folder called Panels. The example demonstrates several properties with one of the special words in the description. As you can see, the display of the property on the page takes on appropriate characteristics based on the context, thanks to the presence of the special word.
    /// You can add other classes in the Panels folder to add new menu items and panels in the GUI that is the web page.
    /// As you can see this page is static, which means that the fields entered here are for general use (not related to the user's browsing session). Static classes therefore keep the values ​​set in the GUI even after a reboot, this saves a lot of time as there is no need to write save routines.
    /// </summary>
    static public class SpecialWords
    {
        /// <summary>
        /// Represents the date of birth or the origin of an event. 
        /// Can be used to track historical timelines or other purposes.
        /// </summary>
        static public DateTime DateOfBird { get; set; }

        /// <summary>
        /// Represents the time of arrival. 
        /// </summary>
        static public DateTime Arrival { get; set; }

        /// <summary>
        /// Stores a password. 
        /// This field can be used for managing secure access or authentication within an application.
        /// </summary>
        static public string? Password { get; set; }

        /// <summary>
        /// Background color
        /// </summary>
        static public string? BackgroundColor { get; set; } = "#F5F5F5";

        /// <summary>
        /// Left sidebar color 
        /// </summary>
        static public string? SidebarColor { get; set; } = "#0102EE";

        /// <summary>
        /// Stores an email address, useful for communication or authentication. 
        /// Must follow the standard email format.
        /// </summary>
        static public string? Email { get; set; }

        /// <summary>
        /// Stores a phone number, formatted to include the international code, 
        /// useful for contact and communication.
        /// </summary>
        static public string? PhoneNumber { get; set; }

        /// <summary>
        /// Contains a QR code identifier based on the class name. 
        /// This property is immutable and can be used for unique identification or quick sharing.
        /// </summary>
        static public string? QrCode { get; } = nameof(SpecialWords);
    }

}
