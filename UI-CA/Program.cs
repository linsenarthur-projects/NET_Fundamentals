// See https://aka.ms/new-console-template for more information

using ProjectFitness.UI_CA;
using ProjectFitness.BL;
using ProjectFitness.DAL;
using Microsoft.EntityFrameworkCore;
using ProjectFitness.DAL.EF;

var builder = new DbContextOptionsBuilder();
builder.UseSqlite("Data Source=ProjectFitness.db");

var dbContext = new FitnessDbContext(builder.Options);

var repository = new Repository(dbContext);
var manager = new Manager(repository);

var ui = new ConsoleUi(manager);
ui.Run();