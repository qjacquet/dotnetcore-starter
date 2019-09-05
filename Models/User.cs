using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DotnetCoreStarter.API.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public UserProfile Profile { get; set; }
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public virtual UserProfileDetails PersonnalDetails { get; set; }
        public virtual UserProfileContact Contact { get; set; }



        public class UserProfileDetails
        {
            public int Id { get; set; }
            public string Nationnality { get; set; }
            public string BirthDate { get; set; }
            public string BirthCountry { get; set; }
            public string BirthCity { get; set; }
        }
        public class UserProfileContact
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public virtual ContactAddress Address { get; set; }

            public class ContactAddress
            {
                public int Id { get; set; }
                public string Number { get; set; }
                public string Name { get; set; }
                public string Zipcode { get; set; }
                public string City { get; set; }
            }
        }
    }
}