# EFDemoApp
This is a study project for EFCore Data Access

8/4/2021
1. viewing the Snapshot we notice that city, state, etc are using nvarchar(max).
it is beacuse those string cloud be very long, but there is problem nvarchar could make your project run slow when there is alot data.