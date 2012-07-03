using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MudHook.Core
{
    public class MetadataModel
    {
        [Required]
        [Display(Name = "Site name")]
        public string SiteName { get; set; }
        [Display(Name = "Site description")]
        public string SiteDescription { get; set; }
        [Display(Name = "Home Page")]
        public string HomePage { get; set; }
        [Display(Name = "Posts Page")]
        public string PostsPage { get; set; }
        [Display(Name = "Posts per page")]
        public int PostsPerPage { get; set; }
        [Display(Name = "Current theme")]
        public string Theme { get; set; }
        [Display(Name = "Auto publish comments")]
        public bool AutoPublishComments { get; set; }
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
    }
}
