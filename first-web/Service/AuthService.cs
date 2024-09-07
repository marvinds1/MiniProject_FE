using System;

namespace first_web.Service
{
    public class AuthService
    {
        private bool _isAuthenticated;
        private string _email;

        public bool IsAuthenticated()
        {
            return _isAuthenticated;
        }

        public void Login(string email, string password)
        {
            // Implement your authentication logic here
            // For example, validate against a database or an API
            _isAuthenticated = true;
            _email = email;
        }

        public void Logout()
        {
            _isAuthenticated = false;
            _email = null;
        }

        public string GetEmail()
        {
            return _email;
        }
    }
}