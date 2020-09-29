using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgersDB.Models
{
    public class Client
    {
        [Key] // primary key of the cleint
        public int CID { get; set; }
        // Name of the client
        public string Name { get; set; }
        // check to see if client is a member of club
        public bool IsClubMemeber { get; set; }
    }
}
