using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApiClient
{
    [JsonObject]
    class Course
    {
        [JsonProperty("id")]
        int courseId { get; set; }
        [JsonProperty("title")]
        public string courseTitle { get; set; }

    }
    [JsonArray]
    class Courses
    {
        public Course[] courses;
    }
}
