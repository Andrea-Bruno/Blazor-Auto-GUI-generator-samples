using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ProjectTemplate.Panels
{
    /// <summary>
    /// Login panel
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// Session of current user;
        /// </summary>
        private static UISupportBlazor.Session? Session => UISupportBlazor.Session.Current();

        /// <summary>
        /// Show the login Credentials when first account not created yet (for first access)
        /// </summary>
        public static string DefaultLoginCredentials => nameof(User.Username) + "=" + DefaultUsername + "; " + nameof(User.hashedPassword) + "=" + DefaultPassword;
        private const string DefaultUsername = "user"; // Used for first access
        private const string DefaultPassword = "password"; // Used for first access

        /// <summary>
        /// Hidden DefaultUser property from GUI until the first user has been created
        /// </summary>
        internal static bool DefaultLoginCredentials_Hidden => IsLoggedIn || UsersPathFile.Exists;

        /// <summary>
        /// Access the application's control panel
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [DebuggerHidden]
        public static void UserLogin(string username, string password)
        {
            if (Session == null)
            {
                throw new Exception("Session not found");
            }
            var hashedPassword = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
            var users = DeserializeUsersListFromFile();
            if (users.Count == 0)
            {
                var defaultUser = new User() { Username = DefaultUsername, hashedPassword = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(DefaultPassword))) };
                users.Add(defaultUser); // add default user for first access
                SerializeUsersListToFile(users);
            }
            var user = users.Find(u => u.Username == username);
            if (user == null || user.hashedPassword != hashedPassword)
            {
                throw new Exception("Invalid login credentials");
            }
            Session.Val.Username = username;
            IsLoggedIn = true;
            OnLoginSuccess?.Invoke();
        }

        /// <summary>
        /// Hidden UserLogin element from GUI after login
        /// </summary>
        internal static bool UserLogin_Hidden => IsLoggedIn;

        /// <summary>
        /// Logged in status of current user
        /// </summary>
        internal static bool IsLoggedIn
        {
            get
            {
                return Session?.Val.IsLoggedIn == true;
            }
            set
            {
                if (Session != null)
                    Session.Val.IsLoggedIn = value;
            }
        }
        /// <summary>
        /// Action to be called when the user logs in successfully
        /// </summary>
        internal static Action? OnLoginSuccess { get => Session?.Val.OnLoginSuccess; set { if (Session != null) Session.Val.OnLoginSuccess = value; } }

        /// <summary>
        /// Change the password of the current user
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="repeatPassword">Repeat new password</param>
        public static void ChangePassword(string oldPassword, string newPassword, string repeatPassword)
        {
            var users = DeserializeUsersListFromFile();
            var username = Session?.Val.Username;
            var user = users.Find(u => u.Username == username);
            if (user.hashedPassword != oldPassword)
            {
                throw new Exception("Invalid password");
            }
            if (newPassword != repeatPassword)
            {
                throw new Exception("Passwords do not match");
            }
            user.hashedPassword = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(newPassword))); ;
            SerializeUsersListToFile(users);
        }

        /// <summary>
        /// Hidden ChangePasswordHidden element from GUI before login
        /// </summary>
        internal static bool ChangePassword_Hidden => !IsLoggedIn;

        /// <summary>
        /// Logout current user
        /// </summary>
        public static void Logout()
        {
            IsLoggedIn = false;
        }

        /// <summary>
        /// Hidden Logout button from UI
        /// </summary>
        internal static bool Logout_Hidden => !IsLoggedIn;


        // Function to serialize a list of Users to a file
        private static void SerializeUsersListToFile(List<User> users)
        {
            lock (UsersPathFile)
            {
                // Check if the directory exists; if not, create it
                if (UsersPathFile?.Directory?.Exists == false)
                {
                    UsersPathFile.Directory.Create();
                }

                // Serialize the list and write it to the file
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(UsersPathFile.FullName, json);
            }
        }

        // Function to deserialize a list of Users from a file
        private static List<User> DeserializeUsersListFromFile()
        {
            lock (UsersPathFile)
            {
                // Check if the file exists; throw an exception if not
                if (!UsersPathFile.Exists)
                {
                    return [];
                }
                // Read the content of the file and deserialize it
                string json = File.ReadAllText(UsersPathFile.FullName);
                return JsonSerializer.Deserialize<List<User>>(json);
            }
        }
        private static readonly FileInfo UsersPathFile = new(Path.Combine(AppData, "users.ligin"));
        private static string AppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


        public class User
        {
            public string Username { get; set; }
            public string hashedPassword { get; set; }
        }
    }
}
