using eEscola.Domain.Entities.Base;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eEscola.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario() { }
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;

            AddNotifications(new Contract<Usuario>()
                .Requires()
                .IsNotNullOrWhiteSpace(Username, nameof(Username), $"O campo {nameof(Username)} deve ser preenchido")
                .IsNotNullOrWhiteSpace(Password, nameof(Password), $"O campo {nameof(Password)} deve ser preenchido")
            );
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
