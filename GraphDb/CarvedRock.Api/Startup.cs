using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.GraphQL.Messaging;
using CarvedRock.Api.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarvedRock.Api
{
	public class Startup
	{
		private readonly IConfiguration _config;
		private readonly IHostingEnvironment _env;

		public Startup(IConfiguration config, IHostingEnvironment env)
		{
			_config = config;
			_env = env;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthentication("Bearer")
				.AddIdentityServerAuthentication(options =>
				{
					options.Authority = "https://identity-internal-dev.altsrc.net/core";
				});

			services.AddDbContext<CarvedRockDbContext>(options =>
				options.UseSqlServer(_config["ConnectionStrings:CarvedRock"]));

			services.AddSingleton<IReviewMessageService, ReviewMessageService>();

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductReviewRepository, ProductReviewRepository>();

			services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddScoped<CarvedRockSchema>();

			services.AddGraphQL(options =>
				{
					options.ExposeExceptions = _env.IsDevelopment();
				})
				.AddGraphTypes(ServiceLifetime.Scoped)
				.AddUserContextBuilder(context => context.User)
				.AddDataLoader()
				.AddWebSockets();

			services.AddCors();
		}

		public void Configure(IApplicationBuilder app)
		{
			SeedInitialDatabase(app);

			app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

			app.UseAuthentication();

			app.UseWebSockets();
			app.UseGraphQLWebSockets<CarvedRockSchema>();
			app.UseGraphQL<CarvedRockSchema>();
			app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
		}

		private void SeedInitialDatabase(IApplicationBuilder app)
		{
			if (_env.IsDevelopment())
			{
				using (var scope = app.ApplicationServices.CreateScope())
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>();
					dbContext.Seed();
				}
			}
		}
	}
}