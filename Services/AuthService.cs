using System;
using EverpineHotelManagement.Data;
using EverpineHotelManagement.Models;

namespace EverpineHotelManagement.Services
{
    public class AuthService
    {
        private readonly UserRepository _users;
        private int _failedAttempts;
        private DateTime? _blockedUntil;

        public AuthService(UserRepository users)
        {
            _users = users;
        }

        public User Login(string login, string password)
        {
            if (_blockedUntil.HasValue)
            {
                if (DateTime.Now < _blockedUntil.Value)
                {
                    var remaining = (_blockedUntil.Value - DateTime.Now).Seconds;
                    throw new InvalidOperationException($"Вход заблокирован. Попробуйте через {remaining} сек.");
                }
                else
                {
                    _blockedUntil = null;
                    _failedAttempts = 0;
                }
            }

            User user = _users.FindByLogin(login);

            if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordSalt, user.PasswordHash))
            {
                RegisterFailure(login, "Неверный логин или пароль");

                if (_blockedUntil.HasValue && DateTime.Now < _blockedUntil.Value)
                {
                    throw new InvalidOperationException("Неверный пароль. Вход заблокирован на 30 секунд!");
                }

                throw new InvalidOperationException("Неверный логин или пароль.");
            }

            if (!user.IsActive)
            {
                throw new InvalidOperationException("Пользователь деактивирован.");
            }

            _failedAttempts = 0;
            _blockedUntil = null;
            _users.AddLoginAttempt(login, true, "Успешный вход");
            return user;
        }

        private void RegisterFailure(string login, string message)
        {
            _failedAttempts++;
            _users.AddLoginAttempt(login, false, message);

            if (_failedAttempts >= 3)
            {
                _blockedUntil = DateTime.Now.AddSeconds(30);
                _failedAttempts = 0;
            }
        }
    }
}