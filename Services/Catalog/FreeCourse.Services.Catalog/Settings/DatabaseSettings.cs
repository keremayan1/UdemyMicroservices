﻿namespace FreeCourse.Services.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CourseCollectionName { get; set; }

        public string CategoryCollectionName { get; set; }

        public virtual string ConnectionStrings { get; set; }

        public string DatabaseName { get; set; }
    }
}
