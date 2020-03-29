# PaySpace
TaxCalculator
DataLayer => 
Connects to SQL server, I had to creating the db context and then add the migration for code first approach. I have tried 
to keep it as simple(clean architecture). I created Repository for each Entity to abstract the data access from consumers and 
did not instroduce Unit Work because my model is not that complex and because of the time constraint.

NUnitTests => 
Uses NUnit framework as well as Mock framework to resolve the conc Created to 2 Unit test again due to time constraint. 

TaxCalculator => 
Business Logic, this does all the calcutions and it's a seperate project so it can be reused as.

WebAPI =>
Is the service/gateway that communicates to both business and data layers.

Web =>
3 Screens.
Is the entry point and the UI. The homepage has a form/table with dropdownlist and input box that can accept 2 decimal places value. The form has client validation, which validate on 0 and alpha chars as well as dropdown selection must be made. The result screen dislays the calculation. The final screen is in the menu called Taxes which is a list of history calculation. The table on this taxes screen uses js data table functionality. So it can group, search, filter and does pagging.

PS: When running the app it should create the database as part of the migration script (code first approach). If you have any issues please contact me.



