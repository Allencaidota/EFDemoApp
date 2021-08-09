using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            _db = db;
        }
        //get all people's address and email
        //excute problem
        public void OnGet()
        {
            LoadSampleData();
            var people = _db.people
                //.Include(a => a.Addresses)
                //.Include(e => e.EmaildAddresses)

                //problem line that would download all users
                //.Where(x=>ApprovedAge(x.Age))
                .Where(x=> x.Age>= 18 && x.Age < 65)
                .ToList();

        }

        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age < 65);
        }

        private void LoadSampleData()
        {
            if(_db.people.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _db.AddRange(people);
                _db.SaveChanges();
            }
        }
    }
}
