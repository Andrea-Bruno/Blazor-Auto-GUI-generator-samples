using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace MultiPanels.Panels
{
    /// <summary>
    /// Demonstration of the OnSelect event on arrays
    /// </summary>
    public class OnSelect
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public OnSelect()
        {
            Users = [new User("Andrea", "Bruno", 52), new User("Max", "Capone", 32), new User("Liam", "Smith", 32)];
        }

        /// <summary>
        /// Add a new user between the ages of 18 and 65
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <param name="surname">Surname of user</param>
        /// <param name="age">Age must be between 18 and 65</param>
        [DebuggerHidden]
        public void AddUser(string name, string surname, int age)
        {            
            var users = Users.ToList();
            users.Add(new User(name, surname, age));
            Users = users.ToArray();
        }


        /// <summary>
        /// Users list
        /// </summary>
        public User[] Users { get; set; } = [];


        /// <summary>
        /// Select a user from list
        /// </summary>
        public string[] UsersList
        {
            get
            {
                List<string> list = [];
                Users.ToList().ForEach(user => list.Add(string.Join(user.Name, user.Surname)));
                return [.. list];
            }
        }

        /// <summary>
        /// Event that fires when the user selects an element of UsersList in the GUI.
        /// This happens because we have created a function with an int parameter called "OnSelect" + the name of the array for which we want to create the event.
        /// </summary>
        /// <param name="item"></param>
        internal void OnSelectUsersList(int item)
        {
            SelectedUser = Users[item];
        }

        /// <summary>
        /// Selected user
        /// </summary>
        public User? SelectedUser { get; private set; }

    }

    /// <summary>
    /// Demonstration of the OnSelect event on arrays
    /// </summary>
    public class User
    {
        internal User(string name, string surname, int age)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(name);
            if (age < 18 || age > 52)
                throw new Exception("Age must be between 18 and 65!");
            Name = name;
            Surname = surname;
            Age = age;
        }
        /// <summary>
        /// Name of user
        /// </summary>
        public string? Name { get; private set; }
        /// <summary>
        /// Surname of user;
        /// </summary>
        public string? Surname { get; private set; }
        /// <summary>
        /// Age of user;
        /// </summary>
        public int Age { get; private set; }
    }


}
