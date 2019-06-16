using System.Collections.Generic;

namespace ASPDotNetCoreTodo.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set; }
    }
}