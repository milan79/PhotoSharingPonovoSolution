//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoSharingPonovo1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Comment
    {
        //[Key]
        public int CommentID { get; set; }
        public int PhotoID { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public virtual Photo Photos { get; set; }
    }
}