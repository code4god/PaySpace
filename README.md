# PaySpace
TaxCalculator
DataLayer => 
Connects to SQL server, I had to creating the db context and then add the migration for code first approach. I have tried 
to keep it as simple(clean architecture). I created Repository for each Entity to abstract the data access from consumers and 
did not instroduce Unit Work because my model is not that complex and because of the time constraint.

NUnitTests => 
Uses NUnit framework as well as Mock framework to resolve the conc Created to 2 Unit test again due to time constraint. 




