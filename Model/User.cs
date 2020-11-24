namespace CarRentalService
{
    public class User
    {
        private string _username;
        private string _password;
        private Role _role;

        public User(string username, string password, Role role)
        {
            _username = username;
            _password = password;
            _role = role;
        }

        public string GetUserName()
        {
            return _username;
        }
        
        public string GetPassword()
        {
            return _password;
        }
    }
}