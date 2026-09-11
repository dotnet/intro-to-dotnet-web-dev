using Microsoft.OpenApi;
using PizzaStore.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Pizza Support",
            Email = "pizza@example.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.MapGet("/", () => "Hello World!");

// Define API endpoints with OpenAPI descriptions
var pizzas = app.MapGroup("/pizzas")
    .WithTags("Pizzas")
    .WithOpenApi();

// Get all pizzas
pizzas.MapGet("/", () => PizzaDB.GetPizzas())
      .WithName("GetAllPizzas")
      .WithSummary("Get all pizzas")
      .WithDescription("Retrieves the complete list of available pizzas");

// Get pizza by ID
pizzas.MapGet("/{id}", (int id) => PizzaDB.GetPizza(id))
      .WithName("GetPizzaById")
      .WithSummary("Get pizza by ID")
      .WithDescription("Gets a specific pizza by its unique identifier")
      .WithOpenApi(operation => {
          operation.Parameters[0].Description = "The unique identifier for the pizza";
          return operation;
      });

// Create a new pizza
pizzas.MapPost("/", (Pizza pizza) => PizzaDB.CreatePizza(pizza))
      .WithName("CreatePizza")
      .WithSummary("Create a new pizza")
      .WithDescription("Adds a new pizza to the menu");

// Update a pizza
pizzas.MapPut("/", (Pizza pizza) => PizzaDB.UpdatePizza(pizza))
      .WithName("UpdatePizza")
      .WithSummary("Update an existing pizza")
      .WithDescription("Updates the details of an existing pizza");

// Delete a pizza
pizzas.MapDelete("/{id}", (int id) => PizzaDB.RemovePizza(id))
      .WithName("DeletePizza")
      .WithSummary("Delete a pizza")
      .WithDescription("Removes a pizza from the menu")
      .WithOpenApi(operation => {
          operation.Parameters[0].Description = "The unique identifier for the pizza to delete";
          return operation;
      });

app.Run();