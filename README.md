# EFDemoApp
This is a study project for EFCore Data Access

8/4/2021
1. viewing the Snapshot we notice that city, state, etc are using nvarchar(max).
it is beacuse those string cloud be very long, but there is problem nvarchar could make your project run slow when there is alot data.
Optimize that we add attribute [Reqired] and [MaxLength] to the propoty string.
At the end, Add-Migration AddedValidation to the libary
2. rowback will not get your databack after your add-migration

8/9/2021
Get the data we can use var people = _db.people base on dependency injection
two simple things we need to be careful:
  when we using LINQ EF will create the data whatever it has by multible time 
  for example:  
            var people = _db.people
                .Include(a => a.Addresses)
                .Include(e => e.EmaildAddresses)
                .ToList();
  we have one to many relationship with person: addresses and email.
  since that the ef will pull row each different in the qeury unit
  If a person has four addresses and three email, we will get 4*4 = 16 row from 
  that person with only addresses and email different in your row
 Sovle: 
  the better way to do that request will seperate person, addresses, and email
 
 second problem:
 don't use method in your LINQ even if this is working for CSharp
 for example:
 
 public void OnGet()
        {
            LoadSampleData();
            var people = _db.people
            
                //problem line that would download all users
                .Where(x=>ApprovedAge(x.Age))
                
                .Where(x=> x.Age>= 18 && x.Age < 65)
                .ToList();

        }

        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age < 65);
        }
  In here we use two way to use select, the first line is using C# to call a boolean function
  This will casue a big problem that C# will download all the user, which will cost a huge memory use 
  the better way to select would be fliter inside the LINQ
