using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class User
  {
    public int UserId { get; set; }

    public string Bio { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public int Host { get; set; } // int as bool

    public string UserName { get; set; }

    public int Zip { get; set; }

    //public virtual ICollection<Favorite> Favorite { get; set ; }

    public User() {
      Host = 0;
    }

  }
}