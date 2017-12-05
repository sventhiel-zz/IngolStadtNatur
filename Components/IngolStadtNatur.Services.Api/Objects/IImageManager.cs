﻿using System.Linq;

namespace IngolStadtNatur.Services.Api.Objects
{
    public interface IImageManager
    {
        IQueryable<Image> Images { get; }
    }
}