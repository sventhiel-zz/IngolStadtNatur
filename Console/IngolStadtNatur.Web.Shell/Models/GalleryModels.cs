using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using IngolStadtNatur.Entities.NH.Media;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class GalleryItemModel
    {
        public string Path { get; set; }

        public static GalleryItemModel Convert(Shot shot)
        {
            return new GalleryItemModel()
            {
                Path = System.IO.Path.Combine(ConfigurationManager.AppSettings["Shots"], shot.Name)
            };
        }
    }
}