using System;
using System.Collections.Generic;

namespace Back_end.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }

        public string UserNick { get; set; }
        public string Region { get; set; }
        public string ProfileImage { get; set; }
        public string UserQuote { get; set; }
        public string Instagram { get; set; }
        public string KIK { get; set; }
        public string WhatsApp { get; set; }
        public string Twitter { get; set; }
        public string SnapChat { get; set; }
        public string PostCount { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

    public class AppUserInfoViewModel
    {
        public string UserID { get; set; }
        public string UserNick { get; set; }
        public string Region { get; set; }
        public string ProfileImage { get; set; }
        public string UserQuote { get; set; }
        public string Instagram { get; set; }
        public string KIK { get; set; }
        public string WhatsApp { get; set; }
        public string Twitter { get; set; }
        public string SnapChat { get; set; }
        public string PostCount { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

}
