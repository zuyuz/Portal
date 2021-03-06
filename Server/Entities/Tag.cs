﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Server.Entities
{
    public class Tag : IEntityBase
    {
        [Key]
        public int Id
        { get; set; }

        public string Name
        { get; set; }

        public string UrlSlug
        { get; set; }

        public string Description
        { get; set; }

        public IList<Post> Posts
        { get; set; }
    }
}
