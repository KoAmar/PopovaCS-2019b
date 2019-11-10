using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorApp.Models.Pulls;
using Microsoft.AspNetCore.Hosting;

namespace BlazorApp.Data
{
    public class JsonPullService : IPullRepository
    {
        public JsonPullService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public JsonPullService()
        {
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "pulls.json"); }
        }

        public Pull Add(Pull pull)
        {
            throw new NotImplementedException();
        }

        public Pull GetPull(int id)
        {
            throw new NotImplementedException();
        }

        public static IList<Pull> GetPulls()
        {
            var jsonFileReader = File.OpenText("C:\\Users\\pa131\\Desktop\\BNTU-2019b\\UnitTesting(Popova)\\PopovaCS\\BlazorApp\\Data\\products.json");
            return JsonSerializer.Deserialize<Pull[]>(jsonFileReader.ReadToEnd());
        }
    }
}
