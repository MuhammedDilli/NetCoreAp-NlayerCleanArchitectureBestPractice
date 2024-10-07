    using App.Repositories;
    using App.Repositories.Extensions;
    using App.Services.Extensions;
    using App.Services.Products;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    var builder = WebApplication.CreateBuilder(args);

   

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<FluentValidationFilter>();
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes= true;
    } );
    builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
   
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);





    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
